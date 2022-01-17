using Logic.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Factory
{
    public static class GroupFactory
    {
        public static Group MakeGroup(int children, int adults, DateTime eventdate)
        {
            List<Person> people = new();
            for (int i = 0; i < children; i++)
            {
                people.Add(PersonFactory.MakeChild(eventdate));
            }
            for (int i = 0; i < adults; i++)
            {
                people.Add(PersonFactory.MakeAdult(eventdate));
            }

            Group group = new();
            foreach (var person in people)
            {
                group.AddPerson(person);
            }

            return group;
        }
    }
}
