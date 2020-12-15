using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using CheckSlnFile;
using Xunit;

namespace TestCheckSlnFile
{
    public class TestParseCSProjFile
    {
        private ParseCsProj csproject;
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
            Assert.Equal("classclassicdotnet.dll", csproject.OutPutFileName);
        }




    }
}


