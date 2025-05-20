using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable enable


namespace Bikiran.Validation
{
    /// <summary>
    /// Provides IP address validation methods for format verification
    /// </summary>
    public class ValIP
    {
        /// <summary>
        /// Validates the format of a single IPv4 address
        /// </summary>
        /// <param name="ip">IP address to validate (nullable string)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Non-empty input
        /// 2. Matches basic IPv4 pattern (###.###.###.###)
        /// Note: This validation only checks format, not numerical validity.
        /// Valid format examples that would pass but are invalid IPs: "999.999.999.999", "256.0.0.1"
        /// </remarks>
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

        /// <summary>
        /// Validates format for multiple IPv4 addresses in a list
        /// </summary>
        /// <param name="ips">List of IP addresses to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation rules:
        /// 1. Non-empty list check
        /// 2. Validates each IP using <see cref="IsValidIpFormat"/>
        /// 3. Returns first invalid IP with specific error message
        /// 4. All IPs must be valid for success
        /// Note: Shares same limitations as single IP validation - checks format only
        /// </remarks>
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