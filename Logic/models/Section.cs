using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Exeptions;

namespace Logic.models
{
    public class Section : IComparable<Section>
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

        public int AvalibleSpaces()
        {
            int avaliblespace = 0;
            foreach (var row in Rows)
            {
                avaliblespace += row.AvalibleChairs();
            }
            return avaliblespace;
        }

        //TODO WTF
        public int AvalibleFrontRowSeats(DateTime eventDate)
        {
            int children = 0;
            foreach (var row in Rows)
            {
                foreach (var chair in row.Chairs)
                {
                    if (chair.ChairPerson.IsAdult(eventDate))
                    {
                        children++;
                    }
                }
            }
            return children;
        }

        private void VerifyGroup(Group group, DateTime eventDate)
        {
            //check if the group fits
            if (group.People.Count > AvalibleSpaces())
            {
                throw new GroupDoesNotFit(AvalibleSpaces(), group.People.Count);
            }

            //check if there is an adult
            bool checkforadult = group.People.Any(x => x.IsAdult(eventDate));
            if (!checkforadult)
            {
                throw new GroupDoesNotContainAdult();
            }
        }

        private int GetCurrentRow()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].AvalibleChairs() > 0)
                {
                    return i;
                }
            }
            throw new GroupDoesNotFit();
        }

        public void AddGroup(Group group, DateTime eventDate)
        {
            VerifyGroup(group, eventDate);
            foreach (var person in group.People)
            {
                Rows[GetCurrentRow()].AddPerson(person);
            }
        }

        public void AddPerson(Person person)
        {
            Rows[GetCurrentRow()].AddPerson(person);
        }

        public string SectionToString(DateTime date)
        {
            StringBuilder section = new();
            foreach (var row in Rows)
            {
                section.AppendLine(row.RowToString(date));
            }
            return section.ToString();
        }

        #region Icomparable
        public int CompareTo(Section other)
        {
            if (this.Rows.Count < other.Rows.Count) return 1;
            else if (this.Rows.Count > other.Rows.Count) return -1;
            else return 0;
        }
        #endregion
    }
}
