using EnvDTE;
using Microsoft.VisualStudio.Web.BrowserLink;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace ScriptError
{
    [Export(typeof(IBrowserLinkExtensionFactory))]
    public class ScriptErrorFactory : IBrowserLinkExtensionFactory
    {
        public BrowserLinkExtension CreateExtensionInstance(BrowserLinkConnection connection)
        {
            return new ScriptErrorExtension();
        }

        public string GetScript()
        {
            using (Stream stream = GetType().Assembly.GetManifestResourceStream("ScriptError.BrowserLink.ScriptError.js"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class ScriptErrorExtension : BrowserLinkExtension
    {
        public override void OnConnected(BrowserLinkConnection connection)
        {
            if (connection.Project == null)
            {
                return;
            }

            string project = connection.Project.Name;
            bool enabled = ScriptErrorPackage.Options.RunOnPageLoad;

            Browsers.Client(connection).Invoke("initialize", project, enabled);
        }

        [BrowserLinkCallback]
        public void Report(string url, int line, int column, string message, string stack, string project)
        {
            var error = new Error
            {
                Message = message,
                Extract = stack,
                LineNumber = Math.Max(0, line - 1),
                ColumnNumber = Math.Max(0, column - 1)
            };

            var result = new ValidationResult
            {
                Project = project,
                Url = FindFileName(url, project)
            };

            result.Errors.Add(error);

            ErrorListService.Process(result);
        }

        private static string FindFileName(string path, string projectName)
        {
            var projects = VsHelpers.DTE.Solution.Projects.GetEnumerator();
            var cleanPath = path.Replace('/', '\\').TrimStart('\\');

            while (projects.MoveNext())
            {
                Project project = projects.Current as Project;

                if (project != null && project.Name == projectName)
                {
                    var root = project.GetRootFolder();
                    var rootPath = Path.Combine(root, cleanPath);

                    if (File.Exists(rootPath))
                        return rootPath;

                    var wwwRootPath = Path.Combine(root, "wwwroot", cleanPath);

                    if (File.Exists(wwwRootPath))
                        return wwwRootPath;
                }
            }

            return cleanPath;
        }
    }
}