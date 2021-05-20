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
    }
}
