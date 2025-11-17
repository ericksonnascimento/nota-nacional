namespace Abrasf.Core.ServicoProcessamento.Models
{

    public class LotePendente
    {
        public Guid NumeroProtocolo { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string InscricaoMunicipal { get; set; }
        public int Quantidade { get; set; }
    }
}