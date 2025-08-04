using System.Text;

namespace HumanCapitalManagement
{
    public class EncryptionHelper
    {

        public static string Encrypt(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        public static string Decrypt(string encrypted)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encrypted));
        }
    }
}