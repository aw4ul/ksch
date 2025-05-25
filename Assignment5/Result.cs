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
    public class Result
    {
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Points { get; set; }
        public string Grade { get; set; }
    }
}