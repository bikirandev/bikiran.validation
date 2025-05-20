using System;

namespace Bikiran.Validation.Phone
{
    public class CountryCode
    {
        public string Code { get; set; } = "";    // Country code (e.g., "1", "44")

        public string NameCode { get; set; } = ""; // Country code in lowercase (e.g., "us", "gb" for "United States", "United Kingdom" respectively)

        public string Name { get; set; } = "";     // Country name (e.g., "United States", "United Kingdom")

        public int MinLength { get; set; }    // Minimum length for phone numbers in this country

        public int MaxLength { get; set; }    // Maximum length for phone numbers in this country

        public int CodeLength => Code.Length; // Length of the country code
    }
}
