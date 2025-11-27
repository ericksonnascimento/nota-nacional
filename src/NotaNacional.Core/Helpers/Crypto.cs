using System.Security.Cryptography;
using System.Text;

namespace NotaNacional.Core.Helpers
{
    internal class Crypto
    {
        private readonly byte[] IVNF = { 240, 3, 45, 29, 0, 76, 173, 59 };
        private readonly byte[] IVQrCode = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        private const string keyNF = "#NC_QueryString_Criptografada-2007#";
        private const string keyQrCode = "CH4V3";

        public string EncryptNF(string entry)
        {
            var bytes = Encoding.UTF8.GetBytes(entry);
            TripleDESCryptoServiceProvider des = new();
            MD5CryptoServiceProvider md5 = new();

            des.IV = IVNF;
            des.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyNF));

            var cryptBytes = des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);

            return BitConverter.ToString(cryptBytes).Replace("-", "+").Replace("+0", "+") + "+";
        }

        public string EncryptAutenticidade(string entry)
        {
            var bytes = Encoding.UTF8.GetBytes(entry);
            var entryCrypted = String.Empty;

            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(keyQrCode, IVQrCode);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new())
                {
                    using (CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                        cs.Close();
                    }

                    entryCrypted = Convert.ToBase64String(ms.ToArray());
                }
            }
            return entryCrypted;
        }
    }
}
