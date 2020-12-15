using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using CheckSlnFile;
using Xunit;

namespace TestCheckSlnFile
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
                project => Assert.Equal("ClassNetCore", project.Name)
                );
        }

        [Fact]
        public void TestNameOfProjectPathsInSolutionFile()
        {
            Assert.Collection(parsedProjects,
                project => Assert.Equal(new Guid("51D71D6E-FA2E-4A58-A529-4916DA598245"), project.Guid),
                project => Assert.Equal(new Guid("179F8F6E-0757-4A11-9C8E-1F717EAA5C11"),  project.Guid));
        }

        [Fact]
        public void TestGuidOfProjectPathsInSolutionFile()
        {
            Assert.Collection(parsedProjects,
                project => Assert.Equal(@"ClassClassicDotNet\ClassClassicDotNet.csproj", project.Path),
                project => Assert.Equal(@"ClassNetCore\ClassNetCore.csproj", project.Path)
                );
        }
    }
}
