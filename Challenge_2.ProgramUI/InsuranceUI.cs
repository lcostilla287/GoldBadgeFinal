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
                Console.WriteLine(String.Format("{0,-10} {1,-9} {2,-15} {3,-10} {4,-15} {5,-14} {6,-10}", claims.ClaimID, claims.ClaimType, claims.Description, claims.ClaimAmount, claims.DateOfIncident, claims.DateOfClaim, claims.IsValid));
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


        }

        private void HelpHandleClaim()
        {
            Console.WriteLine("Thanks for handling this claim!");
            _repo.HandleNextClaim();
            Console.ReadKey();
        }
    }
}
