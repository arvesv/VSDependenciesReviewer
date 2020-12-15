using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CheckSlnFile
{
    public class Project
    {
        public string Name;
        public string Path;
        public Guid Guid;
    }

    public class ParserSolutionFile
    {
        private const string CSharpProjectGuid = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC";

        private static string TrimName(string name)
        {
            return name.Replace('"', ' ').Trim();
        }

        private static Guid ParseGuid(string s)
        {
            return new Guid(TrimName(s));
        }

        public static IEnumerable<Project> GetProjects(string solutionFile)
        {
            var lines = File.ReadAllLines(solutionFile);
            var directory = Path.GetDirectoryName(solutionFile);

            var x = lines
                .Where(line => line.Contains(CSharpProjectGuid))
                .Select(line => line.Substring(53).Split(','))
                .Select(lineSplit => new Project { Name = TrimName(lineSplit[0]), Path = Path.Join(directory, TrimName(lineSplit[1])), Guid = ParseGuid(lineSplit[2])})
                .AsEnumerable();

            return x;
        }
    }
}
