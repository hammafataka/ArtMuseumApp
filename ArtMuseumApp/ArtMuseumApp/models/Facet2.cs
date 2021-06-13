using System.Collections.Generic;


namespace ArtMuseumApp.models
{
    public class Facet2
    {
        public string key { get; set; }
        public int value { get; set; }
        public List<Facet2> facets { get; set; }
        public string name { get; set; }
        public int otherTerms { get; set; }
        public int prettyName { get; set; }
    }
}
