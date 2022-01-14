using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Person 
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsAdult(DateTime eventDate)
        {
            return DateOfBirth.AddYears(18) <= eventDate;
        }

        public string PersonToString(DateTime date)
        {
            StringBuilder person = new();
            if (IsAdult(date))
            {
                person.AppendLine("A");
            }
            else
            {
                person.AppendLine("K");
            }
            return person.ToString();

        }
    }
}
