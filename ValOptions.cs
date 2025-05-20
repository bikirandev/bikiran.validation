using System;

namespace Bikiran.Validation
{
    public class ValOptions
    {
        public static ValidateStatus IsValidateOptions(string? option, string title, List<string>? validOptions = null, string postText = "", bool isOptional = false)
        {
            if (option == null || option.Length == 0)
            {
                if (isOptional)
                {
                    return new ValidateStatus { Error = false, Message = "Optional" };
                }

                return new ValidateStatus { Error = true, Message = $"Please select {title}. {postText}" };
            }

            if (validOptions != null && !validOptions.Contains(option))
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not valid. {postText}" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidateOptions(int? option, string title, List<int>? validOptions = null, string postText = "", bool isOptional = false)
        {
            if (option == null || option == 0)
            {
                if (isOptional)
                {
                    return new ValidateStatus { Error = false, Message = "Optional" };
                }

                return new ValidateStatus { Error = true, Message = $"Please select {title}. {postText}" };
            }

            if (validOptions != null && !validOptions.Contains(option ?? 0))
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not valid. {postText}" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidateOptionsAll(List<string> options, List<string> validOptions, string title)
        {
            var valAll = options.Select(x => IsValidateOptions(x, title, validOptions, $"({x})")).ToList();

            return ValAll.ValidateAll(valAll);
        }
    }
}
