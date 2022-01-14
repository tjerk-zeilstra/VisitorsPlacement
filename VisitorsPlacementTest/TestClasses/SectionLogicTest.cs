using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Logic;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class SectionLogicTest
    {
        PlacementEvent _sectionLogic;

        public SectionLogicTest()
        {
            _sectionLogic = new(new(2021, 12, 21));
        }

        [TestMethod]
        public void AddSections()
        {
            //arange
            //act
            _sectionLogic.AddSection(3, 5);
            //assert
            Assert.AreEqual(3, _sectionLogic.GetSections()[0].Rows.Count);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(5, _sectionLogic.GetSections()[0].Rows[i].Chairs.Count);
            }
        }
    }
}
