using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace SitemapModel.Entities
{
    public enum ChangeFreq
    {
        unknow,
        always,
        hourly,
        daily,
        weekly,
        monthly,
        yearly,
        never
    }

    [XmlRoot("url")]
    public class Url
    {
        [XmlElement("loc")]
        public string Loc { get; set; }

        [XmlElement("lastmod")]
        [DefaultValueAttribute(typeof(System.DateTime), "0001-01-01")]
        public DateTime LastMod { get; set; }

        [XmlElement("changefreq")]
        [DefaultValueAttribute(typeof(ChangeFreq), "unknow")]
        public ChangeFreq ChangeFreq { get; set; }

        [XmlElement("priority")]
        [DefaultValueAttribute(0)]
        public decimal Priority { get; set; }
        
        private List<Image> _imageList = new List<Image>();

        [XmlElement(Namespace = "http://www.google.com/schemas/sitemap-image/1.1", ElementName = "image")]
        public List<Image> ImageList
        {
            get { return _imageList; }
            set { _imageList = value; }
        }     
    }
}
