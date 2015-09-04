using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL
{
    public class Util
    {
        public static string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }

            string password = s.ToString();
            return password;
        }

        public static string criptUrl(string valor)
        {
            string chave = "#Cho053D4t@R0r!s#";

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.IV = new byte[8];
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(chave, new byte[-1 + 1]);
            des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
            System.IO.MemoryStream ms = new System.IO.MemoryStream((valor.Length * 2) - 1);
            CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(valor);
            encStream.Write(plainBytes, 0, plainBytes.Length);
            encStream.FlushFinalBlock();
            byte[] encryptedBytes = new byte[Convert.ToInt32(ms.Length - 1) + 1];
            ms.Position = 0;
            ms.Read(encryptedBytes, 0, Convert.ToInt32(ms.Length));
            encStream.Close();
            string c = null;
            c = Convert.ToBase64String(encryptedBytes).Replace("+", "MAIS");
            return c;

        }

        public static string decriptUrl(string Valor)
        {
            string Chave = "#Cho053D4t@R0r!s#";

            Valor = Valor.Replace("MAIS", "+");
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.IV = new byte[8];
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Chave, new byte[-1 + 1]);
            des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
            byte[] encryptedBytes = Convert.FromBase64String(Valor);
            System.IO.MemoryStream MS = new System.IO.MemoryStream(Valor.Length);
            CryptoStream decStreAM = new CryptoStream(MS, des.CreateDecryptor(), CryptoStreamMode.Write);
            decStreAM.Write(encryptedBytes, 0, encryptedBytes.Length);
            decStreAM.FlushFinalBlock();
            byte[] plainBytes = new byte[Convert.ToInt32(MS.Length - 1) + 1];
            MS.Position = 0;
            MS.Read(plainBytes, 0, Convert.ToInt32(MS.Length));
            decStreAM.Close();
            return System.Text.Encoding.UTF8.GetString(plainBytes);
        }
    }
}
