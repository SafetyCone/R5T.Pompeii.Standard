using System;
using System.IO;
using System.Linq;

using R5T.Angleterria;
using R5T.Lombardy;
using R5T.Magyar;


namespace R5T.Pompeii.Standard
{
    public class SingleProjectInDirectoryEntryPointProjectFilePathProvider : IEntryPointProjectFilePathProvider
    {
        private IEntryPointProjectDirectoryPathProvider EntryPointProjectDirectoryPathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public SingleProjectInDirectoryEntryPointProjectFilePathProvider(
            IEntryPointProjectDirectoryPathProvider entryPointProjectDirectoryPathProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.EntryPointProjectDirectoryPathProvider = entryPointProjectDirectoryPathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetEntryPointProjectFilePath()
        {
            var projectDirectoryPath = this.EntryPointProjectDirectoryPathProvider.GetEntryPointProjectDirectoryPath();

            var searchPattern = $"{SearchPatternHelper.All}{PathHelper.FileExtensionSeparator}{CSharpProjectFile.FileExtension}";

            var filePaths = Directory.EnumerateFiles(projectDirectoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            if (filePaths.Count() > 1)
            {
                throw new Exception($"{nameof(SingleSolutionFileNameProvider)} cannot have more than one project file in the project directory. Found: {filePaths.Count()}. Project directory:\n{projectDirectoryPath}");
            }

            if (filePaths.Count() < 1)
            {
                throw new Exception($"{nameof(SingleSolutionFileNameProvider)} found no project files in directory:\n{projectDirectoryPath}");
            }

            var filePath = filePaths.First();
            return filePath;
        }
    }
}
