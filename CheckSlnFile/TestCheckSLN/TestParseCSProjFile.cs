using System;
using System.Linq;
using CheckSlnFile;
using Xunit;

namespace TestCheckSlnFile
{
    public class TestParseCSProjFile
    {
        private readonly ParseCsProj csproject;

        public TestParseCSProjFile()
        {
            csproject = new ParseCsProj("TestCsProjFile.txt");
        }

        [Fact]
        public void TestReadGuidFromProject()
        {
            Assert.Equal(new Guid("51D71D6E-FA2E-4A58-A529-4916DA598245"), csproject.Guid);
        }

        [Fact]
        public void TestReadoutputFileIsLower()
        {
            Assert.Equal("classclassicdotnet", csproject.OutPutFileName);
        }

        [Fact]
        public void TestCheckReferencesCount()
        {
            Assert.Equal(8, csproject.References.Count());
        }

        [Fact]
        public void TestCheckReferencesElement()
        {
            var coll = csproject.References.Where(n => n == "system");
            Assert.Single(coll);
        }
    }
}