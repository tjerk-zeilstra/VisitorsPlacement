using System;

namespace Logic.Interfaces
{
    public interface IRow
    {
        int RowNumber { get; set; }

        void AddChairs(int numberOfChairs, IChair chair);
    }
}