using System;
using System.Collections.Generic;
using System.Text;

namespace ArtMuseumApp.models
{
    public class ArtObject
    {
        public Links links { get; set; }
        public string id { get; set; }
        public string objectNumber { get; set; }
        public string title { get; set; }
        public bool hasImage { get; set; }
        public string principalOrFirstMaker { get; set; }
        public string longTitle { get; set; }
        public bool showImage { get; set; }
        public bool permitDownload { get; set; }
        public WebImage webImage { get; set; }
        public HeaderImage headerImage { get; set; }
        public List<string> productionPlaces { get; set; }
        public string priref { get; set; }
        public string language { get; set; }
        public object copyrightHolder { get; set; }
        public List<string> titles { get; set; }
        public string description { get; set; }
        public object labelText { get; set; }
        public List<string> objectTypes { get; set; }
        public List<string> objectCollection { get; set; }
        public List<object> makers { get; set; }
        public List<PrincipalMaker> principalMakers { get; set; }
        public string plaqueDescriptionDutch { get; set; }
        public string plaqueDescriptionEnglish { get; set; }
        public string principalMaker { get; set; }
        public object artistRole { get; set; }
        public List<object> associations { get; set; }
        public Acquisition acquisition { get; set; }
        public List<object> exhibitions { get; set; }
        public List<string> materials { get; set; }
        public List<object> techniques { get; set; }
        public Dating dating { get; set; }
        public Classification classification { get; set; }
        public List<string> historicalPersons { get; set; }
        public List<object> inscriptions { get; set; }
        public List<string> documentation { get; set; }
        public List<object> catRefRPK { get; set; }
        public List<Dimension> dimensions { get; set; }
        public List<object> physicalProperties { get; set; }
        public string physicalMedium { get; set; }
        public string subTitle { get; set; }
        public string scLabelLine { get; set; }
        public Label label { get; set; }
        public string location { get; set; }
    }
}
