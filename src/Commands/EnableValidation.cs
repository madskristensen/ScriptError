using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;

namespace ScriptError
{
    internal sealed class EnableValidation
    {
        private readonly Package _package;

        private EnableValidation(Package package)
        {
            _package = package;

            var commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;

            if (commandService != null)
            {
                var cmdId = new CommandID(PackageGuids.guidValidatorPackageCmdSet, PackageIds.EnableScriptError);
                var cmd = new OleMenuCommand(MenuItemCallback, cmdId);
                cmd.BeforeQueryStatus += BeforeQueryStatus;
                commandService.AddCommand(cmd);
            }
        }

        public static EnableValidation Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get { return _package; }
        }

        public static void Initialize(Package package)
        {
            Instance = new EnableValidation(package);
        }

        private void BeforeQueryStatus(object sender, EventArgs e)
        {
            var button = (MenuCommand)sender;

            button.Checked = ScriptErrorPackage.Options?.RunOnPageLoad == true;
        }

        private void MenuItemCallback(object sender, EventArgs e)
        {
            var button = (MenuCommand)sender;

            ScriptErrorPackage.Options.RunOnPageLoad = !button.Checked;
            ScriptErrorPackage.Options.SaveSettingsToStorage();

            if (!ScriptErrorPackage.Options.RunOnPageLoad)
            {
                TableDataSource.Instance.CleanAllErrors();
            }
        }
    }
}
