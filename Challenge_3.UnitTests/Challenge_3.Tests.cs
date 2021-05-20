using Challenge_2.Repository;
using Challenge_3.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge_3.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToDictionary_ShouldReturnTrue()
        {
            Badges badge = new Badges();
            BadgesRepo repo = new BadgesRepo();

            bool wasAdded = repo.AddBadgeToDictionary(badge);

            Assert.IsTrue(wasAdded);
        }

        private Badges _badge;
        private BadgesRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepo();
            _badge = new Badges(3345, new List<string> {"C3", "B7", "D1"});
            _repo.AddBadgeToDictionary(_badge);
        }

        [TestMethod]
        public void GetDictionary_ShouldReturnTrue()
        {
            Dictionary<int, List<string>> dictionary = _repo.GetBadgeValuePairs();

            bool dictionaryHasKey = dictionary.ContainsKey(_badge.BadgeID);
            // bool keyHasValue = dictionary;

            Assert.IsTrue(dictionaryHasKey);
        }

        [TestMethod]
        public void GetBadgeValuePairsByBadgeID_ShouldReturnCorrectValuePair()
        {
            Dictionary<int, List<string>> searchResult = _repo.GetBadgeValuePairsByBadgeID(3345);

            
        }

        [TestMethod]
        public void RemoveADoor_ShouldReturnTrue()
        {
            bool doorWasRemoved = _repo.RemoveDoorFromBadge(3345, "C3");

            Assert.IsTrue(doorWasRemoved);
        }

        [TestMethod]
        public void AddADoor()
        {
            bool doorWasAdded = _repo.AddDoorToBadge(3345, "C7");
            Assert.IsTrue(doorWasAdded);
        }

        [TestMethod]
        public void DeleteABadge()
        {
            bool badgeWasDeleted = _repo.RemoveBadge(3345);
            Assert.IsTrue(badgeWasDeleted);
        }
    }
}
