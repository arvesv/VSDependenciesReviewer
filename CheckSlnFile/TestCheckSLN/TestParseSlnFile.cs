using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using CheckSlnFile;
using Xunit;

namespace TestCheckSLN
{
    public class TestParseSlnFile
    {
        private IEnumerable<Project> parsedProjects;

        public TestParseSlnFile()
        {
            parsedProjects = ParserSolutionFile.GetProjects("TestSlnFile.txt");
        }

        private string GetTestFolder()
        {
            return Path.GetDirectoryName(GetType().Assembly.Location);
        } 
            
        [Fact]
        public void TestNumbersOfProjectInSolutionFile()
        {
            Assert.Equal(2, parsedProjects.Count());
        }

        [Fact]
        public void TestNameOfProjectInSolutionFile()
        {
            Assert.Collection(parsedProjects,
                project => Assert.Equal("ClassClassicDotNet", project.Name),
                project => Assert.Equal("ClassNetCore", project.Name));
        }

        [Fact]
        public void TestNameOfProjectPathsInSolutionFile()
        {
            Assert.Collection(parsedProjects,
                project => Assert.Equal(@"ClassClassicDotNet\ClassClassicDotNet.csproj", project.Path),
                project => Assert.Equal(@"ClassNetCore\ClassNetCore.csproj", project.Path));
        }

    }
}
