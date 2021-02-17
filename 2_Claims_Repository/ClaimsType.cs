using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claims_Repository
{
    public class ClaimsType
    {
        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }


        public enum TypeOfClaim { Car = 1, House, Theft }

        public ClaimsType() { }
        public ClaimsType(int claimId, TypeOfClaim claimType, string description, decimal claimAmount,
            DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;

        }

    }
}