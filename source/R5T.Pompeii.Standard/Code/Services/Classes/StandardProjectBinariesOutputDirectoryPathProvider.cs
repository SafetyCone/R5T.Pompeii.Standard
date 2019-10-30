using System;

using R5T.Angleterria;
using R5T.Lombardy;


namespace R5T.Pompeii.Standard
{
    /// <summary>
    /// Gets the binaries directory path from the solution file path assuming the standard development directory structure enforced by Visual Studio:
    ///     ../{Solution Directory}/{Project Directory}/bin/Debug/netcoreapp2.2 (the binaries directory)
    /// </summary>
    public class StandardProjectBinariesOutputDirectoryPathProvider : IProjectBuildOutputBinariesDirectoryPathProvider
    {
        private ISolutionFilePathProvider SolutionFilePathProvider { get; }
        private IEntryPointProjectNameProvider EntryPointProjectNameProvider { get; }
        private IVisualStudioStringlyTypedPathPartsOperator VisualStudioStringlyTypedPathPartsOperator { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StandardProjectBinariesOutputDirectoryPathProvider(ISolutionFilePathProvider solutionFilePathProvider, IEntryPointProjectNameProvider entryPointProjectNameProvider,
            IVisualStudioStringlyTypedPathPartsOperator visualStudioStringlyTypedPathPartsOperator,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.SolutionFilePathProvider = solutionFilePathProvider;
            this.VisualStudioStringlyTypedPathPartsOperator = visualStudioStringlyTypedPathPartsOperator;
            this.EntryPointProjectNameProvider = entryPointProjectNameProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetProjectBuildOutputBinariesDirectoryPath()
        {
            var solutionFilePath = this.SolutionFilePathProvider.GetSolutionFilePath();

            var solutionDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(solutionFilePath);

            var entryPointProjectName = this.EntryPointProjectNameProvider.GetEntryPointProjectName();

            var entryPointProjectDirectoryName = this.VisualStudioStringlyTypedPathPartsOperator.GetProjectDirectoryNameForProjectName(entryPointProjectName);
            var entryPointProjectDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(solutionDirectoryPath, entryPointProjectDirectoryName);

            var binDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(entryPointProjectDirectoryPath, BinDirectory.DirectoryName);
            var debugDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(binDirectoryPath, DebugDirectory.DirectoryName);

            var framworkDirectoryName = this.SolutionAndProjectFileSystemConventions.GetFrameworkDirectoryNameFromFrameworkName(NetCoreAppV2_2.FrameworkName);

            var binariesOutputDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(debugDirectoryPath, framworkDirectoryName);
            return binariesOutputDirectoryPath;
        }
    }
}
