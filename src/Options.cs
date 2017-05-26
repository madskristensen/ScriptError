using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ScriptError
{
    public class Options : DialogPage
    {
        [Category("General")]
        [DisplayName("Run on page load")]
        [Description("Determines if the the Script Error checker should run automatically on page load.")]
        [DefaultValue(true)]
        public bool RunOnPageLoad { get; set; } = true;
    }
}
