using ITI_Exam.ITI_Exam;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Text;

namespace ITI_Exam.Model.Answers
{
    internal class AnswerList : Repository<Answer>
    {

        public Answer? GetById(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i]?.Id == id) return this[i];
            }
            return null;
        }

        public override string ToString()
        {
            return string.Join(", ", GetAll());
        }

    }
}
