using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2.ProgramUI
{
    public class InsuranceUI
    {
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
            Console.WriteLine("Here are all of the current claims in the queue:");

        }
    }
}
