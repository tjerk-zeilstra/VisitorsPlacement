using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace VisitorsPlacementTest.FakeClasses
{
    class FakeChair : IChair
    {
        public int ChairNumber { get; set; }

        public IPerson ChairPerson { get; }

        public void AddPerson(IPerson person)
        {
            throw new NotImplementedException();
        }
    }
}
