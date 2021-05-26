using System;

namespace PQ_API.Classes
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }


        public Product(string _ProductID, string _ProductName, DateTime? _DateStart, DateTime? _DateEnd)
        {
            ProductID = _ProductID;
            ProductName = _ProductName;
            DateStart = _DateStart;
            DateEnd = _DateEnd;
        }
    }
}