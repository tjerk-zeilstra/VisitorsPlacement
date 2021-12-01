using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.models;
using Logic.Interfaces;

namespace VisitorsPlacementTest
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
    }
}
