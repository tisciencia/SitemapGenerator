using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace SitemapModel.Entities
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9", ElementName = "urlset", IsNullable = false)]
    public class UrlSet
    {
        private List<Url> _urlList = new List<Url>();

        [XmlElement("url")]
        public List<Url> UrlList
        {
            get { return _urlList; }
        }

        #region Serialization

        public void Serialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UrlSet), "");
            StreamWriter writer = new StreamWriter(path);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ns.Add("image", "http://www.google.com/schemas/sitemap-image/1.1");
            ns.Add("video", "http://www.google.com/schemas/sitemap-video/1.1");
            
            serializer.Serialize(writer, this, ns);

            writer.Close();
            writer.Dispose();
        }

        public static UrlSet Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UrlSet));

            StreamReader reader = new StreamReader(path);

            UrlSet xml = (UrlSet)serializer.Deserialize(reader);

            reader.Close();
            reader.Dispose();

            return xml;
        }

        #endregion
    }
}
