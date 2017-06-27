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
    public class PayPalnRepoTest : BaseUnitTest<PayPal>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PayPalRepo repo;

        protected override void SetContextData()
        {
            repo = new PayPalRepo(testCtx);

            var b = new Faker<PayPal>()
                .RuleFor(r => r.PayPalId, f => itrtr32++)
                .RuleFor(r => r.TxnId, f => f.Lorem.Letter(50))
                .RuleFor(r => r.PaymentDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.McGross, f => f.Random.Decimal())
                .RuleFor(r => r.McFee, f => f.Random.Decimal())
                .RuleFor(r => r.PayPalPostVars, f => f.Lorem.Letter(2000))
                .RuleFor(r => r.SourceIp, f => f.Lorem.Letter(50))
                .RuleFor(r => r.PaymentId, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.PayPalId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PayPal.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePayPal()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PayPalId);

            Assert.AreEqual(fakeApp.PayPalId, single.PayPalId);
            Assert.AreEqual(fakeApp.TxnId, single.TxnId);
            Assert.AreEqual(fakeApp.PaymentDate, single.PaymentDate);
            Assert.AreEqual(fakeApp.McGross, single.McGross);
            Assert.AreEqual(fakeApp.McFee, single.McFee);
            Assert.AreEqual(fakeApp.PayPalPostVars, single.PayPalPostVars);
            Assert.AreEqual(fakeApp.SourceIp, single.SourceIp);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
        }

        public void GetSinglePayPalIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePayPal()
        {
            var currentCnt = testCtx.PayPal.Count();

            var entity = testCtx.PayPal.First();
            repo.Delete(entity.PayPalId);
            repo.Save();

            Assert.IsTrue(testCtx.PayPal.Count() == --currentCnt);
        }

        public void DeletePayPalIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
