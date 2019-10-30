using System;


namespace R5T.Pompeii.Standard
{
    public class PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider : IProjectBuildOutputBinariesDirectoryPathProvider
    {
        private IEntryPointProjectBuildOutputPublishDirectoryPathProvider EntryPointProjectBuildOutputPublishDirectoryPathProvider { get; }


        public PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider(
            IEntryPointProjectBuildOutputPublishDirectoryPathProvider entryPointProjectBuildOutputPublishDirectoryPathProvider)
        {
            this.EntryPointProjectBuildOutputPublishDirectoryPathProvider = entryPointProjectBuildOutputPublishDirectoryPathProvider;
        }

        public string GetProjectBuildOutputBinariesDirectoryPath()
        {
            var publishDirectoryPath = this.EntryPointProjectBuildOutputPublishDirectoryPathProvider.GetEntryPointProjectBuildOutputPublishDirectoryPath();
            return publishDirectoryPath;
        }
    }
}
