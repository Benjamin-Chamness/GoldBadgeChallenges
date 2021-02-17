using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class Cafe_UI
    {
        private Cafe_Repo _orderRepo = new Cafe_Repo();
        public void Run()
        {
            RunMenu();
            SeedMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("The Komodo Cafe \n" +
                    "\n" +
                    "1. List orders \n" +
                    "2. Add orders \n" +
                    "3. Delete orders \n" +
                    "4. Exit \n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListOrders();
                        break;
                    case "2":
                        AddOrders();
                        break;
                    case "3":
                        DeleteOrders();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1 and 5.");
                        Console.ReadKey();
                        break;
                }

            }

        }

        public void ListOrders()
        {
            Console.Clear();

            List<Cafe_Menu> listOfOrders = _orderRepo.GetOrderList();

            foreach (Cafe_Menu content in listOfOrders)
            {
                Console.WriteLine($"#{content.MealNumber} {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"MealPrice: {content.MealPrice}\n");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.ReadLine();
        }

        public void AddOrders()
        {
            Cafe_Menu content = new Cafe_Menu();
            Console.Clear();

            Console.WriteLine("Please enter the item number: ");
            content.MealNumber = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Please enter the name of the meal: ");
            content.MealName = Console.ReadLine();

            
            Console.WriteLine($"Please enter description for {content.MealName}: ");
            content.Description = Console.ReadLine();

            
            Console.WriteLine($"Please list the ingredients for {content.MealName}: ");

            
            Console.WriteLine($"Please enter the price for {content.MealName}: ");

            Console.Clear();
            Console.WriteLine("Order Summary\n =" +
                "\n");
            Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                $"Meal Name: {content.MealName}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredient List: {content.Ingredients}\n" +
                $"Price: {content.MealPrice}");

            Console.WriteLine("Your order was placed! \n" +
                "Press any key to continue.");
            Console.ReadKey();

            _orderRepo.AddOrderToList(content);
        }

        public void DeleteOrders()
        {
            Console.Clear();
            Console.WriteLine("Which order would you like to remove?");

            List<Cafe_Menu> listOfOrders = _orderRepo.GetOrderList();
            
            

            foreach (Cafe_Menu content in listOfOrders)
            {
                
                Console.WriteLine($"{content.MealNumber}. {content.MealName}");
            }
            int orderId = int.Parse(Console.ReadLine());

            Cafe_Menu order = _orderRepo.GetOrderID(orderId);
            _orderRepo.DeleteOrder(order);

            Console.WriteLine("Order was deleted! \n" +
                "Press any key to continue");
            Console.ReadKey();
        }

        public void SeedMenu()
        {
            Cafe_Menu chickenNugs = new Cafe_Menu(1, "Chicken Nuggets", "10 deep fried, all white meat chicken nugs",
                "Chicken, grease", 3.99);
            Cafe_Menu quarterPounder = new Cafe_Menu(2, "Quarter Pounder", "A quarter pound of grade A Angus Beef with all the fixins",
                "Beef, lettuce, tomato, pickles, mayo", 4.49);
            Cafe_Menu chickenSandwich = new Cafe_Menu(3, "Grilled Chicken Sandwich", "Grilled chicken smothered in chipotle mayo",
                "Chicken, tomato, chipotle mayo, lettuce", 5.49);
            Cafe_Menu salad = new Cafe_Menu(4, "Tossed Salad", "Leafy greens, loaded with veggies and your choice of dressing",
                "lettuce, cucumber, cheese, tomato, onion, bell pepper, egg", 2.29);
            Cafe_Menu allAmerican = new Cafe_Menu(5, "All American Burger", "Half pound of grade A Angus Beef, loaded with all the goods",
                "Beef, Bacon, fried onions, lettuce, tomato, pickles, fried egg", 6.19);
        }
          

    }
        
            
}

            
        




