using Challenge_2.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2.ProgramUI
{
    public class InsuranceUI
    {
        private InsuranceClaimRepo _repo = new InsuranceClaimRepo();
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome\n" +
                    "What would you like to do:");
                Console.WriteLine("Select an option (1-4)\n" +
                    "1. See all claims\n" +
                    "2. Take care of the next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Update a claim\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        UpdateAClaim();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid menu option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Here are all of the current claims in the queue:");
            Console.WriteLine(" ");
            Console.WriteLine(String.Format("{0,-10} {1,-9} {2,-25} {3,-13} {4,-15} {5,-14} {6,-10}", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid" ));

            Queue<InsuranceClaim> claimQueue = _repo.GetInsuranceClaims();
            foreach(InsuranceClaim claims in claimQueue)
            {
                Console.WriteLine(String.Format("{0,-10} {1,-9} {2,-25} ${3,-12} {4,-15:MM/dd/yy} {5,-14:MM/dd/yy} {6,-10}", claims.ClaimID, claims.ClaimType, claims.Description, claims.ClaimAmount, claims.DateOfIncident, claims.DateOfClaim, claims.IsValid));
            }
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here is the next claim to be handled:");
            Console.WriteLine("");

            Queue<InsuranceClaim> claimQueue = _repo.GetInsuranceClaims();
            InsuranceClaim firstClaim = claimQueue.Peek();
            Console.WriteLine($"ClaimID: {firstClaim.ClaimID}\n" +
                $"Type: {firstClaim.ClaimType}\n" +
                $"Description: {firstClaim.Description}\n" +
                $"Amount: ${firstClaim.ClaimAmount}\n" +

                //wanted the dates to be formatted nicely here
                $"DateOfAccident: {firstClaim.DateOfIncident.ToString("MM/dd/yy")}\n" +
                $"DateOfClaim: {firstClaim.DateOfClaim.ToString("MM/dd/yy")}\n" +

                $"IsValid: {firstClaim.IsValid}\n" +
                $" ");
            Console.WriteLine("Do want to deal with this claim now(y/n)?");

            string response = Console.ReadLine();

            switch (response)
            {
                case "y":
                    HelpHandleClaim();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Please choose a valid option");
                    Console.ReadKey();
                    TakeCareOfNextClaim();
                    break;
            }
            
        }

        private void EnterANewClaim()
        {
            Console.Clear();
            InsuranceClaim newInsuranceClaim = new InsuranceClaim();
            //use consolewrite instead of writeline
            //did a little research here to have the input on the same line and convert the string into and enum. sorry for all of the one liners
            Console.Write("Enter the claim id: ");
            newInsuranceClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the claim type: ");
            newInsuranceClaim.ClaimType = (ClaimType)Enum.Parse(typeof(ClaimType), Console.ReadLine());

            Console.Write("Enter a claim description: ");
            newInsuranceClaim.Description = Console.ReadLine();

            Console.Write("Amount of Damage: $");
            newInsuranceClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Date of Accident(mm/dd/yy): ");
            newInsuranceClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim(mm/dd/yy): ");
            newInsuranceClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            if (newInsuranceClaim.IsValid)
            {
                Console.WriteLine("The claim is valid");
            }
            else 
            { 
                Console.WriteLine("The claim is invalid"); 
            }
            Console.ReadKey();

            bool wasAdded = _repo.AddInsuranceClaimToQueue(newInsuranceClaim);
            if (wasAdded)
            {
                Console.WriteLine("The claim was successfully added to the queue");
            }
            else
            {
                Console.WriteLine("The claim could not be added");
            }
            Console.ReadKey();
        }

        private void HelpHandleClaim()
        {
            Console.WriteLine("Thanks for handling this claim!");
            _repo.HandleNextClaim();
            Console.ReadKey();
        }

        private void UpdateAClaim()
        {
            Console.Clear();
            SeeAllClaims();
            Console.WriteLine(" ");

            Console.WriteLine("Please enter the claim ID you would like to update:");
            int ClaimIDInput = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            InsuranceClaim newInsuranceClaim = new InsuranceClaim();
            
            Console.Write("Enter the new claim id: ");
            newInsuranceClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the claim type: ");
            newInsuranceClaim.ClaimType = (ClaimType)Enum.Parse(typeof(ClaimType), Console.ReadLine());

            Console.Write("Enter a claim description: ");
            newInsuranceClaim.Description = Console.ReadLine();

            Console.Write("Amount of Damage: $");
            newInsuranceClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Date of Accident(mm/dd/yy): ");
            newInsuranceClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim(mm/dd/yy): ");
            newInsuranceClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            if (newInsuranceClaim.IsValid)
            {
                Console.WriteLine("The claim is valid");
            }
            else Console.WriteLine("The claim is invalid");

            bool wasUpdated = _repo.UpdateExistingClaim(ClaimIDInput, newInsuranceClaim);
            if (wasUpdated)
            {
                Console.WriteLine("The claim was successfully updated");
            }
            else 
            {
                Console.WriteLine("The claim could not be updated");
            }
            Console.ReadKey();
        }

        private void SeedContentList()
        {
            InsuranceClaim insuranceClaim1 = new InsuranceClaim(1, ClaimType.Car, "Car accident on 465.", 400.00, DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"));
            _repo.AddInsuranceClaimToQueue(insuranceClaim1);

            InsuranceClaim insuranceClaim2 = new InsuranceClaim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, DateTime.Parse("4/11/18"), DateTime.Parse("4/12/18"));
            _repo.AddInsuranceClaimToQueue(insuranceClaim2);

            InsuranceClaim insuranceClaim3 = new InsuranceClaim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, DateTime.Parse("4/27/18"), DateTime.Parse("6/01/18"));
            _repo.AddInsuranceClaimToQueue(insuranceClaim3);
        }
    }
}
