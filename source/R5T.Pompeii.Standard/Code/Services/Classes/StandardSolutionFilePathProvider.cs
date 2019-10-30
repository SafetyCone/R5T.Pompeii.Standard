using System;

using R5T.Lombardy;


namespace R5T.Pompeii.Standard
{
    /// <summary>
    /// Gets the solution file path from the current executable's file path assuming the standard development directory structure enforced by Visual Studio:
    ///     ../{Solution Directory}/{Project Directory}/bin/Debug/netcoreapp2.2/{executable file}
    /// </summary>
    public class StandardSolutionFilePathProvider : ISolutionFilePathProvider
    {
        private ISolutionDirectoryPathProvider SolutionDirectoryPathProvider { get; }
        private ISolutionFileNameProvider SolutionFileNameProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StandardSolutionFilePathProvider(
            ISolutionDirectoryPathProvider solutionDirectoryPathProvider,
            ISolutionFileNameProvider solutionFileNameProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.SolutionDirectoryPathProvider = solutionDirectoryPathProvider;
            this.SolutionFileNameProvider = solutionFileNameProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetSolutionFilePath()
        {
            var solutionDirectoryPath = this.SolutionDirectoryPathProvider.GetSolutionDirectoryPath();

            var solutionFileName = this.SolutionFileNameProvider.GetSolutionFileName(solutionDirectoryPath);

            var solutionFilePath = this.StringlyTypedPathOperator.GetFilePath(solutionDirectoryPath, solutionFileName);
            return solutionFilePath;
        }
    }
}
