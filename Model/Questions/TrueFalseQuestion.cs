using ITI_Exam.Model.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Questions
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks,Answer correctAnswer) : base(header, body, marks)
        {
            if (correctAnswer is null) throw new ArgumentNullException("Correct answer can not be null.");
            Answers.Add(new Answer(1,"True"));
            Answers.Add(new Answer(1, "False"));
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return CorrectAnswer.Equals(studentAnswer);
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
            Console.Write("Answer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                return Answers?.GetById(id);
            return null;
        }
    }
}
