
namespace PQ_API.Classes
{
    public class FAQ
    {
        public string Question { get; set; }
        public string Question_Fq { get; set; }
        public string Answer { get; set; }
        public string Answer_Fq { get; set; }

        public FAQ(string question, string question_Fq, string answer, string answer_Fq)
        {
            Question = question;
            Question_Fq = question_Fq;
            Answer = answer;
            Answer_Fq = answer_Fq;
        }

        public override string ToString()
        {
            return $"Question {Question}, Question_Fq {Question_Fq}, Answer {Answer}, Answer_Fq {Answer_Fq}";
        }
    }
}