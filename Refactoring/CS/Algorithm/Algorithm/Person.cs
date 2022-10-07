using System;

namespace Algorithm
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsOlderThan(Person person)
        {
            bool isOlderThan = this.BirthDate < person.BirthDate;
            return isOlderThan;
        }

        public decimal AgeInYears
        {
            get
            {
                var years = (DateTime.Today - BirthDate).TotalDays / 365;
                return decimal.Parse(years.ToString("F1"));
            }
        }
    }
}