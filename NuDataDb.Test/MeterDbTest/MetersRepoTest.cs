using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EFMetersDb;
using NuDataDb.Repositories.MeterDbRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test.MeterDbTest
{
    [TestClass]
    public class MetersRepoTest : BaseUnitTest<MeterDevicesDbContext, Meters>
    {
        protected MetersRepo repo;

        protected override void SetContextData()
        {
            repo = new MetersRepo(testCtx);

            var f = new Faker<Meters>()
                .RuleFor(r => r.Corporation, v => v.Company.CompanyName())
                .RuleFor(r => r.CurrentlyActive, v => v.Random.Bool())
                .RuleFor(r => r.ExternalId, v => v.Lorem.Word())
                .RuleFor(r => r.InsuletMarket, v => v.Random.Bool())
                .RuleFor(r => r.MeterClass, v => v.Lorem.Word())
                .RuleFor(r => r.MeterDelphiIndex, v => v.Random.Int(1, 76))
                .RuleFor(r => r.MeterDelphiName, v => v.Lorem.Word())
                .RuleFor(r => r.MeterImageName, v => v.Lorem.Word())
                .RuleFor(r => r.MeterManufacturer, v => v.Company.CompanyName())
                .RuleFor(r => r.MeterModel, v => v.Lorem.Word())
                .RuleFor(r => r.MeterName, v => v.Lorem.Word())
                .RuleFor(r => r.MeterPid, v => v.Lorem.Word())
                .RuleFor(r => r.MeterVid, v => v.Lorem.Word());

            var gen = f.Generate(3).OrderBy(o => o.Id).ToList();
            testCtx.Meters.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleMeters()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Id);

            Assert.AreEqual(fakeApp.Id, single.Id);
            Assert.AreEqual(fakeApp.Corporation, single.Corporation);
            Assert.AreEqual(fakeApp.MeterName, single.MeterName);
            Assert.AreEqual(fakeApp.MeterDelphiIndex, single.MeterDelphiIndex);
        }

        [TestMethod]
        public void GetSingleMetersIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteMeters()
        {
            var currentCnt = testCtx.Meters.Count();

            var entity = testCtx.Meters.First();
            repo.Delete(entity.Id);
            repo.Save();

            Assert.IsTrue(testCtx.Meters.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteMetersIdNotExist()
        {
            var currentCnt = testCtx.Meters.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.Meters.Count() == currentCnt);
        }
    }
}
