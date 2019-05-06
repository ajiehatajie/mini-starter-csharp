using System;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography;
using System.Text;
namespace Repository.Helper
{
    public class Crypt
    {
        string myKey;
        TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();

        public Crypt()
        {
            myKey = "hatajie@gmail.com";
        }

        public string Decrypt(string myString)
        {
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            Byte[] buff = Convert.FromBase64String(myString);
            try
            {
                return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            catch (System.FormatException ex)
            {
                throw new System.FormatException("The provided string does not appear to be Base64 encoded", ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Encrypt(string myString)
        {
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
            Byte[] buff = ASCIIEncoding.ASCII.GetBytes(myString);
            return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }
    }
}
