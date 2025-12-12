using System.ServiceModel;
using NotaNacional.Core.Models.Response;

namespace NotaNacional.Web.Service
{

    [ServiceContract(Namespace = "http://nfse.abrasf.org.br")]
    public interface INfse
    {
        [OperationContract(Name = "CancelarNfse")]
        [XmlSerializerFormat]
        BaseResponse CancelarNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarLoteDps")]
        [XmlSerializerFormat]
        BaseResponse ConsultarLoteDps(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfseServicoPrestado")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfseServicoPrestado(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfseServicoTomado")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfseServicoTomado(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfsePorFaixa")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfsePorFaixa(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarNfseDps")]
        [XmlSerializerFormat]
        BaseResponse ConsultarNfseDps(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "RecepcionarLoteDps")]
        [XmlSerializerFormat]
        BaseResponse RecepcionarLoteDps(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "GerarNfse")]
        [XmlSerializerFormat]
        BaseResponse GerarNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "RecepcionarLoteDpsSincrono")]
        [XmlSerializerFormat]
        BaseResponse RecepcionarLoteDpsSincrono(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarUrlNfse")]
        [XmlSerializerFormat]
        BaseResponse ConsultarUrlNfse(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarDadosCadastrais")]
        [XmlSerializerFormat]
        BaseResponse ConsultarDadosCadastrais(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ConsultarDpsDisponivel")]
        [XmlSerializerFormat]
        BaseResponse ConsultarDpsDisponivel(object nfseCabecMsg, object nfseDadosMsg);

        [OperationContract(Name = "ValidarXml")]
        [XmlSerializerFormat]
        BaseResponse ValidarXml(object nfseCabecMsg, object nfseDadosMsg);
    }
}