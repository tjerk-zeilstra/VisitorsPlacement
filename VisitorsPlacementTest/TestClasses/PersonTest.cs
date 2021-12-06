using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.models;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class PersonTest
    {
        Person _person;

        public PersonTest()
        {
            _person = new();
        }

        [TestMethod]
        public void PersonIsAdultTest()
        {
            //arrange
            _person.DateOfBirth = new(1999, 06, 14);


            //act
            bool assert = _person.IsAdult(new(2021, 12, 4));

            //assert
            Assert.IsTrue(assert);
        }

        [TestMethod]
        public void PersonIsUnderaged()
        {
            //arrange
            _person.DateOfBirth = new(2015, 2, 15);

            //act
            bool assert = _person.IsAdult(new(2021, 12, 4));

            //assert
            Assert.IsFalse(assert);
        }
    }
}
