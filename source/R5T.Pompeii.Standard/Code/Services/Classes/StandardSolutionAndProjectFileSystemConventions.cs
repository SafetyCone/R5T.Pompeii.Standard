using System;

using R5T.Angleterria;
using R5T.Lombardy;


namespace R5T.Pompeii.Standard
{
    /// <summary>
    /// The standard directory hierarchy is:
    /// ./Solution Directory/Project Directory/bin/{Configuration Directory: Debug or Release}/{Framework Directory: netcoreapp2.2 or netstandard2.0}/publish
    /// </summary>
    public class StandardSolutionAndProjectFileSystemConventions : ISolutionAndProjectFileSystemConventions
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StandardSolutionAndProjectFileSystemConventions(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetBinariesDirectoryPathFromConfigurationDirectoryPath(string configurationDirectoryPath)
        {
            var binariesDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(configurationDirectoryPath);
            return binariesDirectoryPath;
        }

        public string GetBinariesDirectoryPathFromProjectDirectoryPath(string projectDirectoryPath)
        {
            var binDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(projectDirectoryPath, BinDirectory.DirectoryName);
            return binDirectoryPath;
        }

        public string GetConfigurationDirectoryNameFromConfigurationName(string configurationName)
        {
            var output = configurationName;
            return output;
        }

        public string GetConfigurationDirectoryPathFromBinariesDirectoryPath(string binariesDirectoryPath, string configurationName)
        {
            var configurationDirectoryName = this.GetConfigurationDirectoryNameFromConfigurationName(configurationName);

            var configurationDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(binariesDirectoryPath, configurationDirectoryName);
            return configurationDirectoryPath;
        }

        public string GetConfigurationDirectoryPathFromFrameworkDirectoryPath(string frameworkDirectoryPath)
        {
            var configurationDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(frameworkDirectoryPath);
            return configurationDirectoryPath;
        }

        public string GetExecutableDirectoryPathFromFrameworkDirectoryPath(string frameworkDirectoryPath)
        {
            var output = frameworkDirectoryPath;
            return output;
        }

        public string GetFrameworkDirectoryNameFromFrameworkName(string frameworkName)
        {
            var output = frameworkName;
            return output;
        }

        public string GetFrameworkDirectoryPathFromConfigurationDirectoryPath(string configurationDirectoryPath, string frameworkName)
        {
            var frameworkDirectoryName = this.GetFrameworkDirectoryNameFromFrameworkName(frameworkName);

            var frameworkDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(configurationDirectoryPath, frameworkDirectoryName);
            return frameworkDirectoryPath;
        }

        public string GetFrameworkDirectoryPathFromExecutableDirectoryPath(string executableDirectoryPath)
        {
            var output = executableDirectoryPath;
            return output;
        }

        public string GetFrameworkDirectoryPathFromPublishDirectoryPath(string publishDirectoryPath)
        {
            var frameworkDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(publishDirectoryPath);
            return frameworkDirectoryPath;
        }

        public string GetProjectDirectoryNameFromProjectName(string projectName)
        {
            var output = projectName;
            return output;
        }

        public string GetProjectDirectoryPathFromBinariesDirectoryPath(string binariesDirectoryPath)
        {
            var projectDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(binariesDirectoryPath);
            return projectDirectoryPath;
        }

        public string GetProjectDirectoryPathFromSolutionDirectoryPath(string solutionDirectoryPath, string projectName)
        {
            var projectDirectoryName = this.GetProjectDirectoryNameFromProjectName(projectName);

            var projectDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(solutionDirectoryPath, projectDirectoryName);
            return projectDirectoryPath;
        }

        public string GetPublishDirectoryPathFromFrameworkDirectoryPath(string frameworkDirectoryPath)
        {
            var output = this.StringlyTypedPathOperator.GetDirectoryPath(frameworkDirectoryPath, PublishDirectory.DirectoryName);
            return output;
        }

        public string GetSolutionDirectoryPathFromProjectDirectoryPath(string projectDirectoryPath)
        {
            var solutionDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(projectDirectoryPath);
            return solutionDirectoryPath;
        }
    }
}
