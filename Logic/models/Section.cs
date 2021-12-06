using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.models
{
    public class Section
    {
        public Section(string sectionName)
        {
            SectionName = sectionName;
            Rows = new();
        }

        public string SectionName { get; set; }
        public List<Row> Rows { get; set; }

        public void AddRows(int numberOfRows, int numberOfChairs)
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                Row row = new(i);
                Rows.Add(row);
                row.AddChairs(numberOfChairs);
            }
        }
    }
}
