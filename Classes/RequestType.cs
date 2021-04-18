namespace PQ_API.Classes
{
    public class RequestType
    {
        public string TypeOfRequest_En { get; set; }
        public string TypeOfRequest_Fq { get; set; }
        public string TypeOfRequest_lbl_En { get; set; }
        public string TypeOfRequest_lbl_Fq { get; set; }

        public RequestType(string sTypeOfRequest_En, string sTypeOfRequest_Fq, string sTypeOfRequest_lbl_En, string sTypeOfRequest_lbl_Fq)
        {
            TypeOfRequest_En = sTypeOfRequest_En;
            TypeOfRequest_Fq = sTypeOfRequest_Fq;
            TypeOfRequest_lbl_En = sTypeOfRequest_lbl_En;
            TypeOfRequest_lbl_Fq = sTypeOfRequest_lbl_Fq;
        }
    }
}