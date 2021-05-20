using Challenge_2.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge_2.UnitTest
{
    [TestClass]
    public class Challenge_2Tests
    {
        [TestMethod]
        public void AddToQueue_ShouldReturnTrue()
        {
            InsuranceClaim claim = new InsuranceClaim();
            InsuranceClaimRepo repo = new InsuranceClaimRepo();

            bool addResult = repo.AddInsuranceClaimToQueue(claim);

            Assert.IsTrue(addResult);
        }

        private InsuranceClaim _claim;
        private InsuranceClaimRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new InsuranceClaimRepo();
            _claim = new InsuranceClaim(6, ClaimType.Theft, "Stolen Cheeburg", 5.35, DateTime.Parse("05/10/21"), DateTime.Parse("05/13/21"));
            _repo.AddInsuranceClaimToQueue(_claim);
        }

        [TestMethod]
        public void GetQueue_ShouldReturnTrue()
        {
            Queue <InsuranceClaim> queue = _repo.GetInsuranceClaims();

            bool queueHasClaim = queue.Contains(_claim);
            Assert.IsTrue(queueHasClaim);
        }

        [TestMethod]
        public void GetClaimByClaimID_ShouldReturnCorrectClaim()
        {
            InsuranceClaim searchResult = _repo.GetInsuranceClaimByClaimID(6);

            Assert.AreEqual(_claim, searchResult);
        }

        [TestMethod]
        public void UpdateExistingClaim_ShouldReturnTrue()
        {
            _repo.UpdateExistingClaim(6, new InsuranceClaim(6, ClaimType.Theft, "Stolen hamburg", 1.55, DateTime.Parse("05/11/21"), DateTime.Parse("05/15/21")));

            Assert.AreEqual(_claim.Description, "Stolen hamburg");
        }

        [TestMethod]
        public void DequeueExistingClaim_ShouldReturnNull()
        {
            InsuranceClaim queue = _repo.GetInsuranceClaimByClaimID(6);
            _repo.HandleNextClaim();
            
            Assert.IsNull(_repo.GetInsuranceClaimByClaimID(6));
        }
    }
}
