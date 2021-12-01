using System;

namespace Logic.Interfaces
{
    public interface IPerson
    {
        DateTime DateOfBirth { get; set; }
        string Name { get; set; }
    }
}