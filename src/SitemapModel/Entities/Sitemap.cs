using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace SitemapModel.Entities
{
    [XmlRoot("sitemap")]
    public class Sitemap
    {
        [XmlElement("loc")]
        public string Loc { get; set; }

        [XmlElement("lastmod")]
        [DefaultValueAttribute(typeof(System.DateTime), "0001-01-01")]
        public DateTime LastMod { get; set; }
    }
}
