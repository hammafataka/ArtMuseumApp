using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class Dimension
    {
        public string unit { get; set; }
        public string type { get; set; }
        public object part { get; set; }
        public string value { get; set; }
    }
}
