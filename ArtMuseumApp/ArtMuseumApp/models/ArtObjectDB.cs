using SQLite;

namespace ArtMuseumApp.models
{
    [Table("ArtObject")]
    public class ArtObjectDB
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int id { get; set; }
        public string titile { get; set; }
        public string principalOrFirstMaker { get; set; }
        public string longTitle { get; set; }
        public string presentingDate { get; set; }
        public string imageUrl { get; set; }
    }
}
