using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.models;
using Logic.Interfaces;
using VisitorsPlacementTest.FakeClasses;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class RowTest
    {
        private readonly Row _row;

        public RowTest()
        {
            _row = new(1);
        }

        [TestMethod]
        public void AddChairsWithNumber()
        {
            //arrange
            int numofchairs = 10;
            //act
            _row.AddChairs(numofchairs);
            //assert
            for (int i = 0; i < numofchairs; i++)
            {
                Assert.AreEqual(_row.Chairs[i].ChairNumber, i + 1);
            }
        }

        [TestMethod]
        public void AvalibleChairsTest()
        {
            //arrange
            int numofchairs = 10;
            _row.AddChairs(numofchairs);

            //act
            int avalibleChairs = _row.AvalibleChairs();

            //assert
            Assert.AreEqual(numofchairs, avalibleChairs);
        }


        [TestMethod]
        public void AddPerson()
        {
            //arrange
            _row.AddChairs(10);
            Person person = new();

            //act
            _row.AddPerson(person);

            //assert
            Assert.AreEqual(person, _row.Chairs[0].ChairPerson);
            Assert.AreEqual(9, _row.AvalibleChairs());

        }
    }
}
