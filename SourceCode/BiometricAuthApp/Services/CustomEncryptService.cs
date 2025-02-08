using BiometricAuthApp.Data;
using BiometricAuthApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Services
{
    public class CustomEncryptService
    {
        private static CustomEncryptService _instance;
        private byte[] key;
        private byte[] vi;

        public static CustomEncryptService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
                _instance.Init();
            }
            return _instance;
        }

        private CustomEncryptService() { }
        private void Init()
        {
            using (var context = new AppDbContext())
            {
                var l = context.EncodeKeys.ToList();
                if (l.Count == 0)
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.GenerateKey();
                        aes.GenerateIV();

                        var encodeKey = new EncodeKey() { Key = aes.Key, Vi = aes.IV };
                        context.EncodeKeys.Add(encodeKey);
                        context.SaveChanges();
                        key = aes.Key;
                        vi = aes.IV;
                    }
                }
                else
                {
                    key = l[0].Key;
                    vi = l[0].Vi;
                }
            }
        }

        public string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {

                aes.Key = key;
                aes.IV = vi; // Инициализационный вектор (IV)
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var writer = new StreamWriter(cs))
                            {
                                writer.Write(plainText);
                            }
                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = vi;
                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var reader = new StreamReader(cs))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        public byte[] Encrypt(byte[] data)
        {
            if (data == null || data.Length == 0) return data;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = vi; // Инициализационный вектор (IV)

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Дешифрование byte[]
        public byte[] Decrypt(byte[] cipherData)
        {
            if (cipherData == null || cipherData.Length == 0) return cipherData;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = vi;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(cipherData))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var output = new MemoryStream())
                {
                    cs.CopyTo(output);
                    return output.ToArray();
                }
            }
        }

        public static byte[] DesEncrypt(byte[] data)
        {
            if (data == null || data.Length == 0) return data;

            using (var des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(Config.DEC_KEY);
                des.IV = Encoding.UTF8.GetBytes(Config.DEC_VI); // Инициализационный вектор (IV)

                using (var encryptor = des.CreateEncryptor(des.Key, des.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Дешифрование byte[]
        public static byte[] DesDecrypt(byte[] cipherData)
        {
            if (cipherData == null || cipherData.Length == 0) return cipherData;

            using (var des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(Config.DEC_KEY);
                des.IV = Encoding.UTF8.GetBytes(Config.DEC_VI);

                using (var decryptor = des.CreateDecryptor(des.Key, des.IV))
                using (var ms = new MemoryStream(cipherData))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var output = new MemoryStream())
                {
                    cs.CopyTo(output);
                    return output.ToArray();
                }
            }
        }

    }
}
