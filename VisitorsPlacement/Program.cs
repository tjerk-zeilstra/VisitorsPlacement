using System;
using System.Collections.Generic;
using Logic.Logic;
using Logic.models;

namespace VisitorsPlacement
{
    public class SubClass : IComparable<SubClass>
    {
        public SubClass(int count)
        {
            Count = count;
        }
        public int Count { get; set; }
        public int CompareTo(SubClass other)
        {
            if (this.Count < other.Count) return 1;
            else if (this.Count > other.Count) return -1;
            else return 0;
        }
    }
    public class Testclass : IComparable<Testclass>
    {
        public List<SubClass> subClasses = new();
        public int CompareTo(Testclass other)
        {
            if (this.subClasses.Count < other.subClasses.Count) return 1;
            else if (this.subClasses.Count > other.subClasses.Count) return -1;
            else return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime eventdate = new(2022,2,4);
            PlacementEvent placementEvent = new PlacementEvent(eventdate);

            #region Setup
            //Make Groups
            Group group1 = new();
            Group group2 = new();

            //AddGroup
            placementEvent.AddGroup(group1);

            //FillGroups
            for (int i = 0; i < 3; i++)
            {
                group1.AddPerson(new Person() { 
                    DateOfBirth = new DateTime(1999, 1, 1),
                    Name = "test adult"
                });
                group1.AddPerson(new Person()
                {
                    DateOfBirth = new DateTime(2021, 1, 1),
                    Name = "test kind"
                });
            }
            for (int i = 0; i < 5; i++)
            {
                group2.AddPerson(new Person()
                {
                    DateOfBirth = new DateTime(1999, 1, 1),
                    Name = "test adult"
                });
            }

            //AddSections
            placementEvent.AddSection(3, 5);
            placementEvent.AddSection(1, 4);

            #endregion

            placementEvent.Place();

        }
    }
}
