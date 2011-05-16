using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using SitemapModel.Entities;
using SitemapGenerator.Builders;
using SitemapEngines;

namespace SitemapGeneratorTest
{
    [TestFixture]
    public class SitemapGeneratorTest
    {
        [Test]
        public void Deve_gerar_os_arquivos_de_sitemap()
        {
            List<Url> urls = new List<Url>();
            
            urls.Add(BuilderHelper.UrlBuilder(ChangeFreq.always, null, DateTime.Now, string.Empty, 0.9m));
            urls.Add(BuilderHelper.UrlBuilder(ChangeFreq.always, null, DateTime.Now, string.Empty, 0.9m));

            SitemapEngine engine = new SitemapEngine()
            {
                UrlSite = "www.code4dev.net",
                Urls = urls,
                SitemapPath = @"C:\",
                SitemapName = "code4dev",
                MaxUrlSitemap = 10
            };
            
            engine.Builder();
        }
    }
}
