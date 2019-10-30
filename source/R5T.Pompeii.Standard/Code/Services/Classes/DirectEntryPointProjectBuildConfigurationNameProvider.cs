using System;


namespace R5T.Pompeii.Standard
{
    public class DirectEntryPointProjectBuildConfigurationNameProvider : IEntryPointProjectBuildConfigurationNameProvider
    {
        private string EntryPointProjectBuildConfigurationName { get; }


        public DirectEntryPointProjectBuildConfigurationNameProvider(string entryPointProjectBuildConfigurationName)
        {
            this.EntryPointProjectBuildConfigurationName = entryPointProjectBuildConfigurationName;
        }

        public string GetEntryPointProjectBuildConfigurationName()
        {
            var output = this.EntryPointProjectBuildConfigurationName;
            return output;
        }
    }
}
