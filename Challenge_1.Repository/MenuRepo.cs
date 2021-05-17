using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1.Repository
{
    public class MenuRepo
    {
        private readonly List<MenuItem> _menuItemsDirectory = new List<MenuItem>();


        //Create
        //I use a bool here because I want to make sure that the new menu item adds correctly
        public bool AddMenuItemToDirectory(MenuItem newMenuItem)
        {
            int startingCount = _menuItemsDirectory.Count;

            _menuItemsDirectory.Add(newMenuItem);

            bool wasAdded = (_menuItemsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        //Read
        //Displays all menu items in the menu item list
        public List<MenuItem> GetMenuItems()
        {
            return _menuItemsDirectory;
        }

        //Also Read
        //I want to get the list item based on the number here
        public MenuItem GetMenuItemByNumber(int menuItemNumber)
        {
            foreach (MenuItem menuItem in _menuItemsDirectory)
            {
                if (menuItem.MealNumber == menuItemNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }

        //Update
        // I also use a bool here because I want to make sure it updates successfully
        public bool UpdateExistingMenuItem(int menuItemNumber, MenuItem updatedMenuItem)
        {
            MenuItem oldMenuItem = GetMenuItemByNumber(menuItemNumber);

            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = updatedMenuItem.MealNumber;
                oldMenuItem.MealName = updatedMenuItem.MealName;
                oldMenuItem.Description = updatedMenuItem.Description;
                oldMenuItem.IngredientList = updatedMenuItem.IngredientList;
                oldMenuItem.MealPrice = updatedMenuItem.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        //I want to give an indication later when the item is successfully deleted
        public bool DeleteExistingMenuItemByItemNumber(int menuItemNumber)
        {
            MenuItem menuItemToDelete = GetMenuItemByNumber(menuItemNumber);
            if (menuItemToDelete != null)
            {
                _menuItemsDirectory.Remove(menuItemToDelete);
                return true;
            }
            else return false;
        }
    }
}
