using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class Classification
    {
        public List<string> iconClassIdentifier { get; set; }
        public List<string> iconClassDescription { get; set; }
        public List<object> motifs { get; set; }
        public List<object> events { get; set; }
        public List<object> periods { get; set; }
        public List<string> places { get; set; }
        public List<string> people { get; set; }
        public List<string> objectNumbers { get; set; }
    }
}
