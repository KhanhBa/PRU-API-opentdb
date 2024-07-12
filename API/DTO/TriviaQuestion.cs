namespace TriviaApi.Models
{
    public class TriviaQuestion
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public string Question { get; set; }
        public string Correct_Answer { get; set; }
        public List<string> Incorrect_Answers { get; set; }
    }
    public class TriviaResponse
    {
        public int Response_Code { get; set; }
        public List<TriviaQuestion> Results { get; set; }
    }
}
