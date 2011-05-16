using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace SitemapModel.Entities
{
    [XmlRoot(ElementName = "image", IsNullable = false)]
    public class Image
    {
        [XmlElement("loc")]
        public string Loc { get; set; }

        [XmlElement("caption")]
        public string Caption { get; set; }

        [XmlElement("geo_location")]
        public string GeoLocation { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("license")]
        public string License { get; set; }
    }
}
