using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace VisitorsPlacementTest.FakeClasses
{
    class FakeRow : IRow
    {
        public int RowNumber { get; set; }

        public void AddChairs(int numberOfChairs)
        {
            throw new NotImplementedException();
        }
    }
}
