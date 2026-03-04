using ITI_Exam.Model;
using ITI_Exam.Model.Exams;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Event
{
    internal delegate void ExamStartedHandler(object sender, ExamEventArgs e);
    internal class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }

        public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject;
            Exam = exam;
        }
    }
}
