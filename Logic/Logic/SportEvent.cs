using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.models;

namespace Logic.Logic
{
    public class SportEvent
    {
        public List<Section> _sections = new();
        private List<Person> _indviduals = new();
        private List<Group> _groups = new();

        public void AddSection(int numRows, int numChairs)
        {
            Section sectionNew = new(GetSectionName2());
            _sections.Add(sectionNew);

            for (int i = 0; i < numRows; i++)
            {
                sectionNew.AddRows(numRows, numChairs); //TODO DI
            }
        }

        private void SortGroups()
        {

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
            if (_sections.Count == 0)
            {
                return "A";
            }

            string name = _sections.Last().SectionName;
            bool loop = true;
            int count = name.Length - 1;

            while (loop)
            {
                char currentchar = name[count];
                if (currentchar == 'Z')
                {
                    name = name.Remove(count, 1);
                    if (count == 0)
                    {   
                        name = name.Insert(count, "AA");
                        loop = false;
                    }
                    else
                    {
                        name = name.Insert(count, "A");
                    }
                    
                    count--;
                }
                else
                {
                    name = name.Remove(count, 1);
                    currentchar++;
                    name = name.Insert(count, Convert.ToString(currentchar));
                    loop = false;
                }
            }

            return name;
        }
    }
}
