using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Quiz.Core;

namespace Quiz
{
    public partial class Form1 : Form
    {
        private class TopicState
        {
            public List<IQuestion> Questions { get; set; }
            public int CurrentQuestion { get; set; }
            public int Score { get; set; }
            public bool Finished { get; set; }
        }

        private Dictionary<string, string> topicFiles = new Dictionary<string, string>();
        private Dictionary<string, TopicState> topicStates = new Dictionary<string, TopicState>();
        private string currentTopic = null;

        private TextBox txtAnswer;
        private List<RadioButton> radioButtons;
        private List<CheckBox> checkBoxes;

        public Form1()
        {
            InitializeComponent();
            InitTopics();
        }

        private void InitTopics()
        {
            topicFiles.Clear();
            topicFiles.Add("Географія", "geography.xml");
            topicFiles.Add("Історія", "history.xml");
            topicFiles.Add("Наука", "science.xml");

            comboBoxTopics.Items.Clear();
            foreach (var t in topicFiles.Keys)
                comboBoxTopics.Items.Add(t);

            if (comboBoxTopics.Items.Count > 0)
                comboBoxTopics.SelectedIndex = 0;
        }

        private void comboBoxTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTopic = comboBoxTopics.SelectedItem.ToString();

            if (topicStates.ContainsKey(currentTopic))
            {
                ShowCurrentQuestionOrResult();
                ShowOverallIfAllFinished();
                return;
            }

            if (topicFiles.TryGetValue(currentTopic, out string path))
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show($"Файл \"{path}\" не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetUI();
                    return;
                }
                var questions = QuestionLoader.LoadFromXml(path);
                topicStates[currentTopic] = new TopicState
                {
                    Questions = questions,
                    CurrentQuestion = 0,
                    Score = 0,
                    Finished = false
                };
                btnSubmit.Enabled = true;
                ShowCurrentQuestionOrResult();
                ShowOverallIfAllFinished();
            }
        }

        private void ShowCurrentQuestionOrResult()
        {
            answerPanel.Controls.Clear();
            lblResult.Text = "";

            var state = topicStates[currentTopic];
            txtAnswer = null;
            radioButtons = null;
            checkBoxes = null;

            if (state.Finished || state.CurrentQuestion >= state.Questions.Count)
            {
                lblQuestion.Text = "Тест завершено!";
                btnSubmit.Enabled = false;
                ShowResult(state.Score, state.Questions.Count);
                state.Finished = true;
                ShowOverallIfAllFinished();
                return;
            }

            btnSubmit.Enabled = true;
            var question = state.Questions[state.CurrentQuestion];
            lblQuestion.Text = $"{state.CurrentQuestion + 1}. {question.Text}";

            if (question is SingleChoiceQuestion scq)
            {
                radioButtons = new List<RadioButton>();
                for (int i = 0; i < scq.Options.Count; i++)
                {
                    var rb = new RadioButton
                    {
                        Text = scq.Options[i],
                        Location = new Point(15, 10 + i * 32),
                        Width = 450,
                        Font = new Font("Segoe UI", 11F)
                    };
                    answerPanel.Controls.Add(rb);
                    radioButtons.Add(rb);
                }
            }
            else if (question is MultipleChoiceQuestion mcq)
            {
                checkBoxes = new List<CheckBox>();
                for (int i = 0; i < mcq.Options.Count; i++)
                {
                    var cb = new CheckBox
                    {
                        Text = mcq.Options[i],
                        Location = new Point(15, 10 + i * 32),
                        Width = 450,
                        Font = new Font("Segoe UI", 11F)
                    };
                    answerPanel.Controls.Add(cb);
                    checkBoxes.Add(cb);
                }
            }
            else if (question is TextQuestion)
            {
                txtAnswer = new TextBox
                {
                    Location = new Point(15, 10),
                    Width = 400,
                    Font = new Font("Segoe UI", 11F)
                };
                answerPanel.Controls.Add(txtAnswer);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentTopic) || !topicStates.ContainsKey(currentTopic))
                return;

            var state = topicStates[currentTopic];
            if (state.Finished || state.CurrentQuestion >= state.Questions.Count)
                return;

            var question = state.Questions[state.CurrentQuestion];
            object userAnswer = null;
            bool isCorrect = false;

            if (question is SingleChoiceQuestion && radioButtons != null)
            {
                int selectedIndex = radioButtons.FindIndex(rb => rb.Checked);
                userAnswer = selectedIndex;
                isCorrect = question.CheckAnswer(userAnswer);
            }
            else if (question is MultipleChoiceQuestion && checkBoxes != null)
            {
                var selectedIndexes = checkBoxes
                    .Select((cb, idx) => new { cb, idx })
                    .Where(x => x.cb.Checked)
                    .Select(x => x.idx)
                    .ToList();
                userAnswer = selectedIndexes;
                isCorrect = question.CheckAnswer(userAnswer);
            }
            else if (question is TextQuestion && txtAnswer != null)
            {
                userAnswer = txtAnswer.Text;
                isCorrect = question.CheckAnswer(userAnswer);
            }

            if (isCorrect) state.Score += 10;
            lblResult.Text = isCorrect ? "Вірно!" : "Невірно!";
            lblResult.ForeColor = isCorrect ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43);

            state.CurrentQuestion++;
            Timer t = new Timer();
            t.Interval = 600;
            t.Tick += (s, ev) =>
            {
                t.Stop();
                ShowCurrentQuestionOrResult();
                ShowOverallIfAllFinished();
            };
            t.Start();
        }

        private void ShowResult(int score, int total)
        {
            int correctAnswers = score / 10;
            double percent = (double)correctAnswers / total;
            int grade = (int)Math.Round(percent * 100);
            Color gradeColor = GetGradeColor(grade);

            lblResult.Text = $"Оцінка: {grade}\nПравильних відповідей: {correctAnswers} з {total}";
            lblResult.ForeColor = gradeColor;
        }

        private void ShowOverallIfAllFinished()
        {
            if (topicFiles.Keys.All(k => topicStates.ContainsKey(k) && topicStates[k].Finished))
            {
                int sumScore = topicStates.Values.Sum(s => s.Score);
                int sumTotalQuestions = topicStates.Values.Sum(s => s.Questions.Count);
                int correctAnswers = sumScore / 10;
                double percent = (double)correctAnswers / sumTotalQuestions;
                int grade = (int)Math.Round(percent * 100);
                Color gradeColor = GetGradeColor(grade);

                lblOverall.Text = $"Загальна оцінка: {grade}\nПравильних відповідей: {correctAnswers} з {sumTotalQuestions}";
                lblOverall.ForeColor = gradeColor;
            }
            else
            {
                lblOverall.Text = "";
            }
        }

        private Color GetGradeColor(int grade)
        {
            if (grade >= 90) return Color.FromArgb(39, 174, 96); // зелений
            if (grade >= 70) return Color.FromArgb(241, 196, 15); // жовтий
            if (grade >= 50) return Color.FromArgb(52, 152, 219); // синій
            return Color.FromArgb(192, 57, 43); // червоний
        }

        private void ResetUI()
        {
            lblQuestion.Text = "";
            answerPanel.Controls.Clear();
            btnSubmit.Enabled = false;
            lblResult.Text = "";
            lblOverall.Text = "";
        }
    }
}