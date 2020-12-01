using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace VMVK
{
    public static class Encryptor
    {
        public static string CPUID
        {
            get
            {
                var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
                ManagementObjectCollection mbsList = mbs.Get();
                foreach (ManagementObject mo in mbsList)
                {
                    if (mo != null && mo["ProcessorId"] != null)
                        return mo["ProcessorId"].ToString();
                }
                return string.Empty;
            }
        }

        public static string Encrypt(string t)
        {
            byte[] bytes = Encoding.UTF8.GetBytes("limmquusmmd1luhd");
            byte[] bytes2 = Encoding.UTF8.GetBytes(t);
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(CPUID, null);
            byte[] bytes3 = passwordDeriveBytes.GetBytes(32);
            ICryptoTransform transform = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            }.CreateEncryptor(bytes3, bytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(bytes2, 0, bytes2.Length);
            cryptoStream.FlushFinalBlock();
            byte[] inArray = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(inArray);
        }
        public static string Decrypt(string t)
        {
            byte[] bytes = Encoding.ASCII.GetBytes("limmquusmmd1luhd");
            byte[] array = Convert.FromBase64String(t);
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(CPUID, null);
            byte[] bytes2 = passwordDeriveBytes.GetBytes(32);
            ICryptoTransform transform = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            }.CreateDecryptor(bytes2, bytes);
            MemoryStream memoryStream = new MemoryStream(array);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
            byte[] array2 = new byte[array.Length];
            int count = cryptoStream.Read(array2, 0, array2.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(array2, 0, count);
        }
        public static string ComputeHmac(byte[] input, byte[] key)
        {
            using (HMACSHA1 hmacsha = new HMACSHA1(key))
                return Convert.ToBase64String(hmacsha.ComputeHash(input));
        }
    }
}
