using System;
using System.Collections.Generic;
using System.Linq;
using Quiz.Core;

namespace Quiz.Factories
{
    public class TestGenerator
    {
        private readonly List<IQuestionFactory> _factories;

        public TestGenerator(IEnumerable<IQuestionFactory> factories)
        {
            _factories = factories.ToList();
        }

        public List<IQuestion> GenerateRandomTest(List<dynamic> questionsData, int count)
        {
            var rnd = new Random();
            var selected = questionsData.OrderBy(x => rnd.Next()).Take(count).ToList();
            var result = new List<IQuestion>();

            foreach (var data in selected)
            {
                IQuestionFactory factory = _factories.FirstOrDefault(f =>
                    f.GetType().Name.StartsWith(data.Type + "QuestionFactory", StringComparison.OrdinalIgnoreCase));
                if (factory != null)
                    result.Add(factory.CreateQuestion(data));
            }
            return result;
        }
    }
}