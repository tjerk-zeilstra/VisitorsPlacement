using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic.models
{
    public class Chair : IChair
    {
        public Chair(int chairnumber)
        {
            ChairNumber = chairnumber;
        }
        public IPerson ChairPerson { get; private set; }
        public int ChairNumber { get; private set; }

        public void AddPerson(IPerson person)
        {
            ChairPerson = person;
        }
    }
}
