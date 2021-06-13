using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class ArtObjectPage
    {
        public string id { get; set; }
        public List<object> similarPages { get; set; }
        public string lang { get; set; }
        public string objectNumber { get; set; }
        public List<object> tags { get; set; }
        public string plaqueDescription { get; set; }
        public object audioFile1 { get; set; }
        public object audioFileLabel1 { get; set; }
        public object audioFileLabel2 { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public AdlibOverrides adlibOverrides { get; set; }
    }
}
