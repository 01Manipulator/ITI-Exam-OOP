using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Answers
{
    internal class Answer : IComparable<Answer>,ICloneable
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";

        public Answer(int id, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Answer text cannot be empty.");
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return $"Answer {{ Id -> {Id}, Text -> {Text} }}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Answer right)
                return Id.Equals(right.Id);
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(Answer? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
