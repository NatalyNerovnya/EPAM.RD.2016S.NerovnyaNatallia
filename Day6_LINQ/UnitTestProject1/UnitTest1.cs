﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private List<User> userListFirst = new List<User>
        {
            new User
            {
                Age = 21,
                Gender = Gender.Man,
                Name = "User1",
                Salary = 21000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 18,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 19000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Ann",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            }
        };

        private List<User> userListSecond = new List<User>
        {
            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            },
            new User
            {
                Age = 28,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 21000
            }
        };

        [TestMethod]
        public void SortByName()
        {
            var actualDataFirstList = new List<User>();
            var expectedData = userListFirst[4];

            //ToDo Add code first list
            actualDataFirstList = userListFirst.OrderBy(u => u.Name).ToList();

            Assert.IsTrue(actualDataFirstList[0].Equals(expectedData));
        }

        [TestMethod]
        public void SortByNameDescending()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = userListFirst[0];

            //ToDo Add code first list
            actualDataSecondList = userListFirst.OrderByDescending(u => u.Name).ToList();

            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
            
        }

        [TestMethod]
        public void SortByNameAndAge()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = userListSecond[4];

            //ToDo Add code second list
            actualDataSecondList = userListSecond.OrderBy(u => u.Name).ThenBy(u=>u.Age).ToList();

            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
        }

        [TestMethod]
        public void RemovesDuplicate()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = new List<User> {userListSecond[0], userListSecond[1], userListSecond[3], userListSecond[4],userListSecond[5]};

            //ToDo Add code second list
            actualDataSecondList = userListSecond.Distinct().ToList();
            CollectionAssert.AreEqual(expectedData, actualDataSecondList);
        }

        [TestMethod]
        public void ReturnsDifferenceFromFirstList()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { userListFirst[0], userListFirst[2], userListFirst[3] };

            //ToDo Add code first list
            actualData = userListFirst.Except(userListSecond).ToList();
            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void SelectsValuesByNameMax()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { userListSecond[0], userListSecond[2] };

            actualData = userListSecond.Where(u => u.Name == "Max").ToList();
            //ToDo Add code for second list

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void ContainOrNotContainName()
        {
            var isContain = false;

            //name max 
            //ToDo Add code for second list
            isContain = userListSecond.Exists(u => u.Name == "Max");

            Assert.IsTrue(isContain);

            // name obama
            //ToDo add code for second list
            isContain = userListSecond.Exists(u => u.Name == "Obama");
            Assert.IsFalse(isContain);
        }

        [TestMethod]
        public void AllListWithName()
        {
            var isAll = false;

            //name max 
            //ToDo Add code for second list
            isAll = userListSecond.TrueForAll(u => u.Name == "Max");

            Assert.IsFalse(isAll);
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameMax()
        {
            var actualData = new User();
            
            try
            {
                //ToDo Add code for second list
                //name Max
                actualData = userListSecond.Single(u => u.Name == "Max");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains more than one matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                actualData = userListSecond.Single(u => u.Name == "Ldfsdfsfd");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list

            //name Ldfsdfsfd

            actualData = userListSecond.SingleOrDefault(u => u.Name == "Ldfsdfsfd");
            Assert.IsTrue(actualData == null);
        }


        [TestMethod]
        public void ReturnsTheFirstElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                actualData = userListSecond.First(u => u.Name == "Ldfsdfsfd");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsTheFirstElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list
            //name Ldfsdfsfd
            actualData = userListSecond.FirstOrDefault(u => u.Name == "Ldfsdfsfd");
            Assert.IsTrue(actualData == null);
        }

        [TestMethod]
        public void GetMaxSalaryFromFirst()
        {
            var expectedData = 54000;
            var actualData = new User();

            //ToDo Add code for first list
            actualData = userListFirst.OrderBy(s => s.Salary).LastOrDefault();

            Assert.IsTrue(expectedData == actualData.Salary);
        }

        [TestMethod]
        public void GetCountUserWithNameMaxFromSecond()
        {
            var expectedData = 2;
            var actualData = 0;

            //ToDo Add code for second list
            actualData = userListSecond.Where(n => n.Name == "Max").Count();
            Assert.IsTrue(expectedData == actualData);
        }


        //сравнить два анонимных типа(коллекции а не их длины)
        //мокаем коллекцию из всех полей. делаем выборку (тоже анонимную)
        [TestMethod]
        public void Join()
        {
            var NameInfo = new[]
            {
                new {name = "Max", Info = "info about Max"},
                new {name = "Alan", Info = "About Alan"},
                new {name = "Alex", Info = "About Alex"}
            }.ToList();

            var expectedData = 3;
            var actualData = -1;

            //ToDo Add code for second list
            actualData = userListSecond.Join(NameInfo, u => u.Name, user => user.name, (u, user) => u.Name == user.name).Count();

            Assert.IsTrue(expectedData == actualData);
        }
    }
}
