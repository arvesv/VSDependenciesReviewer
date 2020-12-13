using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CheckSlnFile
{
    public class Project
    {
        public string Name;
        public string Path;
    }


    public class ParserSolutionFile
    {
        private const string CSharpProjectGuid = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC";

        private static string TrimName(string name)
        {
            return name.Replace('"', ' ').Trim();

        }


        public static IEnumerable<Project> GetProjects(string solutionFile)
        {
            var lines = File.ReadAllLines(solutionFile);
            var directory = Path.GetDirectoryName(solutionFile);

            var x = lines
                .Where(line => line.Contains(CSharpProjectGuid))
                .Select(line => line.Substring(53).Split(','))
                .Select(x => new Project { Name = TrimName(x[0]), Path = TrimName(x[1])})
                .AsEnumerable<Project>();

            return x;
        }


    }
}
