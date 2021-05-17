using Challenge_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1.ProgramUI
{
    public class ProgramUI
    {
        private MenuRepo _repo = new MenuRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.WriteLine("Welcome\n" +
                    "What would you like to do?");

                Console.WriteLine("Select an option (1-6):\n" +
                    "1. Create a new menu item\n" +
                    "2. View all menu items\n" +
                    "3. View menu item by meal number\n" +
                    "4. Update an esisting menu item\n" +
                    "5. Delete an existing menu item\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        DisplayMenuItemByNumber();
                        break;
                    case "4":
                        UpdateExistingMenuItem();
                        break;
                    case "5":
                        DeleteExistingMenuItem();
                        break;
                    case "6":
                        keeprunning = false;
                    default:
                        Console.WriteLine("Please select a valid menu option");
                        break;
                }
            }
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Please enter a new meal number");
        }
    }
}
