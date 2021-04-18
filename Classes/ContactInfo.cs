namespace PQ_API.Classes
{
    public class ContactInfo
    {
        public string ContactId {get; set;}
        public string ContactType {get; set;}
        public string ContactDetails {get; set;}

        public ContactInfo()
        {

        }
        
        public ContactInfo (string contactId, string contactType, string contactDetails)
        {
            ContactId = contactId;
            ContactType = contactType;
            ContactDetails = contactDetails;
        }

        public override string ToString()
        {
            return $"ContactId {ContactId}, ContactType {ContactType}, ContactDetails {ContactDetails}";
        }
    }
}