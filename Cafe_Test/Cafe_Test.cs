using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cafe_Test
{
    [TestClass]
    public class Cafe_Test
    {
        private Cafe_Repo _contentRepo;
        private Cafe_Menu _orderContent;


        [TestMethod]
        public void AddOrder()
        {
            _contentRepo.AddOrderToList(_orderContent);

            int expected = 1;
            int actual = _contentRepo.GetOrderList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteOrder() 
        {
            Cafe_Repo _contentRepo = new Cafe_Repo();

            _contentRepo.AddOrderToList(_orderContent);
              

            bool wasDeleted = _contentRepo.DeleteOrder(_orderContent);
            Assert.IsTrue(wasDeleted);
        }

        [TestMethod]
        public void NewOrderTest()
        {
            Cafe_Menu neworder = new Cafe_Menu(5, "All American Burger", "Half pound of grade A Angus Beef, loaded with all the goods",
                "Beef, Bacon, fried onions, lettuce, tomato, pickles, fried egg", 6.19);

            Assert.AreEqual(5, neworder.MealNumber);
            Assert.AreEqual("All American Burger", neworder.MealName);
            Assert.AreEqual("Half pound of grade A Angus Beef, loaded with all the goods", neworder.Description);
            Assert.AreEqual("Beef, Bacon, fried onions, lettuce, tomato, pickles, fried egg", neworder.Ingredients);
            Assert.AreEqual(6.19, neworder.MealPrice);
        }
    }
}
