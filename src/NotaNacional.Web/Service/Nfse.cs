using NotaNacional.Core.CancelarNfse.Handlers;
using NotaNacional.Core.ConsultarLoteRps.Handlers;
using NotaNacional.Core.ConsultarNfseFaixa.Handlers;
using NotaNacional.Core.ConsultarNfsePorRps.Handlers;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Handlers;
using NotaNacional.Core.ConsultarNfseServicoTomado.Handlers;
using NotaNacional.Core.GerarNfse.Handlers;
using NotaNacional.Core.Models.Response;
using NotaNacional.Core.RecepcionarLoteRps.Handlers;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Handlers;
using NotaNacional.Core.ConsultarUrlNfse.Handlers;
using NotaNacional.Core.ConsultarDadosCadastrais.Handlers;
using NotaNacional.Core.ConsultarRpsDisponivel.Handlers;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.CancelarNfse.Validator;
using NotaNacional.Core.ConsultarLoteRps.Validator;
using NotaNacional.Core.ConsultarNfseFaixa.Validator;
using NotaNacional.Core.ConsultarNfsePorRps.Validator;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Validator;
using NotaNacional.Core.ConsultarNfseServicoTomado.Validator;
using NotaNacional.Core.GerarNfse.Validator;
using NotaNacional.Core.RecepcionarLoteRps.Validator;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Validator;
using NotaNacional.Core.ConsultarUrlNfse.Validator;
using NotaNacional.Core.ConsultarDadosCadastrais.Validator;
using NotaNacional.Core.ConsultarRpsDisponivel.Validator;
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
        private IConsultarLoteRpsHandler _consultarLoteRpsHandler;
        private IConsultarNfseServicoPrestadoHandler _consultarNfseServicoPrestadoHandler;
        private IConsultarNfseServicoTomadoHandler _consultarNfseServicoTomadoHandler;
        private IConsultarNfseFaixaHandler _consultarNfseFaixaHandler;
        private IConsultarNfsePorRpsHandler _consultarNfsePorRpsHandler;
        private IRecepcionarLoteRpsHandler _recepcionarLoteRpsHandler;
        private IGerarNfseHandler _gerarNfseHandler;
        private IRecepcionarLoteRpsSincronoHandler _recepcionarLoteRpsSincronoHandler;
        private IConsultarUrlNfseHandler _consultarUrlNfseHandler;
        private IConsultarDadosCadastraisHandler _consultarDadosCadastraisHandler;
        private IConsultarRpsDisponivelHandler _consultarRpsDisponivelHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        // Validators para ValidarXml
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly ICancelarNfseValidator _cancelarNfseValidator;
        private readonly IConsultarLoteRpsValidator _consultarLoteRpsValidator;
        private readonly IConsultarNfseFaixaValidator _consultarNfseFaixaValidator;
        private readonly IConsultarNfsePorRpsValidator _consultarNfsePorRpsValidator;
        private readonly IConsultarNfseServicoPrestadoValidator _consultarNfseServicoPrestadoValidator;
        private readonly IConsultarNfseServicoTomadoValidator _consultarNfseServicoTomadoValidator;
        private readonly IGerarNfseValidator _gerarNfseValidator;
        private readonly IRecepcionarLoteRpsValidator _recepcionarLoteRpsValidator;
        private readonly IRecepcionarLoteRpsSincronoValidator _recepcionarLoteRpsSincronoValidator;
        private readonly IConsultarUrlNfseValidator _consultarUrlNfseValidator;
        private readonly IConsultarDadosCadastraisValidator _consultarDadosCadastraisValidator;
        private readonly IConsultarRpsDisponivelValidator _consultarRpsDisponivelValidator;
        private readonly IConfiguration _configuration;
        private const string OPERACAO_EM_CONSTRUCAO = "E999";

        public Nfse(
            ICancelarNfseHandler cancelarNfseHandler,
            IConsultarLoteRpsHandler consultarLoteRpsHandler,
            IConsultarNfseServicoPrestadoHandler consultarNfseServicoPrestadoHandler,
            IConsultarNfseServicoTomadoHandler consultarNfseServicoTomadoHandler,
            IConsultarNfseFaixaHandler consultarNfseFaixaHandler,
            IConsultarNfsePorRpsHandler consultarNfsePorRpsHandler,
            IRecepcionarLoteRpsHandler recepcionarLoteRpsHandler,
            IGerarNfseHandler gerarNfseHandler,
            IRecepcionarLoteRpsSincronoHandler recepcionarLoteRpsSincronoHandler,
            IConsultarUrlNfseHandler consultarUrlNfseHandler,
            IConsultarDadosCadastraisHandler consultarDadosCadastraisHandler,
            IConsultarRpsDisponivelHandler consultarRpsDisponivelHandler,
            IHttpContextAccessor httpContextAccessor,
            ICabecalhoValidator cabecalhoValidator,
            ICancelarNfseValidator cancelarNfseValidator,
            IConsultarLoteRpsValidator consultarLoteRpsValidator,
            IConsultarNfseFaixaValidator consultarNfseFaixaValidator,
            IConsultarNfsePorRpsValidator consultarNfsePorRpsValidator,
            IConsultarNfseServicoPrestadoValidator consultarNfseServicoPrestadoValidator,
            IConsultarNfseServicoTomadoValidator consultarNfseServicoTomadoValidator,
            IGerarNfseValidator gerarNfseValidator,
            IRecepcionarLoteRpsValidator recepcionarLoteRpsValidator,
            IRecepcionarLoteRpsSincronoValidator recepcionarLoteRpsSincronoValidator,
            IConsultarUrlNfseValidator consultarUrlNfseValidator,
            IConsultarDadosCadastraisValidator consultarDadosCadastraisValidator,
            IConsultarRpsDisponivelValidator consultarRpsDisponivelValidator,
            IConfiguration configuration)
        {
            _cancelarNfseHandler = cancelarNfseHandler;
            _consultarLoteRpsHandler = consultarLoteRpsHandler;
            _consultarNfseServicoPrestadoHandler = consultarNfseServicoPrestadoHandler;
            _consultarNfseServicoTomadoHandler = consultarNfseServicoTomadoHandler;
            _consultarNfseFaixaHandler = consultarNfseFaixaHandler;
            _consultarNfsePorRpsHandler = consultarNfsePorRpsHandler;
            _recepcionarLoteRpsHandler = recepcionarLoteRpsHandler;
            _gerarNfseHandler = gerarNfseHandler;
            _recepcionarLoteRpsSincronoHandler = recepcionarLoteRpsSincronoHandler;
            _consultarUrlNfseHandler = consultarUrlNfseHandler;
            _consultarDadosCadastraisHandler = consultarDadosCadastraisHandler;
            _consultarRpsDisponivelHandler = consultarRpsDisponivelHandler;
            _httpContextAccessor = httpContextAccessor;
            
            // Validators
            _cabecalhoValidator = cabecalhoValidator;
            _cancelarNfseValidator = cancelarNfseValidator;
            _consultarLoteRpsValidator = consultarLoteRpsValidator;
            _consultarNfseFaixaValidator = consultarNfseFaixaValidator;
            _consultarNfsePorRpsValidator = consultarNfsePorRpsValidator;
            _consultarNfseServicoPrestadoValidator = consultarNfseServicoPrestadoValidator;
            _consultarNfseServicoTomadoValidator = consultarNfseServicoTomadoValidator;
            _gerarNfseValidator = gerarNfseValidator;
            _recepcionarLoteRpsValidator = recepcionarLoteRpsValidator;
            _recepcionarLoteRpsSincronoValidator = recepcionarLoteRpsSincronoValidator;
            _consultarUrlNfseValidator = consultarUrlNfseValidator;
            _consultarDadosCadastraisValidator = consultarDadosCadastraisValidator;
            _consultarRpsDisponivelValidator = consultarRpsDisponivelValidator;
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
            return _recepcionarLoteRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }

        public BaseResponse ConsultarLoteDps(object nfseCabecMsg, object nfseDadosMsg)
        {
            if (!IsOperacaoHabilitada("ConsultarLoteDps"))
            {
                return RetornarOperacaoIndisponivel("ConsultarLoteDps");
            }
            
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarLoteRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
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
            return _consultarNfsePorRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
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
            return _recepcionarLoteRpsSincronoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
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
            return _consultarRpsDisponivelHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
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
                    { "RecepcionarLoteDpsEnvio", "RecepcionarLoteDps" },
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
                "ConsultarLoteDps" => _consultarLoteRpsValidator,
                "ConsultarNfsePorFaixa" => _consultarNfseFaixaValidator,
                "ConsultarNfseDps" => _consultarNfsePorRpsValidator,
                "ConsultarNfseServicoPrestado" => _consultarNfseServicoPrestadoValidator,
                "ConsultarNfseServicoTomado" => _consultarNfseServicoTomadoValidator,
                "GerarNfse" => _gerarNfseValidator,
                "RecepcionarLoteDps" => _recepcionarLoteRpsValidator,
                "RecepcionarLoteDpsSincrono" => _recepcionarLoteRpsSincronoValidator,
                "ConsultarUrlNfse" => _consultarUrlNfseValidator,
                "ConsultarDadosCadastrais" => _consultarDadosCadastraisValidator,
                "ConsultarDpsDisponivel" => _consultarRpsDisponivelValidator,
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