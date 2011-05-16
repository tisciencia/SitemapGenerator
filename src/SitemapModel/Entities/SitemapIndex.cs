using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace SitemapModel.Entities
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9", ElementName = "sitemapindex", IsNullable = false)]
    public class SitemapIndex
    {

        private List<Sitemap> _siteMapList = new List<Sitemap>();

        [XmlElement("sitemap")]
        public List<Sitemap> SiteMapList
        {
            get { return _siteMapList; }
        }

        #region Serialization

        public void Serialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SitemapIndex), "");
            StreamWriter writer = new StreamWriter(path);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.sitemaps.org/schemas/sitemap/0.9");
 
            serializer.Serialize(writer, this, ns);

            writer.Close();
            writer.Dispose();
        }

        public static SitemapIndex Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SitemapIndex));

            StreamReader reader = new StreamReader(path);

            SitemapIndex xml = (SitemapIndex)serializer.Deserialize(reader);

            reader.Close();
            reader.Dispose();

            return xml;
        }

        #endregion
    }
}
