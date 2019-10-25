using System;


namespace R5T.Pompeii.Standard
{
    public interface ISolutionFileNameProvider
    {
        string GetSolutionFileName(string solutionDirectoryPath);
    }
}
