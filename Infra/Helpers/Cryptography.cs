using System;
using System.Security.Cryptography;
using System.Text;

namespace Infra.Helpers
{
    public class Cryptography
    {
        public static string GetMD5(string input)
        {
            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
    }
}
