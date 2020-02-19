using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Angleterria.Standard;
using R5T.Dacia;
using R5T.Lombardy.Standard;
using R5T.Macommania.Standard;

using R5T.Pompeii.Default;


namespace R5T.Pompeii.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ISolutionAndProjectFileSystemConventions"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionAndProjectFileSystemConventions(this IServiceCollection services)
        {
            services.AddStandardSolutionAndProjectFileSystemConventions(
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionAndProjectFileSystemConventions"/> service.
        /// </summary>
        public static ServiceAction<ISolutionAndProjectFileSystemConventions> AddSolutionAndProjectFileSystemConventionsAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionAndProjectFileSystemConventions>(() => services.AddSolutionAndProjectFileSystemConventions());
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
        /// Adds the <see cref="IEntryPointProjectFrameworkNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectFrameworkNameProvider(this IServiceCollection services)
        {
            services.AddNetCoreAppV2_2EntryPointProjectFrameworkNameProvider();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFrameworkNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFrameworkNameProvider> AddEntryPointProjectFrameworkNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFrameworkNameProvider>(() => services.AddEntryPointProjectFrameworkNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionDirectoryPathProvider(this IServiceCollection services)
        {
            services.AddStandardSolutionDirectoryPathProvider(
                services.AddExecutableFileDirectoryPathProviderAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionDirectoryPathProvider> AddSolutionDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionDirectoryPathProvider>(() => services.AddSolutionDirectoryPathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectDirectoryPathProvider(this IServiceCollection services, string entryPointProjectName)
        {
            services.AddStandardEntryPointProjectDirectoryPathProvider(
                services.AddSolutionDirectoryPathProviderAction(),
                services.AddEntryPointProjectNameProviderAction(entryPointProjectName),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectDirectoryPathProvider> AddEntryPointProjectDirectoryPathProviderAction(this IServiceCollection services, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectDirectoryPathProvider>(() => services.AddEntryPointProjectDirectoryPathProvider(entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services, string entryPointProjectName)
        {
            services.AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                services.AddEntryPointProjectDirectoryPathProviderAction(entryPointProjectName),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> AddEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputBinariesDirectoryPathProvider(entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildConfigurationNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildConfigurationNameProvider(this IServiceCollection services, string buildConfigurationName)
        {
            services.AddDirectEntryPointProjectBuildConfigurationNameProvider(buildConfigurationName);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildConfigurationNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> AddEntryPointProjectBuildConfigurationNameProviderAction(this IServiceCollection services, string buildConfigurationName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildConfigurationNameProvider>(() => services.AddEntryPointProjectBuildConfigurationNameProvider(buildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            services.AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(entryPointProjectName),
                services.AddEntryPointProjectBuildConfigurationNameProviderAction(buildConfigurationName),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> AddEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(entryPointProjectName, buildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            services.AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(entryPointProjectName, buildConfigurationName),
                services.AddEntryPointProjectFrameworkNameProviderAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> AddEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(entryPointProjectName, buildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            services.AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(entryPointProjectName, buildConfigurationName),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(entryPointProjectName, buildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectFilePathProvider(this IServiceCollection services, string entryPointProjectName)
        {
            services.AddSingleProjectInDirectoryEntryPointProjectFilePathProvider(
                services.AddEntryPointProjectDirectoryPathProviderAction(entryPointProjectName),
                services.AddStringlyTypedPathOperatorAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFilePathProvider> AddEntryPointProjectFilePathProviderAction(this IServiceCollection services, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFilePathProvider>(() => services.AddEntryPointProjectFilePathProvider(entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds all standard entry point project services.
        /// Including <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> and <see cref="IEntryPointProjectFilePathProvider"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectConventions(this IServiceCollection services, string entryPointProjectName, string buildConfigurationName)
        {
            services
                .AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(entryPointProjectName, buildConfigurationName)
                .AddEntryPointProjectFilePathProvider(entryPointProjectName)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFileNameProvider(this IServiceCollection services, string solutionFileName)
        {
            services.AddDirectSolutionFileNameProvider(solutionFileName);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFileNameProvider> AddSolutionFileNameProviderAction(this IServiceCollection services, string solutionFileName)
        {
            var serviceAction = new ServiceAction<ISolutionFileNameProvider>(() => services.AddSolutionFileNameProvider(solutionFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFileNameProvider(this IServiceCollection services)
        {
            services.AddSingleSolutionFileNameProvider(
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFileNameProvider> AddSolutionFileNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionFileNameProvider>(() => services.AddSolutionFileNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            services.AddStandardSolutionFilePathProvider(
                services.AddSolutionDirectoryPathProviderAction(),
                addSolutionFileNameProvider,
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider(
                addSolutionFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services, string solutionFileName)
        {
            services.AddSolutionFilePathProvider(
                services.AddSolutionFileNameProviderAction(solutionFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services, string solutionFileName)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider(solutionFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services)
        {
            services.AddSolutionFilePathProvider(
                services.AddSolutionFileNameProviderAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services, string solutionFileName, string entryPointProjectName)
        {
            services.AddStandardProjectBinariesOutputDirectoryPathProvider(
                services.AddSolutionFilePathProviderAction(solutionFileName),
                services.AddEntryPointProjectNameProviderAction(entryPointProjectName),
                services.AddVisualStudioStringlyTypedPathPartsOperatorAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }
    }
}
