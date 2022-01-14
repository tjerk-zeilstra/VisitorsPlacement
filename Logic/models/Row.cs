using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Row
    {
        public Row()
        {
            Chairs = new();
        }
        public Row(int rownumber)
        {
            RowNumber = rownumber;
            Chairs = new();
        }
        public int RowNumber { get; set; }
        public List<Chair> Chairs { get; set; }

        public void AddChairs(int numberOfChairs)
        {
            for (int i = 1; i <= numberOfChairs; i++)
            {
                Chair chair = new(i);
                Chairs.Add(chair);
            }
        }

        public void AddPerson(Person person)
        {
            Chairs[Chairs.Count - AvalibleChairs()].AddPerson(person);
        }

        public int AvalibleChairs()
        {
            int avalibleChairs = 0;
            foreach (var chair in Chairs)
            {
                if (chair.ChairPerson == null)
                {
                    avalibleChairs++;
                }
            }
            return avalibleChairs;
        }
    }
}
