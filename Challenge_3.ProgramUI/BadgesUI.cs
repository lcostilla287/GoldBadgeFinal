using Challenge_2.Repository; //note this is actually Chalenge_3.Repository
using Challenge_3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3.ProgramUI
{
    public class BadgesUI
    {
        private BadgesRepo _repo = new BadgesRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu\n" +
                    " ");
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Delete a badge\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        DeleteABadge();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void AddABadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();
            Console.Write("What is the number on the badge: ");
            newBadge.BadgeID = Convert.ToInt32(Console.ReadLine());

            bool miniLoop = true;
            while (miniLoop)
            {
                Console.Write("List a door that it needs access to: ");
                newBadge.DoorNames.Add(Console.ReadLine());

                Console.Write("Any other doors(y/n)?");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                        break;
                    case "n":
                        _repo.AddBadgeToDictionary(newBadge);
                        miniLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option");
                        Console.ReadKey();
                        break;
                }  
            }
        }

        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            Dictionary<int, List<string>> badge = _repo.GetBadgeValuePairsByBadgeID(badgeID);
            if (badge != null)
            {
                Console.Write("List a door that it needs access to: ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry there are no badges by that ID");
            }

        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _repo.GetBadgeValuePairs();

            Console.WriteLine("Key");
            Console.WriteLine("Badge #     Door Access");

            foreach(KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine(badge);// string format this later
            }
        }

        private void DeleteABadge()
        {
            Console.Clear();
        }
    }
}
