using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Bikiran.Validation.Phone
{
    public class PhoneNumberOperation
    {
        public List<CountryCode> _countryCodes { get; }

        public PhoneNumberOperation()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "Bikiran.Validation.Phone.countries.json";

                using var stream = assembly.GetManifestResourceStream(resourceName);
                using var reader = new StreamReader(stream ?? throw new FileNotFoundException("countries.json not found in resources"));
                var json = reader.ReadToEnd();

                _countryCodes = JsonConvert.DeserializeObject<List<CountryCode>>(json) ?? [];
            }
            catch (Exception)
            {
                _countryCodes = [];
            }
        }

        public static string GetPlainNumber(string num)
        {
            return Regex.Replace(num, "[^0-9]", "");
        }

        public static string[] GetParsedNumber(string num)
        {
            num = GetPlainNumber(num);
            var parsedNum = new string[2];

            // Collect Country Codes
            var countryCodes = new PhoneNumberOperation()._countryCodes;

            // Order by code length desc
            countryCodes = countryCodes.OrderByDescending(c => c.CodeLength).ToList();

            // Check if number is empty
            foreach (var countryCode in countryCodes)
            {
                // Check starts with country code
                if (num.StartsWith(countryCode.Code))
                {
                    // Get the country code and the rest of the number
                    parsedNum[0] = countryCode.Code;
                    parsedNum[1] = num.Substring(countryCode.CodeLength);
                    if (parsedNum[1].Length < 6)
                    {
                        return null;
                    }

                    return parsedNum;
                }
            }

            return null;
        }
    }
}
