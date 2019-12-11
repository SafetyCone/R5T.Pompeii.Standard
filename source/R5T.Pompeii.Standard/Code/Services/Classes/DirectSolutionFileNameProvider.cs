using System;


namespace R5T.Pompeii.Standard
{
    public class DirectSolutionFileNameProvider : ISolutionFileNameProvider
    {
        private string SolutionFileName { get; }

        
        public DirectSolutionFileNameProvider(string solutionFileName)
        {
            this.SolutionFileName = solutionFileName;
        }

        public string GetSolutionFileName(string solutionDirectoryPath)
        {
            return this.SolutionFileName;
        }
    }
}
