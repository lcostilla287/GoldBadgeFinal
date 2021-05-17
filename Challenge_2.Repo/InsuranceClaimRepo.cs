using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2.Repo
{
    public class InsuranceClaimRepo
    {
        Queue<InsuranceClaim> insuranceClaims = new Queue<InsuranceClaim>();

        //Create
        public bool AddInsuranceClaimToQueue(InsuranceClaim newInsuraceClaim)
        {
            int startingCount = insuranceClaims.Count;

            insuranceClaims.Enqueue(newInsuraceClaim);

            bool wasAddedCorrectly = (insuranceClaims.Count > startingCount) ? true : false;
            return wasAddedCorrectly;
        }

        //Read
        public Queue<InsuranceClaim> GetInsuranceClaims()
        {
            return insuranceClaims;
        }
        //I don't think we need an update method for this one

        //Delete
        public void HandleNextClaim()
        {
            insuranceClaims.Dequeue();
        }
    }
}
