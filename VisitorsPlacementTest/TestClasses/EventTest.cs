using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Logic;
using Logic.models;
using System;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        [DataRow(1,2,3)]
        public void MyTestMethod(int a, int b, int c)
        {
            Assert.AreEqual(c, a + b);
        }
    }
}
