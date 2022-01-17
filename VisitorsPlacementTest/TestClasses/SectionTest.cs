using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.models;
using Logic.Exeptions;
using System.Collections.Generic;
using System;

namespace VisitorsPlacementTest.TestClasses
{
    [TestClass]
    public class SectionTest
    {
        Section section;
        public SectionTest()
        {
            section = new Section("A");
        }

        [TestMethod]
        public void TestAddRow()
        {
            //arrange
            int numchairs = 5;
            int numrow = 5;

            //act
            section.AddRows(numrow, numchairs);

            //asert
            CollectionAssert.AllItemsAreNotNull(section.Rows);
            for (int i = 0; i < numrow; i++)
            {
                Assert.AreEqual(section.Rows[i].RowNumber, i + 1);
            }
        }

        [TestMethod]
        public void AvalibleSpacesTest()
        {
            //arrange
            Person person = new()
            {
                DateOfBirth = new DateTime(1999, 06, 14),
                Name = "test"
            };
            Chair chair = new()
            {
                ChairNumber = 1,
                ChairPerson = person
            };
            Row row = new()
            {
                RowNumber = 1,
            };
            row.Chairs.Add(chair);
            row.Chairs.Add(chair);
            row.Chairs.Add(chair);
            row.Chairs.Add(new());
            row.Chairs.Add(new());
            row.Chairs.Add(new());

            section.Rows.Add(row);
            section.Rows.Add(row);

            //act
            int avilablespaces = section.AvalibleSpaces();

            //assert
            Assert.AreEqual(6, avilablespaces);
        }

        [TestMethod]
        public void AddGroupTest()
        {
            //arrange
            int adults = 5;
            int childs = 5;
            int rows = 3;
            int chairs = 5;
            DateTime eventdate = new(2021, 06, 14);
            Group testgroup = new();
            for (int i = 0; i < adults; i++)
            {
                testgroup.AddPerson(new Person() { DateOfBirth = new DateTime(2020, 06, 14) });
            }
            for (int i = 0; i < childs; i++)
            {
                testgroup.AddPerson(new Person() { DateOfBirth = new DateTime(1999, 06, 14) });
            }
            section.AddRows(rows, chairs);

            //act
            section.AddGroup(testgroup, eventdate);

            //Assert
            int pCount= 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.AreEqual(testgroup.People[pCount], section.Rows[i].Chairs[j].ChairPerson);
                    pCount++;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(GroupDoesNotFit))]
        public void AddGroup_Group_Does_Not_Fit_ExceptionTest()
        {
            //arrange
            DateTime eventdate = new(2021, 06, 14);
            Group testgroup = new();
            for (int i = 0; i < 5; i++)
            {
                testgroup.AddPerson(new() { DateOfBirth = new DateTime(1999, 06, 14) });
            }
            section.AddRows(2, 2);

            //act
            section.AddGroup(testgroup, eventdate);
        }

        [TestMethod()]
        [ExpectedException(typeof(GroupDoesNotContainAdult))]
        public void AddGroup_No_Adults_ExceptionTest()
        {
            //arrange
            DateTime eventdate = new(2021, 06, 14);
            Group testgroup = new();
            for (int i = 0; i < 3; i++)
            {
                testgroup.AddPerson(new() { DateOfBirth = new DateTime(2020, 06, 14) });
            }
            section.AddRows(2, 2);

            //act
            section.AddGroup(testgroup, eventdate);
        }
    }
}
