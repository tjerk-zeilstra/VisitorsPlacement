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

        public void SortPersons(DateTime eventDate)
        {
            for (int i = 0; i < People.Count; i++)
            {
                if (!People[i].IsAdult(eventDate))
                {
                    var temp = People[i];
                    People.Remove(People[i]);
                    People.Insert(0, temp);
                }
            }
        }
    }
}
