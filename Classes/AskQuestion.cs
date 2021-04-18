using System.ComponentModel.DataAnnotations;

namespace PQ_API.Classes
{
    public class AskQuestion
    {
        [Required]
        public string CMR_ID { get; set; }
        [Required]
        public string RMR_ID { get; set; }
        [Required]
        public string RequestType { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public string ContactInformation { get; set; }
        [Required]
        public string ContactTime { get; set; }

        public AskQuestion(string cmr_id, string rmr_id, string requestType, string comments, string contactInformation, string contactTime)
        {
            CMR_ID = cmr_id;
            RMR_ID = rmr_id;
            RequestType = requestType;
            Comments = comments;
            ContactInformation = contactInformation;
            ContactTime = contactTime;
        }
    }
}