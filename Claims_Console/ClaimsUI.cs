using _2_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    class ClaimsUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            RunMenu();
            SeedContent();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                
                
                Console.WriteLine("Komodo Claims Department\n" +
                    "1. See all claims\n" +
                    "2.Take care of next claim\n" +
                    "3.Enter a new claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Console.Clear();
            Console.ReadLine().ToLower();
            Queue<ClaimsType> claimList = _repo.GetList();

            Console.WriteLine("ClaimID	Type	Description  Amount	  DateOfIncident 	DateOfClaim	  IsValid\n");
            foreach(ClaimsType content in claimList)
            {
                Console.WriteLine($"{content.ClaimId}       {content.ClaimType}     {content.Description}    {content.ClaimAmount}     {content.DateOfIncident.ToShortDateString()}    {content.DateOfClaim.ToShortDateString()}     {content.IsValid}");

            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void TakeNextClaim()
        {
            Console.Clear();
            Console.WriteLine("The details of our next claim are as follows: \n");

            Queue<ClaimsType> newList = _repo.GetList();
            ClaimsType nextClaim = newList.Peek();

            Console.WriteLine($"ClaimId: {nextClaim.ClaimId}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                $"Date Of Incident: {nextClaim.DateOfIncident}\n" +
                $"Date Of Claim: {nextClaim.DateOfClaim}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"\n" +
                $"Would you like to take this claim? (yes/no");

            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "yes":
                    newList.Dequeue();
                    Console.WriteLine("Thank you. You have taken the claim.\n" +
                        "Please press any key to return to the main menu");
                    break;
                case "no":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter yes or no.");
                    break;
            }
            Console.ReadLine().ToLower();
        }

        public void EnterNewClaim()
        {
            ClaimsType content = new ClaimsType();

            Console.Clear();
            Console.WriteLine("ClaimID	Type	Description  Amount	  DateOfIncident 	DateOfClaim	  IsValid\n");

            Console.WriteLine("Please enter the new claim ID: ");
            content.ClaimId = int.Parse(Console.ReadLine());

            Console.WriteLine($"({content.ClaimId}) (Type) (Description) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Please enter the claim type: \n" +
                "1. Car\n" +
                "2. House\n" +
                "3. Theft\n");

            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "1":
                    content.ClaimType = ClaimsType.TypeOfClaim.Car;
                    break;
                case "2":
                    content.ClaimType = ClaimsType.TypeOfClaim.House;
                    break;
                case "3":
                    content.ClaimType = ClaimsType.TypeOfClaim.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine($"({content.ClaimId}) ({content.ClaimType}) (Description) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Please enter a description for the claim: ");
            content.Description = Console.ReadLine().ToLower();

            Console.Clear();
            Console.WriteLine($"({content.ClaimId}) ({content.ClaimType}) ({content.Description}) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Please enter the claim amount: ");
            content.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimId}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Please enter the date of the incident: ");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimId}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) ({content.DateOfIncident}) (Claim Date) (Valid)\n");

            Console.WriteLine("Please enter the date the claim was made: ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimId}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) ({content.DateOfIncident}) ({content.DateOfClaim}) (Valid)\n");

            Console.WriteLine("Please enter whether or not this is a valid claim: ");
            content.IsValid = bool.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimId}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) ({content.DateOfIncident}) ({content.DateOfClaim}) ({content.IsValid})\n");

            _repo.IsValid(content);

            Console.Clear();
            Console.WriteLine($"The following claim will be added to the queue: \n" +
                $"\n" +
                $"Id: {content.ClaimId}/n" +
                $"Type: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: {content.ClaimAmount}\n" +
                $"Incident Date: {content.DateOfIncident}\n" +
                $"Claim Date: {content.DateOfClaim}\n" +
                $"Valid: {content.IsValid}\n" +
                $"\n" +
                $"\n" +
                $"Please press any key to confirm adding new claim");
            Console.ReadKey();

            _repo.AddClaim(content);

            Console.Clear();
            Console.WriteLine("This claim was successfully added to the queue! Update successful.\n" +
                "Press any key to return to the main menu");
            Console.ReadKey();



        }

        public void SeedContent()
        {
            ClaimsType firstClaim = new ClaimsType(1, ClaimsType.TypeOfClaim.Car, "Accident on 465", 400, DateTime.Parse("4/25/2018"), DateTime.Parse("04/27/2018"), true);
            ClaimsType secondClaim = new ClaimsType(2, ClaimsType.TypeOfClaim.House, "Kitchen Fire", 4000, DateTime.Parse("04/26/2018"), DateTime.Parse("04/28/2018"), true);
            ClaimsType thirdClaim = new ClaimsType(3, ClaimsType.TypeOfClaim.Theft, "Stolen pancakes", 4, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);

            _repo.AddClaim(firstClaim);
            _repo.AddClaim(secondClaim);
            _repo.AddClaim(thirdClaim);

        }
    }
}

