using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization.Attributes;

namespace Needs.Api.Models
{
    public class EsdEntry
    {
        public EsdEntry()
        {
            Id = IdGen.Instance.GenerateId();
            AlternateLabels = new Collection<string>();
            ParentEsdIds = new Collection<int>();
        }

        [BsonId(IdGenerator = typeof(FlakeIdGenerator))]
        public long Id { get; private set; }

        public int EsdId { get; set; }
        public string Label { get; set; }
        public Collection<string>  AlternateLabels { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Collection<int> ParentEsdIds { get; set; }
    }
}