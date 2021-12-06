using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.models;
using Logic.Interfaces;
using VisitorsPlacementTest.FakeClasses;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class SectionTest
    {
        Section section;
        public SectionTest()
        {
            section = new Section("A");
        }

        [TestMethod]
        public void TestAddRow()
        {
            //arrange
            int numchairs = 5;
            int numrow = 5;

            //act
            section.AddRows(numrow, numchairs);

            //asert
            CollectionAssert.AllItemsAreNotNull(section.Rows);
            for (int i = 0; i < numrow; i++)
            {
                Assert.AreEqual(section.Rows[i].RowNumber, i + 1);
            }
        }
    }
}
