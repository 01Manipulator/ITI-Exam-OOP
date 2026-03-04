using ITI_Exam.Model.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Questions
{
    internal class ChooseAllQuestion : Question
    {
        public AnswerList CorrectAnswers;
        public ChooseAllQuestion(string header, string body, int marks, AnswerList answers,AnswerList correctAnswers) : base(header, body, marks)
        {
            if (correctAnswers is null) throw new ArgumentNullException("Correct answer can not be null.");
            if (answers is null) throw new ArgumentNullException("Answers can not be null.");
            CorrectAnswers = correctAnswers;
            Answers = answers;
        }
        public override bool CheckAnswer(Answer sa)
        {
            if (sa == null) return false;
            string[] parts = sa.Text.Split(',');
            if (parts.Length != CorrectAnswers.Count) return false;
            for(int i = 0; i < CorrectAnswers.Count;i++)
            {
                bool found = false;
                foreach (var p in parts)
                    if (int.TryParse(p.Trim(), out int id) && id == CorrectAnswers[i].Id) { found = true; break; }
                if (!found) return false;
            }
            return true;
        }

        public override void Display()
        {
            Console.WriteLine($"\n(Choose All Correct) {Header}");
            Console.WriteLine($"  {Body}");
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine($"  {Answers[i]}");
        }

        public override Answer ReadAnswerFromUser()
        {
            Console.Write("Answer (e.g. 1,2): ");
            string input = Console.ReadLine();
            return new Answer(0, input);
        }
    }
}
