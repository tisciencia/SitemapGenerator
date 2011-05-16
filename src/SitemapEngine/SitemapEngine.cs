using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SitemapModel.Entities;

namespace SitemapEngines
{
    public class SitemapEngine
    {
        public int MaxUrlSitemap { get; set; }
        public string SitemapName {get; set; }
        public string SitemapPath { get; set; }
        public string UrlSite { get; set; }
        public List<Url> Urls { get; set; }
        private List<string> _SitemapNames;
        private SitemapIndex _SitemapIndex;

        public SitemapEngine()
        {
            _SitemapIndex = new SitemapIndex();            
        }

        public void Builder()
        {
            if (String.IsNullOrEmpty(this.SitemapPath) 
                || String.IsNullOrEmpty(this.SitemapName) 
                || this.Urls.Count == 0
                || MaxUrlSitemap <= 0)
                throw new ArgumentException("Parâmetros para geração do sitemap inválidos. Verifique: [SitemapName, SitemapPath, Urls]");

            BuildSiteMaps();
            BuilderSiteMapIndex();
        }

        private void BuildSiteMaps()
        {
            _SitemapNames = new List<string>();
            for (int i = 0; i < GetQuantidadeSiteMap(); i++)
            {
                BuildUrlSet(SubList(i * MaxUrlSitemap, MaxUrlSitemap), i);
            }
        }

        private int GetQuantidadeSiteMap()
        {
            if (Urls.Count > MaxUrlSitemap)
                return (int)Math.Ceiling((decimal)this.Urls.Count / MaxUrlSitemap);
            else
                return 1;
        }

        private void BuilderSiteMapIndex()
        {
            foreach (var name in _SitemapNames)
            {
                Sitemap siteMap = new Sitemap();
                siteMap.Loc = String.Format("{0}/{1}", UrlSite, name);
                siteMap.LastMod = DateTime.Now;
                _SitemapIndex.SiteMapList.Add(siteMap);
            }
            _SitemapIndex.Serialize(Path.Combine(SitemapPath, "Sitemap.xml"));
        }

        private List<Url> SubList(int posIni, int posFim)
        {
            return this.Urls.Skip(posIni).Take(posFim).ToList();
        }

        private void BuildUrlSet(List<Url> urls, int sequence)
        {
            this._SitemapNames.Add(String.Format("{0}{1}.xml", this.SitemapName, sequence + 1));
            var urlSet = new UrlSet();
            urlSet.UrlList.AddRange(urls);
            urlSet.Serialize(Path.Combine(SitemapPath, String.Format("{0}{1}.xml", this.SitemapName, sequence + 1)));
        }
    }
}
