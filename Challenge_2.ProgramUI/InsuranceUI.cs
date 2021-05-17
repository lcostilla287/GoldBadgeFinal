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
                    "3 Enter a new claim\n" +
                    "4. Exit");

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
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid menu option");
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Here are all of the current claims in the queue:");
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,-10} {1,-9} {2,-15} {3,-10} {4,-15} {5,-14} {6,-10}", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid" ));

            Queue<InsuranceClaim> claimQueue = _repo.GetInsuranceClaims();
            foreach(InsuranceClaim claims in claimQueue)
            {
                Console.WriteLine(String.Format("{0,-10} {1,-9} {2,-15} {3,-10} {4,-15:MM/dd/yy} {5,-14:MM/dd/yy} {6,-10}", claims.ClaimID, claims.ClaimType, claims.Description, claims.ClaimAmount, claims.DateOfIncident, claims.DateOfClaim, claims.IsValid));
            }
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here is the next claim to be handled:");

            Queue<InsuranceClaim> claimQueue = _repo.GetInsuranceClaims();
            InsuranceClaim firstClaim = claimQueue.Peek();
            Console.WriteLine($"ClaimID: {firstClaim.ClaimID}\n" +
                $"\n" +
                $"Type: {firstClaim.ClaimType}\n" +
                $"\n" +
                $"Description: {firstClaim.Description}\n" +
                $"\n" +
                $"Amount: {firstClaim.ClaimAmount}\n" +
                $"\n" +
                $"DateOfAccident: {firstClaim.DateOfIncident}\n" +
                $"\n" +
                $"DateOfClaim: {firstClaim.DateOfClaim}\n" +
                $"\n" +
                $"IsValid: {firstClaim.IsValid}\n" +
                $" ");
            Console.WriteLine("Do want to deal with this claim now(y/n)?");

            string response = Console.ReadLine();

            switch (response)
            {
                case "y":
                    HelpHandleClaim();
                    break;
                default:
                    Menu();
                    break;
            }
            
        }

        private void EnterANewClaim()
        {
            Console.Clear();
            InsuranceClaim newInsuranceClaim = new InsuranceClaim();

            //did a little research here to have the input on the same line and convert the string into and enum. sorry for all of the one liners
            Console.WriteLine($"Enter the claim id: {newInsuranceClaim.ClaimID = Convert.ToInt32(Console.ReadLine())}");
            Console.WriteLine(" ");
            Console.WriteLine($"Enter the claim type: {newInsuranceClaim.ClaimType = (ClaimType)Enum.Parse(typeof(ClaimType), Console.ReadLine())}");
            Console.WriteLine(" ");
            Console.WriteLine($"Enter a claim description: {newInsuranceClaim.Description = Console.ReadLine()}");
            Console.WriteLine(" ");
            Console.WriteLine($"Amount of Damage: ${newInsuranceClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine())}");
            Console.WriteLine(" ");

            Console.WriteLine($"Date of Accident(mm/dd/yyyy): {newInsuranceClaim.DateOfIncident = DateTime.Parse(Console.ReadLine())}");
            Console.WriteLine(" ");
            Console.WriteLine($"Date of Claim(mm/dd/yyyy): {newInsuranceClaim.DateOfClaim = DateTime.Parse(Console.ReadLine())}");

            if (newInsuranceClaim.IsValid)
            {
                Console.WriteLine("The claim is valid");
            }
            else Console.WriteLine("The claim is invalid");
            
        }

        private void HelpHandleClaim()
        {
            Console.WriteLine("Thanks for handling this claim!");
            _repo.HandleNextClaim();
            Console.ReadKey();
        }
    }
}
