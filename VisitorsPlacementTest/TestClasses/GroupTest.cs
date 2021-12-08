using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Logic;
using Logic.models;
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
            Person child1 = new();
            child1.DateOfBirth = new(2020, 12, 12);
            Person adult1 = new();
            adult1.DateOfBirth = new(1990, 12, 12);
            Person child2 = new();
            child2.DateOfBirth = new(2020, 12, 12);
            Person adult2 = new();
            adult2.DateOfBirth = new(1990, 12, 12);

            _group.AddPerson(child1);
            _group.AddPerson(adult1);
            _group.AddPerson(adult2);
            _group.AddPerson(child2);

            DateTime eventdate = new(2021, 12, 6);

            //act
            _group.SortPersons(eventdate);

            //assert
            Assert.AreEqual(_group.People[0].IsAdult(eventdate), false);
            Assert.AreEqual(_group.People[1].IsAdult(eventdate), false);
            Assert.AreEqual(_group.People[2].IsAdult(eventdate), true);
            Assert.AreEqual(_group.People[3].IsAdult(eventdate), true);
        }
    }
}
