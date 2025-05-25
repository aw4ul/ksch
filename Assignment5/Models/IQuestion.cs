namespace Quiz.Core
{
    public interface IQuestion
    {
        int Id { get; }
        string Text { get; }
        string Category { get; }
        string GetQuestionText();
        bool CheckAnswer(object userAnswer);
        string DisplayOptions(); // Для відображення варіантів
    }
}