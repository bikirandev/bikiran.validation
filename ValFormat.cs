using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValFormat
    {
        public static ValidateStatus IsValidDateFormat(string? date, string title = "Date")
        {
            if (string.IsNullOrEmpty(date) || date.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Define a regular expression pattern to match the YYYY-MM-DD format
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            var st = Regex.IsMatch(date, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = "Please enter valid " + title };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidEmailFormat(string? email, string title, string postText = "")
        {
            if (email == null || email.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = $"Please enter {title}. {postText}" };
            }

            if (email.Length < 6)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should be minimum 3 characters long. {postText}" };
            }

            if (email.Length > 200)
            {
                return new ValidateStatus { Error = true, Message = $" {title} should be maximum 200 characters long. {postText}" };
            }

            // Define a regular expression pattern to match the email format
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var st = Regex.IsMatch(email, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = $"Please enter valid {title}. {postText}" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidEmailFormatAll(List<string> email, string title)
        {
            var validateAll = email.Select(x => IsValidEmailFormat(x, title, $"({x})")).ToList();

            return ValAll.ValidateAll(validateAll);
        }

        public static ValidateStatus IsValidPasswordFormat(string? password, string title = "Password")
        {
            if (password == null || password.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (password.Length < 8)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum 8 characters long" };
            }

            if (password.Length > 32)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 32 characters long" };
            }

            //--Define a regular expression pattern to match the password format
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$";
            var st = Regex.IsMatch(password, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " should contain at least one uppercase letter, one lowercase letter, one digit and one special character" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidString(string? name, string title, int min = 2, int max = 100)
        {
            if (name == null || name.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (name.Length < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min + " character long" };
            }

            if (name.Length > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max + " character long" };
            }

            //--Define a regular expression pattern to match the name format win a min and max length
            string pattern = @"^[a-zA-Z0-9\s\.\- ,\(\)]+$";
            var st = Regex.IsMatch(name, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " should be alphanumeric" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidLongString(string? name, string title, int min = 2, int max = 5000, bool isOptional = false)
        {
            if (isOptional && (name == null || name.Trim().Length == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            if (name == null || name.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (name.Length < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min + " character long" };
            }

            if (name.Length > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max + " character long" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidDomainFormat(string? domainName, string title, bool isOptional = false)
        {
            if (isOptional && (domainName == null || domainName.Length == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            //--VerifyAsync Valid Domain Format
            if (domainName == null || domainName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            //--Define a regular expression pattern to match the domain format
            string pattern = @"^([a-zA-Z0-9][a-zA-Z0-9\-]{0,61}[a-zA-Z0-9]\.)+[a-zA-Z]{2,}$";
            var st = Regex.IsMatch(domainName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = title + " is Valid" };
        }

        public static ValidateStatus IsValidDomainFormatAll(List<string>? domainName, string title, bool isOptional = false)
        {
            if (isOptional && (domainName == null || domainName.Count == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            if (domainName == null || domainName.Count == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            foreach (var domain in domainName)
            {
                var st = IsValidDomainFormat(domain, title);
                if (st.Error)
                {
                    st.Message = st.Message + ": " + domain;
                    return st;
                }
            }

            return new ValidateStatus { Error = false, Message = title + " is Valid" };
        }

        public static ValidateStatus IsValidUrlFormat(string? logoUrl, string title, bool isOptional = false)
        {
            if (string.IsNullOrEmpty(logoUrl) && isOptional)
            {
                return new ValidateStatus { Error = false, Message = "Optional" };
            }


            // Check if the URL is null or empty
            if (string.IsNullOrWhiteSpace(logoUrl))
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Updated pattern to allow localhost with ports and optional paths
            //             = @"^((http|https):\/\/)?([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?$";
            string pattern = @"^(http|https):\/\/(localhost(:\d+)?|([\w-]+\.)+[\w-]+)(\/[\w- .\/?%&=]*)?$";
            bool isValid = Regex.IsMatch(logoUrl, pattern, RegexOptions.IgnoreCase);

            if (!isValid)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidUserNameFormat(string userName, string title)
        {
            //--Check is Username Format is valid
            if (userName == null || userName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (userName.Length < 5)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum 5 characters long" };
            }

            if (userName.Length > 20)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 20 characters long" };
            }

            //--Define a regular expression pattern to match the username format
            string pattern = @"^[a-zA-Z0-9\.\-\@]+$";
            var st = Regex.IsMatch(userName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " should be alphanumeric or Dot(.), Hyphen(-), At the rate(@)" };
            }

            //--Check if username not starts with a letter
            if (!char.IsLetter(userName[0]))
            {
                return new ValidateStatus { Error = true, Message = title + " should start with a letter" };
            }

            //--Check if username not ends with a letter or number
            if (!char.IsLetterOrDigit(userName[^1]))
            {
                return new ValidateStatus { Error = true, Message = title + " should end with a letter or number" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static string GetReferenceName(List<string> refNames, int errorIndex)
        {
            if (errorIndex == -1)
            {
                return "";
            }

            if (errorIndex >= refNames.Count)
            {
                return "";
            }

            return refNames[errorIndex];
        }

        public static ValidateStatus IsValidIpFormat(string? ip, string title)
        {
            if (ip == null || ip.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Define a regular expression pattern to match the IP format
            string pattern = @"^(\d{1,3}\.){3}\d{1,3}$";
            var st = Regex.IsMatch(ip, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidIpFormatAll(List<string>? ips, string title)
        {
            if (ips == null || ips.Count == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            foreach (var ip in ips)
            {
                var st = IsValidIpFormat(ip, title);
                if (st.Error)
                {
                    st.Message = $"IP: {ip} is not valid";
                    return st;
                }
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidPathPattern(string sourceDir, string title)
        {
            if (sourceDir == null || sourceDir.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Define a regular expression pattern to match the path format
            string pattern = @"^([a-zA-Z]:\\)?[^<>:""/\\|?*]+$";
            var st = Regex.IsMatch(sourceDir, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
