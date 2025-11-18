using System;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Abrasf.Core.Models
{
    // Tipos temporários para compatibilidade com o padrão Nacional v101
    // Estes tipos serão usados até que os tipos completos sejam regenerados dos schemas XSD
    // NOTA: Os tipos referenciados (SignatureType, tcIdentificacaoPessoaEmpresa) estão definidos em NfseTypes.cs
    
    /// <summary>
    /// Tipo temporário para EnviarLoteDpsEnvio (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "EnviarLoteDpsEnvio", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    public partial class EnviarLoteDpsEnvio
    {
        [XmlElement(ElementName = "LoteDps", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public tcLoteDps LoteDps { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }
    }

    /// <summary>
    /// Tipo temporário para EnviarLoteDpsSincronoEnvio (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "EnviarLoteDpsSincronoEnvio", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    public partial class EnviarLoteDpsSincronoEnvio
    {
        [XmlElement(ElementName = "LoteDps", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public tcLoteDps LoteDps { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }
    }

    /// <summary>
    /// Tipo temporário para ConsultarNfseDpsEnvio (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "ConsultarNfseDpsEnvio", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    public partial class ConsultarNfseDpsEnvio
    {
        [XmlElement(ElementName = "IdentificacaoDps", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public tcIdentificacaoDps IdentificacaoDps { get; set; }

        [XmlElement(ElementName = "Prestador", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public tcIdentificacaoPessoaEmpresa Prestador { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }
    }

    /// <summary>
    /// Tipo temporário para ConsultarDpsDisponivelEnvio (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "ConsultarDpsDisponivelEnvio", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    public partial class ConsultarDpsDisponivelEnvio
    {
        [XmlElement(ElementName = "Prestador", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public tcIdentificacaoPessoaEmpresa Prestador { get; set; }

        [XmlElement(ElementName = "IdentificacaoDps", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public tcIdentificacaoDps IdentificacaoDps { get; set; }

        [XmlElement(ElementName = "Pagina", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public string Pagina { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }
    }

    /// <summary>
    /// Tipo temporário para tcLoteDps (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    public partial class tcLoteDps
    {
        [XmlElement(DataType = "nonNegativeInteger")]
        public string NumeroLote { get; set; }

        public tcIdentificacaoPessoaEmpresa Prestador { get; set; }

        public int QuantidadeDps { get; set; }

        [XmlArray(ElementName = "ListaDps", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        [XmlArrayItem(ElementName = "Dps", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
        public TCDPS[] ListaDps { get; set; }

        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "versao")]
        public string Versao { get; set; }
    }

    /// <summary>
    /// Tipo temporário para tcIdentificacaoDps (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    public partial class tcIdentificacaoDps
    {
        [XmlElement(ElementName = "NumDPS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public string NumDPS { get; set; }

        [XmlElement(ElementName = "SerieDPS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public string SerieDPS { get; set; }
    }

    /// <summary>
    /// Tipo temporário para TCDPS (padrão nacional)
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    public partial class TCDPS
    {
        [XmlElement(ElementName = "infDPS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public TCInfDPS InfDPS { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }

        [XmlAttribute(AttributeName = "versao")]
        public string Versao { get; set; }
    }

    /// <summary>
    /// Tipo temporário para TCInfDPS (padrão nacional)
    /// Esta é uma classe simplificada - o tipo completo deve ser regenerado do schema
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    public partial class TCInfDPS
    {
        // Propriedades básicas - tipo completo deve ser regenerado do schema
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }
}

