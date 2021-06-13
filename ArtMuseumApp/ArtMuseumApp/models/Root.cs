using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class Root
    {
        public int elapsedMilliseconds { get; set; }
        public int count { get; set; }
        public List<ArtObject> artObjects { get; set; }
        public List<Facet2> facets { get; set; }
        public ArtObject artObject { get; set; }
        public ArtObjectPage artObjectPage { get; set; }
        public List<Level> levels { get; set; }
    }
}
