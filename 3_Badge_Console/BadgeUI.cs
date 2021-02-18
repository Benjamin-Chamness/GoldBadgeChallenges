using _3_Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge_Console
{
    public class BadgeUI
    {
        private BadgeRepo _repo = new BadgeRepo();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Insurance Badging System\n" +
                    "\n" +
                    "Please select an option.\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowAll();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
        }

        public void CreateBadge()
        {
            Badges badge = new Badges();
            badge.DoorAccess = new List<string>();

            Console.Clear();
            Console.WriteLine("This is a new badge\n" +
                "\n" +
                "Please enter a new badge number: ");
            badge.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"This is a new badge\n" +
                $"Badge ID: {badge.BadgeID}\n");
            Console.WriteLine($"Select a door that Badge ID {badge.BadgeID} needs access to: \n" +
                $"\n");
            badge.DoorAccess.Add(Console.ReadLine());

            bool yes = true;

            Console.WriteLine($"The door was successfully added so Badge ID {badge.BadgeID} can now access it: ");

            while (yes)
            {
                Console.WriteLine($"Would you like to add more doors to Badge ID {badge.BadgeID}? (yes/no");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "yes":
                        Console.WriteLine($"Select another door that Badge ID {badge.BadgeID} needs access to");
                        badge.DoorAccess.Add(Console.ReadLine());
                        break;
                    case "no":
                        yes = false;
                        break;
                }
            }

            _repo.CreateBadge(badge);

            Console.Clear();

            Console.WriteLine($"Badge ID {badge.BadgeID} has been successfully added.\n" +
                $"\n"  +
                $"Please press any key to return to the main menu");

            Console.ReadKey();

        }

        public void UpdateBadge()
        {
            Badges badge = new Badges();
            badge.DoorAccess = new List<string>();

            Console.Clear();
            Console.WriteLine("Please enter a badge number that you would like to edit: ");
            badge.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"What do you want to change for {badge.BadgeID}/n" +
                $"n\" +" +
                $"1. Remove a door\n" +
                $"2. Add a door\n" +
                $"3. Return to main menu");

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    RemoveDoorFromUpdate(badge.BadgeID);
                    break;
                case "2":
                    AddDoorToUpdate(badge.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
            }
        }

        public void RemoveDoorFromUpdate(int badgeid)
        {
            Console.WriteLine("Please select a door to delete: ");
            string door = Console.ReadLine();
            _repo.DeleteDoor(badgeid, door);

            Console.WriteLine($"Door has been deleted and is no longer accessible.\n" +
                $"\n" +
                $"Please press any key to return to the main menu.");

            Console.ReadKey();
        }

        public void AddDoorToUpdate(int badgeid)
        {
            Console.WriteLine("Please select a door to add: ");
            string door = Console.ReadLine();
            _repo.UpdateBadge(badgeid, door);

            Console.WriteLine($"Door access granted!\n" +
                $"\n" +
                $"Please press any key to return to the main menu.");

            Console.ReadKey();
        }

        public void ShowAll()
        {
            Dictionary<int, List<string>> Badges = _repo.GetDictionary();

            foreach (KeyValuePair<int, List<string>> badge in Badges)
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
            }
            Console.WriteLine("\n Please press any key to return to the main menu: ");
            Console.ReadLine();
        }
        public void SeedContent()
        {
            Badges badgeOne = new Badges(12345, new List<string> { "Door A7" });
            Badges badgeTwo = new Badges(22345, new List<string> { "Doors A1, A4, B1, B2" });
            Badges badgeThree = new Badges(32345, new List<string> {"Doors A4, A5"});

            _repo.CreateBadge(badgeOne);
            _repo.CreateBadge(badgeTwo);
            _repo.CreateBadge(badgeThree);
        }
    }
}
