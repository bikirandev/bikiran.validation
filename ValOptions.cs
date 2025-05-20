using System;

namespace Bikiran.Validation
{
    public class ValOptions
    {
        public static StatusObj IsValidateOptions(string? option, string title, List<string>? validOptions = null, string postText = "", bool isOptional = false)
        {
            if (option == null || option.Length == 0)
            {
                if (isOptional)
                {
                    return new StatusObj { Error = false, Message = "Optional" };
                }

                return new StatusObj { Error = true, Message = $"Please select {title}. {postText}" };
            }

            if (validOptions != null && !validOptions.Contains(option))
            {
                return new StatusObj { Error = true, Message = $"{title} is not valid. {postText}" };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsValidateOptions(int? option, string title, List<int>? validOptions = null, string postText = "", bool isOptional = false)
        {
            if (option == null || option == 0)
            {
                if (isOptional)
                {
                    return new StatusObj { Error = false, Message = "Optional" };
                }

                return new StatusObj { Error = true, Message = $"Please select {title}. {postText}" };
            }

            if (validOptions != null && !validOptions.Contains(option ?? 0))
            {
                return new StatusObj { Error = true, Message = $"{title} is not valid. {postText}" };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsValidateOptionsAll(List<string> options, List<string> validOptions, string title)
        {
            var valAll = options.Select(x => IsValidateOptions(x, title, validOptions, $"({x})")).ToList();

            return ValAll.ValidateAll(valAll);
        }
    }
}
