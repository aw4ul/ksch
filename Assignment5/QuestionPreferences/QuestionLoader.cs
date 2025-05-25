using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Quiz.Core;

namespace Quiz.Core
{
    public static class QuestionLoader
    {
        private static readonly Random _rnd = new Random();

        public static List<IQuestion> LoadFromXml(string path)
        {
            var doc = XDocument.Load(path);
            var questions = new List<IQuestion>();
            int idCounter = 1;

            foreach (var q in doc.Root.Elements("question"))
            {
                string type = (string)q.Attribute("type");
                string text = (string)q.Element("text");

                if (type == "SingleChoice")
                {
                    var options = q.Elements("option").Select(o => o.Value).ToList();
                    int correctIndex = int.Parse(q.Element("correct").Value);
                    questions.Add(new SingleChoiceQuestion
                    {
                        Id = idCounter++,
                        Text = text,
                        Options = options,
                        CorrectIndex = correctIndex
                    });
                }
                else if (type == "MultipleChoice")
                {
                    var options = q.Elements("option").Select(o => o.Value).ToList();
                    var correct = q.Elements("correct").Select(c => int.Parse(c.Value)).ToList();
                    questions.Add(new MultipleChoiceQuestion
                    {
                        Id = idCounter++,
                        Text = text,
                        Options = options,
                        CorrectIndexes = correct
                    });
                }
                else if (type == "Text")
                {
                    string correct = q.Element("correct").Value.Trim();
                    questions.Add(new TextQuestion
                    {
                        Id = idCounter++,
                        Text = text,
                        CorrectAnswer = correct
                    });
                }
            }
            return questions.OrderBy(x => _rnd.Next()).ToList();
        }
    }
}