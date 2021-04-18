namespace PQ_API.Classes
{
    public class ContactInfo
    {
        public string ContactId {get; set;}
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }

        public ContactInfo()
        {

        }
        
        public ContactInfo (string contactId, string email, string homePhone, string workPhone, string mobilePhone)
        {
            ContactId = contactId;
            Email = email;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
        }

        public override string ToString()
        {
            return $"ContactId {ContactId}, Email {Email}, HomePhone {HomePhone}, WorkPhone {WorkPhone}, MobilePhone {MobilePhone}";
        }
    }
}