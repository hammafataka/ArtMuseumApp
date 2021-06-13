using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class HeaderImage
    {
        public string guid { get; set; }
        public int offsetPercentageX { get; set; }
        public int offsetPercentageY { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
    }
}
