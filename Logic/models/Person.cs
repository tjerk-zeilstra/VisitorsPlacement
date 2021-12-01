using System;
using Logic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
