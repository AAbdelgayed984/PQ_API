namespace PQ_API.Classes
{
    public class RubiDBSettings
    {
        public string ServerName { get; set; }
        public string DbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ConnectionString 
        { 
            get
            {
                return $"data source={ServerName}; initial catalog={DbName}; user id={UserName}; password={Password}";
            }
        }
    }
}
