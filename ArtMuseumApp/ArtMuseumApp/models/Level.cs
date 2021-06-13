using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class Level
    {
        public string name { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<Tile> tiles { get; set; }
    }
}
