using System.ServiceModel;
using System.Xml.Serialization;
using NotaNacional.Core.Models.Response;

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ListaMensagemRetornoLote
{

    private tcMensagemRetornoLote[] mensagemRetornoField;

    /// <remarks/>
    [XmlElementAttribute("MensagemRetorno")]
    public tcMensagemRetornoLote[] MensagemRetorno
    {
        get
        {
            return mensagemRetornoField;
        }
        set
        {
            mensagemRetornoField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcMensagemRetornoLote
{

    private tcIdentificacaoRps identificacaoRpsField;

    private string codigoField;

    private string mensagemField;

    /// <remarks/>
    public tcIdentificacaoRps IdentificacaoRps
    {
        get
        {
            return identificacaoRpsField;
        }
        set
        {
            identificacaoRpsField = value;
        }
    }

    /// <remarks/>
    public string Codigo
    {
        get
        {
            return codigoField;
        }
        set
        {
            codigoField = value;
        }
    }

    /// <remarks/>
    public string Mensagem
    {
        get
        {
            return mensagemField;
        }
        set
        {
            mensagemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoRps
{

    private string numeroField;

    private string serieField;

    private sbyte tipoField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Numero
    {
        get
        {
            return numeroField;
        }
        set
        {
            numeroField = value;
        }
    }

    /// <remarks/>
    public string Serie
    {
        get
        {
            return serieField;
        }
        set
        {
            serieField = value;
        }
    }

    /// <remarks/>
    public sbyte Tipo
    {
        get
        {
            return tipoField;
        }
        set
        {
            tipoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcRetCancelamento
{

    private tcCancelamentoNfse nfseCancelamentoField;

    /// <remarks/>
    public tcCancelamentoNfse NfseCancelamento
    {
        get
        {
            return nfseCancelamentoField;
        }
        set
        {
            nfseCancelamentoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcCancelamentoNfse
{

    private tcConfirmacaoCancelamento confirmacaoField;

    private SignatureType signatureField;

    private string versaoField;

    /// <remarks/>
    public tcConfirmacaoCancelamento Confirmacao
    {
        get
        {
            return confirmacaoField;
        }
        set
        {
            confirmacaoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "token")]
    public string versao
    {
        get
        {
            return versaoField;
        }
        set
        {
            versaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcConfirmacaoCancelamento
{

    private tcPedidoCancelamento pedidoField;

    private DateTime dataHoraField;

    private string idField;

    /// <remarks/>
    public tcPedidoCancelamento Pedido
    {
        get
        {
            return pedidoField;
        }
        set
        {
            pedidoField = value;
        }
    }

    /// <remarks/>
    public DateTime DataHora
    {
        get
        {
            return dataHoraField;
        }
        set
        {
            dataHoraField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcPedidoCancelamento
{

    private tcInfPedidoCancelamento infPedidoCancelamentoField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcInfPedidoCancelamento InfPedidoCancelamento
    {
        get
        {
            return infPedidoCancelamentoField;
        }
        set
        {
            infPedidoCancelamentoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcInfPedidoCancelamento
{

    private tcIdentificacaoNfse identificacaoNfseField;

    private sbyte codigoCancelamentoField;

    private string idField;

    /// <remarks/>
    public tcIdentificacaoNfse IdentificacaoNfse
    {
        get
        {
            return identificacaoNfseField;
        }
        set
        {
            identificacaoNfseField = value;
        }
    }

    /// <remarks/>
    public sbyte CodigoCancelamento
    {
        get
        {
            return codigoCancelamentoField;
        }
        set
        {
            codigoCancelamentoField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoNfse
{

    private string numeroField;

    private tcCpfCnpj cpfCnpjField;

    private string inscricaoMunicipalField;

    private int codigoMunicipioField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Numero
    {
        get
        {
            return numeroField;
        }
        set
        {
            numeroField = value;
        }
    }

    /// <remarks/>
    public tcCpfCnpj CpfCnpj
    {
        get
        {
            return cpfCnpjField;
        }
        set
        {
            cpfCnpjField = value;
        }
    }

    /// <remarks/>
    public string InscricaoMunicipal
    {
        get
        {
            return inscricaoMunicipalField;
        }
        set
        {
            inscricaoMunicipalField = value;
        }
    }

    /// <remarks/>
    public int CodigoMunicipio
    {
        get
        {
            return codigoMunicipioField;
        }
        set
        {
            codigoMunicipioField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcCpfCnpj
{

    private string itemField;

    private ItemChoiceType itemElementNameField;

    /// <remarks/>
    [XmlElementAttribute("Cnpj", typeof(string))]
    [XmlElementAttribute("Cpf", typeof(string))]
    [XmlChoiceIdentifierAttribute("ItemElementName")]
    public string Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public ItemChoiceType ItemElementName
    {
        get
        {
            return itemElementNameField;
        }
        set
        {
            itemElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
public enum ItemChoiceType
{

    /// <remarks/>
    Cnpj,

    /// <remarks/>
    Cpf,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SignatureType
{

    private SignedInfoType signedInfoField;

    private SignatureValueType signatureValueField;

    private KeyInfoType keyInfoField;

    private ObjectType[] objectField;

    private string idField;

    /// <remarks/>
    public SignedInfoType SignedInfo
    {
        get
        {
            return signedInfoField;
        }
        set
        {
            signedInfoField = value;
        }
    }

    /// <remarks/>
    public SignatureValueType SignatureValue
    {
        get
        {
            return signatureValueField;
        }
        set
        {
            signatureValueField = value;
        }
    }

    /// <remarks/>
    public KeyInfoType KeyInfo
    {
        get
        {
            return keyInfoField;
        }
        set
        {
            keyInfoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("Object")]
    public ObjectType[] Object
    {
        get
        {
            return objectField;
        }
        set
        {
            objectField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SignedInfoType
{

    private CanonicalizationMethodType canonicalizationMethodField;

    private SignatureMethodType signatureMethodField;

    private ReferenceType[] referenceField;

    private string idField;

    /// <remarks/>
    public CanonicalizationMethodType CanonicalizationMethod
    {
        get
        {
            return canonicalizationMethodField;
        }
        set
        {
            canonicalizationMethodField = value;
        }
    }

    /// <remarks/>
    public SignatureMethodType SignatureMethod
    {
        get
        {
            return signatureMethodField;
        }
        set
        {
            signatureMethodField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("Reference")]
    public ReferenceType[] Reference
    {
        get
        {
            return referenceField;
        }
        set
        {
            referenceField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class CanonicalizationMethodType
{

    private System.Xml.XmlNode[] anyField;

    private string algorithmField;

    /// <remarks/>
    [XmlTextAttribute()]
    [XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any
    {
        get
        {
            return anyField;
        }
        set
        {
            anyField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Algorithm
    {
        get
        {
            return algorithmField;
        }
        set
        {
            algorithmField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SignatureMethodType
{

    private string hMACOutputLengthField;

    private System.Xml.XmlNode[] anyField;

    private string algorithmField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "integer")]
    public string HMACOutputLength
    {
        get
        {
            return hMACOutputLengthField;
        }
        set
        {
            hMACOutputLengthField = value;
        }
    }

    /// <remarks/>
    [XmlTextAttribute()]
    [XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any
    {
        get
        {
            return anyField;
        }
        set
        {
            anyField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Algorithm
    {
        get
        {
            return algorithmField;
        }
        set
        {
            algorithmField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class ReferenceType
{

    private TransformType[] transformsField;

    private DigestMethodType digestMethodField;

    private byte[] digestValueField;

    private string idField;

    private string uRIField;

    private string typeField;

    /// <remarks/>
    [XmlArrayItemAttribute("Transform", IsNullable = false)]
    public TransformType[] Transforms
    {
        get
        {
            return transformsField;
        }
        set
        {
            transformsField = value;
        }
    }

    /// <remarks/>
    public DigestMethodType DigestMethod
    {
        get
        {
            return digestMethodField;
        }
        set
        {
            digestMethodField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] DigestValue
    {
        get
        {
            return digestValueField;
        }
        set
        {
            digestValueField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string URI
    {
        get
        {
            return uRIField;
        }
        set
        {
            uRIField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Type
    {
        get
        {
            return typeField;
        }
        set
        {
            typeField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class TransformType
{

    private object[] itemsField;

    private string[] textField;

    private string algorithmField;

    /// <remarks/>
    [XmlAnyElementAttribute()]
    [XmlElementAttribute("XPath", typeof(string))]
    public object[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return textField;
        }
        set
        {
            textField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Algorithm
    {
        get
        {
            return algorithmField;
        }
        set
        {
            algorithmField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class DigestMethodType
{

    private System.Xml.XmlNode[] anyField;

    private string algorithmField;

    /// <remarks/>
    [XmlTextAttribute()]
    [XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any
    {
        get
        {
            return anyField;
        }
        set
        {
            anyField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Algorithm
    {
        get
        {
            return algorithmField;
        }
        set
        {
            algorithmField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SignatureValueType
{

    private string idField;

    private byte[] valueField;

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }

    /// <remarks/>
    [XmlTextAttribute(DataType = "base64Binary")]
    public byte[] Value
    {
        get
        {
            return valueField;
        }
        set
        {
            valueField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class KeyInfoType
{

    private object[] itemsField;

    private ItemsChoiceType5[] itemsElementNameField;

    private string[] textField;

    private string idField;

    /// <remarks/>
    [XmlAnyElementAttribute()]
    [XmlElementAttribute("KeyName", typeof(string))]
    [XmlElementAttribute("KeyValue", typeof(KeyValueType))]
    [XmlElementAttribute("MgmtData", typeof(string))]
    [XmlElementAttribute("PGPData", typeof(PGPDataType))]
    [XmlElementAttribute("RetrievalMethod", typeof(RetrievalMethodType))]
    [XmlElementAttribute("SPKIData", typeof(SPKIDataType))]
    [XmlElementAttribute("X509Data", typeof(X509DataType))]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType5[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }

    /// <remarks/>
    [XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return textField;
        }
        set
        {
            textField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("KeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class KeyValueType
{

    private object itemField;

    private string[] textField;

    /// <remarks/>
    [XmlAnyElementAttribute()]
    [XmlElementAttribute("DSAKeyValue", typeof(DSAKeyValueType))]
    [XmlElementAttribute("RSAKeyValue", typeof(RSAKeyValueType))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }

    /// <remarks/>
    [XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return textField;
        }
        set
        {
            textField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class DSAKeyValueType
{

    private byte[] pField;

    private byte[] qField;

    private byte[] gField;

    private byte[] yField;

    private byte[] jField;

    private byte[] seedField;

    private byte[] pgenCounterField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] P
    {
        get
        {
            return pField;
        }
        set
        {
            pField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] Q
    {
        get
        {
            return qField;
        }
        set
        {
            qField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] G
    {
        get
        {
            return gField;
        }
        set
        {
            gField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] Y
    {
        get
        {
            return yField;
        }
        set
        {
            yField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] J
    {
        get
        {
            return jField;
        }
        set
        {
            jField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] Seed
    {
        get
        {
            return seedField;
        }
        set
        {
            seedField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] PgenCounter
    {
        get
        {
            return pgenCounterField;
        }
        set
        {
            pgenCounterField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("RSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class RSAKeyValueType
{

    private byte[] modulusField;

    private byte[] exponentField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] Modulus
    {
        get
        {
            return modulusField;
        }
        set
        {
            modulusField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "base64Binary")]
    public byte[] Exponent
    {
        get
        {
            return exponentField;
        }
        set
        {
            exponentField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("PGPData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class PGPDataType
{

    private object[] itemsField;

    private ItemsChoiceType4[] itemsElementNameField;

    /// <remarks/>
    [XmlAnyElementAttribute()]
    [XmlElementAttribute("PGPKeyID", typeof(byte[]), DataType = "base64Binary")]
    [XmlElementAttribute("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary")]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType4[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
public enum ItemsChoiceType4
{

    /// <remarks/>
    [XmlEnumAttribute("##any:")]
    Item,

    /// <remarks/>
    PGPKeyID,

    /// <remarks/>
    PGPKeyPacket,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("RetrievalMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class RetrievalMethodType
{

    private TransformType[] transformsField;

    private string uRIField;

    private string typeField;

    /// <remarks/>
    [XmlArrayItemAttribute("Transform", IsNullable = false)]
    public TransformType[] Transforms
    {
        get
        {
            return transformsField;
        }
        set
        {
            transformsField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string URI
    {
        get
        {
            return uRIField;
        }
        set
        {
            uRIField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Type
    {
        get
        {
            return typeField;
        }
        set
        {
            typeField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("SPKIData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SPKIDataType
{

    private byte[][] sPKISexpField;

    private System.Xml.XmlElement anyField;

    /// <remarks/>
    [XmlElementAttribute("SPKISexp", DataType = "base64Binary")]
    public byte[][] SPKISexp
    {
        get
        {
            return sPKISexpField;
        }
        set
        {
            sPKISexpField = value;
        }
    }

    /// <remarks/>
    [XmlAnyElementAttribute()]
    public System.Xml.XmlElement Any
    {
        get
        {
            return anyField;
        }
        set
        {
            anyField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class X509DataType
{

    private object[] itemsField;

    private ItemsChoiceType3[] itemsElementNameField;

    /// <remarks/>
    [XmlAnyElementAttribute()]
    [XmlElementAttribute("X509CRL", typeof(byte[]), DataType = "base64Binary")]
    [XmlElementAttribute("X509Certificate", typeof(byte[]), DataType = "base64Binary")]
    [XmlElementAttribute("X509IssuerSerial", typeof(X509IssuerSerialType))]
    [XmlElementAttribute("X509SKI", typeof(byte[]), DataType = "base64Binary")]
    [XmlElementAttribute("X509SubjectName", typeof(string))]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType3[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class X509IssuerSerialType
{

    private string x509IssuerNameField;

    private string x509SerialNumberField;

    /// <remarks/>
    public string X509IssuerName
    {
        get
        {
            return x509IssuerNameField;
        }
        set
        {
            x509IssuerNameField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "integer")]
    public string X509SerialNumber
    {
        get
        {
            return x509SerialNumberField;
        }
        set
        {
            x509SerialNumberField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
public enum ItemsChoiceType3
{

    /// <remarks/>
    [XmlEnumAttribute("##any:")]
    Item,

    /// <remarks/>
    X509CRL,

    /// <remarks/>
    X509Certificate,

    /// <remarks/>
    X509IssuerSerial,

    /// <remarks/>
    X509SKI,

    /// <remarks/>
    X509SubjectName,
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
public enum ItemsChoiceType5
{

    /// <remarks/>
    [XmlEnumAttribute("##any:")]
    Item,

    /// <remarks/>
    KeyName,

    /// <remarks/>
    KeyValue,

    /// <remarks/>
    MgmtData,

    /// <remarks/>
    PGPData,

    /// <remarks/>
    RetrievalMethod,

    /// <remarks/>
    SPKIData,

    /// <remarks/>
    X509Data,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("Object", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class ObjectType
{

    private System.Xml.XmlNode[] anyField;

    private string idField;

    private string mimeTypeField;

    private string encodingField;

    /// <remarks/>
    [XmlTextAttribute()]
    [XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any
    {
        get
        {
            return anyField;
        }
        set
        {
            anyField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string MimeType
    {
        get
        {
            return mimeTypeField;
        }
        set
        {
            mimeTypeField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Encoding
    {
        get
        {
            return encodingField;
        }
        set
        {
            encodingField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcLoteRps
{

    private string numeroLoteField;

    private tcIdentificacaoPessoaEmpresa prestadorField;

    private int quantidadeRpsField;

    private tcDeclaracaoPrestacaoServico[] listaRpsField;

    private string idField;

    private string versaoField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NumeroLote
    {
        get
        {
            return numeroLoteField;
        }
        set
        {
            numeroLoteField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    public int QuantidadeRps
    {
        get
        {
            return quantidadeRpsField;
        }
        set
        {
            quantidadeRpsField = value;
        }
    }

    /// <remarks/>
    [XmlArrayItemAttribute("Rps", IsNullable = false)]
    public tcDeclaracaoPrestacaoServico[] ListaRps
    {
        get
        {
            return listaRpsField;
        }
        set
        {
            listaRpsField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "token")]
    public string versao
    {
        get
        {
            return versaoField;
        }
        set
        {
            versaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoPessoaEmpresa
{

    private tcCpfCnpj cpfCnpjField;

    private string inscricaoMunicipalField;

    /// <remarks/>
    public tcCpfCnpj CpfCnpj
    {
        get
        {
            return cpfCnpjField;
        }
        set
        {
            cpfCnpjField = value;
        }
    }

    /// <remarks/>
    public string InscricaoMunicipal
    {
        get
        {
            return inscricaoMunicipalField;
        }
        set
        {
            inscricaoMunicipalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDeclaracaoPrestacaoServico
{

    private tcInfDeclaracaoPrestacaoServico infDeclaracaoPrestacaoServicoField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcInfDeclaracaoPrestacaoServico InfDeclaracaoPrestacaoServico
    {
        get
        {
            return infDeclaracaoPrestacaoServicoField;
        }
        set
        {
            infDeclaracaoPrestacaoServicoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcInfDeclaracaoPrestacaoServico
{

    private tcInfRps rpsField;

    private DateTime competenciaField;

    private tcDadosServico servicoField;

    private tcIdentificacaoPessoaEmpresa prestadorField;

    private tcDadosTomador tomadorServicoField;

    private tcDadosIntermediario intermediarioField;

    private tcDadosConstrucaoCivil construcaoCivilField;

    private sbyte regimeEspecialTributacaoField;

    private bool regimeEspecialTributacaoFieldSpecified;

    private sbyte optanteSimplesNacionalField;

    private sbyte incentivoFiscalField;

    private tcEvento eventoField;

    private string informacoesComplementaresField;

    private tcDadosDeducao[] deducaoField;

    private string idField;

    /// <remarks/>
    public tcInfRps Rps
    {
        get
        {
            return rpsField;
        }
        set
        {
            rpsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime Competencia
    {
        get
        {
            return competenciaField;
        }
        set
        {
            competenciaField = value;
        }
    }

    /// <remarks/>
    public tcDadosServico Servico
    {
        get
        {
            return servicoField;
        }
        set
        {
            servicoField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    public tcDadosTomador TomadorServico
    {
        get
        {
            return tomadorServicoField;
        }
        set
        {
            tomadorServicoField = value;
        }
    }

    /// <remarks/>
    public tcDadosIntermediario Intermediario
    {
        get
        {
            return intermediarioField;
        }
        set
        {
            intermediarioField = value;
        }
    }

    /// <remarks/>
    public tcDadosConstrucaoCivil ConstrucaoCivil
    {
        get
        {
            return construcaoCivilField;
        }
        set
        {
            construcaoCivilField = value;
        }
    }

    /// <remarks/>
    public sbyte RegimeEspecialTributacao
    {
        get
        {
            return regimeEspecialTributacaoField;
        }
        set
        {
            regimeEspecialTributacaoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool RegimeEspecialTributacaoSpecified
    {
        get
        {
            return regimeEspecialTributacaoFieldSpecified;
        }
        set
        {
            regimeEspecialTributacaoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public sbyte OptanteSimplesNacional
    {
        get
        {
            return optanteSimplesNacionalField;
        }
        set
        {
            optanteSimplesNacionalField = value;
        }
    }

    /// <remarks/>
    public sbyte IncentivoFiscal
    {
        get
        {
            return incentivoFiscalField;
        }
        set
        {
            incentivoFiscalField = value;
        }
    }

    /// <remarks/>
    public tcEvento Evento
    {
        get
        {
            return eventoField;
        }
        set
        {
            eventoField = value;
        }
    }

    /// <remarks/>
    public string InformacoesComplementares
    {
        get
        {
            return informacoesComplementaresField;
        }
        set
        {
            informacoesComplementaresField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("Deducao")]
    public tcDadosDeducao[] Deducao
    {
        get
        {
            return deducaoField;
        }
        set
        {
            deducaoField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcInfRps
{

    private tcIdentificacaoRps identificacaoRpsField;

    private DateTime dataEmissaoField;

    private sbyte statusField;

    private tcIdentificacaoRps rpsSubstituidoField;

    private string idField;

    /// <remarks/>
    public tcIdentificacaoRps IdentificacaoRps
    {
        get
        {
            return identificacaoRpsField;
        }
        set
        {
            identificacaoRpsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataEmissao
    {
        get
        {
            return dataEmissaoField;
        }
        set
        {
            dataEmissaoField = value;
        }
    }

    /// <remarks/>
    public sbyte Status
    {
        get
        {
            return statusField;
        }
        set
        {
            statusField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoRps RpsSubstituido
    {
        get
        {
            return rpsSubstituidoField;
        }
        set
        {
            rpsSubstituidoField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosServico
{

    private tcValoresDeclaracaoServico valoresField;

    private sbyte issRetidoField;

    private sbyte responsavelRetencaoField;

    private bool responsavelRetencaoFieldSpecified;

    private tsItemListaServico itemListaServicoField;

    private int codigoCnaeField;

    private bool codigoCnaeFieldSpecified;

    private string codigoTributacaoMunicipioField;

    private string codigoNbsField;

    private string discriminacaoField;

    private int codigoMunicipioField;

    private string codigoPaisField;

    private sbyte exigibilidadeISSField;

    private string identifNaoExigibilidadeField;

    private int municipioIncidenciaField;

    private bool municipioIncidenciaFieldSpecified;

    private string numeroProcessoField;

    /// <remarks/>
    public tcValoresDeclaracaoServico Valores
    {
        get
        {
            return valoresField;
        }
        set
        {
            valoresField = value;
        }
    }

    /// <remarks/>
    public sbyte IssRetido
    {
        get
        {
            return issRetidoField;
        }
        set
        {
            issRetidoField = value;
        }
    }

    /// <remarks/>
    public sbyte ResponsavelRetencao
    {
        get
        {
            return responsavelRetencaoField;
        }
        set
        {
            responsavelRetencaoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ResponsavelRetencaoSpecified
    {
        get
        {
            return responsavelRetencaoFieldSpecified;
        }
        set
        {
            responsavelRetencaoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public tsItemListaServico ItemListaServico
    {
        get
        {
            return itemListaServicoField;
        }
        set
        {
            itemListaServicoField = value;
        }
    }

    /// <remarks/>
    public int CodigoCnae
    {
        get
        {
            return codigoCnaeField;
        }
        set
        {
            codigoCnaeField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool CodigoCnaeSpecified
    {
        get
        {
            return codigoCnaeFieldSpecified;
        }
        set
        {
            codigoCnaeFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string CodigoTributacaoMunicipio
    {
        get
        {
            return codigoTributacaoMunicipioField;
        }
        set
        {
            codigoTributacaoMunicipioField = value;
        }
    }

    /// <remarks/>
    public string CodigoNbs
    {
        get
        {
            return codigoNbsField;
        }
        set
        {
            codigoNbsField = value;
        }
    }

    /// <remarks/>
    public string Discriminacao
    {
        get
        {
            return discriminacaoField;
        }
        set
        {
            discriminacaoField = value;
        }
    }

    /// <remarks/>
    public int CodigoMunicipio
    {
        get
        {
            return codigoMunicipioField;
        }
        set
        {
            codigoMunicipioField = value;
        }
    }

    /// <remarks/>
    public string CodigoPais
    {
        get
        {
            return codigoPaisField;
        }
        set
        {
            codigoPaisField = value;
        }
    }

    /// <remarks/>
    public sbyte ExigibilidadeISS
    {
        get
        {
            return exigibilidadeISSField;
        }
        set
        {
            exigibilidadeISSField = value;
        }
    }

    /// <remarks/>
    public string IdentifNaoExigibilidade
    {
        get
        {
            return identifNaoExigibilidadeField;
        }
        set
        {
            identifNaoExigibilidadeField = value;
        }
    }

    /// <remarks/>
    public int MunicipioIncidencia
    {
        get
        {
            return municipioIncidenciaField;
        }
        set
        {
            municipioIncidenciaField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool MunicipioIncidenciaSpecified
    {
        get
        {
            return municipioIncidenciaFieldSpecified;
        }
        set
        {
            municipioIncidenciaFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string NumeroProcesso
    {
        get
        {
            return numeroProcessoField;
        }
        set
        {
            numeroProcessoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcValoresDeclaracaoServico
{

    private decimal valorServicosField;

    private decimal valorDeducoesField;

    private bool valorDeducoesFieldSpecified;

    private decimal valorPisField;

    private bool valorPisFieldSpecified;

    private decimal valorCofinsField;

    private bool valorCofinsFieldSpecified;

    private decimal valorInssField;

    private bool valorInssFieldSpecified;

    private decimal valorIrField;

    private bool valorIrFieldSpecified;

    private decimal valorCsllField;

    private bool valorCsllFieldSpecified;

    private decimal outrasRetencoesField;

    private bool outrasRetencoesFieldSpecified;

    private decimal valTotTributosField;

    private bool valTotTributosFieldSpecified;

    private decimal valorIssField;

    private bool valorIssFieldSpecified;

    private decimal aliquotaField;

    private bool aliquotaFieldSpecified;

    private decimal descontoIncondicionadoField;

    private bool descontoIncondicionadoFieldSpecified;

    private decimal descontoCondicionadoField;

    private bool descontoCondicionadoFieldSpecified;

    /// <remarks/>
    public decimal ValorServicos
    {
        get
        {
            return valorServicosField;
        }
        set
        {
            valorServicosField = value;
        }
    }

    /// <remarks/>
    public decimal ValorDeducoes
    {
        get
        {
            return valorDeducoesField;
        }
        set
        {
            valorDeducoesField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorDeducoesSpecified
    {
        get
        {
            return valorDeducoesFieldSpecified;
        }
        set
        {
            valorDeducoesFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorPis
    {
        get
        {
            return valorPisField;
        }
        set
        {
            valorPisField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorPisSpecified
    {
        get
        {
            return valorPisFieldSpecified;
        }
        set
        {
            valorPisFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorCofins
    {
        get
        {
            return valorCofinsField;
        }
        set
        {
            valorCofinsField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorCofinsSpecified
    {
        get
        {
            return valorCofinsFieldSpecified;
        }
        set
        {
            valorCofinsFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorInss
    {
        get
        {
            return valorInssField;
        }
        set
        {
            valorInssField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorInssSpecified
    {
        get
        {
            return valorInssFieldSpecified;
        }
        set
        {
            valorInssFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorIr
    {
        get
        {
            return valorIrField;
        }
        set
        {
            valorIrField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorIrSpecified
    {
        get
        {
            return valorIrFieldSpecified;
        }
        set
        {
            valorIrFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorCsll
    {
        get
        {
            return valorCsllField;
        }
        set
        {
            valorCsllField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorCsllSpecified
    {
        get
        {
            return valorCsllFieldSpecified;
        }
        set
        {
            valorCsllFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal OutrasRetencoes
    {
        get
        {
            return outrasRetencoesField;
        }
        set
        {
            outrasRetencoesField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool OutrasRetencoesSpecified
    {
        get
        {
            return outrasRetencoesFieldSpecified;
        }
        set
        {
            outrasRetencoesFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValTotTributos
    {
        get
        {
            return valTotTributosField;
        }
        set
        {
            valTotTributosField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValTotTributosSpecified
    {
        get
        {
            return valTotTributosFieldSpecified;
        }
        set
        {
            valTotTributosFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorIss
    {
        get
        {
            return valorIssField;
        }
        set
        {
            valorIssField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorIssSpecified
    {
        get
        {
            return valorIssFieldSpecified;
        }
        set
        {
            valorIssFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal Aliquota
    {
        get
        {
            return aliquotaField;
        }
        set
        {
            aliquotaField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool AliquotaSpecified
    {
        get
        {
            return aliquotaFieldSpecified;
        }
        set
        {
            aliquotaFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal DescontoIncondicionado
    {
        get
        {
            return descontoIncondicionadoField;
        }
        set
        {
            descontoIncondicionadoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool DescontoIncondicionadoSpecified
    {
        get
        {
            return descontoIncondicionadoFieldSpecified;
        }
        set
        {
            descontoIncondicionadoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal DescontoCondicionado
    {
        get
        {
            return descontoCondicionadoField;
        }
        set
        {
            descontoCondicionadoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool DescontoCondicionadoSpecified
    {
        get
        {
            return descontoCondicionadoFieldSpecified;
        }
        set
        {
            descontoCondicionadoFieldSpecified = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public enum tsItemListaServico
{

    /// <remarks/>
    [XmlEnumAttribute("01.01")]
    Item0101,

    /// <remarks/>
    [XmlEnumAttribute("01.02")]
    Item0102,

    /// <remarks/>
    [XmlEnumAttribute("01.03")]
    Item0103,

    /// <remarks/>
    [XmlEnumAttribute("01.04")]
    Item0104,

    /// <remarks/>
    [XmlEnumAttribute("01.05")]
    Item0105,

    /// <remarks/>
    [XmlEnumAttribute("01.06")]
    Item0106,

    /// <remarks/>
    [XmlEnumAttribute("01.07")]
    Item0107,

    /// <remarks/>
    [XmlEnumAttribute("01.08")]
    Item0108,

    /// <remarks/>
    [XmlEnumAttribute("01.09")]
    Item0109,

    /// <remarks/>
    [XmlEnumAttribute("02.01")]
    Item0201,

    /// <remarks/>
    [XmlEnumAttribute("03.02")]
    Item0302,

    /// <remarks/>
    [XmlEnumAttribute("03.03")]
    Item0303,

    /// <remarks/>
    [XmlEnumAttribute("03.04")]
    Item0304,

    /// <remarks/>
    [XmlEnumAttribute("03.05")]
    Item0305,

    /// <remarks/>
    [XmlEnumAttribute("04.01")]
    Item0401,

    /// <remarks/>
    [XmlEnumAttribute("04.02")]
    Item0402,

    /// <remarks/>
    [XmlEnumAttribute("04.03")]
    Item0403,

    /// <remarks/>
    [XmlEnumAttribute("04.04")]
    Item0404,

    /// <remarks/>
    [XmlEnumAttribute("04.05")]
    Item0405,

    /// <remarks/>
    [XmlEnumAttribute("04.06")]
    Item0406,

    /// <remarks/>
    [XmlEnumAttribute("04.07")]
    Item0407,

    /// <remarks/>
    [XmlEnumAttribute("04.08")]
    Item0408,

    /// <remarks/>
    [XmlEnumAttribute("04.09")]
    Item0409,

    /// <remarks/>
    [XmlEnumAttribute("04.10")]
    Item0410,

    /// <remarks/>
    [XmlEnumAttribute("04.11")]
    Item0411,

    /// <remarks/>
    [XmlEnumAttribute("04.12")]
    Item0412,

    /// <remarks/>
    [XmlEnumAttribute("04.13")]
    Item0413,

    /// <remarks/>
    [XmlEnumAttribute("04.14")]
    Item0414,

    /// <remarks/>
    [XmlEnumAttribute("04.15")]
    Item0415,

    /// <remarks/>
    [XmlEnumAttribute("04.16")]
    Item0416,

    /// <remarks/>
    [XmlEnumAttribute("04.17")]
    Item0417,

    /// <remarks/>
    [XmlEnumAttribute("04.18")]
    Item0418,

    /// <remarks/>
    [XmlEnumAttribute("04.19")]
    Item0419,

    /// <remarks/>
    [XmlEnumAttribute("04.20")]
    Item0420,

    /// <remarks/>
    [XmlEnumAttribute("04.21")]
    Item0421,

    /// <remarks/>
    [XmlEnumAttribute("04.22")]
    Item0422,

    /// <remarks/>
    [XmlEnumAttribute("04.23")]
    Item0423,

    /// <remarks/>
    [XmlEnumAttribute("05.01")]
    Item0501,

    /// <remarks/>
    [XmlEnumAttribute("05.02")]
    Item0502,

    /// <remarks/>
    [XmlEnumAttribute("05.03")]
    Item0503,

    /// <remarks/>
    [XmlEnumAttribute("05.04")]
    Item0504,

    /// <remarks/>
    [XmlEnumAttribute("05.05")]
    Item0505,

    /// <remarks/>
    [XmlEnumAttribute("05.06")]
    Item0506,

    /// <remarks/>
    [XmlEnumAttribute("05.07")]
    Item0507,

    /// <remarks/>
    [XmlEnumAttribute("05.08")]
    Item0508,

    /// <remarks/>
    [XmlEnumAttribute("05.09")]
    Item0509,

    /// <remarks/>
    [XmlEnumAttribute("06.01")]
    Item0601,

    /// <remarks/>
    [XmlEnumAttribute("06.02")]
    Item0602,

    /// <remarks/>
    [XmlEnumAttribute("06.03")]
    Item0603,

    /// <remarks/>
    [XmlEnumAttribute("06.04")]
    Item0604,

    /// <remarks/>
    [XmlEnumAttribute("06.05")]
    Item0605,

    /// <remarks/>
    [XmlEnumAttribute("06.06")]
    Item0606,

    /// <remarks/>
    [XmlEnumAttribute("07.01")]
    Item0701,

    /// <remarks/>
    [XmlEnumAttribute("07.02")]
    Item0702,

    /// <remarks/>
    [XmlEnumAttribute("07.03")]
    Item0703,

    /// <remarks/>
    [XmlEnumAttribute("07.04")]
    Item0704,

    /// <remarks/>
    [XmlEnumAttribute("07.05")]
    Item0705,

    /// <remarks/>
    [XmlEnumAttribute("07.06")]
    Item0706,

    /// <remarks/>
    [XmlEnumAttribute("07.07")]
    Item0707,

    /// <remarks/>
    [XmlEnumAttribute("07.08")]
    Item0708,

    /// <remarks/>
    [XmlEnumAttribute("07.09")]
    Item0709,

    /// <remarks/>
    [XmlEnumAttribute("07.10")]
    Item0710,

    /// <remarks/>
    [XmlEnumAttribute("07.11")]
    Item0711,

    /// <remarks/>
    [XmlEnumAttribute("07.12")]
    Item0712,

    /// <remarks/>
    [XmlEnumAttribute("07.13")]
    Item0713,

    /// <remarks/>
    [XmlEnumAttribute("07.16")]
    Item0716,

    /// <remarks/>
    [XmlEnumAttribute("07.17")]
    Item0717,

    /// <remarks/>
    [XmlEnumAttribute("07.18")]
    Item0718,

    /// <remarks/>
    [XmlEnumAttribute("07.19")]
    Item0719,

    /// <remarks/>
    [XmlEnumAttribute("07.20")]
    Item0720,

    /// <remarks/>
    [XmlEnumAttribute("07.21")]
    Item0721,

    /// <remarks/>
    [XmlEnumAttribute("07.22")]
    Item0722,

    /// <remarks/>
    [XmlEnumAttribute("08.01")]
    Item0801,

    /// <remarks/>
    [XmlEnumAttribute("08.02")]
    Item0802,

    /// <remarks/>
    [XmlEnumAttribute("09.01")]
    Item0901,

    /// <remarks/>
    [XmlEnumAttribute("09.02")]
    Item0902,

    /// <remarks/>
    [XmlEnumAttribute("09.03")]
    Item0903,

    /// <remarks/>
    [XmlEnumAttribute("10.01")]
    Item1001,

    /// <remarks/>
    [XmlEnumAttribute("10.02")]
    Item1002,

    /// <remarks/>
    [XmlEnumAttribute("10.03")]
    Item1003,

    /// <remarks/>
    [XmlEnumAttribute("10.04")]
    Item1004,

    /// <remarks/>
    [XmlEnumAttribute("10.05")]
    Item1005,

    /// <remarks/>
    [XmlEnumAttribute("10.06")]
    Item1006,

    /// <remarks/>
    [XmlEnumAttribute("10.07")]
    Item1007,

    /// <remarks/>
    [XmlEnumAttribute("10.08")]
    Item1008,

    /// <remarks/>
    [XmlEnumAttribute("10.09")]
    Item1009,

    /// <remarks/>
    [XmlEnumAttribute("10.10")]
    Item1010,

    /// <remarks/>
    [XmlEnumAttribute("11.01")]
    Item1101,

    /// <remarks/>
    [XmlEnumAttribute("11.02")]
    Item1102,

    /// <remarks/>
    [XmlEnumAttribute("11.03")]
    Item1103,

    /// <remarks/>
    [XmlEnumAttribute("11.04")]
    Item1104,

    /// <remarks/>
    [XmlEnumAttribute("11.05")]
    Item1105,

    /// <remarks/>
    [XmlEnumAttribute("12.01")]
    Item1201,

    /// <remarks/>
    [XmlEnumAttribute("12.02")]
    Item1202,

    /// <remarks/>
    [XmlEnumAttribute("12.03")]
    Item1203,

    /// <remarks/>
    [XmlEnumAttribute("12.04")]
    Item1204,

    /// <remarks/>
    [XmlEnumAttribute("12.05")]
    Item1205,

    /// <remarks/>
    [XmlEnumAttribute("12.06")]
    Item1206,

    /// <remarks/>
    [XmlEnumAttribute("12.07")]
    Item1207,

    /// <remarks/>
    [XmlEnumAttribute("12.08")]
    Item1208,

    /// <remarks/>
    [XmlEnumAttribute("12.09")]
    Item1209,

    /// <remarks/>
    [XmlEnumAttribute("12.10")]
    Item1210,

    /// <remarks/>
    [XmlEnumAttribute("12.11")]
    Item1211,

    /// <remarks/>
    [XmlEnumAttribute("12.12")]
    Item1212,

    /// <remarks/>
    [XmlEnumAttribute("12.13")]
    Item1213,

    /// <remarks/>
    [XmlEnumAttribute("12.14")]
    Item1214,

    /// <remarks/>
    [XmlEnumAttribute("12.15")]
    Item1215,

    /// <remarks/>
    [XmlEnumAttribute("12.16")]
    Item1216,

    /// <remarks/>
    [XmlEnumAttribute("12.17")]
    Item1217,

    /// <remarks/>
    [XmlEnumAttribute("13.02")]
    Item1302,

    /// <remarks/>
    [XmlEnumAttribute("13.03")]
    Item1303,

    /// <remarks/>
    [XmlEnumAttribute("13.04")]
    Item1304,

    /// <remarks/>
    [XmlEnumAttribute("13.05")]
    Item1305,

    /// <remarks/>
    [XmlEnumAttribute("14.01")]
    Item1401,

    /// <remarks/>
    [XmlEnumAttribute("14.02")]
    Item1402,

    /// <remarks/>
    [XmlEnumAttribute("14.03")]
    Item1403,

    /// <remarks/>
    [XmlEnumAttribute("14.04")]
    Item1404,

    /// <remarks/>
    [XmlEnumAttribute("14.05")]
    Item1405,

    /// <remarks/>
    [XmlEnumAttribute("14.06")]
    Item1406,

    /// <remarks/>
    [XmlEnumAttribute("14.07")]
    Item1407,

    /// <remarks/>
    [XmlEnumAttribute("14.08")]
    Item1408,

    /// <remarks/>
    [XmlEnumAttribute("14.09")]
    Item1409,

    /// <remarks/>
    [XmlEnumAttribute("14.10")]
    Item1410,

    /// <remarks/>
    [XmlEnumAttribute("14.11")]
    Item1411,

    /// <remarks/>
    [XmlEnumAttribute("14.12")]
    Item1412,

    /// <remarks/>
    [XmlEnumAttribute("14.13")]
    Item1413,

    /// <remarks/>
    [XmlEnumAttribute("14.14")]
    Item1414,

    /// <remarks/>
    [XmlEnumAttribute("15.01")]
    Item1501,

    /// <remarks/>
    [XmlEnumAttribute("15.02")]
    Item1502,

    /// <remarks/>
    [XmlEnumAttribute("15.03")]
    Item1503,

    /// <remarks/>
    [XmlEnumAttribute("15.04")]
    Item1504,

    /// <remarks/>
    [XmlEnumAttribute("15.05")]
    Item1505,

    /// <remarks/>
    [XmlEnumAttribute("15.06")]
    Item1506,

    /// <remarks/>
    [XmlEnumAttribute("15.07")]
    Item1507,

    /// <remarks/>
    [XmlEnumAttribute("15.08")]
    Item1508,

    /// <remarks/>
    [XmlEnumAttribute("15.09")]
    Item1509,

    /// <remarks/>
    [XmlEnumAttribute("15.10")]
    Item1510,

    /// <remarks/>
    [XmlEnumAttribute("15.11")]
    Item1511,

    /// <remarks/>
    [XmlEnumAttribute("15.12")]
    Item1512,

    /// <remarks/>
    [XmlEnumAttribute("15.13")]
    Item1513,

    /// <remarks/>
    [XmlEnumAttribute("15.14")]
    Item1514,

    /// <remarks/>
    [XmlEnumAttribute("15.15")]
    Item1515,

    /// <remarks/>
    [XmlEnumAttribute("15.16")]
    Item1516,

    /// <remarks/>
    [XmlEnumAttribute("15.17")]
    Item1517,

    /// <remarks/>
    [XmlEnumAttribute("15.18")]
    Item1518,

    /// <remarks/>
    [XmlEnumAttribute("16.01")]
    Item1601,

    /// <remarks/>
    [XmlEnumAttribute("16.02")]
    Item1602,

    /// <remarks/>
    [XmlEnumAttribute("17.01")]
    Item1701,

    /// <remarks/>
    [XmlEnumAttribute("17.02")]
    Item1702,

    /// <remarks/>
    [XmlEnumAttribute("17.03")]
    Item1703,

    /// <remarks/>
    [XmlEnumAttribute("17.04")]
    Item1704,

    /// <remarks/>
    [XmlEnumAttribute("17.05")]
    Item1705,

    /// <remarks/>
    [XmlEnumAttribute("17.06")]
    Item1706,

    /// <remarks/>
    [XmlEnumAttribute("17.08")]
    Item1708,

    /// <remarks/>
    [XmlEnumAttribute("17.09")]
    Item1709,

    /// <remarks/>
    [XmlEnumAttribute("17.10")]
    Item1710,

    /// <remarks/>
    [XmlEnumAttribute("17.11")]
    Item1711,

    /// <remarks/>
    [XmlEnumAttribute("17.12")]
    Item1712,

    /// <remarks/>
    [XmlEnumAttribute("17.13")]
    Item1713,

    /// <remarks/>
    [XmlEnumAttribute("17.14")]
    Item1714,

    /// <remarks/>
    [XmlEnumAttribute("17.15")]
    Item1715,

    /// <remarks/>
    [XmlEnumAttribute("17.16")]
    Item1716,

    /// <remarks/>
    [XmlEnumAttribute("17.17")]
    Item1717,

    /// <remarks/>
    [XmlEnumAttribute("17.18")]
    Item1718,

    /// <remarks/>
    [XmlEnumAttribute("17.19")]
    Item1719,

    /// <remarks/>
    [XmlEnumAttribute("17.20")]
    Item1720,

    /// <remarks/>
    [XmlEnumAttribute("17.21")]
    Item1721,

    /// <remarks/>
    [XmlEnumAttribute("17.22")]
    Item1722,

    /// <remarks/>
    [XmlEnumAttribute("17.23")]
    Item1723,

    /// <remarks/>
    [XmlEnumAttribute("17.24")]
    Item1724,

    /// <remarks/>
    [XmlEnumAttribute("17.25")]
    Item1725,

    /// <remarks/>
    [XmlEnumAttribute("18.01")]
    Item1801,

    /// <remarks/>
    [XmlEnumAttribute("19.01")]
    Item1901,

    /// <remarks/>
    [XmlEnumAttribute("20.01")]
    Item2001,

    /// <remarks/>
    [XmlEnumAttribute("20.02")]
    Item2002,

    /// <remarks/>
    [XmlEnumAttribute("20.03")]
    Item2003,

    /// <remarks/>
    [XmlEnumAttribute("21.01")]
    Item2101,

    /// <remarks/>
    [XmlEnumAttribute("22.01")]
    Item2201,

    /// <remarks/>
    [XmlEnumAttribute("23.01")]
    Item2301,

    /// <remarks/>
    [XmlEnumAttribute("24.01")]
    Item2401,

    /// <remarks/>
    [XmlEnumAttribute("25.01")]
    Item2501,

    /// <remarks/>
    [XmlEnumAttribute("25.02")]
    Item2502,

    /// <remarks/>
    [XmlEnumAttribute("25.03")]
    Item2503,

    /// <remarks/>
    [XmlEnumAttribute("25.04")]
    Item2504,

    /// <remarks/>
    [XmlEnumAttribute("25.05")]
    Item2505,

    /// <remarks/>
    [XmlEnumAttribute("26.01")]
    Item2601,

    /// <remarks/>
    [XmlEnumAttribute("27.01")]
    Item2701,

    /// <remarks/>
    [XmlEnumAttribute("28.01")]
    Item2801,

    /// <remarks/>
    [XmlEnumAttribute("29.01")]
    Item2901,

    /// <remarks/>
    [XmlEnumAttribute("30.01")]
    Item3001,

    /// <remarks/>
    [XmlEnumAttribute("31.01")]
    Item3101,

    /// <remarks/>
    [XmlEnumAttribute("32.01")]
    Item3201,

    /// <remarks/>
    [XmlEnumAttribute("33.01")]
    Item3301,

    /// <remarks/>
    [XmlEnumAttribute("34.01")]
    Item3401,

    /// <remarks/>
    [XmlEnumAttribute("35.01")]
    Item3501,

    /// <remarks/>
    [XmlEnumAttribute("36.01")]
    Item3601,

    /// <remarks/>
    [XmlEnumAttribute("37.01")]
    Item3701,

    /// <remarks/>
    [XmlEnumAttribute("38.01")]
    Item3801,

    /// <remarks/>
    [XmlEnumAttribute("39.01")]
    Item3901,

    /// <remarks/>
    [XmlEnumAttribute("40.01")]
    Item4001,

    /// <remarks/>
    [XmlEnumAttribute("99.99")]
    Item9999,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosTomador
{

    private tcIdentificacaoPessoaEmpresa identificacaoTomadorField;

    private string nifTomadorField;

    private string razaoSocialField;

    private object itemField;

    private tcContato contatoField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa IdentificacaoTomador
    {
        get
        {
            return identificacaoTomadorField;
        }
        set
        {
            identificacaoTomadorField = value;
        }
    }

    /// <remarks/>
    public string NifTomador
    {
        get
        {
            return nifTomadorField;
        }
        set
        {
            nifTomadorField = value;
        }
    }

    /// <remarks/>
    public string RazaoSocial
    {
        get
        {
            return razaoSocialField;
        }
        set
        {
            razaoSocialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("Endereco", typeof(tcEndereco))]
    [XmlElementAttribute("EnderecoExterior", typeof(tcEnderecoExterior))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }

    /// <remarks/>
    public tcContato Contato
    {
        get
        {
            return contatoField;
        }
        set
        {
            contatoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcEndereco
{

    private string enderecoField;

    private string numeroField;

    private string complementoField;

    private string bairroField;

    private int codigoMunicipioField;

    private tsUf ufField;

    private string cepField;

    /// <remarks/>
    public string Endereco
    {
        get
        {
            return enderecoField;
        }
        set
        {
            enderecoField = value;
        }
    }

    /// <remarks/>
    public string Numero
    {
        get
        {
            return numeroField;
        }
        set
        {
            numeroField = value;
        }
    }

    /// <remarks/>
    public string Complemento
    {
        get
        {
            return complementoField;
        }
        set
        {
            complementoField = value;
        }
    }

    /// <remarks/>
    public string Bairro
    {
        get
        {
            return bairroField;
        }
        set
        {
            bairroField = value;
        }
    }

    /// <remarks/>
    public int CodigoMunicipio
    {
        get
        {
            return codigoMunicipioField;
        }
        set
        {
            codigoMunicipioField = value;
        }
    }

    /// <remarks/>
    public tsUf Uf
    {
        get
        {
            return ufField;
        }
        set
        {
            ufField = value;
        }
    }

    /// <remarks/>
    public string Cep
    {
        get
        {
            return cepField;
        }
        set
        {
            cepField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public enum tsUf
{

    /// <remarks/>
    AC,

    /// <remarks/>
    AL,

    /// <remarks/>
    AM,

    /// <remarks/>
    AP,

    /// <remarks/>
    BA,

    /// <remarks/>
    CE,

    /// <remarks/>
    DF,

    /// <remarks/>
    ES,

    /// <remarks/>
    GO,

    /// <remarks/>
    MA,

    /// <remarks/>
    MG,

    /// <remarks/>
    MS,

    /// <remarks/>
    MT,

    /// <remarks/>
    PA,

    /// <remarks/>
    PB,

    /// <remarks/>
    PE,

    /// <remarks/>
    PI,

    /// <remarks/>
    PR,

    /// <remarks/>
    RJ,

    /// <remarks/>
    RN,

    /// <remarks/>
    RO,

    /// <remarks/>
    RR,

    /// <remarks/>
    RS,

    /// <remarks/>
    SC,

    /// <remarks/>
    SE,

    /// <remarks/>
    SP,

    /// <remarks/>
    TO,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcEnderecoExterior
{

    private string codigoPaisField;

    private string enderecoCompletoExteriorField;

    /// <remarks/>
    public string CodigoPais
    {
        get
        {
            return codigoPaisField;
        }
        set
        {
            codigoPaisField = value;
        }
    }

    /// <remarks/>
    public string EnderecoCompletoExterior
    {
        get
        {
            return enderecoCompletoExteriorField;
        }
        set
        {
            enderecoCompletoExteriorField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcContato
{

    private string[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    /// <remarks/>
    [XmlElementAttribute("Email", typeof(string))]
    [XmlElementAttribute("Telefone", typeof(string))]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
public enum ItemsChoiceType
{

    /// <remarks/>
    Email,

    /// <remarks/>
    Telefone,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosIntermediario
{

    private tcIdentificacaoPessoaEmpresa identificacaoIntermediarioField;

    private string razaoSocialField;

    private int codigoMunicipioField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa IdentificacaoIntermediario
    {
        get
        {
            return identificacaoIntermediarioField;
        }
        set
        {
            identificacaoIntermediarioField = value;
        }
    }

    /// <remarks/>
    public string RazaoSocial
    {
        get
        {
            return razaoSocialField;
        }
        set
        {
            razaoSocialField = value;
        }
    }

    /// <remarks/>
    public int CodigoMunicipio
    {
        get
        {
            return codigoMunicipioField;
        }
        set
        {
            codigoMunicipioField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosConstrucaoCivil
{

    private string[] itemsField;

    private ItemsChoiceType1[] itemsElementNameField;

    /// <remarks/>
    [XmlElementAttribute("Art", typeof(string))]
    [XmlElementAttribute("CodigoObra", typeof(string))]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType1[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
public enum ItemsChoiceType1
{

    /// <remarks/>
    Art,

    /// <remarks/>
    CodigoObra,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcEvento
{

    private string[] itemsField;

    private ItemsChoiceType2[] itemsElementNameField;

    /// <remarks/>
    [XmlElementAttribute("DescricaoEvento", typeof(string))]
    [XmlElementAttribute("IdentificacaoEvento", typeof(string))]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType2[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
public enum ItemsChoiceType2
{

    /// <remarks/>
    DescricaoEvento,

    /// <remarks/>
    IdentificacaoEvento,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosDeducao
{

    private sbyte tipoDeducaoField;

    private string descricaoDeducaoField;

    private tcIdentificacaoDocumentoDeducao identificacaoDocumentoDeducaoField;

    private tcDadosFornecedor dadosFornecedorField;

    private DateTime dataEmissaoField;

    private decimal valorDedutivelField;

    private decimal valorUtilizadoDeducaoField;

    /// <remarks/>
    public sbyte TipoDeducao
    {
        get
        {
            return tipoDeducaoField;
        }
        set
        {
            tipoDeducaoField = value;
        }
    }

    /// <remarks/>
    public string DescricaoDeducao
    {
        get
        {
            return descricaoDeducaoField;
        }
        set
        {
            descricaoDeducaoField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoDocumentoDeducao IdentificacaoDocumentoDeducao
    {
        get
        {
            return identificacaoDocumentoDeducaoField;
        }
        set
        {
            identificacaoDocumentoDeducaoField = value;
        }
    }

    /// <remarks/>
    public tcDadosFornecedor DadosFornecedor
    {
        get
        {
            return dadosFornecedorField;
        }
        set
        {
            dadosFornecedorField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataEmissao
    {
        get
        {
            return dataEmissaoField;
        }
        set
        {
            dataEmissaoField = value;
        }
    }

    /// <remarks/>
    public decimal ValorDedutivel
    {
        get
        {
            return valorDedutivelField;
        }
        set
        {
            valorDedutivelField = value;
        }
    }

    /// <remarks/>
    public decimal ValorUtilizadoDeducao
    {
        get
        {
            return valorUtilizadoDeducaoField;
        }
        set
        {
            valorUtilizadoDeducaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoDocumentoDeducao
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("IdentificacaoNfe", typeof(tcIdentificacaoNfeDeducao))]
    [XmlElementAttribute("IdentificacaoNfse", typeof(tcIdentificacaoNfseDeducao))]
    [XmlElementAttribute("OutroDocumento", typeof(tcOutroDocumentoDeducao))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoNfeDeducao
{

    private string numeroNfeField;

    private tsUf ufNfeField;

    private string chaveAcessoNfeField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NumeroNfe
    {
        get
        {
            return numeroNfeField;
        }
        set
        {
            numeroNfeField = value;
        }
    }

    /// <remarks/>
    public tsUf UfNfe
    {
        get
        {
            return ufNfeField;
        }
        set
        {
            ufNfeField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string ChaveAcessoNfe
    {
        get
        {
            return chaveAcessoNfeField;
        }
        set
        {
            chaveAcessoNfeField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoNfseDeducao
{

    private int codigoMunicipioGeradorField;

    private string numeroNfseField;

    private string codigoVerificacaoField;

    /// <remarks/>
    public int CodigoMunicipioGerador
    {
        get
        {
            return codigoMunicipioGeradorField;
        }
        set
        {
            codigoMunicipioGeradorField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NumeroNfse
    {
        get
        {
            return numeroNfseField;
        }
        set
        {
            numeroNfseField = value;
        }
    }

    /// <remarks/>
    public string CodigoVerificacao
    {
        get
        {
            return codigoVerificacaoField;
        }
        set
        {
            codigoVerificacaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcOutroDocumentoDeducao
{

    private string identificacaoDocumentoField;

    /// <remarks/>
    public string IdentificacaoDocumento
    {
        get
        {
            return identificacaoDocumentoField;
        }
        set
        {
            identificacaoDocumentoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosFornecedor
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("FornecedorExterior", typeof(tcFornecedorExterior))]
    [XmlElementAttribute("IdentificacaoFornecedor", typeof(tcIdentificacaoFornecedor))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcFornecedorExterior
{

    private string nifFornecedorField;

    private string codigoPaisField;

    /// <remarks/>
    public string NifFornecedor
    {
        get
        {
            return nifFornecedorField;
        }
        set
        {
            nifFornecedorField = value;
        }
    }

    /// <remarks/>
    public string CodigoPais
    {
        get
        {
            return codigoPaisField;
        }
        set
        {
            codigoPaisField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoFornecedor
{

    private tcCpfCnpj cpfCnpjField;

    /// <remarks/>
    public tcCpfCnpj CpfCnpj
    {
        get
        {
            return cpfCnpjField;
        }
        set
        {
            cpfCnpjField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcInfSubstituicaoNfse
{

    private string nfseSubstituidoraField;

    private string idField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NfseSubstituidora
    {
        get
        {
            return nfseSubstituidoraField;
        }
        set
        {
            nfseSubstituidoraField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcSubstituicaoNfse
{

    private tcInfSubstituicaoNfse substituicaoNfseField;

    private SignatureType[] signatureField;

    private string versaoField;

    /// <remarks/>
    public tcInfSubstituicaoNfse SubstituicaoNfse
    {
        get
        {
            return substituicaoNfseField;
        }
        set
        {
            substituicaoNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType[] Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "token")]
    public string versao
    {
        get
        {
            return versaoField;
        }
        set
        {
            versaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcIdentificacaoOrgaoGerador
{

    private int codigoMunicipioField;

    private tsUf ufField;

    /// <remarks/>
    public int CodigoMunicipio
    {
        get
        {
            return codigoMunicipioField;
        }
        set
        {
            codigoMunicipioField = value;
        }
    }

    /// <remarks/>
    public tsUf Uf
    {
        get
        {
            return ufField;
        }
        set
        {
            ufField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcDadosPrestador
{

    private string razaoSocialField;

    private string nomeFantasiaField;

    private tcEndereco enderecoField;

    private tcContato contatoField;

    /// <remarks/>
    public string RazaoSocial
    {
        get
        {
            return razaoSocialField;
        }
        set
        {
            razaoSocialField = value;
        }
    }

    /// <remarks/>
    public string NomeFantasia
    {
        get
        {
            return nomeFantasiaField;
        }
        set
        {
            nomeFantasiaField = value;
        }
    }

    /// <remarks/>
    public tcEndereco Endereco
    {
        get
        {
            return enderecoField;
        }
        set
        {
            enderecoField = value;
        }
    }

    /// <remarks/>
    public tcContato Contato
    {
        get
        {
            return contatoField;
        }
        set
        {
            contatoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcValoresNfse
{

    private decimal baseCalculoField;

    private decimal aliquotaField;

    private bool aliquotaFieldSpecified;

    private decimal valorIssField;

    private bool valorIssFieldSpecified;

    private decimal valorLiquidoNfseField;

    /// <remarks/>
    public decimal BaseCalculo
    {
        get
        {
            return baseCalculoField;
        }
        set
        {
            baseCalculoField = value;
        }
    }

    /// <remarks/>
    public decimal Aliquota
    {
        get
        {
            return aliquotaField;
        }
        set
        {
            aliquotaField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool AliquotaSpecified
    {
        get
        {
            return aliquotaFieldSpecified;
        }
        set
        {
            aliquotaFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorIss
    {
        get
        {
            return valorIssField;
        }
        set
        {
            valorIssField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorIssSpecified
    {
        get
        {
            return valorIssFieldSpecified;
        }
        set
        {
            valorIssFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal ValorLiquidoNfse
    {
        get
        {
            return valorLiquidoNfseField;
        }
        set
        {
            valorLiquidoNfseField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcInfNfse
{

    private string numeroField;

    private string codigoVerificacaoField;

    private DateTime dataEmissaoField;

    private string nfseSubstituidaField;

    private string outrasInformacoesField;

    private tcValoresNfse valoresNfseField;

    private string descricaoCodigoTributacaoMunicípioField;

    private decimal valorCreditoField;

    private bool valorCreditoFieldSpecified;

    private tcDadosPrestador prestadorServicoField;

    private tcIdentificacaoOrgaoGerador orgaoGeradorField;

    private tcDeclaracaoPrestacaoServico declaracaoPrestacaoServicoField;

    private string idField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Numero
    {
        get
        {
            return numeroField;
        }
        set
        {
            numeroField = value;
        }
    }

    /// <remarks/>
    public string CodigoVerificacao
    {
        get
        {
            return codigoVerificacaoField;
        }
        set
        {
            codigoVerificacaoField = value;
        }
    }

    /// <remarks/>
    public DateTime DataEmissao
    {
        get
        {
            return dataEmissaoField;
        }
        set
        {
            dataEmissaoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NfseSubstituida
    {
        get
        {
            return nfseSubstituidaField;
        }
        set
        {
            nfseSubstituidaField = value;
        }
    }

    /// <remarks/>
    public string OutrasInformacoes
    {
        get
        {
            return outrasInformacoesField;
        }
        set
        {
            outrasInformacoesField = value;
        }
    }

    /// <remarks/>
    public tcValoresNfse ValoresNfse
    {
        get
        {
            return valoresNfseField;
        }
        set
        {
            valoresNfseField = value;
        }
    }

    /// <remarks/>
    public string DescricaoCodigoTributacaoMunicípio
    {
        get
        {
            return descricaoCodigoTributacaoMunicípioField;
        }
        set
        {
            descricaoCodigoTributacaoMunicípioField = value;
        }
    }

    /// <remarks/>
    public decimal ValorCredito
    {
        get
        {
            return valorCreditoField;
        }
        set
        {
            valorCreditoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool ValorCreditoSpecified
    {
        get
        {
            return valorCreditoFieldSpecified;
        }
        set
        {
            valorCreditoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public tcDadosPrestador PrestadorServico
    {
        get
        {
            return prestadorServicoField;
        }
        set
        {
            prestadorServicoField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoOrgaoGerador OrgaoGerador
    {
        get
        {
            return orgaoGeradorField;
        }
        set
        {
            orgaoGeradorField = value;
        }
    }

    /// <remarks/>
    public tcDeclaracaoPrestacaoServico DeclaracaoPrestacaoServico
    {
        get
        {
            return declaracaoPrestacaoServicoField;
        }
        set
        {
            declaracaoPrestacaoServicoField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcNfse
{

    private tcInfNfse infNfseField;

    private SignatureType signatureField;

    private string versaoField;

    /// <remarks/>
    public tcInfNfse InfNfse
    {
        get
        {
            return infNfseField;
        }
        set
        {
            infNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "token")]
    public string versao
    {
        get
        {
            return versaoField;
        }
        set
        {
            versaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcMensagemRetorno
{

    private string codigoField;

    private string mensagemField;

    private string correcaoField;

    /// <remarks/>
    public string Codigo
    {
        get
        {
            return codigoField;
        }
        set
        {
            codigoField = value;
        }
    }

    /// <remarks/>
    public string Mensagem
    {
        get
        {
            return mensagemField;
        }
        set
        {
            mensagemField = value;
        }
    }

    /// <remarks/>
    public string Correcao
    {
        get
        {
            return correcaoField;
        }
        set
        {
            correcaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ListaMensagemRetorno
{

    private tcMensagemRetorno[] mensagemRetornoField;

    /// <remarks/>
    [XmlElementAttribute("MensagemRetorno")]
    public tcMensagemRetorno[] MensagemRetorno
    {
        get
        {
            return mensagemRetornoField;
        }
        set
        {
            mensagemRetornoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ListaMensagemAlertaRetorno
{

    private tcMensagemRetorno[] mensagemRetornoField;

    /// <remarks/>
    [XmlElementAttribute("MensagemRetorno")]
    public tcMensagemRetorno[] MensagemRetorno
    {
        get
        {
            return mensagemRetornoField;
        }
        set
        {
            mensagemRetornoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class cabecalho
{

    private string versaoDadosField;

    private string versaoField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "token")]
    public string versaoDados
    {
        get
        {
            return versaoDadosField;
        }
        set
        {
            versaoDadosField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "token")]
    public string versao
    {
        get
        {
            return versaoField;
        }
        set
        {
            versaoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute("CompNfse", Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class tcCompNfse
{

    private tcNfse nfseField;

    private tcCancelamentoNfse nfseCancelamentoField;

    private tcSubstituicaoNfse nfseSubstituicaoField;

    /// <remarks/>
    public tcNfse Nfse
    {
        get
        {
            return nfseField;
        }
        set
        {
            nfseField = value;
        }
    }

    /// <remarks/>
    public tcCancelamentoNfse NfseCancelamento
    {
        get
        {
            return nfseCancelamentoField;
        }
        set
        {
            nfseCancelamentoField = value;
        }
    }

    /// <remarks/>
    public tcSubstituicaoNfse NfseSubstituicao
    {
        get
        {
            return nfseSubstituicaoField;
        }
        set
        {
            nfseSubstituicaoField = value;
        }
    }
}

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute("Links", Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class tcLinks
{

    private tcIdentificacaoNfse identificacaoNfseField;

    private tcIdentificacaoRps identificacaoRpsField;

    private string urlVisualizacaoNfse;

    private string urlVerificaAutenticidade;

    /// <remarks/>
    public tcIdentificacaoNfse IdentificacaoNfse
    {
        get
        {
            return identificacaoNfseField;
        }
        set
        {
            identificacaoNfseField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoRps IdentificacaoRps
    {
        get
        {
            return identificacaoRpsField;
        }
        set
        {
            identificacaoRpsField = value;
        }
    }

    /// <remarks/>
    public string UrlVisualizacaoNfse
    {
        get
        {
            return urlVisualizacaoNfse;
        }
        set
        {
            urlVisualizacaoNfse = value;
        }
    }

    /// <remarks/>
    public string UrlVerificaAutenticidade
    {
        get
        {
            return urlVerificaAutenticidade;
        }
        set
        {
            urlVerificaAutenticidade = value;
        }
    }
}


/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class EnviarLoteRpsEnvio
{

    private tcLoteRps loteRpsField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcLoteRps LoteRps
    {
        get
        {
            return loteRpsField;
        }
        set
        {
            loteRpsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class EnviarLoteRpsResposta
{

    private object[] itemsField;

    private ItemsChoiceType6[] itemsElementNameField;

    /// <remarks/>
    [XmlElementAttribute("DataRecebimento", typeof(DateTime))]
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("NumeroLote", typeof(string), DataType = "nonNegativeInteger")]
    [XmlElementAttribute("Protocolo", typeof(string))]
    [XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ItemsElementName")]
    [XmlIgnoreAttribute()]
    public ItemsChoiceType6[] ItemsElementName
    {
        get
        {
            return itemsElementNameField;
        }
        set
        {
            itemsElementNameField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IncludeInSchema = false)]
public enum ItemsChoiceType6
{

    /// <remarks/>
    DataRecebimento,

    /// <remarks/>
    ListaMensagemRetorno,

    /// <remarks/>
    NumeroLote,

    /// <remarks/>
    Protocolo,
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class EnviarLoteRpsSincronoEnvio
{

    private tcLoteRps loteRpsField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcLoteRps LoteRps
    {
        get
        {
            return loteRpsField;
        }
        set
        {
            loteRpsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "EnviarLoteRpsSincronoResposta")]
public partial class EnviarLoteRpsSincronoResposta : BaseResponse
{

    private string numeroLoteField;

    private DateTime dataRecebimentoField;

    private bool dataRecebimentoFieldSpecified;

    private string protocoloField;

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NumeroLote
    {
        get
        {
            return numeroLoteField;
        }
        set
        {
            numeroLoteField = value;
        }
    }

    /// <remarks/>
    public DateTime DataRecebimento
    {
        get
        {
            return dataRecebimentoField;
        }
        set
        {
            dataRecebimentoField = value;
        }
    }

    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool DataRecebimentoSpecified
    {
        get
        {
            return dataRecebimentoFieldSpecified;
        }
        set
        {
            dataRecebimentoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string Protocolo
    {
        get
        {
            return protocoloField;
        }
        set
        {
            protocoloField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaMensagemRetornoLote", typeof(ListaMensagemRetornoLote))]
    [XmlElementAttribute("ListaNfse", typeof(EnviarLoteRpsSincronoRespostaListaNfse))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class EnviarLoteRpsSincronoRespostaListaNfse
{

    private tcCompNfse[] compNfseField;

    private tcMensagemRetorno[] listaMensagemAlertaRetornoField;

    /// <remarks/>
    [XmlElementAttribute("CompNfse")]
    public tcCompNfse[] CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlArrayItemAttribute("MensagemRetorno", IsNullable = false)]
    public tcMensagemRetorno[] ListaMensagemAlertaRetorno
    {
        get
        {
            return listaMensagemAlertaRetornoField;
        }
        set
        {
            listaMensagemAlertaRetornoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class GerarNfseEnvio
{

    private tcDeclaracaoPrestacaoServico rpsField;

    /// <remarks/>
    public tcDeclaracaoPrestacaoServico Rps
    {
        get
        {
            return rpsField;
        }
        set
        {
            rpsField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "GerarNfseResposta")]
public partial class GerarNfseResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaNfse", typeof(GerarNfseRespostaListaNfse))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class GerarNfseRespostaListaNfse
{

    private tcCompNfse compNfseField;

    private tcMensagemRetorno[] listaMensagemAlertaRetornoField;

    /// <remarks/>
    public tcCompNfse CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlArrayItemAttribute("MensagemRetorno", IsNullable = false)]
    public tcMensagemRetorno[] ListaMensagemAlertaRetorno
    {
        get
        {
            return listaMensagemAlertaRetornoField;
        }
        set
        {
            listaMensagemAlertaRetornoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class CancelarNfseEnvio
{

    private tcPedidoCancelamento pedidoField;
    private SignatureType signatureField;


    /// <remarks/>
    public tcPedidoCancelamento Pedido
    {
        get
        {
            return pedidoField;
        }
        set
        {
            pedidoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "CancelarNfseResposta")]
public partial class CancelarNfseResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("RetCancelamento", typeof(tcRetCancelamento))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class SubstituirNfseEnvio
{

    private SubstituirNfseEnvioSubstituicaoNfse substituicaoNfseField;

    private SignatureType signatureField;

    /// <remarks/>
    public SubstituirNfseEnvioSubstituicaoNfse SubstituicaoNfse
    {
        get
        {
            return substituicaoNfseField;
        }
        set
        {
            substituicaoNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class SubstituirNfseEnvioSubstituicaoNfse
{

    private tcPedidoCancelamento pedidoField;

    private tcDeclaracaoPrestacaoServico rpsField;

    private string idField;

    /// <remarks/>
    public tcPedidoCancelamento Pedido
    {
        get
        {
            return pedidoField;
        }
        set
        {
            pedidoField = value;
        }
    }

    /// <remarks/>
    public tcDeclaracaoPrestacaoServico Rps
    {
        get
        {
            return rpsField;
        }
        set
        {
            rpsField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class SubstituirNfseResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("RetSubstituicao", typeof(SubstituirNfseRespostaRetSubstituicao))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class SubstituirNfseRespostaRetSubstituicao
{

    private SubstituirNfseRespostaRetSubstituicaoNfseSubstituida nfseSubstituidaField;

    private SubstituirNfseRespostaRetSubstituicaoNfseSubstituidora nfseSubstituidoraField;

    /// <remarks/>
    public SubstituirNfseRespostaRetSubstituicaoNfseSubstituida NfseSubstituida
    {
        get
        {
            return nfseSubstituidaField;
        }
        set
        {
            nfseSubstituidaField = value;
        }
    }

    /// <remarks/>
    public SubstituirNfseRespostaRetSubstituicaoNfseSubstituidora NfseSubstituidora
    {
        get
        {
            return nfseSubstituidoraField;
        }
        set
        {
            nfseSubstituidoraField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class SubstituirNfseRespostaRetSubstituicaoNfseSubstituida
{

    private tcCompNfse compNfseField;

    private tcMensagemRetorno[] listaMensagemAlertaRetornoField;

    /// <remarks/>
    public tcCompNfse CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlArrayItemAttribute("MensagemRetorno", IsNullable = false)]
    public tcMensagemRetorno[] ListaMensagemAlertaRetorno
    {
        get
        {
            return listaMensagemAlertaRetornoField;
        }
        set
        {
            listaMensagemAlertaRetornoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class SubstituirNfseRespostaRetSubstituicaoNfseSubstituidora
{

    private tcCompNfse compNfseField;

    /// <remarks/>
    public tcCompNfse CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarLoteRpsEnvio
{

    private tcIdentificacaoPessoaEmpresa prestadorField;

    private string protocoloField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    public string Protocolo
    {
        get
        {
            return protocoloField;
        }
        set
        {
            protocoloField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarLoteRpsResposta")]
public partial class ConsultarLoteRpsResposta : BaseResponse
{

    private sbyte situacaoField;

    private object itemField;

    /// <remarks/>
    public sbyte Situacao
    {
        get
        {
            return situacaoField;
        }
        set
        {
            situacaoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaMensagemRetornoLote", typeof(ListaMensagemRetornoLote))]
    [XmlElementAttribute("ListaNfse", typeof(ConsultarLoteRpsRespostaListaNfse))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarLoteRpsRespostaListaNfse
{

    private tcCompNfse[] compNfseField;

    private tcMensagemRetorno[] listaMensagemAlertaRetornoField;

    /// <remarks/>
    [XmlElementAttribute("CompNfse")]
    public tcCompNfse[] CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlArrayItemAttribute("MensagemRetorno", IsNullable = false)]
    public tcMensagemRetorno[] ListaMensagemAlertaRetorno
    {
        get
        {
            return listaMensagemAlertaRetornoField;
        }
        set
        {
            listaMensagemAlertaRetornoField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarNfseRpsEnvio
{

    private tcIdentificacaoRps identificacaoRpsField;

    private tcIdentificacaoPessoaEmpresa prestadorField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcIdentificacaoRps IdentificacaoRps
    {
        get
        {
            return identificacaoRpsField;
        }
        set
        {
            identificacaoRpsField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarNfseRpsResposta")]
public partial class ConsultarNfseRpsResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("CompNfse", typeof(tcCompNfse))]
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class tcPedidoConsultarNfseServicoPrestado
{
    private tcIdentificacaoPessoaEmpresa prestadorField;

    private object itemField;

    private tcIdentificacaoPessoaEmpresa tomadorField;

    private tcIdentificacaoPessoaEmpresa intermediarioField;

    private string paginaField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("NumeroNfse", typeof(string), DataType = "nonNegativeInteger")]
    [XmlElementAttribute("PeriodoCompetencia", typeof(ConsultarNfseServicoPrestadoEnvioPeriodoCompetencia))]
    [XmlElementAttribute("PeriodoEmissao", typeof(ConsultarNfseServicoPrestadoEnvioPeriodoEmissao))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Tomador
    {
        get
        {
            return tomadorField;
        }
        set
        {
            tomadorField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Intermediario
    {
        get
        {
            return intermediarioField;
        }
        set
        {
            intermediarioField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarNfseServicoPrestadoEnvio
{

    private tcPedidoConsultarNfseServicoPrestado tcPedidoConsultarNfseServicoPrestadoField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcPedidoConsultarNfseServicoPrestado Pedido
    {
        get
        {
            return tcPedidoConsultarNfseServicoPrestadoField;
        }
        set
        {
            tcPedidoConsultarNfseServicoPrestadoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseServicoPrestadoEnvioPeriodoCompetencia
{

    private DateTime dataInicialField;

    private DateTime dataFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseServicoPrestadoEnvioPeriodoEmissao
{

    private DateTime dataInicialField;

    private DateTime dataFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarNfseServicoPrestadoResposta")]
public partial class ConsultarNfseServicoPrestadoResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaNfse", typeof(ConsultarNfseServicoPrestadoRespostaListaNfse))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseServicoPrestadoRespostaListaNfse
{

    private tcCompNfse[] compNfseField;

    private string paginaField;

    /// <remarks/>
    [XmlElementAttribute("CompNfse")]
    public tcCompNfse[] CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class tcPedidoConsultarNfseServicoTomado
{
    private tcIdentificacaoPessoaEmpresa consulenteField;

    private object itemField;

    private tcIdentificacaoPessoaEmpresa prestadorField;

    private tcIdentificacaoPessoaEmpresa tomadorField;

    private tcIdentificacaoPessoaEmpresa intermediarioField;

    private string paginaField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Consulente
    {
        get
        {
            return consulenteField;
        }
        set
        {
            consulenteField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("NumeroNfse", typeof(string), DataType = "nonNegativeInteger")]
    [XmlElementAttribute("PeriodoCompetencia", typeof(ConsultarNfseServicoTomadoEnvioPeriodoCompetencia))]
    [XmlElementAttribute("PeriodoEmissao", typeof(ConsultarNfseServicoTomadoEnvioPeriodoEmissao))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Tomador
    {
        get
        {
            return tomadorField;
        }
        set
        {
            tomadorField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Intermediario
    {
        get
        {
            return intermediarioField;
        }
        set
        {
            intermediarioField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarNfseServicoTomadoEnvio
{

    private tcPedidoConsultarNfseServicoTomado tcPedidoConsultarNfseServicoTomadoField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcPedidoConsultarNfseServicoTomado Pedido
    {
        get
        {
            return tcPedidoConsultarNfseServicoTomadoField;
        }
        set
        {
            tcPedidoConsultarNfseServicoTomadoField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseServicoTomadoEnvioPeriodoCompetencia
{

    private DateTime dataInicialField;

    private DateTime dataFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseServicoTomadoEnvioPeriodoEmissao
{

    private DateTime dataInicialField;

    private DateTime dataFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarNfseServicoTomadoResposta")]
public partial class ConsultarNfseServicoTomadoResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaNfse", typeof(ConsultarNfseServicoTomadoRespostaListaNfse))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseServicoTomadoRespostaListaNfse
{

    private tcCompNfse[] compNfseField;

    private string paginaField;

    /// <remarks/>
    [XmlElementAttribute("CompNfse")]
    public tcCompNfse[] CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class tcPedidoConsultarNfseFaixa
{
    private tcIdentificacaoPessoaEmpresa prestadorField;

    private ConsultarNfseFaixaEnvioFaixa faixaField;

    private string paginaField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    public ConsultarNfseFaixaEnvioFaixa Faixa
    {
        get
        {
            return faixaField;
        }
        set
        {
            faixaField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarNfseFaixaEnvio
{

    private tcPedidoConsultarNfseFaixa tcPedidoConsultarNfseFaixaField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcPedidoConsultarNfseFaixa Pedido
    {
        get
        {
            return tcPedidoConsultarNfseFaixaField;
        }
        set
        {
            tcPedidoConsultarNfseFaixaField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseFaixaEnvioFaixa
{

    private string numeroNfseInicialField;

    private string numeroNfseFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NumeroNfseInicial
    {
        get
        {
            return numeroNfseInicialField;
        }
        set
        {
            numeroNfseInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string NumeroNfseFinal
    {
        get
        {
            return numeroNfseFinalField;
        }
        set
        {
            numeroNfseFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarNfseFaixaResposta")]
public partial class ConsultarNfseFaixaResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaNfse", typeof(ConsultarNfseFaixaRespostaListaNfse))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarNfseFaixaRespostaListaNfse
{

    private tcCompNfse[] compNfseField;

    private string paginaField;

    /// <remarks/>
    [XmlElementAttribute("CompNfse")]
    public tcCompNfse[] CompNfse
    {
        get
        {
            return compNfseField;
        }
        set
        {
            compNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class TransformsType
{

    private TransformType[] transformField;

    /// <remarks/>
    [XmlElementAttribute("Transform")]
    public TransformType[] Transform
    {
        get
        {
            return transformField;
        }
        set
        {
            transformField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("Manifest", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class ManifestType
{

    private ReferenceType[] referenceField;

    private string idField;

    /// <remarks/>
    [XmlElementAttribute("Reference")]
    public ReferenceType[] Reference
    {
        get
        {
            return referenceField;
        }
        set
        {
            referenceField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("SignatureProperties", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SignaturePropertiesType
{

    private SignaturePropertyType[] signaturePropertyField;

    private string idField;

    /// <remarks/>
    [XmlElementAttribute("SignatureProperty")]
    public SignaturePropertyType[] SignatureProperty
    {
        get
        {
            return signaturePropertyField;
        }
        set
        {
            signaturePropertyField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRootAttribute("SignatureProperty", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class SignaturePropertyType
{

    private System.Xml.XmlElement[] itemsField;

    private string[] textField;

    private string targetField;

    private string idField;

    /// <remarks/>
    [XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Items
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }

    /// <remarks/>
    [XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return textField;
        }
        set
        {
            textField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "anyURI")]
    public string Target
    {
        get
        {
            return targetField;
        }
        set
        {
            targetField = value;
        }
    }

    /// <remarks/>
    [XmlAttributeAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}


[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class tcPedidoConsultarUrlNfse
{
    private tcIdentificacaoPessoaEmpresa prestadorField;

    private tcIdentificacaoRps identificacaoRpsField;


    private object itemField;

    private tcIdentificacaoPessoaEmpresa tomadorField;

    private tcIdentificacaoPessoaEmpresa intermediarioField;

    private string paginaField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return prestadorField;
        }
        set
        {
            prestadorField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoRps IdentificacaoRps
    {
        get
        {
            return identificacaoRpsField;
        }
        set
        {
            identificacaoRpsField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute("NumeroNfse", typeof(string), DataType = "nonNegativeInteger")]
    [XmlElementAttribute("PeriodoCompetencia", typeof(ConsultarUrlNfseEnvioPeriodoCompetencia))]
    [XmlElementAttribute("PeriodoEmissao", typeof(ConsultarUrlNfseEnvioPeriodoEmissao))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Tomador
    {
        get
        {
            return tomadorField;
        }
        set
        {
            tomadorField = value;
        }
    }

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Intermediario
    {
        get
        {
            return intermediarioField;
        }
        set
        {
            intermediarioField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarUrlNfseEnvio
{

    private tcPedidoConsultarUrlNfse tcPedidoConsultarUrlNfseField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcPedidoConsultarUrlNfse Pedido
    {
        get
        {
            return tcPedidoConsultarUrlNfseField;
        }
        set
        {
            tcPedidoConsultarUrlNfseField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarUrlNfseEnvioPeriodoCompetencia
{

    private DateTime dataInicialField;

    private DateTime dataFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarUrlNfseEnvioPeriodoEmissao
{

    private DateTime dataInicialField;

    private DateTime dataFinalField;

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "date")]
    public DateTime DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarUrlNfseResposta")]
public partial class ConsultarUrlNfseResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("ListaLinks", typeof(ConsultarUrlNfseRespostaListaLinks))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarUrlNfseRespostaListaLinks
{

    private tcLinks[] linksField;

    private string paginaField;

    /// <remarks/>
    [XmlElementAttribute("Links")]
    public tcLinks[] Links
    {
        get
        {
            return linksField;
        }
        set
        {
            linksField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarDadosCadastraisEnvio
{

    private tcIdentificacaoPessoaEmpresa tcConsultarDadosCadastraisField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Pedido
    {
        get
        {
            return tcConsultarDadosCadastraisField;
        }
        set
        {
            tcConsultarDadosCadastraisField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarDadosCadastraisResposta")]
public partial class ConsultarDadosCadastraisResposta : BaseResponse
{

    private object itemField;

    /// <remarks/>    
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]
    [XmlElementAttribute("Cadastro", typeof(ConsultarDadosCadastraisRespostaCadastro))]
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcOpcaoSimplesNacional
{

    private string optanteSimplesNacionalField;

    private tcVigencias vigenciasField;

    /// <remarks/>    
    public string OptanteSimplesNacional
    {
        get
        {
            return optanteSimplesNacionalField;
        }
        set
        {
            optanteSimplesNacionalField = value;
        }
    }

    public tcVigencias Vigencias
    {
        get
        {
            return vigenciasField;
        }
        set
        {
            vigenciasField = value;
        }
    }

}
/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcVigencias
{

    private tcVigencia[] itemsField;

    /// <remarks/>   
    [XmlElementAttribute("Vigencia")]
    public tcVigencia[] Vigencia
    {
        get
        {
            return itemsField;
        }
        set
        {
            itemsField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcVigencia
{
    private string dataInicialField;
    private string dataFinalField;

    /// <remarks/>
    public string DataInicial
    {
        get
        {
            return dataInicialField;
        }
        set
        {
            dataInicialField = value;
        }
    }
    public string DataFinal
    {
        get
        {
            return dataFinalField;
        }
        set
        {
            dataFinalField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcOpcaoMei
{
    private string optanteMeiField;

    /// <remarks/>    
    public string OptanteMei
    {
        get
        {
            return optanteMeiField;
        }
        set
        {
            optanteMeiField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcAtividades
{

    private tcAtividade[] atividadeField;

    /// <remarks/>    
    [XmlElementAttribute("Atividade")]
    public tcAtividade[] Atividade
    {
        get
        {
            return atividadeField;
        }
        set
        {
            atividadeField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcAtividade
{
    private string codigoTributacaoMunicipioField;
    private string descricaoCodigoTributacaoMunicípioField;
    private tcVigencias vigenciasField;
    private decimal aliquotaField;

    /// <remarks/>    
    public string CodigoTributacaoMunicipio
    {
        get
        {
            return codigoTributacaoMunicipioField;
        }
        set
        {
            codigoTributacaoMunicipioField = value;
        }
    }
    public string DescricaoCodigoTributacaoMunicípio
    {
        get
        {
            return descricaoCodigoTributacaoMunicípioField;
        }
        set
        {
            descricaoCodigoTributacaoMunicípioField = value;
        }
    }
    public tcVigencias Vigencias
    {
        get
        {
            return vigenciasField;
        }
        set
        {
            vigenciasField = value;
        }
    }

    public decimal Aliquota
    {
        get
        {
            return aliquotaField;
        }
        set
        {
            aliquotaField = value;
        }
    }
}
/// <remarks/>  
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcCnaes
{
    private string[] codigoCnaesField;

    /// <remarks/>       
    [XmlElementAttribute("CodigoCnae")]
    public string[] Cnaes
    {
        get
        {
            return codigoCnaesField;
        }
        set
        {
            codigoCnaesField = value;
        }
    }
}

/// <remarks/>  
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcOperacoesPermitidas
{
    private string[] exigibilidadeISSField;

    /// <remarks/>       
    [XmlElementAttribute("ExigibilidadeISS")]
    public string[] OperacoesPermitidas
    {
        get
        {
            return exigibilidadeISSField;
        }
        set
        {
            exigibilidadeISSField = value;
        }
    }
}

/// <remarks/> 
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcPessoasAutorizadas
{
    private tcPessoaAutorizada[] pessoaAutorizadaField;

    /// <remarks/>       
    [XmlElementAttribute("PessoaAutorizada")]
    public tcPessoaAutorizada[] PessoasAutorizadas
    {
        get
        {
            return pessoaAutorizadaField;
        }
        set
        {
            pessoaAutorizadaField = value;
        }
    }
}

/// <remarks/>  
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class tcPessoaAutorizada
{
    private tcCpfCnpj cpfCnpjField;
    private string razaoSocialField;

    /// <remarks/>    
    public tcCpfCnpj CpfCnpj
    {
        get
        {
            return cpfCnpjField;
        }
        set
        {
            cpfCnpjField = value;
        }
    }
    public string RazaoSocial
    {
        get
        {
            return razaoSocialField;
        }
        set
        {
            razaoSocialField = value;
        }
    }
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarDadosCadastraisRespostaCadastro
{
    private tcCpfCnpj cpfCnpjField;
    private string inscricaoMunicipalField;
    private string statusCadastroField;
    private string razaoSocialField;
    private string nomeFantasiaField;
    private tcEndereco enderecoField;
    private tcContato contatoField;
    private tcOpcaoSimplesNacional opcaoSimplesNacionalField;
    private tcOpcaoMei opcaoMeiField;
    private tcAtividades atividadesField;
    private tcCnaes cnaesField;
    private tcOperacoesPermitidas operacoesPermitidasField;
    private tcPessoasAutorizadas pessoasAutorizadasField;
    private string emiteNfseField;
    private string permiteInformarOutrasDeducoesField;
    private string permiteInformarDescontoCondicionadoField;
    private string permiteInformarDescontoIncondicionadoField;
    private string permiteTributarForaField;
   
    public tcCpfCnpj CpfCnpj
    {
        get
        {
            return cpfCnpjField;
        }
        set
        {
            cpfCnpjField = value;

        }
    }
    public string InscricaoMunicipal
    {
        get
        {
            return inscricaoMunicipalField;
        }
        set
        {
            inscricaoMunicipalField = value;

        }
    }
    public string StatusCadastro
    {
        get
        {
            return statusCadastroField;
        }
        set
        {
            statusCadastroField = value;

        }
    }
    public string RazaoSocial
    {
        get
        {
            return razaoSocialField;
        }
        set
        {
            razaoSocialField = value;

        }
    }
    public string NomeFantasia
    {
        get
        {
            return nomeFantasiaField;
        }
        set
        {
            nomeFantasiaField = value;

        }
    }
    public tcEndereco Endereco
    {
        get
        {
            return enderecoField;
        }
        set
        {
            enderecoField = value;

        }
    }
    public tcContato Contato
    {
        get
        {
            return contatoField;
        }
        set
        {
            contatoField = value;

        }
    }
    public tcOpcaoSimplesNacional OpcaoSimplesNacional
    {
        get
        {
            return opcaoSimplesNacionalField;
        }
        set
        {
            opcaoSimplesNacionalField = value;

        }
    }
    public tcOpcaoMei OpcaoMei
    {
        get
        {
            return opcaoMeiField;
        }
        set
        {
            opcaoMeiField = value;

        }
    }
    public tcAtividades Atividades
    {
        get
        {
            return atividadesField;
        }
        set
        {
            atividadesField = value;

        }
    }
    public tcCnaes Cnaes
    {
        get
        {
            return cnaesField;
        }
        set
        {
            cnaesField = value;

        }
    }
    public tcOperacoesPermitidas OperacoesPermitidas
    {
        get
        {
            return operacoesPermitidasField;
        }
        set
        {
            operacoesPermitidasField = value;

        }
    }
    public tcPessoasAutorizadas PessoasAutorizadas
    {
        get
        {
            return pessoasAutorizadasField;
        }
        set
        {
            pessoasAutorizadasField = value;

        }
    }
    public string EmiteNfse
    {
        get
        {
            return emiteNfseField;
        }
        set
        {
            emiteNfseField = value;

        }
    }
    public string PermiteInformarOutrasDeducoes
    {
        get
        {
            return permiteInformarOutrasDeducoesField;
        }
        set
        {
            permiteInformarOutrasDeducoesField = value;

        }
    }
    public string PermiteInformarDescontoCondicionado
    {
        get
        {
            return permiteInformarDescontoCondicionadoField;
        }
        set
        {
            permiteInformarDescontoCondicionadoField = value;

        }
    }
    public string PermiteInformarDescontoIncondicionado
    {
        get
        {
            return permiteInformarDescontoIncondicionadoField;
        }
        set
        {
            permiteInformarDescontoIncondicionadoField = value;

        }
    }
    public string PermiteTributarFora
    {
        get
        {
            return permiteTributarForaField;
        }
        set
        {
            permiteTributarForaField = value;

        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
public partial class ConsultarRpsDisponivelEnvio
{

    private tcIdentificacaoPessoaEmpresa tcConsultarRpsDisponivelField;

    private SignatureType signatureField;

    /// <remarks/>
    public tcIdentificacaoPessoaEmpresa Pedido
    {
        get
        {
            return tcConsultarRpsDisponivelField;
        }
        set
        {
            tcConsultarRpsDisponivelField = value;
        }
    }

    /// <remarks/>
    [XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }
        set
        {
            signatureField = value;
        }
    }
}

/// <remarks/>

[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
[XmlRootAttribute(Namespace = "http://www.abrasf.org.br/nfse.xsd", IsNullable = false)]
[MessageContract(WrapperName = "ConsultarRpsDisponivelResposta")]
public partial class ConsultarRpsDisponivelResposta : BaseResponse
{
    private object itemField;  

    /// <remarks/>    
    [XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno))]    
    [XmlElementAttribute("ListaRpsDisponivel", typeof(ConsultarRpsDisponivelRespostaLista))]    
    public object Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }  
}

/// <remarks/>
[SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.abrasf.org.br/nfse.xsd")]
public partial class ConsultarRpsDisponivelRespostaLista
{
    private tcIdentificacaoPessoaEmpresa identificacaoPessoaEmpresaField;

    private tcIdentificacaoRps[] identificacaoRpsField;

    private string paginaField;


    public tcIdentificacaoPessoaEmpresa Prestador
    {
        get
        {
            return identificacaoPessoaEmpresaField;
        }
        set
        {
            identificacaoPessoaEmpresaField = value;

        }
    }
    [XmlElementAttribute("RpsDisponivel")]
    public tcIdentificacaoRps[] RpsDisponivel
    {
        get
        {
            return identificacaoRpsField;
        }
        set
        {
            identificacaoRpsField = value;

        }
    }
    [XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string Pagina
    {
        get
        {
            return paginaField;
        }
        set
        {
            paginaField = value;
        }
    }
}
