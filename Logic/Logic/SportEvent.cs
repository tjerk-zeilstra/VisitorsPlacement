using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.models;
using Logic.Exeptions;

namespace Logic.Logic
{
    public class SportEvent
    {
        private List<Section> _sections = new();
        private List<Person> _indviduals = new();
        private List<Group> _groups = new();
        public DateTime EventDate { get; set; }

        public List<Section> GetSections() => _sections;

        public SportEvent(DateTime eventDate)
        {
            EventDate = eventDate;
        }

        public void AddSection(int numRows, int numChairs)
        {
            Section sectionNew = new(GetSectionName2());
            _sections.Add(sectionNew);
            sectionNew.AddRows(numRows, numChairs);
        }

        #region Add Group
        public void AddGroup(Group group)
        {
            if (group.People.Count > AvilbleChairs())
            {
                throw new GroupDoesNotFit();
            }

            _groups.Add(group);
        }

        public int AvilbleChairs()
        {
            int chairs = 0;
            int poeple = 0;

            foreach (var section in _sections)
            {
                chairs += section.AvalibleSpaces();
            }

            foreach (var person in _groups)
            {
                poeple += person.People.Count;
            }
            poeple += _indviduals.Count;

            return chairs - poeple;
        }

        #endregion

        #region Sort Groups and Sections
        private void SortGroups()
        {
            for (int i = 0; i < _groups.Count; i++)
            {
                _groups[i].SortPersons(EventDate);
            }
        }

        private void SortSectionsOnSize()
        {
            for (int i = 0; i < _sections.Count; i++)
            {
                for (int j = 1; j < _sections.Count; j++)
                {
                    if (_sections[i].AvalibleSpaces() < _sections[j].AvalibleSpaces())
                    {
                        Section temp = _sections[i];
                        _sections[i] = _sections[j];
                        _sections[j] = temp;
                    }
                }
            }
        }
        #endregion

        #region Placement
        public void Place()
        {
            SortSectionsOnSize();
            SortGroups();

            MakePlacement();
        }

        private void MakePlacement()
        {
            for (int i = 0; i < _groups.Count; i++)
            {
                for (int j = 0; j < _groups.Count; j++)
                {

                }
            }
        }
        #endregion

        #region Set section name
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
        #endregion
    }
}
