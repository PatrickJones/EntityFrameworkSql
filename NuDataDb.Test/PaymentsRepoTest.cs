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
    public class PaymentsnRepoTest : BaseUnitTest<Payments>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PaymentsRepo repo;

        protected override void SetContextData()
        {
            repo = new PaymentsRepo(testCtx);

            var b = new Faker<Payments>()
                .RuleFor(r => r.PaymentId, f => itrtr32++)
                .RuleFor(r => r.PaymentMethod, f => f.Random.Int())
                .RuleFor(r => r.PaymentApproved, f => f.Random.Bool())
                .RuleFor(r => r.ApprovalDate, f => new DateTime(f.Random.Long()));

            var bs = b.Generate(3).OrderBy(o => o.PaymentId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Payments.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePayments()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PaymentId);

            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(fakeApp.PaymentApproved, single.PaymentApproved);
            Assert.AreEqual(fakeApp.ApprovalDate, single.ApprovalDate);
        }

        public void GetSinglePaymentIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePayments()
        {
            var currentCnt = testCtx.Payments.Count();

            var entity = testCtx.Payments.First();
            repo.Delete(entity.PaymentId);
            repo.Save();

            Assert.IsTrue(testCtx.Payments.Count() == --currentCnt);
        }

        public void DeletePaymentIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
