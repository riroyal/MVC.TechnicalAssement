using System.Text.RegularExpressions;

namespace Logic.TechnicalAssement.App.Validator
{
    public class EmailAddressValidator
    {
        public static string RegexEmailFormat => @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public bool IsValidFormat(string input)
        {
            var regex = new Regex(RegexEmailFormat);

            return regex.IsMatch(input);
        }
    }
}
