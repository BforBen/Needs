using System.Collections.ObjectModel;

namespace Needs.Api.Models
{
    public class EsdEntry
    {
        public EsdEntry()
        {
            AlternateLabels = new Collection<string>();
            ParentEsdIds = new Collection<int>();
        }

        //[MongoDB.Bson.Serialization.Attributes.BsonElement]
        public int Id { get; set; }

        public int EsdId { get; set; }
        public string Label { get; set; }
        public Collection<string>  AlternateLabels { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Collection<int> ParentEsdIds { get; set; }
    }
}