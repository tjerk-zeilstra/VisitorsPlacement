using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.models;

namespace Logic.Logic
{
    public class PlacementLogic
    {
        public List<Section> Sections { get; set; }

        public void AddSection(int numRows, int numChairs)
        {
            Section sectionNew = new();
            sectionNew.SectionName = GetSectionName(Sections.Count);

            for (int i = 0; i < numRows; i++)
            {
                Row row = new(i + 1);
                sectionNew.Rows.Add(row);
                for (int j = 0; j < numChairs; j++)
                {

                }
            }
        }

        private string GetSectionName(int sectionNum)
        {
            string name = string.Empty;
            int length = sectionNum;
            int num;

            while (length > 0)
            {
                num = (length - 1) % 26;
                name = Convert.ToChar(num + 65).ToString() + name;
                length = ((length - num) / 26);
            }
            return name;
        }

        private string GetSectionName2()
        {
            if (Sections.Count == 0)
            {
                return "A";
            }

            string name = Sections.Last().SectionName;
            bool loop = true;
            int count = name.Length - 1;

            while (loop)
            {
                char currentchar = name[count];
                if (currentchar == 'Z')
                {
                    if (count == 0)
                    {
                        name = name.Remove(count, 1);
                        name = name.Insert(count, "AA");
                        loop = false;
                    }
                    else
                    {
                        name = name.Remove(count, 1);
                        name = name.Insert(count, "A");
                    }
                    
                    count--;
                }
                else
                {
                    name = name.Remove(count, 1);
                    name = name.Insert(count, Convert.ToString(currentchar++));
                    loop = false;
                }
            }

            return name;
        }
    }
}
