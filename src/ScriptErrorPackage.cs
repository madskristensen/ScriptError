using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace ScriptError
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(PackageGuids.guidPackageString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPage(typeof(Options), "Web", "W3C Validator", 101, 111, true, new string[0], ProvidesLocalizedCategoryName = false)]
    [ProvideAutoLoad(PackageGuids.guidAutoLoadString)]
    [ProvideUIContextRule(PackageGuids.guidAutoLoadString, "Load Package",
        "WAP | WebSite | ProjectK | DotNetCoreWeb",
        new string[] {
            "WAP",
            "WebSite",
            "ProjectK",
            "DotNetCoreWeb"
        },
        new string[] {
            "SolutionHasProjectFlavor:{349C5851-65DF-11DA-9384-00065B846F21}",
            "SolutionHasProjectFlavor:{E24C65DC-7377-472B-9ABA-BC803B73C61A}",
            "SolutionHasProjectFlavor:{8BB2217D-0F2D-49D1-97BC-3654ED321F3B}",
            "SolutionHasProjectCapability:DotNetCoreWeb"
        })]
    public sealed class ScriptErrorPackage : Package
    {
        public static Options Options { get; private set; }

        protected override void Initialize()
        {
            Options = (Options)GetDialogPage(typeof(Options));
            EnableValidation.Initialize(this);
        }
    }
}
