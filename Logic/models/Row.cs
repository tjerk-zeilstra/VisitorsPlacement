using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Row : IRow
    {
        public Row(int rownumber)
        {
            RowNumber = rownumber;
        }
        public int RowNumber { get; set; }
        public List<IChair> Chairs = new();

        public void AddChairs(int numberOfChairs)
        {
            for (int i = 1; i <= numberOfChairs; i++)
            {
                Chairs.Add(new Chair(i)); //TODO DI
            }
        }
    }
}
