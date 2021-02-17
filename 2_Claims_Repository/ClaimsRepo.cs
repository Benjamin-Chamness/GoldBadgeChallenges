using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claims_Repository
{
    public class ClaimsRepo
    {
        private Queue<ClaimsType> _claims = new Queue<ClaimsType>();
        public Queue<ClaimsType> GetList()
        {
            return _claims;
        }

        public void AddClaim(ClaimsType newClaim)
        {
            _claims.Enqueue(newClaim);
        }

        public void DeleteClaim()
        {
            _claims.Dequeue();
        }

        public void IsValid(ClaimsType claim)
        {
            TimeSpan diff = claim.DateOfClaim - claim.DateOfIncident;

            if (diff.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;

        }
    }
}
