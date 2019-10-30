using System;


namespace R5T.Pompeii.Standard
{
    public class StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider : IEntryPointProjectBuildOutputBinariesDirectoryPathProvider
    {
        private IEntryPointProjectDirectoryPathProvider EntryPointProjectDirectoryPathProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
            IEntryPointProjectDirectoryPathProvider entryPointProjectDirectoryPathProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.EntryPointProjectDirectoryPathProvider = entryPointProjectDirectoryPathProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectBuildOutputBinariesDirectoryPath()
        {
            var entryPointProjectDirectoryPath = this.EntryPointProjectDirectoryPathProvider.GetEntryPointProjectDirectoryPath();

            var entryPointProjectBuildOutputBinariesDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetBinariesDirectoryPathFromProjectDirectoryPath(entryPointProjectDirectoryPath);
            return entryPointProjectBuildOutputBinariesDirectoryPath;
        }
    }
}
