using Quiz.Core;

namespace Quiz.Factories
{
    public interface IQuestionFactory
    {
        IQuestion CreateQuestion(dynamic data);
    }
}