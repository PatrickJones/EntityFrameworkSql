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
    public class BasalDeliveriesRepoTest_old : BaseUnitTest<BasalDeliveries>
    {
        protected BasalDeliveriesRepo repo;

        int sequential = 0;

        protected override void SetContextData()
        {
            repo = new BasalDeliveriesRepo(testCtx);

            var b = new Faker<BasalDeliveries>()
                .RuleFor(r => r.BasalDeliveryId, f => sequential++)
                .RuleFor(r => r.AmountDelivered, f => f.Random.Int())
                .RuleFor(r => r.DeliveryRate, f => f.Random.Float())
                .RuleFor(r => r.IsTemp, f => f.Random.Bool())
                .RuleFor(r => r.Duration, f => f.Lorem.Word())
                .RuleFor(r => r.StartDateTime, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.BasalDeliveryId)
                .ToList();
            FakeCollection.AddRange(bs);

            testCtx.BasalDeliveries.AddRange(bs);
            testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBasalDeliveries()
        {
            var fakeApp = FakeCollection.First();
            //var single = repo.GetSingle(fakeApp.ApplicationId);
        }
    }

    //[TestClass] // temporarily here to generate code.
    //public class codeitclass
    //{
    //    [TestMethod]
    //    public void GenerateCodes()
    //    {
    //        GenerateTheCode codeit = new GenerateTheCode();
    //        codeit.GenRepoCode();
    //        codeit.GenRepoTestCode();
    //    }
    //}
}
