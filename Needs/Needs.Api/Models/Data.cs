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
        public Collection<string> AlternateLabels { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Collection<int> ParentEsdIds { get; set; }
    }

    public class Need
    {
        public Need()
        {
            AppliesToAllOrganisations = false;
        }

        public int Id { get; private set; }
        public string Role { get; set; }
        public string Goal { get; set; }
        public string Benefit { get; set; }
        public Collection<int> OrganisationIds { get; set; }
        public Collection<string> Justifications { get; set; }
        public string Impact { get; set; }
        public string MetWhen { get; set; }
        public int YearlyUserContacts { get; set; }
        public int YearlySiteViews { get; set; }
        public int YearlyNeedViews { get; set; }
        public int YearlySearches { get; set; }
        public string OtherEvidence { get; set; }
        public string Legislation { get; set; }
        public bool AppliesToAllOrganisations { get; set; }
        public int? DuplicateOf { get; set; }

        public NeedStatus Status { get; set; }
    }

    public enum Status
    {
        Proposed,
        Not_valid,
        Valid,
        Valid_with_conditions
    }

    public class NeedStatus
    {
        public Status Status { get; set; }
        public string Description { get; set; }
        public Collection<string> Reasons { get; set; }
        public string AdditionalComments { get; set; }
        public string ValidationConditions { get; set; }
    }
}