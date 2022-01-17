using Logic.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Factory
{
    public static class PersonFactory
    {
        public static Person MakeAdult(DateTime eventdate)
        {
            DateTime dateOfBirth = eventdate.AddYears(-30);
            Person person = new();
            person.DateOfBirth = dateOfBirth;
            return person;
        }

        public static Person MakeChild(DateTime eventdate)
        {
            DateTime dateOfBirth = eventdate.AddYears(-1);
            Person person = new();
            person.DateOfBirth = dateOfBirth;
            return person;
        }
    }
}
