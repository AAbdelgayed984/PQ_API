using System;

namespace PQ_API.Classes
{
    public class IndustrySector
    {
        public string IndustrySectorId { get; set; }
        public string Description { get; set; }

        public IndustrySector(string _IndustrySectorId, string _Description)
        {
            IndustrySectorId = _IndustrySectorId;
            Description = _Description;
        }
    }
}