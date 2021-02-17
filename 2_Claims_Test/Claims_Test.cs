using _2_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _2_Claims_Test
{
    [TestClass]
    public class Claims_Test
    {
        private ClaimsRepo _repo;
        private ClaimsType _claims;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new ClaimsRepo();
            _claims = new ClaimsType(1, ClaimsType.TypeOfClaim.Car, "Accident on 465", 400, DateTime.Parse("4/25/2018"), DateTime.Parse("04/27/2018"), true);
        }

        [TestMethod]
        public void GetListTest()
        {
            _repo.GetList();
            Assert.IsNotNull(_repo);
        }

        [TestMethod]
        public void ClaimTest()
        {
            ClaimsType newClaimsType = new ClaimsType(2, ClaimsType.TypeOfClaim.House, "Kitchen Fire", 4000, DateTime.Parse("04/26/2018"), DateTime.Parse("04/28/2018"), true);

            Assert.AreEqual(2, newClaimsType.ClaimId);
            Assert.AreEqual(ClaimsType.TypeOfClaim.House, newClaimsType.ClaimType);
            Assert.AreEqual("Kitchen Fire", newClaimsType.Description);
            Assert.AreEqual(4000, newClaimsType.ClaimAmount);
            Assert.AreEqual(("04/26/2018"), newClaimsType.DateOfIncident);
            Assert.AreEqual(("04/28/2018"), newClaimsType.DateOfClaim);
            Assert.AreEqual(true, newClaimsType.IsValid);
        }

        [TestMethod]
        public void AddClaimTest()
        {
            _repo.AddClaim(_claims);
            int expected = 1;
            int actual = _repo.GetList().Count;

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void DeleteClaimTest()
        {
            ClaimsRepo content = new ClaimsRepo();
        }

        [TestMethod]
        public void IsValid()
        {
            _repo.AddClaim(_claims);
            bool expected = true;
            bool actual = _claims.IsValid;

            Assert.AreEqual(expected, actual);
        }

       
    }
}
