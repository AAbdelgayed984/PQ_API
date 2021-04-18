namespace PQ_API.Classes
{
    public class BrandInfo
    {
        public string Brand_CMR_ID { get; set; }
        public string Brand_Name { get; set; }
        public string Brand_EmailAddress { get; set; }

        public BrandInfo(string _Brand_CMR_ID, string _Brand_Name, string _Brand_FromEmailAddress)
        {
            Brand_CMR_ID = _Brand_CMR_ID;
            Brand_Name = _Brand_Name;
            Brand_EmailAddress = _Brand_FromEmailAddress;
        }

        public override string ToString()
        {
            return $"Brand_CMR_ID {Brand_CMR_ID}, Brand_Name {Brand_Name}, Brand_EmailAddress {Brand_EmailAddress}";
        }
    }
}