using ITI_Exam.Model.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Questions
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks, Answer correctAnswer) : base(header, body, marks)
        {
            if (correctAnswer is null) throw new ArgumentNullException("Correct answer can not be null.");
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
            CorrectAnswers.Add(correctAnswer);
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            if (CorrectAnswers.Count == 0) throw new InvalidOperationException("No correct answers assigned to this question.");
            return CorrectAnswers[0].Equals(studentAnswer);
        }

        public override void Display()
        {
            Console.WriteLine($"(T/F) {Header}");
            Console.WriteLine($"  {Body}");
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine($"  {Answers[i]}");
        }

        public override Answer ReadAnswerFromUser()
        {
            Answer selected = null;
            while (selected == null)
            {
                Console.Write("Answer (1: True, 2: False): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    selected = Answers?.GetById(id);
                }
                if (selected == null)
                {
                    Console.WriteLine("Invalid ID. Please choose 1 or 2.");
                }
            }
            return selected;
        }
    }
}
