using System;

namespace Algorithm
{
    public class Couple
    {
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }

        public TimeSpan AgeDiff
        {
            get
            {
                var ageDiff = (Person2.BirthDate - Person1.BirthDate);
                return ageDiff;
            }
        }

        public override string ToString()
        {
            return $"{Person1.Name} ({Person1.AgeInYears}) and {Person2.Name} ({Person2.AgeInYears})";
        }
    }
}