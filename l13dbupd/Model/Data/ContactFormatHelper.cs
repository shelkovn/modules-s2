using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace l9_mvvm.Model.Data
{
    public class ContactFormatHelper
    {
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Regex allows +7 or 8, optional spaces, optional brackets, and optional hyphens
            string pattern = @"^(?:\+7|8)[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }

        public bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Pattern allows only letters, spaces, hyphens, and apostrophes.
            // It also ensures there are at least 3 letters anywhere in the string.
            string pattern = @"^(?=(?:.*?[a-zA-Z\u0400-\u04FF]){3,})[a-zA-Z\u0400-\u04FF\s\-']+$";

            return Regex.IsMatch(name, pattern);
        }

        public string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return string.Empty;

            // 1. Remove all non-digit characters
            string digits = Regex.Replace(phoneNumber, @"\D", "");

            // 2. Normalize prefix: if it starts with 8 and has 11 digits, replace 8 with 7
            if (digits.Length == 11 && digits.StartsWith("8"))
            {
                digits = "7" + digits.Substring(1);
            }
            // If it is 10 digits (e.g., 9991234567), assume the country code is missing and add 7
            else if (digits.Length == 10)
            {
                digits = "7" + digits;
            }

            // 3. Check if we have exactly 11 digits now
            if (digits.Length != 11 || !digits.StartsWith("7"))
            {
                return "Invalid phone number length or format";
            }

            // 4. Format into +7 (XXX) XXX-XX-XX
            return $"+7 ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9, 2)}";
        }
    }
}
