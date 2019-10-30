using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.Pompeii.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection UseStandardEntryPointProjectConventions(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            services
                .AddSingleton<IEntryPointProjectNameProvider>(new DirectEntryPointProjectNameProvider(entryPointProjectName))
                .AddSingleton<IEntryPointProjectFilePathProvider, SingleProjectInDirectoryEntryPointProjectFilePathProvider>()

                .AddSingleton<ISolutionDirectoryPathProvider, StandardSolutionDirectoryPathProvider>()
                .AddSingleton<IEntryPointProjectDirectoryPathProvider, StandardEntryPointProjectDirectoryPathProvider>()
                .AddSingleton<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider, StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider>()
                .AddSingleton<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider, StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>()
                .AddSingleton<IEntryPointProjectBuildConfigurationNameProvider>(new DirectEntryPointProjectBuildConfigurationNameProvider(buildConfigurationName))
                .AddSingleton<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider, StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider>()
                .AddSingleton<IEntryPointProjectBuildOutputPublishDirectoryPathProvider, StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider>()
                .AddSingleton<IEntryPointProjectFrameworkNameProvider, NetCoreAppV2_2EntryPointProjectFrameworkNameProvider>()
                .AddSingleton<IEntryPointProjectBuildOutputPublishDirectoryPathProvider, StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider>()

                .AddSingleton<ISolutionAndProjectFileSystemConventions, StandardSolutionAndProjectFileSystemConventions>()
                ;

            return services;
        }
    }
}
