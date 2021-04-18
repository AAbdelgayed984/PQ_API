namespace PQ_API.Classes
{
    public class StreetType
    {
        public string XSYSst_ID { get; set; }
        public string XSYSst_Code { get; set; }
        public string XSYSst_Description { get; set; }

        public StreetType(string xSYSst_ID, string xSYSst_Code, string xSYSst_Description)
        {
            XSYSst_ID = xSYSst_ID;
            XSYSst_Code = xSYSst_Code;
            XSYSst_Description = xSYSst_Description;
        }

        public override string ToString()
        {
            return $"XSYSst_Code {XSYSst_ID}, XSYSst_Code {XSYSst_Code}, XSYSst_Description {XSYSst_Description}";
        }
    }
}
