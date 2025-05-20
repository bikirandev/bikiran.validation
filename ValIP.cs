using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValIP
    {
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
    }
}
