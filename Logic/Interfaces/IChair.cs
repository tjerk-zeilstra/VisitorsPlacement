using Logic.Interfaces;

namespace Logic.Interfaces
{
    public interface IChair
    {
        int ChairNumber { get; set; }
        IPerson ChairPerson { get; }

        void AddPerson(IPerson person);
    }
}