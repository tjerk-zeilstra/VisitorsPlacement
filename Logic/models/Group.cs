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
           
        }

        public List<Person> People { get; private set; }

        public int AmountOfChildren(DateTime eventDate)
        {
            int aChildren = 0;
            foreach (var person in People)
            {
                if (!person.IsAdult(eventDate))
                {
                    aChildren++;
                }
            }
            return aChildren;
        }

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
