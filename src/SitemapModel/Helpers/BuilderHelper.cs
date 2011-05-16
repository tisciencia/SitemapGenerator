using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitemapModel.Entities;

namespace SitemapGenerator.Builders
{
    public static class BuilderHelper
    {
        public static Url UrlBuilder(ChangeFreq changeFreq, List<Image> imageList, DateTime lastMod, string loc, decimal priority)
        {         
            return new Url(){
                ChangeFreq = changeFreq,
                ImageList = imageList,
                LastMod = lastMod,
                Loc = loc,
                Priority = priority
            };
        }

        public static Image ImageBuilder()
        {
            return new Image();
        }
    }
}
