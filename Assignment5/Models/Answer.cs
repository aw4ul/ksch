namespace Quiz.Core
{
    public class Answer
    {
        public int QuestionId { get; set; }
        public object UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}