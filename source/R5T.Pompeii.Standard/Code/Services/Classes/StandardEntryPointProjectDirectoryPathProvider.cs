using System;


namespace R5T.Pompeii.Standard
{
    public class StandardEntryPointProjectDirectoryPathProvider : IEntryPointProjectDirectoryPathProvider
    {
        private ISolutionDirectoryPathProvider SolutionDirectoryPathProvider { get; }
        private IEntryPointProjectNameProvider EntryPointProjectNameProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectDirectoryPathProvider(
            ISolutionDirectoryPathProvider solutionDirectoryPathProvider,
            IEntryPointProjectNameProvider entryPointProjectNameProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.SolutionDirectoryPathProvider = solutionDirectoryPathProvider;
            this.EntryPointProjectNameProvider = entryPointProjectNameProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectDirectoryPath()
        {
            var solutionDirectoryPath = this.SolutionDirectoryPathProvider.GetSolutionDirectoryPath();

            var entryPointProjectName = this.EntryPointProjectNameProvider.GetEntryPointProjectName();

            var entryPointProjectDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetProjectDirectoryPathFromSolutionDirectoryPath(solutionDirectoryPath, entryPointProjectName);
            return entryPointProjectDirectoryPath;
        }
    }
}
