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
        public static IServiceAction<ISolutionAndProjectFileSystemConventions> AddSolutionAndProjectFileSystemConventionsAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionAndProjectFileSystemConventions>(() => services.AddSolutionAndProjectFileSystemConventions());
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
        public static IServiceAction<IEntryPointProjectFrameworkNameProvider> AddEntryPointProjectFrameworkNameProviderAction(this IServiceCollection services)
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
        public static IServiceAction<ISolutionDirectoryPathProvider> AddSolutionDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionDirectoryPathProvider>(() => services.AddSolutionDirectoryPathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddStandardEntryPointProjectDirectoryPathProvider(
                services.AddSolutionDirectoryPathProviderAction(),
                addEntryPointProjectNameProvider,
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IEntryPointProjectDirectoryPathProvider> AddEntryPointProjectDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectDirectoryPathProvider>(() => services.AddEntryPointProjectDirectoryPathProvider(addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                services.AddEntryPointProjectDirectoryPathProviderAction(addEntryPointProjectNameProvider),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> AddEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(addEntryPointProjectNameProvider),
                addBuildConfigurationNameProvider,
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> AddEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                addEntryPointProjectNameProvider,
                addBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider),
                services.AddEntryPointProjectFrameworkNameProviderAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> AddEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectFilePathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddSingleProjectInDirectoryEntryPointProjectFilePathProvider(
                services.AddEntryPointProjectDirectoryPathProviderAction(addEntryPointProjectNameProvider),
                services.AddStringlyTypedPathOperatorAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static IServiceAction<IEntryPointProjectFilePathProvider> AddEntryPointProjectFilePathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFilePathProvider>(() => services.AddEntryPointProjectFilePathProvider(addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds all standard entry point project services.
        /// Including <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> and <see cref="IEntryPointProjectFilePathProvider"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectConventions(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services
                .AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider)
                .AddEntryPointProjectFilePathProvider(addEntryPointProjectNameProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSingleSolutionFileNameProvider(this IServiceCollection services)
        {
            services.AddSingleSolutionFileNameProvider(
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static IServiceAction<ISolutionFileNameProvider> AddSingleSolutionFileNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionFileNameProvider>(() => services.AddSingleSolutionFileNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddStandardSolutionFilePathProvider(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
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
        public static IServiceAction<ISolutionFilePathProvider> AddStandardSolutionFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddStandardSolutionFilePathProvider(
                addSolutionFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            services.AddStandardSolutionFilePathProvider(addSolutionFileNameProvider);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider(
                addSolutionFileNameProvider));
            return serviceAction;
        }

        ///// <summary>
        ///// Adds the <see cref="ISolutionFilePathProvider"/> service.
        ///// </summary>
        //public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services)
        //{
        //    services.AddSolutionFilePathProvider(
        //        services.AddSingleSolutionFileNameProviderAction());

        //    return services;
        //}

        ///// <summary>
        ///// Adds the <see cref="ISolutionFilePathProvider"/> service.
        ///// </summary>
        //public static ServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services)
        //{
        //    var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider());
        //    return serviceAction;
        //}

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddStandardProjectBinariesOutputDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider
            )
        {
            services.AddStandardProjectBinariesOutputDirectoryPathProvider(
                services.AddSolutionFilePathProviderAction(addSolutionFileNameProvider),
                addEntryPointProjectNameProvider,
                services.AddVisualStudioStringlyTypedPathPartsOperatorAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider> AddStandardProjectBinariesOutputDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddStandardProjectBinariesOutputDirectoryPathProvider(
                addSolutionFileNameProvider,
                addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddPublishProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            services.AddPublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addBuildConfigurationNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider> AddPublishProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddPublishProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectNameProvider,
                addBuildConfigurationNameProvider));
            return serviceAction;
        }
    }
}
