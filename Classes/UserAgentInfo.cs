namespace PQ_API.Classes
{
    public class UserAgentInfo
    {
        public string UserAgent { get; set; }

        public string RequestDateTime { get; set; }

        public string IPAddress { get; set; }

        public string FullName { get; set; }

        public UserAgentInfo(string userAgent, string requestDateTime, string ipAddress)
        {
            UserAgent = userAgent;
            RequestDateTime = requestDateTime;
            IPAddress = ipAddress;
        }

        public UserAgentInfo(string userAgent, string requestDateTime, string ipAddress, string fullName)
        {
            UserAgent = userAgent;
            RequestDateTime = requestDateTime;
            IPAddress = ipAddress;
            FullName = fullName;
        }

    }
}