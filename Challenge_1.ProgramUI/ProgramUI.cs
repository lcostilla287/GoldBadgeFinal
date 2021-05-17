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
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome\n" +
                    "What would you like to do?");

                Console.WriteLine("Select an option (1-6):\n" +
                    "1. Create a new menu item\n" +
                    "2. View all menu items\n" +
                    "3. View menu item by meal number\n" +
                    "4. Update an existing menu item\n" +
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
                        DeleteExistingMenuItemByItemNumber();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
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

            Console.WriteLine("Please enter a new meal number:");
            newMenuItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the name of the meal?");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a description of the meal:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Please enter the ingredients of the meal:");
            newMenuItem.IngredientList = Console.ReadLine();

            Console.WriteLine("Finally, enter the price of the meal:");
            newMenuItem.MealPrice = Convert.ToDouble(Console.ReadLine());

            bool wasAddedCorrectly = _repo.AddMenuItemToDirectory(newMenuItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The new menu item was added successfully!");
            }
            else
            {
                Console.WriteLine("The new menu item could not be added. Please try again.");
            }
            Console.ReadKey();
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> allMenuItems = _repo.GetMenuItems();
            if (allMenuItems.Count != 0)
            {
                foreach (MenuItem menuItem in allMenuItems)
                {
                    Console.WriteLine($"Menu Number: {menuItem.MealNumber}\n" +
                        $"{menuItem.MealName}\n" +
                        $"Price: ${menuItem.MealPrice}");
                }
            }
            else
            {
                Console.WriteLine("There are no menu items to display");
            }
            Console.ReadKey();
        }

        private void DisplayMenuItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("What menu item number would you like to view?");

            MenuItem menuItemToDisplay = _repo.GetMenuItemByNumber(Convert.ToInt32(Console.ReadLine()));
            if (menuItemToDisplay != null)
            {
                Console.WriteLine($"Menu Number: {menuItemToDisplay.MealNumber}\n" +
                    $"{menuItemToDisplay.MealName}\n" +
                    $"Description: {menuItemToDisplay.Description}\n" +
                    $"Ingredients: {menuItemToDisplay.IngredientList}\n" +
                    $"Price: ${menuItemToDisplay.MealPrice}");
            }
            else
            {
                Console.WriteLine("There is no menu item by that number");
            }
            Console.ReadKey();
        }

        private void UpdateExistingMenuItem()
        {
            Console.Clear();
            List<MenuItem> allMenuItems = _repo.GetMenuItems();
            if (allMenuItems.Count > 0)
            {
                DisplayAllMenuItems();
                Console.WriteLine("Please enter the menu number of the menu item that you would like to update.");

                int menuNumber = Convert.ToInt32(Console.ReadLine());

                MenuItem updateMenuItem = new MenuItem();

                Console.WriteLine("Please enter a new menu number");
                updateMenuItem.MealNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the name of the meal");
                updateMenuItem.MealName = Console.ReadLine();

                Console.WriteLine("Please enter a meal description");
                updateMenuItem.Description = Console.ReadLine();

                Console.WriteLine("Please enter the ingredients of the meal");
                updateMenuItem.IngredientList = Console.ReadLine();

                Console.WriteLine("Finally, enter the price of the updated meal");
                updateMenuItem.MealPrice = Convert.ToDouble(Console.ReadLine());

                bool wasUpdated = _repo.UpdateExistingMenuItem(menuNumber, updateMenuItem);
                if (wasUpdated)
                {
                    Console.WriteLine("The menu item was successfully updated");
                }
                else
                {
                    Console.WriteLine("The menu item could not be updated");
                }
            }
            else
            {
                Console.WriteLine("There are no menu items to update");
            }
            Console.ReadKey();
        }

        private void DeleteExistingMenuItemByItemNumber()
        {
            Console.Clear();
            List<MenuItem> allMenuItems = _repo.GetMenuItems();
            if (allMenuItems.Count > 0)
            {
                DisplayAllMenuItems();
                Console.WriteLine("Please select a menu item number to delete");

                bool wasDeleted = _repo.DeleteExistingMenuItemByItemNumber(Convert.ToInt32(Console.ReadLine()));
                if (wasDeleted)
                {
                    Console.WriteLine("The menu item was successfully deleted");
                }
                else
                {
                    Console.WriteLine("The menu item could not be deleted");
                }
            }
            else
            {
                Console.WriteLine("There is nothing to delete");
            }
            Console.ReadKey();
        }
    }
}
