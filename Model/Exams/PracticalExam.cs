using ITI_Exam.Enum;
using ITI_Exam.Model.Answers;
using ITI_Exam.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Exams
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int time, Subject subject) : base(time, subject) { }

        public override void ShowExam()
        {
            Console.WriteLine("\nPRACTICE EXAM");
            foreach (var q in Questions)
            {
                q.Display();
                QuestionAnswerDictionary[q] = q.ReadAnswerFromUser();
            }
        }

        public override void FinishExam()
        {
            SetMode(ExamMode.Finished);
            Console.WriteLine("\nReview:");
            foreach (var q in Questions)
            {
                QuestionAnswerDictionary.TryGetValue(q, out Answer sa);
                string correct = q.CorrectAnswers.ToString();
                Console.WriteLine($"\nQ: {q.Body}");
                Console.WriteLine($"  Submitted Answer: {sa}");
                Console.WriteLine($"  Right Answer    : {correct}");
                Console.WriteLine($"  Final Result    : {(q.CheckAnswer(sa) ? "Correct" : "Wrong")}");
            }
            CorrectExam();
        }
    }
}
