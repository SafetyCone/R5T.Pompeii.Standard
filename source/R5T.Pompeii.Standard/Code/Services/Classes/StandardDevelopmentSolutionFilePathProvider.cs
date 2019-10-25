using System;

using R5T.Lombardy;
using R5T.Macommania;


namespace R5T.Pompeii.Standard
{
    /// <summary>
    /// Gets the solution file path from the current executable's file path assuming the standard development directory structure enforced by Visual Studio:
    ///     ../{Solution Directory}/{Project Directory}/bin/Debug/netcoreapp2.2/{executable file}
    /// </summary>
    public class StandardDevelopmentSolutionFilePathProvider : ISolutionFilePathProvider
    {
        private IExecutableFileDirectoryPathProvider ExecutableFileDirectoryPathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        private ISolutionFileNameProvider SolutionFileNameProvider { get; }


        public StandardDevelopmentSolutionFilePathProvider(IExecutableFileDirectoryPathProvider executableFileDirectoryPathProvider, IStringlyTypedPathOperator stringlyTypedPathOperator, ISolutionFileNameProvider solutionFileNameProvider)
        {
            this.ExecutableFileDirectoryPathProvider = executableFileDirectoryPathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.SolutionFileNameProvider = solutionFileNameProvider;
        }

        public string GetSolutionFilePath()
        {
            var executableFileDirectoryPath = this.ExecutableFileDirectoryPathProvider.GetExecutableFileDirectoryPath();

            var binDebugDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(executableFileDirectoryPath);
            var binDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(binDebugDirectoryPath);
            var projectDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(binDirectoryPath);
            var solutionDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(projectDirectoryPath);

            var solutionFileName = this.SolutionFileNameProvider.GetSolutionFileName(solutionDirectoryPath);

            var solutionFilePath = this.StringlyTypedPathOperator.GetFilePath(solutionDirectoryPath, solutionFileName);
            return solutionFilePath;
        }
    }
}
