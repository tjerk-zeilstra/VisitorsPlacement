using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.models;
using System;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class PersonTest
    {
        readonly Person _person;

        public PersonTest()
        {
            _person = new();
        }

        [TestMethod()]
        [DataRow(2015, 2, 15, false)] // child
        [DataRow(1999, 06, 14, true)] // adult
        [DataRow(2003, 12, 4, true)] // exectly adult
        [DataRow(2021, 12, 5, false)] // day after event
        [DataRow(2021, 12 , 4, false)] // same day as event
        public void TestPersonIsAdult(int year, int month, int day, bool expected)
        {
            //arrange
            _person.DateOfBirth = new DateTime(year, month, day);

            //act
            bool assertbool = _person.IsAdult(new DateTime(2021, 12, 4));

            //assert
            Assert.AreEqual(expected, assertbool);
        }
    }
}
