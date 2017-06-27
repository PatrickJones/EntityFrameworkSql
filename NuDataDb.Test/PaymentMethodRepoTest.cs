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
    public class PaymentMethodnRepoTest : BaseUnitTest<PaymentMethod>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PaymentMethodRepo repo;

        protected override void SetContextData()
        {
            repo = new PaymentMethodRepo(testCtx);

            var b = new Faker<PaymentMethod>()
                .RuleFor(r => r.MethodId, f => itrtr32++)
                .RuleFor(r => r.MethodName, f => f.Lorem.Letter(50));

            var bs = b.Generate(3).OrderBy(o => o.MethodId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PaymentMethod.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePaymentMethod()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.MethodId);

            Assert.AreEqual(fakeApp.MethodId, single.MethodId);
            Assert.AreEqual(fakeApp.MethodName, single.MethodName);
        }

        public void GetSingleMethodIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePaymentMethod()
        {
            var currentCnt = testCtx.PaymentMethod.Count();

            var entity = testCtx.PaymentMethod.First();
            repo.Delete(entity.MethodId);
            repo.Save();

            Assert.IsTrue(testCtx.PaymentMethod.Count() == --currentCnt);
        }

        public void DeleteMethodIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
