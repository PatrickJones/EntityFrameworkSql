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
    public class SubscriptionsViewRepoTest : BaseUnitTest<NuMedicsGlobalContext, SubscriptionsView>
    {
        protected SubscriptionsViewRepo repo;

        protected override void SetContextData()
        {
            repo = new SubscriptionsViewRepo(testCtx);

            var b = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => f.Random.Int(1, 8))
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => f.Random.Bool())
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => f.Random.Int(1,2))
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => f.Random.Int(1, 4))
                .RuleFor(r => r.PaymentId, f => f.Random.Int())
                .RuleFor(r => r.CheckId, f => f.Random.Int())
                .RuleFor(r => r.CheckStatus, f => f.Random.Int(1, 5))
                .RuleFor(r => r.CheckNumber, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.CheckCode, f => f.Random.Long())
                .RuleFor(r => r.CheckDateRecieved, f => f.Date.Past())
                .RuleFor(r => r.CheckAmount, f => f.Finance.Amount())
                .RuleFor(r => r.PayPalId, f => f.Random.Int())
                .RuleFor(r => r.PayPalPaymentDate, f => f.Date.Past())
                .RuleFor(r => r.PayPalPaymentStatus, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.PayPalPayment, f => f.Finance.Amount());

            var bs = b.Generate(3).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Set<SubscriptionsView>().AddRange(bs);
            int added = testCtx.SaveChanges();
        }

    }
}
