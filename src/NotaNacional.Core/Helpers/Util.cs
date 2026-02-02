using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace NotaNacional.Core.Helpers
{

    public class Util
    {
        public static bool IsCnpj(string cnpj)
        {
            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        
        public static string ExtractPersonalDocumentFromCertificate(X509Certificate2? certificate)
        {
            if (certificate == null)
                return string.Empty;
            
            // Tenta extrair CNPJ da extensão Subject Alternative Name (OID 2.5.29.17)
            const string oid = "2.5.29.17";
            if (certificate.Extensions[oid] != null)
            {
                var extension = certificate.Extensions[oid];
                var data = Encoding.UTF8.GetString(extension.RawData);
                var matches = Regex.Matches(data, @"(?<!\d)\d{14}(?!\d)");
                var cnpj = matches.FirstOrDefault(x => Util.IsCnpj(x.Value));

                if (cnpj != null && !string.IsNullOrEmpty(cnpj.Value))
                {
                    return cnpj.Value;
                }
            }

            // Se não encontrou CNPJ na extensão, tenta extrair do Common Name (CN) do Subject
            var cnParts = certificate.Subject.Split(',')
                .Select(x => x.Trim().Split('='))
                .Where(x => x.Length == 2 && x[0].Equals("CN", StringComparison.OrdinalIgnoreCase))
                .Select(x => x[1])
                .FirstOrDefault();

            return !string.IsNullOrEmpty(cnParts) ?
                // Extrai apenas os dígitos do CN
                new string(cnParts.Where(char.IsDigit).ToArray()) : string.Empty;
        }

        public static string XmlVazio(OperacaoNfse operacao)
        {
            return operacao switch
            {
                OperacaoNfse.ConsultarDadosCadastrais =>
                    "<ConsultarDadosCadastraisEnvio></ConsultarDadosCadastraisEnvio>",
                OperacaoNfse.CancelarNfse => "<CancelarNfse></CancelarNfse>",
                OperacaoNfse.ConsultarDpsDisponivel => "<ConsultarDpsDisponivel></ConsultarDpsDisponivel>",
                OperacaoNfse.ConsultarLoteDps => "<ConsultarLoteDps></ConsultarLoteDps>",
                OperacaoNfse.ConsultarNfseDps => "<ConsultarNfseDps></ConsultarNfseDps>",
                OperacaoNfse.ConsultarNfsePorFaixa => "<ConsultarNfsePorFaixa></ConsultarNfsePorFaixa>",
                OperacaoNfse.ConsultarNfsePorRps => "<ConsultarNfsePorRps></ConsultarNfsePorRps>",
                OperacaoNfse.ConsultarNfseServicoPrestado => "<ConsultarNfseServicoPrestado></ConsultarNfseServicoPrestado>",
                OperacaoNfse.ConsultarNfseServicoTomado => "<ConsultarNfseServicoTomado></ConsultarNfseServicoTomado>",
                OperacaoNfse.ConsultarRpsDisponivel => "<ConsultarRpsDisponivel></ConsultarRpsDisponivel>",
                OperacaoNfse.ConsultarUrlNfse => "<ConsultarUrlNfse></ConsultarUrlNfse>",
                OperacaoNfse.GerarNfse => "<GerarNfse></GerarNfse>",
                OperacaoNfse.RecepcionarLoteDps => "<RecepcionarLoteDps></RecepcionarLoteDps>",
                OperacaoNfse.RecepcionarLoteDpsSincrono => "<RecepcionarLoteDpsSincrono></RecepcionarLoteDpsSincrono>",
                OperacaoNfse.RecepcionarLoteRpsSincrono => "<RecepcionarLoteRpsSincrono></RecepcionarLoteRpsSincrono>",
                _ => ""
            };
        }
    }
}