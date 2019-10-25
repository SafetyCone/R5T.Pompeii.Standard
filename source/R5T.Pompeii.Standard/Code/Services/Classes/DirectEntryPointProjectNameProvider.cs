using System;


namespace R5T.Pompeii.Standard
{
    public class DirectEntryPointProjectNameProvider : IEntryPointProjectNameProvider
    {
        private string EntryPointProjectName { get; }


        public DirectEntryPointProjectNameProvider(string entryPointProjectName)
        {
            this.EntryPointProjectName = entryPointProjectName;
        }

        public string GetEntryPointProjectName()
        {
            return this.EntryPointProjectName;
        }
    }
}
