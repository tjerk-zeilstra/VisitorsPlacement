using System;
using System.Collections.Generic;
using Logic.Logic;
using Logic.models;
using Logic.Factory;

namespace VisitorsPlacement
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime eventdate = new(2022,2,4);
            PlacementEvent placementEvent = new(eventdate);
            Random random = new();

            #region Setup
            //Make Groups
            List<Group> groups = new();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(GroupFactory.MakeGroup(random.Next(3, 6), random.Next(3, 12), eventdate));
                groups.Add(GroupFactory.MakeGroup(random.Next(1, 2), random.Next(3, 5), eventdate));
            }

            //AddSections
            for (int i = 0; i < 11; i++)
            {
                placementEvent.AddSection(random.Next(1, 3), random.Next(3, 10));
            }
            

            //AddGroup
            foreach (var group in groups)
            {
                placementEvent.AddGroup(group);
                Console.WriteLine("---");
                Console.WriteLine(group.People.Count);
                Console.WriteLine("---");
            }
            #endregion

            placementEvent.Place();

            Console.WriteLine(placementEvent.GenerateString());
            Console.ReadLine();
        }
    }
}
