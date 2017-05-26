using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ScriptError
{
    public class Options : DialogPage
    {
        [Category("General")]
        [DisplayName("Enable script detection")]
        [Description("Determines if the the error detector should run automatically on page load.")]
        [DefaultValue(true)]
        public bool RunOnPageLoad { get; set; } = true;
    }
}
