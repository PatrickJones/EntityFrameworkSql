using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using NuDataDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public class AssignedUserTypesRepoTest : BaseUnitTest<NuMedicsGlobalContext, AssignedUserTypes>
    {
        protected AssignedUserTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new AssignedUserTypesRepo(testCtx);

            var b = new Faker<AssignedUserTypes>()
                .RuleFor(r => r.UserType, f => f.PickRandom<int>(1, 2, 3))
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).ToList();
            FakeCollection.AddRange(bs);

            testCtx.AssignedUserTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleAssignedUserType()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Id);

            Assert.AreEqual(fakeApp.Id, single.Id);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.UserId, single.UserId);

        }
        
        [TestMethod]
        public void GetSingleIdNotExist()
        {
            var fakeId = 888;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteAssignedUserType()
        {
            var currentCnt = testCtx.AssignedUserTypes.Count();

            var entity = testCtx.AssignedUserTypes.First();
            repo.Delete(entity.Id);
            repo.Save();

            Assert.IsTrue(testCtx.AssignedUserTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteIdNotExist()
        {
            var currentCnt = testCtx.AssignedUserTypes.Count();

            var fakeId = new int();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AssignedUserTypes.Count() == currentCnt);
        }

    }
}
