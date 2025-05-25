using Quiz.Core;

namespace Quiz.Factories
{
    public class TextQuestionFactory : IQuestionFactory
    {
        public IQuestion CreateQuestion(dynamic data)
        {
            return new TextQuestion
            {
                Id = data.Id,
                Text = data.Text,
                Category = data.Category,
                CorrectAnswer = data.CorrectAnswer
            };
        }
    }
}