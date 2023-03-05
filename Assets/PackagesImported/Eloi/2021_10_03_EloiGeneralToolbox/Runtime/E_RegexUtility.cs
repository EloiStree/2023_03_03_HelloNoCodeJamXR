using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Eloi
{
    public class E_RegexUtility
    {

        public static void DoesMailAddressHasMinimumAndRegex(in string mail, bool ignoreCase, out bool isMailAddress)
        {

            IsMailHasMinimumArobasAndPoint(mail, out bool hasMinimValue);
            if (!hasMinimValue) { isMailAddress = false; }
            else {
            IsMailHasRegexPattern(mail, ignoreCase, out bool mailRegexValide);

            isMailAddress = mailRegexValide && hasMinimValue;
            }
         

        }

        public static void IsMailHasRegexPattern(in string mail, bool ignoreCase, out  bool isMailAddressRegex)
        {
            string mailValue = mail.Trim();
            if (ignoreCase)
                mailValue = mailValue.ToLower();
            Regex r = new Regex("^(?(\")(\".+?(?<!\\\\)\"@) |(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$");
            Match m = r.Match(mailValue);
            isMailAddressRegex = m.Success && m.Value.Length == mailValue.Length;
        }
        public static void  IsMailHasMinimumArobasAndPoint(in string mail, out bool isMailAddress)
        {
            int arrobasIndex = mail.LastIndexOf("@");
            int dotIndex = mail.LastIndexOf(".");
            isMailAddress = arrobasIndex > 0 && dotIndex > 0 && dotIndex > arrobasIndex;
        }

        public static void CheckIfStringContainCharacterThatDontFitPhoneNumber(in string phone, out bool couldBePhoneNumber)
        {
            Regex rgx = new Regex("[^+0-9 ()-]");
            string phoneNumber = rgx.Replace(phone, "");
            couldBePhoneNumber = phone.Length == phoneNumber.Length;
        }
    }
}