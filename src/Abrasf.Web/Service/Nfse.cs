using Abrasf.Core.CancelarNfse.Handlers;
using Abrasf.Core.ConsultarLoteRps.Handlers;
using Abrasf.Core.ConsultarNfseFaixa.Handlers;
using Abrasf.Core.ConsultarNfsePorRps.Handlers;
using Abrasf.Core.ConsultarNfseServicoPrestado.Handlers;
using Abrasf.Core.ConsultarNfseServicoTomado.Handlers;
using Abrasf.Core.GerarNfse.Handlers;
using Abrasf.Core.Models.Response;
using Abrasf.Core.RecepcionarLoteRps.Handlers;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Handlers;
using Abrasf.Core.SubstituirNfse.Handlers;
using Abrasf.Core.ConsultarUrlNfse.Handlers;
using Abrasf.Core.ConsultarDadosCadastrais.Handlers;
using Abrasf.Core.ConsultarRpsDisponivel.Handlers;

namespace Abrasf.Web.Service
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
        private ISubstituirNfseHandler _substituirNfseHandler;
        private IRecepcionarLoteRpsSincronoHandler _recepcionarLoteRpsSincronoHandler;
        private IConsultarUrlNfseHandler _consultarUrlNfseHandler;
        private IConsultarDadosCadastraisHandler _consultarDadosCadastraisHandler;
        private IConsultarRpsDisponivelHandler _consultarRpsDisponivelHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Nfse(
            ICancelarNfseHandler cancelarNfseHandler,
            IConsultarLoteRpsHandler consultarLoteRpsHandler,
            IConsultarNfseServicoPrestadoHandler consultarNfseServicoPrestadoHandler,
            IConsultarNfseServicoTomadoHandler consultarNfseServicoTomadoHandler,
            IConsultarNfseFaixaHandler consultarNfseFaixaHandler,
            IConsultarNfsePorRpsHandler consultarNfsePorRpsHandler,
            IRecepcionarLoteRpsHandler recepcionarLoteRpsHandler,
            IGerarNfseHandler gerarNfseHandler,
            ISubstituirNfseHandler substituirNfseHandler,
            IRecepcionarLoteRpsSincronoHandler recepcionarLoteRpsSincronoHandler,
            IConsultarUrlNfseHandler consultarUrlNfseHandler,
            IConsultarDadosCadastraisHandler consultarDadosCadastraisHandler,
            IConsultarRpsDisponivelHandler consultarRpsDisponivelHandler,
            IHttpContextAccessor httpContextAccessor)
        {
            _cancelarNfseHandler = cancelarNfseHandler;
            _consultarLoteRpsHandler = consultarLoteRpsHandler;
            _consultarNfseServicoPrestadoHandler = consultarNfseServicoPrestadoHandler;
            _consultarNfseServicoTomadoHandler = consultarNfseServicoTomadoHandler;
            _consultarNfseFaixaHandler = consultarNfseFaixaHandler;
            _consultarNfsePorRpsHandler = consultarNfsePorRpsHandler;
            _recepcionarLoteRpsHandler = recepcionarLoteRpsHandler;
            _gerarNfseHandler = gerarNfseHandler;
            _substituirNfseHandler = substituirNfseHandler;
            _recepcionarLoteRpsSincronoHandler = recepcionarLoteRpsSincronoHandler;
            _consultarUrlNfseHandler = consultarUrlNfseHandler;
            _consultarDadosCadastraisHandler = consultarDadosCadastraisHandler;
            _consultarRpsDisponivelHandler = consultarRpsDisponivelHandler;
            _httpContextAccessor = httpContextAccessor;
        }


        public BaseResponse CancelarNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _cancelarNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse RecepcionarLoteRps(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _recepcionarLoteRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }

        public BaseResponse ConsultarLoteRps(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarLoteRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfseServicoPrestado(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseServicoPrestadoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfseServicoTomado(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseServicoTomadoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfsePorFaixa(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfseFaixaHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarNfsePorRps(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarNfsePorRpsHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse GerarNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _gerarNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse SubstituirNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _substituirNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse RecepcionarLoteRpsSincrono(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _recepcionarLoteRpsSincronoHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarUrlNfse(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarUrlNfseHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarDadosCadastrais(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarDadosCadastraisHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
        }
        public BaseResponse ConsultarRpsDisponivel(object nfseCabecMsg, object nfseDadosMsg)
        {
            var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return _consultarRpsDisponivelHandler.Handle(nfseCabecMsg, nfseDadosMsg, ip);
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