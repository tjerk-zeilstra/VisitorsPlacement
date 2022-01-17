using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Logic;
using Logic.Exeptions;
using System;
using Logic.models;
using Logic.Factory;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class PlacementEventTest
    {
        PlacementEvent _PlacementEvent;

        public PlacementEventTest()
        {
            _PlacementEvent = new(new DateTime(2021, 12, 21));
        }

        [TestMethod()]
        [DataRow(3,10)] //largest
        [DataRow(1, 3)] //smallest
        public void AddSectionsTest(int numrows, int numchairs)
        {
            //arange
            //act
            _PlacementEvent.AddSection(numrows, numchairs);
            //assert
            Assert.AreEqual(numrows, _PlacementEvent.GetSections()[0].Rows.Count);
            for (int i = 0; i < numrows; i++)
            {
                Assert.AreEqual(numchairs, _PlacementEvent.GetSections()[0].Rows[i].Chairs.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SectionToLarge))]
        [DataRow(1, 11)] // too many chairs
        [DataRow(4, 3)] // too many rows
        [DataRow(4, 11)] // too many rows and chairs
        public void AddSectionToLarge(int numrows, int numchairs)
        {
            //act
            _PlacementEvent.AddSection(numrows, numchairs);
        }

        [TestMethod]
        [DataRow(15, 15)] // full
        [DataRow(30, 0)] // no children
        public void AddGroupTest(int adults, int children)
        {
            //arange
            _PlacementEvent.AddSection(3, 5);
            _PlacementEvent.AddSection(3, 5);
            Group group = GroupFactory.MakeGroup(children, adults, _PlacementEvent.EventDate);

            //act
            _PlacementEvent.AddGroup(group);

            //assert
            Assert.AreEqual(1, _PlacementEvent._groups.Count);
            Assert.AreEqual(adults + children, _PlacementEvent._groups[0].People.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(GroupDoesNotFit))]
        [DataRow(30, 1)]
        public void AddToLargeGroupTest(int adults, int children)
        {
            _PlacementEvent.AddSection(3, 5);
            _PlacementEvent.AddSection(3, 5);
            Group group = GroupFactory.MakeGroup(children, adults, _PlacementEvent.EventDate);

            //act
            _PlacementEvent.AddGroup(group);
        }
    }
}
