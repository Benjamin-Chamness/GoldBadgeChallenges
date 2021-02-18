using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _3_Badge_Repository;


namespace _3_Badge_Test
{
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepo _repo;
        private Badges _badges;

        [Test Initialize]
        public void Initialize()
        {
            List<string> badge = new List<string>();
            badge.Add("door_1");

            _repo = new BadgeRepo();
            _badges = new Badges(1000, badge);
        }

        [TestMethod]
        public void DeleteDoor()
        {
          BadgeRepo badge = new BadgeRepo();
            
        }
    }
}
            
            
