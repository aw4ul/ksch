using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Collections;
namespace Quiz.Core
{
    public abstract class Question : IQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }

        public virtual string GetQuestionText() => Text;

        public abstract bool CheckAnswer(object userAnswer);

        public abstract string DisplayOptions();
    }
}