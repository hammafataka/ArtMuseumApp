using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class PrincipalMaker
    {
        public string name { get; set; }
        public string unFixedName { get; set; }
        public string placeOfBirth { get; set; }
        public string dateOfBirth { get; set; }
        public object dateOfBirthPrecision { get; set; }
        public string dateOfDeath { get; set; }
        public object dateOfDeathPrecision { get; set; }
        public string placeOfDeath { get; set; }
        public List<string> occupation { get; set; }
        public List<string> roles { get; set; }
        public object nationality { get; set; }
        public object biography { get; set; }
        public List<string> productionPlaces { get; set; }
        public object qualification { get; set; }
    }
}
