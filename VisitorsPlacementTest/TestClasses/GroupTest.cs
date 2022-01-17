using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Logic;
using Logic.models;
using Logic.Factory;
using System;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class GroupTest
    {
        Group _group;

        public GroupTest()
        {
            _group = new();
        }

        [TestMethod]
        public void SortPersons()
        {
            //arrange
            DateTime eventdate = new(2020, 12, 12);

            Person child1 = PersonFactory.MakeChild(eventdate);
            Person adult1 = PersonFactory.MakeAdult(eventdate);
            Person child2 = PersonFactory.MakeChild(eventdate);
            Person adult2 = PersonFactory.MakeAdult(eventdate);

            _group.AddPerson(child1);
            _group.AddPerson(adult1);
            _group.AddPerson(adult2);
            _group.AddPerson(child2);

            //act
            _group.SortPersons(eventdate);

            //assert
            Assert.AreEqual(_group.People[0].IsAdult(eventdate), false);
            Assert.AreEqual(_group.People[1].IsAdult(eventdate), false);
            Assert.AreEqual(_group.People[2].IsAdult(eventdate), true);
            Assert.AreEqual(_group.People[3].IsAdult(eventdate), true);
        }

        [TestMethod]
        [DataRow(10, 10)] //adults and children
        [DataRow(0, 10)] // no children
        [DataRow(10, 0)] // no adults
        public void AmountOfChildren(int children, int adults)
        {
            //arrange
            DateTime dateTime = new(2020, 12, 12);
            for (int i = 0; i < children; i++)
            {
                Person child = PersonFactory.MakeChild(dateTime);
                _group.AddPerson(child);
            }
            for (int i = 0; i < adults; i++)
            {
                Person adult = PersonFactory.MakeAdult(dateTime);
                _group.AddPerson(adult);
            }

            //act
            int amount = _group.AmountOfChildren(dateTime);

            //
            Assert.AreEqual(children, amount);
        }
    }
}
