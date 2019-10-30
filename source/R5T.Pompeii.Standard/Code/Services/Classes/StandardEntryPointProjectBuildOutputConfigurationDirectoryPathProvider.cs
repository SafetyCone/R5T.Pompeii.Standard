using System;


namespace R5T.Pompeii.Standard
{
    public class StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider : IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider
    {
        private IEntryPointProjectBuildOutputBinariesDirectoryPathProvider EntryPointProjectBuildOutputBinariesDirectoryPathProvider { get; }
        private IEntryPointProjectBuildConfigurationNameProvider EntryPointProjectBuildConfigurationNameProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
            IEntryPointProjectBuildOutputBinariesDirectoryPathProvider entryPointProjectBuildOutputBinariesDirectoryPathProvider,
            IEntryPointProjectBuildConfigurationNameProvider entryPointProjectBuildConfigurationNameProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.EntryPointProjectBuildOutputBinariesDirectoryPathProvider = entryPointProjectBuildOutputBinariesDirectoryPathProvider;
            this.EntryPointProjectBuildConfigurationNameProvider = entryPointProjectBuildConfigurationNameProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectBuildOutputConfigurationDirectoryPath()
        {
            var binDirectoryPath = this.EntryPointProjectBuildOutputBinariesDirectoryPathProvider.GetEntryPointProjectBuildOutputBinariesDirectoryPath();

            var configurationName = this.EntryPointProjectBuildConfigurationNameProvider.GetEntryPointProjectBuildConfigurationName();

            var configurationDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetConfigurationDirectoryPathFromBinariesDirectoryPath(binDirectoryPath, configurationName);
            return configurationDirectoryPath;
        }
    }
}
