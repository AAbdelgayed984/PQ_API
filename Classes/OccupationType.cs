using System;

namespace PQ_API.Classes
{
    public class OccupationType
    {
        public string OccupationTypeId { get; set; }
        public string Description { get; set; }

        public OccupationType(string _OccupationTypeId, string _Description)
        {
            OccupationTypeId = _OccupationTypeId;
            Description = _Description;
        }
    }
}