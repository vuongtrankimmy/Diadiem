using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Encrypto
{
    public static class Encrypto
    {
        const string KEY = "12345678900000001234567890000000";

        private static readonly string AES_IV = "1234567890000000";//16 bits    

        /// <summary>  
        /// AES encryption algorithm  
        /// </summary>  
        /// <param name="input">plain string</param>  
        /// <returns>string</returns>  
        public static string EncryptByAES(string input)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(KEY[..32]);
            using AesCryptoServiceProvider aesAlg = new();
            aesAlg.Key = keyBytes;
            aesAlg.IV = Encoding.UTF8.GetBytes(AES_IV[..16]);
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msEncrypt = new ();
            using CryptoStream csEncrypt = new (msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(input);
            }
            byte[] bytes = msEncrypt.ToArray();
            return ByteArrayToHexString(bytes);
        }

        /// <summary>  
        /// AES decryption  
        /// </summary>  
        /// <param name="input"> ciphertext byte array</param>  
        /// <returns> returns the decrypted string</returns>  
        public static string DecryptByAES(string input)
        {
            byte[] inputBytes = HexStringToByteArray(input);
            byte[] keyBytes = Encoding.UTF8.GetBytes(KEY[..32]);
            using AesCryptoServiceProvider aesAlg = new();
            aesAlg.Key = keyBytes;
            aesAlg.IV = Encoding.UTF8.GetBytes(AES_IV[..16]);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msEncrypt = new(inputBytes);
            using CryptoStream csEncrypt = new(msEncrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srEncrypt = new(csEncrypt);
            return srEncrypt.ReadToEnd();
        }

        /// <summary>
        /// Convert the specified hex string to a byte array
        /// </summary>
        /// <param name="s">hexadecimal string (eg "7F 2C 4A" or "7F2C4A")</param>
        /// <returns>byte array corresponding to hexadecimal string</returns>
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// Convert a byte array into a formatted hex string
        /// </summary>
        /// <param name="data">byte array</param>
        /// <returns> formatted hexadecimal string</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new(data.Length * 3);
            foreach (byte b in data)
            {
                //hexadecimal number
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
                //16 digits separated by spaces
                //sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return sb.ToString();
        }
    }
}
