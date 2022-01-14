using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Chair
    {
        public Chair()
        {

        }
        public Chair(int chairnumber)
        {
            ChairNumber = chairnumber;
        }
        public Person ChairPerson { get; set; }
        public int ChairNumber { get; set; }

        public void AddPerson(Person person)
        {
            ChairPerson = person;
        }

        public string ChairToString(DateTime date)
        {
            StringBuilder chair = new();
            if (ChairPerson == null)
            {
                chair.AppendFormat("( )");
            }
            else
            {
                chair.AppendFormat("({0})", ChairPerson.PersonToString(date));
            }
            return chair.ToString();
        }
    }
}
