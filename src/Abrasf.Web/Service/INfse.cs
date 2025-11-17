using System.ServiceModel;
using Abrasf.Core.Models.Response;

namespace Abrasf.Web.Service
{

    [ServiceContract(Namespace = "http://nfse.abrasf.org.br")]
    public interface INfse
    {
        [OperationContract(Name = "CancelarNfse")]
        [XmlSerializerFormat]
        BaseResponse CancelarNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarLoteRps")]
        [XmlSerializerFormat]
        BaseResponse ConsultarLoteRps(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfseServicoPrestado")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfseServicoPrestado(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfseServicoTomado")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfseServicoTomado(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfsePorFaixa")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfsePorFaixa(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfsePorRps")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfsePorRps(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "RecepcionarLoteRps")]
        [XmlSerializerFormat]
        BaseResponse RecepcionarLoteRps(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "GerarNfse")]
        [XmlSerializerFormat]
        BaseResponse GerarNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "SubstituirNfse")]
        [XmlSerializerFormat]
        BaseResponse SubstituirNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "RecepcionarLoteRpsSincrono")]
        [XmlSerializerFormat]
        BaseResponse RecepcionarLoteRpsSincrono(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarUrlNfse")]
        [XmlSerializerFormat]
        BaseResponse ConsultarUrlNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarDadosCadastrais")]
        [XmlSerializerFormat]
        BaseResponse ConsultarDadosCadastrais(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarRpsDisponivel")]
        [XmlSerializerFormat]
        BaseResponse ConsultarRpsDisponivel(object nfseCabecMsg, object nfseDadosMsg);
    }
}