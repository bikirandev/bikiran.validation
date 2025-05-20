using System;

namespace Bikiran.Validation
{
    public class StatusObj
    {
        public bool Error { get; set; } = true;

        public string Message { get; set; } = "Initial Error";

        public int ErrorIndex { get; set; } = 0;
    }
}
