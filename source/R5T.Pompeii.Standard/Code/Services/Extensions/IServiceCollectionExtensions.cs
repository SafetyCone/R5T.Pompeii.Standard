using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Macommania;

using R5T.Pompeii.Default;


namespace R5T.Pompeii.Standard
{
    public static class IServiceCollectionExtensions
    {
        #region Standard Aggregations

        /// <summary>
        /// Adds the <see cref="ISolutionAndProjectFileSystemConventions"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionAndProjectFileSystemConventions(this IServiceCollection services,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services.AddStandardSolutionAndProjectFileSystemConventions(addStringlyTypedPathOperator);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionAndProjectFileSystemConventions"/> service.
        /// </summary>
        public static ServiceAction<ISolutionAndProjectFileSystemConventions> AddSolutionAndProjectFileSystemConventionsAction(this IServiceCollection services,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISolutionAndProjectFileSystemConventions>(() => services.AddSolutionAndProjectFileSystemConventions(
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectNameProvider(this IServiceCollection services, string entryPointProjectName)
        {
            services.AddDirectEntryPointProjectNameProvider(entryPointProjectName);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectNameProvider> AddEntryPointProjectNameProviderAction(this IServiceCollection services, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectNameProvider>(() => services.AddEntryPointProjectNameProvider(entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services.AddSingleProjectInDirectoryEntryPointProjectFilePathProvider(
                addEntryPointProjectDirectoryPathProvider,
                addStringlyTypedPathOperator);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFilePathProvider> AddEntryPointProjectDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFilePathProvider>(() => services.AddEntryPointProjectDirectoryPathProvider(
                addEntryPointProjectDirectoryPathProvider,
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        #endregion





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
