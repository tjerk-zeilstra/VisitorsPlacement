using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic.models
{
    public class Group
    {
        public Group()
        {
            People = new();
        }
        public List<Person> People = new();

        public void AddPerson(Person person)
        {
            People.Add(person);
        }
    }
}
