using Challenge_1.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge_1.Repo
{
    [TestClass]
    public class Challenge_1Tests
    {
        [TestMethod]
        public void AddToDirectory_ShouldReturnTrue()
        {
            MenuItem item = new MenuItem();
            MenuRepo repository = new MenuRepo();

            bool addResult = repository.AddMenuItemToDirectory(item);
            Assert.IsTrue(addResult);
        }

        //fields here
        private MenuItem _item;
        private MenuRepo _repo;

        //Arrange
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _item = new MenuItem(2, "CheeBurg", "Yummy", "Cheese, Hamburger, Buns", 2.00);
            _repo.AddMenuItemToDirectory(_item);
        }

        [TestMethod]
        public void GetByItemNumber_ShouldReturnCorrectMenuItem()
        {
            //Act
            MenuItem searchResult = _repo.GetMenuItemByNumber(2);
            //Assert
            Assert.AreEqual(_item, searchResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnTrue()
        {
            List<MenuItem> directory = _repo.GetMenuItems();

            bool directoryHasMenuItems = directory.Contains(_item);
            Assert.IsTrue(directoryHasMenuItems);
        }

        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnTrue()
        {
            _repo.UpdateExistingMenuItem(2, new MenuItem(3, "Hamburg", "Delicious", "Hamburger, Buns", 1.95));

            Assert.AreEqual(_item.MealName, "Hamburg");
        }

        [TestMethod]
        public void DeleteExistingMenuItem_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteExistingMenuItemByItemNumber(2);

            Assert.IsTrue(wasDeleted);
        }
    }
}
