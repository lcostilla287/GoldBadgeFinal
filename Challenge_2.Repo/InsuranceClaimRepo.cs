using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2.Repo
{
    public class InsuranceClaimRepo
    {
        private readonly Queue<InsuranceClaim> _insuranceClaims = new Queue<InsuranceClaim>();

        //Create
        public bool AddInsuranceClaimToQueue(InsuranceClaim newInsuraceClaim)
        {
            int startingCount = _insuranceClaims.Count;

            _insuranceClaims.Enqueue(newInsuraceClaim);

            bool wasAddedCorrectly = (_insuranceClaims.Count > startingCount) ? true : false;
            return wasAddedCorrectly;
        }

        //Read
        public Queue<InsuranceClaim> GetInsuranceClaims()
        {
            return _insuranceClaims;
        }

        public InsuranceClaim GetInsuranceClaimByClaimID(int claimID)
        {

            foreach(InsuranceClaim insuranceClaim in _insuranceClaims)
            {
                if (insuranceClaim.ClaimID == claimID)
                {
                    return insuranceClaim;
                }
            }
            return null;
        }

        //Update
        public bool UpdateExistingClaim(int claimID, InsuranceClaim updatedInsuranceClaim)
        {
            InsuranceClaim oldInsuranceClaim = GetInsuranceClaimByClaimID(claimID);

            if (oldInsuranceClaim != null)
            {
                oldInsuranceClaim.ClaimID = updatedInsuranceClaim.ClaimID;
                oldInsuranceClaim.ClaimType = updatedInsuranceClaim.ClaimType;
                oldInsuranceClaim.Description = updatedInsuranceClaim.Description;
                oldInsuranceClaim.ClaimAmount = updatedInsuranceClaim.ClaimAmount;
                oldInsuranceClaim.DateOfIncident = updatedInsuranceClaim.DateOfIncident;
                oldInsuranceClaim.DateOfClaim = updatedInsuranceClaim.DateOfClaim;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public void HandleNextClaim()
        {
            _insuranceClaims.Dequeue();
        }
    }
}
