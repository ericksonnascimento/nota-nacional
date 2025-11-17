using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Abrasf.Core.Helpers;

namespace Abrasf.Core.Base
{
    public class ValidateException : Exception
    {
        public string code;

        public ValidateException(string code) {
            this.code = code;
        }
    }

    public abstract class BaseHandler
    {
        protected static void DuplicateIdValidation(string xmlString)
        {
            XDocument xmlDoc = XDocument.Parse(xmlString);

            if (XmlDuplicateIds(xmlDoc))
            {
                throw new ValidateException("L107");
            }
        }

        private static bool XmlDuplicateIds(XDocument xmlDoc)
        {
            var elementsWithId = xmlDoc.Descendants().Where(e =>
            {
                var idAttribute = e.Attribute("id") ?? e.Attribute("ID") ?? e.Attribute("Id");
                return idAttribute != null;
            });

            var duplicateIds = elementsWithId.GroupBy(e => e.Attributes().First(a => a.Name.LocalName.Equals("id", StringComparison.OrdinalIgnoreCase)).Value)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key)
                                .ToList();

            return duplicateIds.Count > 0;
        }

        private static string ValidateSignature(X509Certificate2 certificate)
        {
            if (certificate.NotAfter < DateTime.Now)
            {
                throw new ValidateException("E189");
            }

            if (!ValidaAC(certificate.Issuer))
            {
                throw new ValidateException("E189");
                //return certificate.Issuer; // Teste de SA fora da listagem
            }

            return "";
        }

        protected static string ValidateCertificate(SignatureType signature)
        {
            try
            {
                var certificate = new X509Certificate2((signature.KeyInfo.Items[0] as X509DataType).Items[0] as byte[]);
                return ValidateSignature(certificate);
            }
            catch (ValidateException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new ValidateException("E190");
            }
        }

        protected static string ExtractPersonalDocumentFromSignature(SignatureType signature)
        {
            try
            {
                var certificate = new X509Certificate2((signature.KeyInfo.Items[0] as X509DataType).Items[0] as byte[]);

                var oid = "2.5.29.17";
                var extension = certificate.Extensions[oid];
                var data = Encoding.UTF8.GetString(extension.RawData);
                var matches = Regex.Matches(data, @"(?<!\d)\d{14}(?!\d)");
                var cnpj = matches.FirstOrDefault(x => Util.IsCnpj(x.Value));

                if (cnpj != null && !string.IsNullOrEmpty(cnpj.Value))
                {
                    return cnpj.Value;
                }

                var cn = certificate.Subject.Split(',')
                    .Select(x => x.Split('=')).Where(x => x[0] == "CN")
                    .Select(x => x[1])
                    .First() ?? string.Empty;

                return cn.Any(char.IsDigit) ? new string(cn.Where(char.IsDigit).ToArray()) : string.Empty;
            }
            catch (ValidateException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new ValidateException("E190");
            }
        }

        private static bool ValidaAC(string issuer)
        {
            // www.gov.br/iti/pt-br/assuntos/repositorio/cadeias-da-icp-brasil
            // Data última atualização: 16/02/2024 18h34
            string[] listAC =
            {
                //Raiz
                "CN=AUTORIDADE CERTIFICADORA RAIZ BRASILEIRA V4",
                "CN=AUTORIDADE CERTIFICADORA RAIZ BRASILEIRA V5",
                "CN=AUTORIDADE CERTIFICADORA RAIZ BRASILEIRA V6",
                "CN=AUTORIDADE CERTIFICADORA RAIZ BRASILEIRA V10",

                //AC Certisign - 21/03/2025 14h45
                "CN=AC CERTISIGN G7",
                "CN=AC CERTISIGN ICP-BRASIL SSL G2",
                "CN=AC CERTISIGN ICP-BRASIL SSL EV G3",
                "CN=AC CERTISIGN ICP-BRASIL SSL EV G4",
                "CN=AC CERTISIGN MULTIPLA G7",
                "CN=AC CERTISIGN MULTIPLA CODESIGNING" ,
                "CN=AC CERTISIGN MULTIPLA SSL",
                "CN=AC CERTISIGN SPB G6",
                "CN=AC EGBA MULTIPLA G2",
                "CN=AC SINCOR G4",
                "CN=AC OAB G3",
                "CN=AC INSTITUTO FENACON G3",
                "CN=AC INSTITUTO FENACON G4",
                "CN =AC CERTISIGN G8",

                //AC Defesa - 07/12/2022 08h59
                "CN=AUTORIDADE CERTIFICADORA DE DEFESA",

                //AC Digital Mais - 07/12/2022 09h00
                "CN=AC DIGITAL MAIS",
                "CN=AC DIGITAL MULTIPLA G1",

                //AC Digitalsign - 19/07/2023 15h29
                "CN=AC DIGITALSIGN ACP G2",
                "CN=AC DIGITALSIGN G2",

                //AC DOCCLOUD - 07/12/2022 09h00
                "CN=AC DOCCLOUD",

                //AC INMETRO - 06/02/2024 17h22
                "CN=INSTITUTO NACIONAL DE METROLOGIA QUALIDADE E TECNOLOGIA INMETRO",
                "CN=AC SOLUTI OM-BR",

                //AC JUS - 07/12/2022 09h02
                "CN=AUTORIDADE CERTIFICADORA DA JUSTICA V5",
                "CN=AC CERTISIGN-JUS G5",
                "CN=AC CERTISIGN-JUS G6",
                "CN=AC CERTISIGN-JUS CODESIGNING G6",
                "CN=AC CERTISIGN-JUS SSL G6",
                "CN=AC SERASA-JUS V5",
                "CN=AC SERPRO-JUS V5",
                "CN=AC SOLUTI-JUS V5",
                "CN=AC SOLUTI-JUS SSL V5",
                "CN=AC SOLUTI-JUS CODESIGNING V5",
                "CN=AC VALID-JUS V5",
                "CN=AC VALID-JUS SSL V5",
                "CN=AC VALID-JUS CODESIGNING V5",

                //AC Ministério das Relações Exteriores - 24/02/2025 14h25
                "CN=AUTORIDADE CERTIFICADORA MINISTERIO DAS RELACOES EXTERIORES",
                "CN=AUTORIDADE CERTIFICADORA MINISTÉRIO DAS RELAÇÕES EXTERIORESV1",

                //AC PR - 30/06/2023 10h30
                "CN=AUTORIDADE CERTIFICADORA DA PRESIDENCIA DA REPUBLICA V5",

                //AC PRODESP SP - 07/12/2022 09h09
                "CN=AC PRODESP SP",
                "CN=AC PRODESP V1",

                //AC Receita Federal - 31/01/2025 16h09
                "CN=AC SECRETARIA DA RECEITA FEDERAL DO BRASIL V4",
                "CN=AC A DIGIFORTE RFB",
                "CN=AC BR RFB G4",
                "CN=AC CACB RFB G2",
                "CN=AC CERTISIGN RFB G5",
                "CN=AC CNDL RFB V3",
                "CN=AC CONSULTI BRASIL RFB",
                "CN=AC CONSULTI RFB",
                "CN=AC DOCCLOUD RFB V2",
                "CN=AC DIGITALSIGN RFB G2",
                "CN=AC DIGITALSIGN RFB G3",
                "CN=AC EGBA RFB",
                "CN=AC FENACOR RFB",
                "CN=AC IMPRENSA OFICIAL SP RFB SSL",
                "CN=AC IMPRENSA OFICIAL SP RFB G5",
                "CN=AC INSTITUTO FENACON RFB G3",
                "CN=AC LINK RFB V2",
                "CN=AC NOTARIAL RFB G4",
                "CN=AC ONLINE RFB V5",
                "CN=AC PRODEMGE RFB G4",
                "CN=AC PRODEMGE RFB",
                "CN=AC PRODESP RFB V1",
                "CN=AC REDE IDEIA RFB",
                "CN=AC SAFEWEB RFB V5",
                "CN=AC SEMPRE RFB V2",
                "CN=AC SERASA RFB V5",
                "CN=AUTORIDADE CERTIFICADORA SERPRORFBV5",
                "CN=AC SIC RFB",
                "CN=AC SINCOR RFB G5",
                "CN=AC SINCOR RIO RFB G2",
                "CN=AC SOLUTI RFB V5",
                "CN=AC VALID RFB V5",

                //AC Safeweb - 07/12/2022 09h36
                "CN=AC SAFEWEB",
                "CN=AC CACB CD",
                "CN=AC CERTIPE CD",
                "CN=AC CERTMAIS CD",
                "CN=AC LINK CD",
                "CN=AC META CERTIFICADO DIGITAL CD",
                "CN=AC PLANO DIGITAL CD",
                "CN=AC PREMIUM CERTIFICADORA DIGITAL CD",
                "CN=AC REDE IDEIA CD",
                "CN=AC SAFEWEB CD",
                "CN=AC SAFEWEB TIMESTAMPING",
                "CN=AC SAFETECH CD",
                "CN=AC SEMPRE CD",

                //AC Serasa ACP - 26/04/2023 09h15
                "CN=SERASA AUTORIDADE CERTIFICADORA PRINCIPAL V5",
                "CN=AC SERASA SSL EV V2",
                "CN=AC SERASA SSL EV V3",
                "CN=AC SERASA SSL EV V4",
                "CN=SERASA CERTIFICADORA DIGITAL V5",
                "CN=SERASA CD SSL V5",
                "CN=SERASA AUTORIDADE CERTIFICADORA v5",

                //AC SERPRO - 31/01/2025 16h20
                "CN=AUTORIDADE CERTIFICADORA SERPRO V4",
                "CN=AUTORIDADE CERTIFICADORA DO SERPRO SSLV1",
                "CN=AUTORIDADE CERTIFICADORA ALTERNATIVE",
                "CN=AUTORIDADE CERTIFICADORA BRASIL CERTEC",
                "CN=AUTORIDADE CERTIFICADORA DIGITAL CERTY",
                "CN=AUTORIDADE CERTIFICADORA INFOCOMEX",
                "CN=AUTORIDADE CERTIFICADORA INVIA",
                "CN=AUTORIDADE CERTIFICADORA NACIONAL",
                "CN=AUTORIDADE CERTIFICADORA PRIMECERT",
                "CN=AUTORIDADE CERTIFICADORA PROCERTI",
                "CN=AUTORIDADE CERTIFICADORA SAFE-ID BRASIL",
                "CN=AUTORIDADE CERTIFICADORA SDI",
                "CN=AUTORIDADE CERTIFICADORA SEFAZCE",
                "CN=AUTORIDADE CERTIFICADORA DO SERPRO FINAL SSL",
                "CN=AUTORIDADE CERTIFICADORA DO SERPRO FINAL V5",
                "CN=AUTORIDADE CERTIFICADORA DO SERPRO V4",

                //AC Soluti - 19/07/2023 15h35
                "CN=AC SOLUTI V5",
                "CN=AC SOLUTI V5 G2",
                "CN=AC SOLUTI SSL EV G2",
                "CN=AC SOLUTI SSL EV G3",
                "CN=AC SOLUTI SSL EV G4",
                "CN=AC A R A CERTIFICACAO DIGITAL V5",
                "CN=AC ACD V5",
                "CN=AC CCN COMPANHIA CERTIFICADORA NACIONAL V5",
                "CN=AC CERTIFICA MINAS V5",
                "CN=AC CERTIFICA ANAPOLIS V5",
                "CN=AC CERTIFICA ANAPOLIS V5 G2",
                "CN=AC CERTFACIL V5",
                "CN=AC DIGISEC V5",
                "CN=AC FCDL SC V5",
                "CN=AC FCDL SC V5 G2",
                "CN=AC INFOCO DIGITAL V5",
                "CN=AC INTERCERT V5",
                "CN=AC MAXIMUS TECNOLOGIA E EVENTOS V5",
                "CN=AC MAXIMUS TECNOLOGIA E EVENTOS V5 G2",
                "CN=AC MULT V5",
                "CN=AC PRIME V5",
                "CN=AC QUALITYCERT V5",
                "CN=AC REDE BRASIL V5",
                "CN=AC REDE BRASIL V5 G2",
                "CN=AC SEGURA ID V5",
                "CN=AC SOLUTI MULTIPLA V5",
                "CN=AC SOLUTI MULTIPLA V5 G2",
                "CN=AC SOLUTI MULTIPLA TIMESTAMPING V5",
                "CN=AC SOLUTI SPB V5",

                //AC SyngularID - 09/01/2025 10h00
                "CN=AC SYNGULARID",
                "CN=AC SYNGULARID MULTIPLA",
                "CN=AC SOLUCAO DIGITAL MULTIPLA",
                "CN=AC VALIDAR MULTIPLA",

                //AC Valid - 07/12/2022 09h59
                "CN=AC VALID V5",
                "CN=AC VALID SSL EV",
                "CN=AC VALID CODE SIGNING",
                "CN=AC CERTBANK",
                "CN=AC CERTDATA BRASIL",
                "CN=AC ONLINE BRASIL V5",
                "CN=AC SENHA DIGITAL BRASIL",
                "CN=AC SIC BRASIL",
                "CN=AC SIG BRASIL",
                "CN=AC VALID BRASIL CODESIGNING",
                "CN=AC VALID BRASIL SSL",
                "CN=AC VALID BRASIL V5",
                "CN=AC VALID PLUS V5",
                "CN=AC VALID PLUS CODESIGNING",
                "CN=AC VALID PLUS SSL",
                "CN=AC VALID PLUS TIMESTAMPING",
                "CN=AC VALID SPB V5",

                //AC IDFEDERAL - 31/01/2025 16h18
                "CN=AUTORIDADE CERTIFICADORA IDFEDERAL",

                //AC PR - 04/12/2024 11h48
                "CN=AC PRESIDÊNCIA DA REPÚBLICA V5",
                "CN=AC PRESIDÊNCIA DA REPÚBLICA V6"
            };

            var certInfo = issuer.Split(',');

            foreach (var info in certInfo)
            {
                if (listAC.Contains(info.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}