using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.models;
using Logic.Exeptions;

namespace Logic.Logic
{
    public class PlacementEvent
    {
        private List<Section> _sections = new();
        private List<Person> _indviduals = new();
        private List<Group> _groups = new();
        public DateTime EventDate { get; set; }

        public List<Section> GetSections() => _sections;

        public PlacementEvent(DateTime eventDate)
        {
            EventDate = eventDate;
        }

        public void AddSection(int numRows, int numChairs)
        {
            Section sectionNew = new(GetSectionName());
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
        private List<Group> GetGroupsWithChild()
        {
            List<Group> groupsWithChildren = new();

            foreach (var group in _groups)
            {
                if (group.AmountOfChildren(EventDate) > 0)
                {
                    groupsWithChildren.Add(group);
                }
            }
            return groupsWithChildren;
        }

        private List<Group> GetGroupsWithoutChild()
        {
            List<Group> groupsWithOutChildren = new();

            foreach (var group in _groups)
            {
                if (group.AmountOfChildren(EventDate) == 0)
                {
                    groupsWithOutChildren.Add(group);
                }
            }
            return groupsWithOutChildren;
        }
        #endregion

        #region Placement
        public void Place()
        {
            _sections.Sort();
            _groups.Sort();

            foreach (var group in _groups)
            {
                List<Section> placment = GetSectionsForGroup(group.People.Count);
                PlaceGroupInSections(placment, group);
                _sections.Sort();
            }

            foreach (var section in _sections)
            {
                section.PlaceChildrenInFrontRow(EventDate);
            }
        }

        private List<Section> GetSectionsForGroupWithChildren(Group group)
        {
            List<Section> sections = new();
            int remaining = group.People.Count;
            int children = group.AmountOfChildren(EventDate);

            int i = 0;

            while(true)
            {
                int frontrowseats = _sections[i].AvalibleFrontRowSeats(EventDate);
                int avaliblespaces = _sections[i].AvalibleSpaces();
                if (children >= frontrowseats && avaliblespaces > 0 && frontrowseats > 0)
                {
                    sections.Add(_sections[i]);
                    remaining -= avaliblespaces;
                    children -= frontrowseats;
                    i++;
                }
                else break;
                
            }
            if (remaining > 0)
            {
                while (true)
                {
                    int avaliblespaces = _sections[i].AvalibleSpaces();
                    if (avaliblespaces >= remaining && i != _sections.Count)
                    {
                        i++;
                    }
                    else
                    {
                        i--;
                        remaining -= avaliblespaces;
                        sections.Add(_sections[i]);
                        break;
                    }
                }
            }
            if(remaining > 0)
            {
                List<Section> rest = GetSectionsForGroup(remaining);
                foreach (var r in rest)
                {
                    sections.Add(r);
                }
            }

            return sections;
        }

        private List<Section> GetSectionsForGroup(int groupCount)
        {
            List<Section> sections = new();
            int restwaarde = groupCount;
            int i = 0;
            while (true)
            {
                int avaliblespaces = _sections[i].AvalibleSpaces();
                if (restwaarde >= avaliblespaces && avaliblespaces > 0)
                {
                    sections.Add(_sections[i]);
                    restwaarde -= avaliblespaces;
                    if(i != _sections.Count - 1) i++;
                }
                else break;
            }
            if (restwaarde > 0)
            {
                while (true)
                {
                    if (_sections[i].AvalibleSpaces() >= restwaarde && i != _sections.Count - 1){
                        i++;
                    }
                    else
                    {
                        i--;
                        sections.Add(_sections[i]);
                        break;
                    }
                }
            }

            return sections;
        }

        private void PlaceGroupInSections(List<Section> sections, Group group)
        {
            group.SortPersons(EventDate);
            int children = group.AmountOfChildren(EventDate);
            if (sections.Count > group.People.Count - children)
            {
                throw new GroupDoesNotContainEnoughAdults();
            }

            if (children > 0)
            {
                //place adult in every section
                foreach (var section in sections)
                {
                    Person tempperson = new();
                    foreach (var person in group.People)
                    {
                        if (person.IsAdult(EventDate))
                        {
                            section.AddPerson(person);
                            tempperson = person;                            
                            break;
                        }
                    }
                    group.People.Remove(tempperson);
                }
                //place children
                foreach (var section in sections)
                {
                    children = group.AmountOfChildren(EventDate);
                    if (children == 0) break;
                    for (int i = 0; i < children; i++)
                    {
                        int frontrow = section.AvalibleFrontRowSeats(EventDate);
                        if (frontrow != 0)
                        {
                            section.AddPerson(group.People[0]);
                            group.People.Remove(group.People[0]);
                        }
                        else break;
                    }
                }
            }

            //place Rest
            int sectioncount = 0;
            foreach(var person in group.People)
            {
                if (sections[sectioncount].AvalibleSpaces() > 0)
                {
                    sections[sectioncount].AddPerson(person);
                }
                else
                {
                    sectioncount++;
                    sections[sectioncount].AddPerson(person);
                }
                
            }
        }
        #endregion

        #region Set section name
        private string GetSectionName()
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

        #region Train
        public string GenerateString()
        {
            StringBuilder placementevent = new();

            foreach (var section in _sections)
            {
                placementevent.Append(section.SectionToString(EventDate));
            }

            return placementevent.ToString();
        }
        #endregion
    }
}
