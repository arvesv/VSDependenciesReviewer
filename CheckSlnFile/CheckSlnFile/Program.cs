using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CheckSlnFile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solutionFile = args[0];

            Console.WriteLine("\nAnalyzing project {0}", solutionFile);
            var projects = ParserSolutionFile.GetProjects(solutionFile).ToList();

            var analyzedProjects = new List<ParseCsProj>();
            var dllsCreatedBySolution = new List<string>();
            
            projects.ForEach(project =>
            {
                if (File.Exists(project.Path))
                {
                    var projectInfo = new ParseCsProj(project.Path);
                    analyzedProjects.Add(projectInfo);
                    dllsCreatedBySolution.Add(projectInfo.OutPutFileName);
                }
                else
                {
                    Console.WriteLine("Referenced project {0} does not exist");
                    Environment.Exit(1);
                }
            });

            
            foreach (var project in analyzedProjects)
            {
                foreach (var fileReference in project.References)
                {
                    if (dllsCreatedBySolution.Contains(fileReference))
                    {
                        Console.WriteLine("Project {0} uses a file references to  {1}", project.OutPutFileName, fileReference);
                        Environment.ExitCode = 1;
                    }
                }
            }
        }
    }
}