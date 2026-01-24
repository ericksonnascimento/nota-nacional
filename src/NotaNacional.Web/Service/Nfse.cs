using NotaNacional.Core.CancelarNfse.Handlers;
using NotaNacional.Core.ConsultarLoteDps.Handlers;
using NotaNacional.Core.ConsultarNfseFaixa.Handlers;
using NotaNacional.Core.ConsultarNfseDps.Handlers;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Handlers;
using NotaNacional.Core.ConsultarNfseServicoTomado.Handlers;
using NotaNacional.Core.GerarNfse.Handlers;
using NotaNacional.Core.Models.Response;
using NotaNacional.Core.RecepcionarLoteDps.Handlers;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Handlers;
using NotaNacional.Core.ConsultarUrlNfse.Handlers;
using NotaNacional.Core.ConsultarDadosCadastrais.Handlers;
using NotaNacional.Core.ConsultarDpsDisponivel.Handlers;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.CancelarNfse.Validator;
using NotaNacional.Core.ConsultarLoteDps.Validator;
using NotaNacional.Core.ConsultarNfseFaixa.Validator;
using NotaNacional.Core.ConsultarNfseDps.Validator;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Validator;
using NotaNacional.Core.ConsultarNfseServicoTomado.Validator;
using NotaNacional.Core.GerarNfse.Validator;
using NotaNacional.Core.RecepcionarLoteDps.Validator;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Validator;
using NotaNacional.Core.ConsultarUrlNfse.Validator;
using NotaNacional.Core.ConsultarDadosCadastrais.Validator;
using NotaNacional.Core.ConsultarDpsDisponivel.Validator;
using NotaNacional.Core.Base.Validator;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Web.Service
{

    public class Nfse : INfse
    {
        private ICancelarNfseHandler _cancelarNfseHandler;
        private IConsultarLoteDpsHandler _consultarLoteDpsHandler;
        private IConsultarNfseServicoPrestadoHandler _consultarNfseServicoPrestadoHandler;
        private IConsultarNfseServicoTomadoHandler _consultarNfseServicoTomadoHandler;
        private IConsultarNfseFaixaHandler _consultarNfseFaixaHandler;
        private IConsultarNfseDpsHandler _consultarNfseDpsHandler;
        private IRecepcionarLoteDpsHandler _recepcionarLoteDpsHandler;
        private IGerarNfseHandler _gerarNfseHandler;
        private IRecepcionarLoteDpsSincronoHandler _recepcionarLoteDpsSincronoHandler;
        private IConsultarUrlNfseHandler _consultarUrlNfseHandler;
        private IConsultarDadosCadastraisHandler _consultarDadosCadastraisHandler;
        private IConsultarDpsDisponivelHandler _consultarDpsDisponivelHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        // Validators para ValidarXml
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly ICancelarNfseValidator _cancelarNfseValidator;
        private readonly IConsultarLoteDpsValidator _consultarLoteDpsValidator;
        private readonly IConsultarNfseFaixaValidator _consultarNfseFaixaValidator;
        private readonly IConsultarNfseDpsValidator _consultarNfseDpsValidator;
        private readonly IConsultarNfseServicoPrestadoValidator _consultarNfseServicoPrestadoValidator;
        private readonly IConsultarNfseServicoTomadoValidator _consultarNfseServicoTomadoValidator;
        private readonly IGerarNfseValidator _gerarNfseValidator;
        private readonly IRecepcionarLoteDpsValidator _recepcionarLoteDpsValidator;
        private readonly IRecepcionarLoteDpsSincronoValidator _recepcionarLoteDpsSincronoValidator;
        private readonly IConsultarUrlNfseValidator _consultarUrlNfseValidator;
        private readonly IConsultarDadosCadastraisValidator _consultarDadosCadastraisValidator;
        private readonly IConsultarDpsDisponivelValidator _consultarDpsDisponivelValidator;
        private readonly IConfiguration _configuration;
        private const string OPERACAO_EM_CONSTRUCAO = "E999";

        public Nfse(
            ICancelarNfseHandler cancelarNfseHandler,
            IConsultarLoteDpsHandler consultarLoteDpsHandler,
            IConsultarNfseServicoPrestadoHandler consultarNfseServicoPrestadoHandler,
            IConsultarNfseServicoTomadoHandler consultarNfseServicoTomadoHandler,
            IConsultarNfseFaixaHandler consultarNfseFaixaHandler,
            IConsultarNfseDpsHandler consultarNfseDpsHandler,
            IRecepcionarLoteDpsHandler recepcionarLoteDpsHandler,
            IGerarNfseHandler gerarNfseHandler,
            IRecepcionarLoteDpsSincronoHandler recepcionarLoteDpsSincronoHandler,
            IConsultarUrlNfseHandler consultarUrlNfseHandler,
            IConsultarDadosCadastraisHandler consultarDadosCadastraisHandler,
            IConsultarDpsDisponivelHandler consultarDpsDisponivelHandler,
            IHttpContextAccessor httpContextAccessor,
            ICabecalhoValidator cabecalhoValidator,
            ICancelarNfseValidator cancelarNfseValidator,
            IConsultarLoteDpsValidator consultarLoteDpsValidator,
            IConsultarNfseFaixaValidator consultarNfseFaixaValidator,
            IConsultarNfseDpsValidator consultarNfseDpsValidator,
            IConsultarNfseServicoPrestadoValidator consultarNfseServicoPrestadoValidator,
            IConsultarNfseServicoTomadoValidator consultarNfseServicoTomadoValidator,
            IGerarNfseValidator gerarNfseValidator,
            IRecepcionarLoteDpsValidator recepcionarLoteDpsValidator,
            IRecepcionarLoteDpsSincronoValidator recepcionarLoteDpsSincronoValidator,
            IConsultarUrlNfseValidator consultarUrlNfseValidator,
            IConsultarDadosCadastraisValidator consultarDadosCadastraisValidator,
            IConsultarDpsDisponivelValidator consultarDpsDisponivelValidator,
            IConfiguration configuration)
        {
            _cancelarNfseHandler = cancelarNfseHandler;
            _consultarLoteDpsHandler = consultarLoteDpsHandler;
            _consultarNfseServicoPrestadoHandler = consultarNfseServicoPrestadoHandler;
            _consultarNfseServicoTomadoHandler = consultarNfseServicoTomadoHandler;
            _consultarNfseFaixaHandler = consultarNfseFaixaHandler;
            _consultarNfseDpsHandler = consultarNfseDpsHandler;
            _recepcionarLoteDpsHandler = recepcionarLoteDpsHandler;
            _gerarNfseHandler = gerarNfseHandler;
            _recepcionarLoteDpsSincronoHandler = recepcionarLoteDpsSincronoHandler;
            _consultarUrlNfseHandler = consultarUrlNfseHandler;
            _consultarDadosCadastraisHandler = consultarDadosCadastraisHandler;
            _consultarDpsDisponivelHandler = consultarDpsDisponivelHandler;
            _httpContextAccessor = httpContextAccessor;
            
            // Validators
            _cabecalhoValidator = cabecalhoValidator;
            _cancelarNfseValidator = cancelarNfseValidator;
            _consultarLoteDpsValidator = consultarLoteDpsValidator;
            _consultarNfseFaixaValidator = consultarNfseFaixaValidator;
            _consultarNfseDpsValidator = consultarNfseDpsValidator;
            _consultarNfseServicoPrestadoValidator = consultarNfseServicoPrestadoValidator;
            _consultarNfseServicoTomadoValidator = consultarNfseServicoTomadoValidator;
            _gerarNfseValidator = gerarNfseValidator;
            _recepcionarLoteDpsValidator = recepcionarLoteDpsValidator;
            _recepcionarLoteDpsSincronoValidator = recepcionarLoteDpsSincronoValidator;
            _consultarUrlNfseValidator = consultarUrlNfseValidator;
            _consultarDadosCadastraisValidator = consultarDadosCadastraisValidator;
            _consultarDpsDisponivelValidator = consultarDpsDisponivelValidator;
            _configuration = configuration;
        }


        public BaseResponse CancelarNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("CancelarNfse"))
            {
                return RetornarOperacaoIndisponivel("CancelarNfse");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _cancelarNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse RecepcionarLoteDps(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("RecepcionarLoteDps"))
            {
                return RetornarOperacaoIndisponivel("RecepcionarLoteDps");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _recepcionarLoteDpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }

        public BaseResponse ConsultarLoteDps(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarLoteDps"))
            {
                return RetornarOperacaoIndisponivel("ConsultarLoteDps");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarLoteDpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfseServicoPrestado(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarNfseServicoPrestado"))
            {
                return RetornarOperacaoIndisponivel("ConsultarNfseServicoPrestado");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseServicoPrestadoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfseServicoTomado(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarNfseServicoTomado"))
            {
                return RetornarOperacaoIndisponivel("ConsultarNfseServicoTomado");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseServicoTomadoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfsePorFaixa(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarNfsePorFaixa"))
            {
                return RetornarOperacaoIndisponivel("ConsultarNfsePorFaixa");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseFaixaHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfseDps(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarNfseDps"))
            {
                return RetornarOperacaoIndisponivel("ConsultarNfseDps");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseDpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse GerarNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("GerarNfse"))
            {
                return RetornarOperacaoIndisponivel("GerarNfse");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _gerarNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse RecepcionarLoteDpsSincrono(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("RecepcionarLoteDpsSincrono"))
            {
                return RetornarOperacaoIndisponivel("RecepcionarLoteDpsSincrono");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _recepcionarLoteDpsSincronoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarUrlNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarUrlNfse"))
            {
                return RetornarOperacaoIndisponivel("ConsultarUrlNfse");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarUrlNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarDadosCadastrais(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarDadosCadastrais"))
            {
                return RetornarOperacaoIndisponivel("ConsultarDadosCadastrais");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarDadosCadastraisHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarDpsDisponivel(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarDpsDisponivel"))
            {
                return RetornarOperacaoIndisponivel("ConsultarDpsDisponivel");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarDpsDisponivelHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }

        public BaseResponse ValidarXml(object nfseCabecMsg, object nfseDadosMsg)
        {
            try
            {
                // Validar cabeçalho
                var headerValidationResult = _cabecalhoValidator.Validate(nfseCabecMsg);
                
                // Extrair versão do cabeçalho para usar como referência na validação do body
                var headerVersion = ExtractVersionFromHeader(nfseCabecMsg);
                
                // Identificar operação pelo elemento raiz do XML do body
                var bodyXml = ParseHelper.GetXml(nfseDadosMsg);
                var operation = IdentifyOperation(bodyXml);
                
                if (operation == null)
                {
                    return BuildValidationResponse(headerValidationResult, null, "Operação não identificada no XML do body.");
                }
                
                // Validar corpo usando o validator apropriado, passando a versão do cabeçalho como preferencial
                var bodyValidator = GetValidatorForOperation(operation);
                ValidationResult? bodyValidationResult = null;
                
                if (bodyValidator is BaseSchemaValidator baseValidator)
                {
                    // Usar o método sobrecarregado que aceita versão preferencial E captura detalhes dos erros
                    bodyValidationResult = baseValidator.Validate(nfseDadosMsg, headerVersion, captureErrorDetails: true);
                }
                else
                {
                    // Fallback para o método padrão se não for BaseSchemaValidator
                    bodyValidationResult = bodyValidator?.Validate(nfseDadosMsg);
                }
                
                // Combinar resultados de validação
                return BuildValidationResponse(headerValidationResult, bodyValidationResult, null);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retornar resposta com erro genérico
                var response = new ValidarXmlResposta();
                response.ListaMensagemRetorno.Add(new TcMensagemRetorno
                {
                    Codigo = "E232",
                    Mensagem = $"Ocorreu um erro no processamento do arquivo: {ex.Message}"
                });
                return response;
            }
        }

        private string? IdentifyOperation(string xml)
        {
            try
            {
                var doc = XDocument.Parse(xml);
                var rootElement = doc.Root;
                
                if (rootElement == null)
                    return null;
                
                var elementName = rootElement.Name.LocalName;
                
                // Mapear elementos para operações
                var operationMap = new Dictionary<string, string>
                {
                    { "CancelarNfseEnvio", "CancelarNfse" },
                    { "ConsultarLoteDpsEnvio", "ConsultarLoteDps" },
                    { "ConsultarNfseFaixaEnvio", "ConsultarNfsePorFaixa" },
                    { "ConsultarNfseDpsEnvio", "ConsultarNfseDps" },
                    { "ConsultarNfseServicoPrestadoEnvio", "ConsultarNfseServicoPrestado" },
                    { "ConsultarNfseServicoTomadoEnvio", "ConsultarNfseServicoTomado" },
                    { "GerarNfseEnvio", "GerarNfse" },
                    { "EnviarLoteDpsEnvio", "RecepcionarLoteDps" },
                    { "RecepcionarLoteDpsEnvio", "RecepcionarLoteDps" },
                    { "EnviarLoteDpsSincronoEnvio", "RecepcionarLoteDpsSincrono" },
                    { "RecepcionarLoteDpsSincronoEnvio", "RecepcionarLoteDpsSincrono" },
                    { "ConsultarUrlNfseEnvio", "ConsultarUrlNfse" },
                    { "ConsultarDadosCadastraisEnvio", "ConsultarDadosCadastrais" },
                    { "ConsultarDpsDisponivelEnvio", "ConsultarDpsDisponivel" }
                };
                
                return operationMap.TryGetValue(elementName, out var operation) ? operation : null;
            }
            catch
            {
                return null;
            }
        }

        private IValidator? GetValidatorForOperation(string? operation)
        {
            return operation switch
            {
                "CancelarNfse" => _cancelarNfseValidator,
                "ConsultarLoteDps" => _consultarLoteDpsValidator,
                "ConsultarNfsePorFaixa" => _consultarNfseFaixaValidator,
                "ConsultarNfseDps" => _consultarNfseDpsValidator,
                "ConsultarNfseServicoPrestado" => _consultarNfseServicoPrestadoValidator,
                "ConsultarNfseServicoTomado" => _consultarNfseServicoTomadoValidator,
                "GerarNfse" => _gerarNfseValidator,
                "RecepcionarLoteDps" => _recepcionarLoteDpsValidator,
                "RecepcionarLoteDpsSincrono" => _recepcionarLoteDpsSincronoValidator,
                "ConsultarUrlNfse" => _consultarUrlNfseValidator,
                "ConsultarDadosCadastrais" => _consultarDadosCadastraisValidator,
                "ConsultarDpsDisponivel" => _consultarDpsDisponivelValidator,
                _ => null
            };
        }

        private BaseResponse BuildValidationResponse(ValidationResult headerResult, ValidationResult? bodyResult, string? errorMessage)
        {
            var response = new ValidarXmlResposta();
            
            // Adicionar erros do cabeçalho
            if (headerResult != null && !headerResult.IsValid)
            {
                foreach (var message in headerResult.Messages)
                {
                    response.ListaMensagemRetorno.Add(new TcMensagemRetorno
                    {
                        Codigo = message.Key,
                        Mensagem = message.Value
                    });
                }
            }
            
            // Adicionar erros do corpo
            if (bodyResult != null && !bodyResult.IsValid)
            {
                foreach (var message in bodyResult.Messages)
                {
                    response.ListaMensagemRetorno.Add(new TcMensagemRetorno
                    {
                        Codigo = message.Key,
                        Mensagem = message.Value
                    });
                }
            }
            
            // Adicionar erro genérico se fornecido
            if (!string.IsNullOrEmpty(errorMessage))
            {
                response.ListaMensagemRetorno.Add(new TcMensagemRetorno
                {
                    Codigo = "E232",
                    Mensagem = errorMessage
                });
            }
            
            // Se não houver erros, adicionar mensagem de sucesso
            if (response.ListaMensagemRetorno.Count == 0)
            {
                response.ListaMensagemRetorno.Add(new TcMensagemRetorno
                {
                    Codigo = "S000",
                    Mensagem = "XML válido. Validação realizada com sucesso."
                });
            }
            
            return response;
        }

        private bool IsOperacaoHabilitada(string nomeOperacao)
        {
            return _configuration.GetValue<bool>($"OperacoesHabilitadas:{nomeOperacao}", false);
        }

        private BaseResponse RetornarOperacaoIndisponivel(string operacao)
        {
            var response = new ValidarXmlResposta();
            response.ListaMensagemRetorno.Add(new TcMensagemRetorno
            {
                Codigo = OPERACAO_EM_CONSTRUCAO,
                Mensagem = $"Operação {operacao} está temporariamente indisponível. Serviço em construção."
            });
            return response;
        }

        /// <summary>
        /// Extrai a versão do cabeçalho (versaoDados ou versao) para usar como referência na validação do body
        /// </summary>
        private string? ExtractVersionFromHeader(object nfseCabecMsg)
        {
            try
            {
                var headerXml = ParseHelper.GetXml(nfseCabecMsg);
                var doc = XDocument.Parse(headerXml);
                
                // Procurar por versaoDados (elemento) - prioridade 1
                var versaoDados = doc.Descendants()
                    .FirstOrDefault(e => e.Name.LocalName == "versaoDados")?.Value;
                if (!string.IsNullOrEmpty(versaoDados))
                {
                    return versaoDados;
                }
                
                // Procurar por versao (atributo no elemento cabecalho) - prioridade 2
                var cabecalho = doc.Descendants()
                    .FirstOrDefault(e => e.Name.LocalName == "cabecalho");
                if (cabecalho != null)
                {
                    var versaoAttr = cabecalho.Attribute("versao")?.Value;
                    if (!string.IsNullOrEmpty(versaoAttr))
                    {
                        return versaoAttr;
                    }
                }
            }
            catch
            {
                // Se não conseguir parsear, retorna null
            }
            
            return null;
        }

        //public BaseResponse CancelarNfse(object nfseCabecMsg, object nfseDadosMsg)
        //    => _cancelarNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarLoteRps(object nfseCabecMsg, object nfseDadosMsg)
        //    => _consultarLoteRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarNfseServicoPrestado(object nfseCabecMsg, object nfseDadosMsg)
        //    => _consultarNfseServicoPrestadoHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarNfseServicoTomado(object nfseCabecMsg, object nfseDadosMsg)
        //    => _consultarNfseServicoTomadoHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarNfsePorFaixa(object nfseCabecMsg, object nfseDadosMsg)
        //    => _consultarNfseFaixaHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarNfsePorRps(object nfseCabecMsg, object nfseDadosMsg)
        //    => _consultarNfsePorRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse RecepcionarLoteRps(object nfseCabecMsg, object nfseDadosMsg)
        //    => _recepcionarLoteRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse GerarNfse(object nfseCabecMsg, object nfseDadosMsg)
        //    => _gerarNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse SubstituirNfse(object nfseCabecMsg, object nfseDadosMsg)
        //    => _substituirNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse RecepcionarLoteRpsSincrono(object nfseCabecMsg, object nfseDadosMsg)
        //    => _recepcionarLoteRpsSincronoHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarUrlNfse(object nfseCabecMsg, object nfseDadosMsg)
        //  => _consultarUrlNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarDadosCadastrais(object nfseCabecMsg, object nfseDadosMsg)
        //  => _consultarDadosCadastraisHandler.Handle(nfseCabecMsg, nfseDadosMsg);

        //public BaseResponse ConsultarRpsDisponivel(object nfseCabecMsg, object nfseDadosMsg)
        //  => _consultarRpsDisponivelHandler.Handle(nfseCabecMsg, nfseDadosMsg);
    }
}