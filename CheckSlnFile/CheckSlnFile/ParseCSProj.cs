using System;
using System.Collections.Generic;
using System.Xml;

namespace CheckSlnFile
{
    public class ParseCsProj
    {
        public Guid Guid;
        public string OutPutFileName;
        public IList<string> References;
        public string ProjectFile;

        public ParseCsProj(string projectFile)
        {
            ProjectFile = projectFile;
            var doc = new XmlDocument();
            doc.Load(projectFile);

            var nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("ab", "http://schemas.microsoft.com/developer/msbuild/2003");
            var d = doc.SelectSingleNode("//ab:ProjectGuid", nsMgr);

            Guid = Guid.Parse(d.InnerText);

            var name = doc.SelectSingleNode("//ab:AssemblyName", nsMgr);
            OutPutFileName = name.FirstChild.Value.ToLower();

            var nod = doc.SelectNodes("//ab:Reference", nsMgr);
            References = new string[nod.Count];

            for (var i = 0; i < References.Count; i++) References[i] = nod[i].Attributes[0].Value.ToLower();
        }
    }
}