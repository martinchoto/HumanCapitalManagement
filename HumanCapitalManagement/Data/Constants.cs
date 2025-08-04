using System.Text.RegularExpressions;

namespace HumanCapitalManagement.Data
{
    public class Constants
    {
        public const int MAX_IBAN_LENGTH = 34;
        public const int MIN_IBAN_LENGTH = 15;
        public const string IBANREGEXPATTERN = @"^[A-Z]{2}[0-9]{2}[A-Z0-9]{11,30}$";
    }
}
