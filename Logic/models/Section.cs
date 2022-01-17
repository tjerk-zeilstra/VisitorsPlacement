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

        public void PlaceChildrenInFrontRow(DateTime eventdate)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Rows[i].Chairs.Count; j++)
                {
                    for (int u = 0; u < Rows.Count; u++)
                    {
                        for (int p = 0; p < Rows[u].Chairs.Count; p++)
                        {
                            if (Rows[u].Chairs[p].ChairHasAdult(eventdate) == true && Rows[i].Chairs[j].ChairHasAdult(eventdate) == false)
                            {
                                Person tempPerson = Rows[u].Chairs[p].ChairPerson;
                                Rows[u].Chairs[p].ChairPerson = Rows[i].Chairs[j].ChairPerson;
                                Rows[i].Chairs[j].ChairPerson = tempPerson;
                                break;
                            }
                        }
                    }
                }
            }
        }

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

        public int AvalibleFrontRowSeats(DateTime eventDate)
        {
            int children = 0;
            int frontrow = Rows[0].Chairs.Count;

            foreach (var row in Rows)
            {
                
                foreach (var chair in row.Chairs)
                {
                    if (!chair.ChairHasAdult(eventDate))
                    {
                        children++;
                    }
                }
            }
            return frontrow - children;
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
            section.AppendLine("----"+SectionName+"----");
            foreach (var row in Rows)
            {
                section.AppendLine(row.RowToString(date));
            }
            section.AppendLine("-------");
            return section.ToString();
        }

        #region Icomparable
        public int CompareTo(Section other)
        {
            if (this.AvalibleSpaces() < other.AvalibleSpaces()) return 1;
            else if (this.AvalibleSpaces() > other.AvalibleSpaces()) return -1;
            else return 0;
        }
        #endregion
    }
}
