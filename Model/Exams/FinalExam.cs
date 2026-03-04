using ITI_Exam.Enum;
using ITI_Exam.Model.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, Subject subject) : base(time, subject) { }

        public override void ShowExam()
        {
            Console.WriteLine("\nFINAL EXAM");
            foreach (var q in Questions)
            {
                q.Display();
                QuestionAnswerDictionary[q] = q.ReadAnswerFromUser();
            }
        }

        public override void FinishExam()
        {
            SetMode(ExamMode.Finished);
            Console.WriteLine("\nSubmitted Answers:");
            foreach (var q in Questions)
            {
                QuestionAnswerDictionary.TryGetValue(q, out Answer sa);
                Console.WriteLine($"Q: {q.Body}  |  Answered: {sa}");
            }
            CorrectExam();
        }
    }
}
