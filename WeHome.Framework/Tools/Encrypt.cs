using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WeHome.Framework.Tools
{
    public class EncryptTool
    {
        private static readonly byte[] Keys = {0x12, 0x34, 0x57, 0x74, 0x90, 0xAB, 0xCD, 0xE7};

        private const string Key = "1qazxsw2";

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="convertString"></param>
        /// <returns></returns>
        public static string GetMd5Str(string convertString)
        {
            Check.NotEmpty(convertString, "ConvertString");
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(convertString)), 4, 8);
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            Check.NotEmpty(encryptString, "encryptString");
            var rgbKey = Encoding.UTF8.GetBytes(Key);
            var rgbIv = Keys;
            var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            var dCsp = new DESCryptoServiceProvider();
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, dCsp.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="decryptString"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            Check.NotEmpty(decryptString, "decryptString");
            var rgbKey = Encoding.UTF8.GetBytes(Key);
            var rgbIv = Keys;
            var inputByteArray = Convert.FromBase64String(decryptString);
            var dcsp = new DESCryptoServiceProvider();
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
    }
}
