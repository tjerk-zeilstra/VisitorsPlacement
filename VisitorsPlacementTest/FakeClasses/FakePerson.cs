using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorsPlacementTest.FakeClasses
{
    class FakePerson : IPerson
    {
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
    }
}
