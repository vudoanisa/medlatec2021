using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CMS_Core.Common
{
    public class AES
    {

        static string keyPrivate = "MedCOm20190401";

        public static string EncryptString(string text, string password)
        {
            password = "M#dl4t4c081188";
            byte[] baPwd = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            byte[] baPwdHash = SHA256Managed.Create().ComputeHash(baPwd);

            byte[] baText = Encoding.UTF8.GetBytes(text);



            byte[] baSalt = GetRandomBytes();
            byte[] baEncrypted = new byte[baSalt.Length + baText.Length];

            // Combine Salt + Text
            for (int i = 0; i < baSalt.Length; i++)
                baEncrypted[i] = baSalt[i];
            for (int i = 0; i < baText.Length; i++)
                baEncrypted[i + baSalt.Length] = baText[i];

            baEncrypted = AES_Encrypt(baEncrypted, baPwdHash);

            string result = Convert.ToBase64String(baEncrypted);
            return result;
        }

        public static string Decrypt(string text, string password)
        {
            password = "M#dl4t4c081188";
            byte[] baPwd = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            byte[] baPwdHash = SHA256Managed.Create().ComputeHash(baPwd);

            byte[] baText = Convert.FromBase64String(text);

            byte[] baDecrypted = AES_Decrypt(baText, baPwdHash);

            // Remove salt
            int saltLength = GetSaltLength();
            byte[] baResult = new byte[baDecrypted.Length - saltLength];
            for (int i = 0; i < baResult.Length; i++)
                baResult[i] = baDecrypted[i + saltLength];



            string result = Encoding.UTF8.GetString(baResult);
            return result;
        }

        public static string DecryptQrCode(string text, string password)
        {
          //  password = "M#dl4t4c081188";
            byte[] baPwd = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            byte[] baPwdHash = SHA256Managed.Create().ComputeHash(baPwd);

            byte[] baText = Convert.FromBase64String(text);

            byte[] baDecrypted = AES_Decrypt(baText, baPwdHash);

            // Remove salt
            int saltLength = GetSaltLength();
            byte[] baResult = new byte[baDecrypted.Length - saltLength];
            for (int i = 0; i < baResult.Length; i++)
                baResult[i] = baDecrypted[i + saltLength];



            string result = Encoding.UTF8.GetString(baResult);
            return result;
        }

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public static byte[] GetRandomBytes()
        {
            int saltLength = GetSaltLength();
            byte[] ba = new byte[saltLength];
            RNGCryptoServiceProvider.Create().GetBytes(ba);
            return ba;
        }

        public static int GetSaltLength()
        {
            return 8;
        }


        public static String CreateKey(int numBytes)
        {
            try
            {
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buff = new byte[numBytes];

                rng.GetBytes(buff);
                return keyPrivate + BytesToHexString(buff);
            }
            catch (Exception ex)
            {
              //  logError.Info("CreateKey: " + ex.ToString());
                return keyPrivate;
            }
        }


        static String BytesToHexString(byte[] bytes)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int counter = 0; counter < bytes.Length; counter++)
            {
                hexString.Append(String.Format("{0:X2}", bytes[counter]));
            }
            return hexString.ToString();
        }



        //static readonly byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };
        //static string keyPrivate = "MedCOm20190401";

        //public static string EncryptString(string plainText, string password)
        //{
        //    try
        //    {
        //        password = "M#dl4t4c081188";
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, u8_Salt);
        //        using (RijndaelManaged i_Alg = new RijndaelManaged { Key = pdb.GetBytes(32), IV = pdb.GetBytes(16) })
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            using (var cryptoStream = new CryptoStream(memoryStream, i_Alg.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                byte[] data = Encoding.UTF8.GetBytes(plainText);
        //                cryptoStream.Write(data, 0, data.Length);
        //                cryptoStream.FlushFinalBlock();

        //                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //  logError.Info("EncryptString: " + ex.ToString());
        //        return plainText;
        //    }
        //}


        //public static string Decrypt(string cipherText, string password)
        //{
        //    try
        //    {
        //        password = "M#dl4t4c081188";
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, u8_Salt);

        //        using (RijndaelManaged i_Alg = new RijndaelManaged { Padding = PaddingMode.Zeros, Key = pdb.GetBytes(32), IV = pdb.GetBytes(16) })
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                using (var cryptoStream = new CryptoStream(memoryStream, i_Alg.CreateDecryptor(), CryptoStreamMode.Write))
        //                {
        //                    byte[] data = Convert.FromBase64String(cipherText);
        //                    cryptoStream.Write(data, 0, data.Length);
        //                    cryptoStream.Flush();

        //                    return RegExReplace(Encoding.UTF8.GetString(memoryStream.ToArray())).Trim();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // logError.Info("Decrypt: " + ex.ToString());
        //        return cipherText;
        //    }
        //}

        //public static String CreateKey(int numBytes)
        //{
        //    try
        //    {
        //        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        //        byte[] buff = new byte[numBytes];

        //        rng.GetBytes(buff);
        //        return keyPrivate + BytesToHexString(buff);
        //    }
        //    catch (Exception ex)
        //    {
        //        // logError.Info("CreateKey: " + ex.ToString());
        //        return keyPrivate;
        //    }
        //}


        //static String BytesToHexString(byte[] bytes)
        //{
        //    StringBuilder hexString = new StringBuilder(64);

        //    for (int counter = 0; counter < bytes.Length; counter++)
        //    {
        //        hexString.Append(String.Format("{0:X2}", bytes[counter]));
        //    }
        //    return hexString.ToString();
        //}


        //private static String RegExReplace(string inputString)
        //{

        //    if (!string.IsNullOrEmpty(inputString))
        //    {
        //        inputString = inputString.Replace("\u0002", string.Empty);
        //        inputString = inputString.Replace("\u0003", string.Empty);
        //        inputString = inputString.Replace("\u0001", string.Empty);
        //        inputString = inputString.Replace("\u0006", string.Empty);
        //        inputString = inputString.Replace("\u0005", string.Empty);
        //        inputString = inputString.Replace("\u0004", string.Empty);
        //        inputString = inputString.Replace("\0", string.Empty);
        //        inputString = Regex.Replace(inputString, @"(\\u000)+$", string.Empty);
        //        inputString = Regex.Replace(inputString, @"[^\u0000-\u007F]", "");

        //    }
        //    return inputString;

        //}





        //static readonly byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };
        //static string keyPrivate = "MedCOm20190401";
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="plainText"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //public static string EncryptString(string plainText, string password)
        //{
        //    try
        //    {
        //        password = "M#dl4t4c081188";
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, u8_Salt);
        //        using (RijndaelManaged i_Alg = new RijndaelManaged { Key = pdb.GetBytes(32), IV = pdb.GetBytes(16) })
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            using (var cryptoStream = new CryptoStream(memoryStream, i_Alg.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                byte[] data = Encoding.UTF8.GetBytes(plainText);
        //                cryptoStream.Write(data, 0, data.Length);
        //                cryptoStream.FlushFinalBlock();

        //                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
                
        //        return plainText;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="cipherText"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //public static string Decrypt(string cipherText, string password)
        //{
        //    try
        //    {
        //        password = "M#dl4t4c081188";
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, u8_Salt);

        //        using (RijndaelManaged i_Alg = new RijndaelManaged { Padding = PaddingMode.Zeros, Key = pdb.GetBytes(32), IV = pdb.GetBytes(16) })
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                using (var cryptoStream = new CryptoStream(memoryStream, i_Alg.CreateDecryptor(), CryptoStreamMode.Write))
        //                {
        //                    byte[] data = Convert.FromBase64String(cipherText);
        //                    cryptoStream.Write(data, 0, data.Length);
        //                    cryptoStream.Flush();

        //                    return RegExReplace(Encoding.UTF8.GetString(memoryStream.ToArray()));
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
                
        //        return cipherText;
        //    }
        //}

        //public static String CreateKey(int numBytes)
        //{
        //    try
        //    {
        //        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        //        byte[] buff = new byte[numBytes];

        //        rng.GetBytes(buff);
        //        return keyPrivate + BytesToHexString(buff);
        //    }
        //    catch (Exception ex)
        //    {
                
        //        return keyPrivate;
        //    }
        //}


        //static String BytesToHexString(byte[] bytes)
        //{
        //    StringBuilder hexString = new StringBuilder(64);

        //    for (int counter = 0; counter < bytes.Length; counter++)
        //    {
        //        hexString.Append(String.Format("{0:X2}", bytes[counter]));
        //    }
        //    return hexString.ToString();
        //}


        //private static String RegExReplace(string inputString)
        //{

        //    if (!string.IsNullOrEmpty(inputString))
        //    {
        //        inputString = inputString.Replace("\u0002", string.Empty);
        //        inputString = inputString.Replace("\u0003", string.Empty);
        //        inputString = inputString.Replace("\u0001", string.Empty);
        //        inputString = inputString.Replace("\u0006", string.Empty);
        //        inputString = inputString.Replace("\u0005", string.Empty);
        //        inputString = inputString.Replace("\u0004", string.Empty);
        //        inputString = inputString.Replace("\u0010", string.Empty);
        //        inputString = inputString.Replace("\0", string.Empty);
        //        inputString = inputString.Replace("\f", string.Empty);
        //        inputString = inputString.Replace("\a", string.Empty);
        //        inputString = inputString.Replace("\b", string.Empty);

        //        inputString = inputString.Replace("\n", string.Empty);
        //        inputString = inputString.Replace("\r", string.Empty);
        //        inputString = inputString.Replace("\t", string.Empty);
        //        inputString = inputString.Replace("\v", string.Empty);

             

        //        inputString = Regex.Replace(inputString, @"(\\u000)+$", string.Empty);
        //        inputString = Regex.Replace(inputString, @"[^\u0000-\u007F]", "");
        //    }           
        //    return inputString;

        //}


    }
}
