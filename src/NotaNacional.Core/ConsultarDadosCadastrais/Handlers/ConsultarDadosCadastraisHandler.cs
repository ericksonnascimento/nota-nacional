using NotaNacional.Core.Base;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.ConsultarDadosCadastrais.Models;
using NotaNacional.Core.ConsultarDadosCadastrais.Repositories;
using NotaNacional.Core.ConsultarDadosCadastrais.Validator;
using NotaNacional.Core.Configuration;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace NotaNacional.Core.ConsultarDadosCadastrais.Handlers
{
    public class ConsultarDadosCadastraisHandler : BaseHandler, IConsultarDadosCadastraisHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarDadosCadastraisValidator _ConsultarUrlNfseValidator;
        private readonly IConsultarDadosCadastraisRepository _repository;
        private readonly ILogger<ConsultarDadosCadastraisHandler>? _logger;
        private readonly bool _apenasValidar;

        public ConsultarDadosCadastraisHandler(ICabecalhoValidator cabecalhoValidator,
          IConsultarDadosCadastraisValidator ConsultarUrlNfseValidator,
          IConsultarDadosCadastraisRepository repository,
          IConfiguration configuration,
          ILogger<ConsultarDadosCadastraisHandler>? logger = null)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _ConsultarUrlNfseValidator = ConsultarUrlNfseValidator;
            _repository = repository;
            _logger = logger;
            var handlerConfig = configuration.GetSection("HandlerConfiguration").Get<HandlerConfiguration>() ?? new HandlerConfiguration();
            _apenasValidar = handlerConfig.ApenasValidar;
        }

        public BaseResponse Handle(object header, object body, string ipUsuario, string cpfCnpjCertificado = "")
        {
            var erros = string.Empty;

            try
            {
                // ===== LOGS DE DIAGNÓSTICO =====
                _logger?.LogInformation("=== ConsultarDadosCadastrais - INÍCIO ===");
                _logger?.LogInformation("IP: {IP}, CPF/CNPJ Certificado: {CpfCnpj}", ipUsuario, cpfCnpjCertificado);

                // Log do tipo dos parâmetros
                _logger?.LogInformation("Header Type: {HeaderType}", header?.GetType().FullName ?? "null");
                _logger?.LogInformation("Body Type: {BodyType}", body?.GetType().FullName ?? "null");

                // Log do conteúdo bruto do body
                if (body is XmlNode[] xmlNodes)
                {
                    _logger?.LogInformation("Body é XmlNode[] com {Count} elementos", xmlNodes.Length);
                    for (int i = 0; i < Math.Min(xmlNodes.Length, 5); i++)
                    {
                        _logger?.LogInformation("Body XmlNode[{Index}]: NodeType={NodeType}, Name={Name}, OuterXml={OuterXml}",
                            i, xmlNodes[i].NodeType, xmlNodes[i].Name,
                            xmlNodes[i].OuterXml?.Length > 500 ? xmlNodes[i].OuterXml?.Substring(0, 500) + "..." : xmlNodes[i].OuterXml);
                    }
                }
                else
                {
                    _logger?.LogWarning("Body NÃO é XmlNode[], é: {BodyType}", body?.GetType().FullName ?? "null");
                }

                // Tentar extrair o XML do body
                try
                {
                    var bodyXml = ParseHelper.GetXml(body);
                    _logger?.LogInformation("Body XML extraído (primeiros 1000 chars): {BodyXml}",
                        bodyXml?.Length > 1000 ? bodyXml.Substring(0, 1000) + "..." : bodyXml);
                }
                catch (Exception exXml)
                {
                    _logger?.LogError(exXml, "Erro ao extrair XML do body: {Message}", exXml.Message);
                }
                // ===== FIM LOGS DE DIAGNÓSTICO =====

                //Validar cabecalho
                var headValidatorResult = _cabecalhoValidator.Validate(header);
                _logger?.LogInformation("Validação cabeçalho - IsValid: {IsValid}, Mensagens: {Messages}",
                    headValidatorResult.IsValid,
                    string.Join(", ", headValidatorResult.Messages.Select(m => $"{m.Key}:{m.Value}")));

                if (!headValidatorResult.IsValid)
                {
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabeçalho do arquivo enviado está fora do padrão especificado.
                }

                ////Validar corpo
                var bodyValidator = _ConsultarUrlNfseValidator.Validate(body);
                _logger?.LogInformation("Validação corpo - IsValid: {IsValid}, Mensagens: {Messages}",
                    bodyValidator.IsValid,
                    string.Join(", ", bodyValidator.Messages.Select(m => $"{m.Key}:{m.Value}")));

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                    _logger?.LogWarning("Validação do corpo FALHOU - Erros: {Erros}",
                        string.Join("; ", bodyValidator.Messages.Select(m => $"{m.Key}:{m.Value}")));
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Find(Util.XmlVazio(OperacaoNfse.ConsultarDadosCadastrais), cpfCnpjCertificado, erros,ipUsuario);
                    return BuildResponse(result);
                }

                if (_apenasValidar)
                {
                    var result = _repository.Find(Util.XmlVazio(OperacaoNfse.ConsultarDadosCadastrais), cpfCnpjCertificado, string.Empty, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                NotaNacional.Core.Models.ConsultarDadosCadastraisEnvio consulta;

                try
                {
                    consulta = ParseHelper.ParseXml<NotaNacional.Core.Models.ConsultarDadosCadastraisEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Find(xmlString, cpfCnpjCertificado, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    // ConsultarDadosCadastraisEnvio não tem Signature no padrão nacional
                    var result = _repository.Find(xmlString, cpfCnpjCertificado, erros, ipUsuario);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Find(xmlString, cpfCnpjCertificado, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Find(Util.XmlVazio(OperacaoNfse.ConsultarDadosCadastrais), string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }
        private NotaNacional.Core.Models.ConsultarDadosCadastraisResposta BuildResponse(WsConsultarDadosCadastraisResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<NotaNacional.Core.Models.ConsultarDadosCadastraisResposta>(result.XmlResposta);
        }

    }
}
