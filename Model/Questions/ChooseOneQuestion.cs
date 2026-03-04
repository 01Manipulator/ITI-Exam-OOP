using ITI_Exam.Model.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Questions
{
    internal class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, int marks,AnswerList answers,Answer correctAnswer) : base(header, body, marks)
        {
            if (correctAnswer is null) throw new ArgumentNullException("Correct answer can not be null.");
            if (answers is null) throw new ArgumentNullException("Answers can not be null.");
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return CorrectAnswer.Equals(studentAnswer);
        }

        public override void Display()
        {
            Console.WriteLine($"(Choose One) {Header}");
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
