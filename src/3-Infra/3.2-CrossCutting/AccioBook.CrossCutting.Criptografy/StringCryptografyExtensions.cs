using System.Security.Cryptography;

namespace AccioBook.CrossCutting.Criptografy
{
    public static class StringCryptografyExtensions
    {
        public static string Encrypt(this string clearValue, string encriptKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = CreateKey(encriptKey);
                byte[] encrypted = AesEncryptStringToBytes(clearValue, aes.Key, aes.IV);
                return Convert.ToBase64String(encrypted) + ";" + Convert.ToBase64String(aes.IV);
            }
        }

        public static string Decrypt(this string encryptedValue, string encryptKey)
        {
            string iv = encryptedValue.Substring(encryptedValue.IndexOf(';') + 1, encryptedValue.Length - encryptedValue.IndexOf(';') - 1);
            encryptedValue = encryptedValue.Substring(0, encryptedValue.IndexOf(';'));

            return AesDecryptStringFromBytes(Convert.FromBase64String(encryptedValue), CreateKey(encryptKey), Convert.FromBase64String(iv));
        }

        private static string AesDecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            string plainText;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (StreamReader streamReader = new StreamReader(cryptoStream))
                    plainText = streamReader.ReadToEnd();
            }
            return plainText;
        }

        private static byte[] AesEncryptStringToBytes(string plaintText, byte[] key, byte[] iv)
        {
            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plaintText);
                    }
                    encrypted = memoryStream.ToArray();
                }
            }
            return encrypted;
        }

        private static byte[] CreateKey(string encriptKey, int keyBytes = 32)
        {
            byte[] salt = new byte[] { 50, 69, 71, 75, 65, 69, 72, 61 };
            int iterations = 300;
            var keyGenerator = new Rfc2898DeriveBytes(encriptKey, salt, iterations);
            return keyGenerator.GetBytes(keyBytes);
        }
    }
}