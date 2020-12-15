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

        public ParseCsProj(string projectfile)
        {
            var doc = new XmlDocument();
            doc.Load(projectfile);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ab", "http://schemas.microsoft.com/developer/msbuild/2003");
            var d = doc.SelectSingleNode("//ab:ProjectGuid", nsmgr);


            Guid = Guid.Parse(d.InnerText);

            var name = doc.SelectSingleNode("//ab:AssemblyName", nsmgr);
            OutPutFileName = name.FirstChild.Value.ToLower();

            var nod = doc.SelectNodes("//ab:Reference", nsmgr);
            References = new string[nod.Count];

            for (var i = 0; i < References.Count; i++) References[i] = nod[i].Attributes[0].Value.ToLower();
        }
    }
}