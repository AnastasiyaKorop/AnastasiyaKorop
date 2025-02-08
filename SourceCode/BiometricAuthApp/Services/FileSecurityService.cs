using BiometricAuthApp.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

public class FileSecurityService
{
    private ECDsa _ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
    private FilesKeyRepository keyRepo = new();

    public (string B, string X, string Y) GenerateKeys()
    {
        var parameters = _ecdsa.ExportParameters(true);

        var B = parameters.D != null ? Convert.ToBase64String(parameters.D) : string.Empty;
        var X = parameters.Q.X != null ? Convert.ToBase64String(parameters.Q.X) : string.Empty;
        var Y = parameters.Q.Y != null ? Convert.ToBase64String(parameters.Q.Y) : string.Empty;

        return (B, X, Y);
    }

    public void LoadKey(string B, string X, string Y)
    {
        var parameters = new ECParameters
        {
            Curve = ECCurve.NamedCurves.nistP256,
            D = !string.IsNullOrEmpty(B) ? Convert.FromBase64String(B) : null,
            Q = new ECPoint
            {
                X = !string.IsNullOrEmpty(X) ? Convert.FromBase64String(X) : null,
                Y = !string.IsNullOrEmpty(Y) ? Convert.FromBase64String(Y) : null
            }
        };

        _ecdsa.ImportParameters(parameters);
    }

    public byte[] SignData(byte[] data)
    {
        return _ecdsa.SignData(data, HashAlgorithmName.SHA256);
    }

    public bool VerifyData(byte[] data, byte[] signature)
    {
        return _ecdsa.VerifyData(data, signature, HashAlgorithmName.SHA256);
    }

    public async Task EncryptFile(string input, string output)
    {
        using (var aes = Aes.Create())
        {
            aes.GenerateKey(); // Генерирует случайный ключ
            aes.GenerateIV();  // Генерирует случайный IV
            var filesKey = await keyRepo.Add(aes.Key, aes.IV);
            if (filesKey == null)
            {
                throw new ArgumentException("Не удалось сгенерировать ключи");
            }
            using (var outputFile = new FileStream(output, FileMode.Create))
            {
                // Записываем ключ ID как метаданные
                var keyIdBytes = BitConverter.GetBytes(filesKey.Id);
                outputFile.Write(BitConverter.GetBytes(keyIdBytes.Length), 0, 4); // Длина ключа
                outputFile.Write(keyIdBytes, 0, keyIdBytes.Length);              // Сам ключ ID


                using (var cryptoStream = new CryptoStream(outputFile, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (var inputFile = new FileStream(input, FileMode.Open, FileAccess.Read))
                {
                    inputFile.CopyTo(cryptoStream);
                }
            }


        }
    }
    public async Task DencryptFile(string input, string output)
    {
        using (var inputFile = new FileStream(input, FileMode.Open, FileAccess.Read))
        {
            // Читаем ID ключа
            var keyIdLengthBytes = new byte[4];
            inputFile.Read(keyIdLengthBytes, 0, 4);
            int keyIdLength = BitConverter.ToInt32(keyIdLengthBytes, 0);

            var keyIdBytes = new byte[keyIdLength];
            inputFile.Read(keyIdBytes, 0, keyIdLength);
            int keyId = BitConverter.ToInt32(keyIdBytes);

            // Получаем ключ и IV из базы
            var fileKey = await keyRepo.FindById(keyId);
            if (fileKey == null)
            {
                throw new ArgumentException("Не найден подходящий ключ");
            }

            using (var aes = Aes.Create())
            {
                aes.Key = fileKey.Key;
                aes.IV = fileKey.Vi;

                using (var cryptoStream = new CryptoStream(inputFile, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var outputFile = new FileStream(output, FileMode.Create))
                {
                    cryptoStream.CopyTo(outputFile);
                }
            }
        }
    }
}