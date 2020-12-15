using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CheckSlnFile
{
    public class ParseCsProj
    {
        public Guid Guid;
        public string OutPutFileName;

        public ParseCsProj(string projectfile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(projectfile);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ab", "http://schemas.microsoft.com/developer/msbuild/2003");
            var d = doc.SelectSingleNode("//ab:ProjectGuid", nsmgr);

            Guid = System.Guid.Parse(d.InnerText);

            var name = doc.SelectSingleNode("//ab:AssemblyName", nsmgr);
            OutPutFileName = name.Value;

        }
    }
}
