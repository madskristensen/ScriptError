using System.Collections.Generic;

namespace ScriptError
{
    class ValidationResult
    {
        public string Url { get; set; }
        public string Project { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();
    }

    public class Error
    {
        public string Extract { get; set; }
        public string Message { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
    }
}
