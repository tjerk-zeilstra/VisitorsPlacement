using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Person : IComparable<Person>
    {
        public Person()
        {
            
        }

        public Person(DateTime eventDate)
        {
            Adult = IsAdult(eventDate);
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Adult { get; set; }

        public bool IsAdult(DateTime eventDate)
        {
            Adult = DateOfBirth.AddYears(18) <= eventDate;
            return Adult;
        }

        #region Icomparable
        public int CompareTo(Person other)
        {
            if (this.Adult == other.Adult) return 0;
            else return (this.Adult == true) ? 1 : -1;
        }
        #endregion

        public string PersonToString(DateTime date)
        {
            StringBuilder person = new();
            if (IsAdult(date))
            {
                person.Append('A');
            }
            else
            {
                person.Append('K');
            }
            return person.ToString();

        }
    }
}
