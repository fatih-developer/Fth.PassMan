﻿using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


namespace Core.Utilities.Security.Hashing;

public class CryptoHelper
{
    private static readonly Encoding encoding = Encoding.UTF8;
    
    public static string Encrypt(string plainText, string key)
    {
        try
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            aes.Key = encoding.GetBytes(key);
            aes.GenerateIV();

            ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] buffer = encoding.GetBytes(plainText);

            string encryptedText = Convert.ToBase64String(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));

            String mac = "";

            mac = BitConverter.ToString(HmacSHA256(Convert.ToBase64String(aes.IV) + encryptedText, key)).Replace("-", "").ToLower();

            var keyValues = new Dictionary<string, object>
            {
                { "iv", Convert.ToBase64String(aes.IV) },
                { "value", encryptedText },
                { "mac", mac },
            };

            var resultPass = Convert.ToBase64String(encoding.GetBytes(JsonSerializer.Serialize(keyValues)));


            return resultPass;
        }
        catch (Exception e)
        {
            throw new Exception("Error encrypting: " + e.Message);
        }
    }

    public static string Decrypt(string plainText, string key)
    {
        try
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            aes.Key = encoding.GetBytes(key);

            // Base 64 decode
            byte[] base64Decoded = Convert.FromBase64String(plainText);
            string base64DecodedStr = encoding.GetString(base64Decoded);

            //TextReader textReader = new StringReader(base64DecodedStr);
            //JsonReader jsonReader = new JsonTextReader(textReader);
            //JsonSerializer serializer = new JsonSerializer();
           

            // JSON Decode base64Str
            var payload = JsonSerializer.Deserialize<Dictionary<string, string>>(base64DecodedStr);

            aes.IV = Convert.FromBase64String(payload["iv"]);

            ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] buffer = Convert.FromBase64String(payload["value"]);

            return encoding.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
        }
        catch (Exception e)
        {
            throw new Exception("Error decrypting: " + e.Message);
        }
    }

    static byte[] HmacSHA256(String data, String key)
    {
        using (HMACSHA256 hmac = new HMACSHA256(encoding.GetBytes(key)))
        {
            return hmac.ComputeHash(encoding.GetBytes(data));
        }
    }

}