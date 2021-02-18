using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _3_Badge_Repository;
using _3_Badge_Console;


namespace _3_Badge_Test
{
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepo _repo;
        private Badges _badges;

        [Test Initialize]
        
            public void SeedContent()
            {
                Badges badgeOne = new Badges(12345, new List<string> { "Door A7" });
                Badges badgeTwo = new Badges(22345, new List<string> { "Doors A1, A4, B1, B2" });
                Badges badgeThree = new Badges(32345, new List<string> { "Doors A4, A5" });

                _repo.CreateBadge(badgeOne);
                _repo.CreateBadge(badgeTwo);
                _repo.CreateBadge(badgeThree);
            }
        
        

        [TestMethod]
        public void RemoveDoor()
        {
            bool wasRemoved = _repo.DeleteDoor("32345, A5");
            Assert.IsTrue(wasRemoved);

        }

        [TestMethod]
        public void ShowAll()
        {
            Badges badge = new Badges badge() 
            Console.WriteLine("Key" 
                "\n" +
            Badges badgeOne = new Badges(12345, new List<string> { "Door A7" });
            Badges badgeTwo = new Badges(22345, new List<string> { "Doors A1, A4, B1, B2" });
            Badges badgeThree = new Badges(32345, new List<string> { "Doors A4, A5" });
        }

        [TestMethod]
        public void CreateBadge()
        {
            Badges badge = new Badges badge()


            badge.badgeID = 12345;
            string expected = 12345;
            string actual = badge.badgeID;

            Assert.AreEqual(expected, actual);

        }
    }
}
            
            
