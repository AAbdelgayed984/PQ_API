using System;

namespace PQ_API.Classes
{
    public class IncomeType
    {
        public string IncomeTypeId { get; set; }
        public string Description { get; set; }

        public IncomeType(string _IncomeTypeId, string _Description)
        {
            IncomeTypeId = _IncomeTypeId;
            Description = _Description;
        }
    }
}