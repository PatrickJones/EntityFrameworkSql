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

            //Patient Check
            var b = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => f.PickRandom<int>(1, 2, 3, 4))
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => false)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 1)
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => 2)
                .RuleFor(r => r.PaymentId, f => f.Random.Int())
                .RuleFor(r => r.CheckId, f => f.Random.Int())
                .RuleFor(r => r.CheckStatus, f => f.Random.Int(1, 5))
                .RuleFor(r => r.CheckNumber, f => f.Random.Word().Take(3).ToString())
                .RuleFor(r => r.CheckCode, f => f.Random.Long())
                .RuleFor(r => r.CheckDateRecieved, f => f.Date.Past())
                .RuleFor(r => r.CheckAmount, f => f.Finance.Amount());

            //Patient PayPal
            var c = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => f.PickRandom<int>(1, 2, 3, 4))
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => false)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 1)
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => 1)
                .RuleFor(r => r.PaymentId, f => f.Random.Int())
                .RuleFor(r => r.CheckId, f => 0)
                .RuleFor(r => r.CheckStatus, f => 0)
                .RuleFor(r => r.CheckNumber, f => String.Empty)
                .RuleFor(r => r.CheckCode, f => 0)
                .RuleFor(r => r.CheckDateRecieved, f => new DateTime(1800, 1, 1))
                .RuleFor(r => r.CheckAmount, f => 0)
                .RuleFor(r => r.PayPalId, f => f.Random.Int())
                .RuleFor(r => r.PayPalPaymentDate, f => f.Date.Past())
                .RuleFor(r => r.PayPalPaymentStatus, f => f.Random.Word().Take(3).ToString())
                .RuleFor(r => r.PayPalPayment, f => f.Finance.Amount());

            //Clinician
            var d = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => f.PickRandom<int>(5, 6))
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => false)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 2)
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => 3)
                .RuleFor(r => r.PaymentId, f => f.Random.Int())
                .RuleFor(r => r.CheckId, f => f.Random.Int())
                .RuleFor(r => r.CheckStatus, f => f.Random.Int(1, 5))
                .RuleFor(r => r.CheckNumber, f => f.Random.Word().Take(3).ToString())
                .RuleFor(r => r.CheckCode, f => 0)
                .RuleFor(r => r.CheckDateRecieved, f => f.Date.Past())
                .RuleFor(r => r.CheckAmount, f => f.Finance.Amount());

            //Patient Trial
            var e = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => 0)
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => true)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 1)
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => 0)
                .RuleFor(r => r.PaymentId, f => 0)
                .RuleFor(r => r.CheckId, f => 0)
                .RuleFor(r => r.CheckStatus, f => 0)
                .RuleFor(r => r.CheckNumber, f => String.Empty)
                .RuleFor(r => r.CheckCode, f => 0)
                .RuleFor(r => r.CheckDateRecieved, f => new DateTime(1800, 1, 1))
                .RuleFor(r => r.CheckAmount, f => 0);

            //Patient Free Download
            var g = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => 8)
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => false)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 1)
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => 0)
                .RuleFor(r => r.PaymentId, f => 0)
                .RuleFor(r => r.CheckId, f => 0)
                .RuleFor(r => r.CheckStatus, f => 0)
                .RuleFor(r => r.CheckNumber, f => String.Empty)
                .RuleFor(r => r.CheckCode, f => 0)
                .RuleFor(r => r.CheckDateRecieved, f => new DateTime(1800, 1, 1))
                .RuleFor(r => r.CheckAmount, f => 0);

            //Adjustment
            var h = new Faker<SubscriptionsView>()
                .RuleFor(r => r.SubscriptionId, f => f.Random.Int())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionType, f => 7)
                .RuleFor(r => r.SubscriptionDate, f => f.Date.Past())
                .RuleFor(r => r.ExpirationDate, f => f.Date.Future())
                .RuleFor(r => r.IsTrial, f => false)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => f.PickRandom<int>(1,2))
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PaymentMethod, f => 4)
                .RuleFor(r => r.PaymentId, f => 0)
                .RuleFor(r => r.CheckId, f => 0)
                .RuleFor(r => r.CheckStatus, f => 0)
                .RuleFor(r => r.CheckNumber, f => String.Empty)
                .RuleFor(r => r.CheckCode, f => 0)
                .RuleFor(r => r.CheckDateRecieved, f => new DateTime(1800, 1, 1))
                .RuleFor(r => r.CheckAmount, f => 0);

            var bs = b.Generate(3).ToList();
            var cs = c.Generate(3).ToList();
            var ds = d.Generate(3).ToList();
            var es = e.Generate(3).ToList();
            var gs = g.Generate(3).ToList();
            var hs = h.Generate(3).ToList();

            FakeCollection.AddRange(bs);
            FakeCollection.AddRange(cs);
            FakeCollection.AddRange(ds);
            FakeCollection.AddRange(es);
            FakeCollection.AddRange(gs);
            FakeCollection.AddRange(hs);

            testCtx.Set<SubscriptionsView>().AddRange(bs);
            testCtx.Set<SubscriptionsView>().AddRange(cs);
            testCtx.Set<SubscriptionsView>().AddRange(ds);
            testCtx.Set<SubscriptionsView>().AddRange(es);
            testCtx.Set<SubscriptionsView>().AddRange(gs);
            testCtx.Set<SubscriptionsView>().AddRange(hs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSinglePatientCheckSubscriptionView()
        {
            var fakeApp = FakeCollection.First(t => t.PayPalId == 0 && t.UserType == 1);
            var single = testCtx.Set<SubscriptionsView>().FirstOrDefault(f => f.SubscriptionId == fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.IsTrue(single.IsTrial == false);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(single.UserType, 1);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.AreEqual(fakeApp.CheckStatus, single.CheckStatus);
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
            Assert.AreEqual(fakeApp.CheckCode, single.CheckCode);
            Assert.AreEqual(fakeApp.CheckDateRecieved, single.CheckDateRecieved);
            Assert.AreEqual(fakeApp.CheckAmount, single.CheckAmount);
            Assert.AreEqual(single.PayPalId, 0);
            Assert.IsTrue(single.PayPalPaymentDate < new DateTime(1800, 1, 1));
            Assert.IsNull(single.PayPalPaymentStatus);
            Assert.AreEqual(single.PayPalPayment, 0);
        }

        [TestMethod]
        public void GetSinglePatientPayPalSubscriptionView()
        {
            var fakeApp = FakeCollection.First(t => t.CheckId == 0 && t.UserType == 1);
            var single = testCtx.Set<SubscriptionsView>().FirstOrDefault(f => f.SubscriptionId == fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.IsTrue(single.IsTrial == false);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(single.UserType, 1);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.IsTrue(single.CheckId == 0);
            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.IsTrue(single.CheckStatus == 0);
            Assert.AreEqual(fakeApp.CheckStatus, single.CheckStatus);
            Assert.IsTrue(String.IsNullOrEmpty(single.CheckNumber));
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
            Assert.IsTrue(single.CheckCode == 0);
            Assert.AreEqual(fakeApp.CheckCode, single.CheckCode);
            Assert.IsTrue(single.CheckDateRecieved == new DateTime(1800, 1, 1));
            Assert.AreEqual(fakeApp.CheckDateRecieved, single.CheckDateRecieved);
            Assert.IsTrue(single.CheckAmount == 0);
            Assert.AreEqual(fakeApp.CheckAmount, single.CheckAmount);
            Assert.AreEqual(fakeApp.PayPalId, single.PayPalId);
            Assert.AreEqual(fakeApp.PayPalPaymentDate, single.PayPalPaymentDate);
            Assert.AreEqual(fakeApp.PayPalPaymentStatus, single.PayPalPaymentStatus);
            Assert.AreEqual(fakeApp.PayPalPayment, single.PayPalPayment);
        }

        [TestMethod]
        public void GetSingleClinicianSubscriptionView()
        {
            var fakeApp = FakeCollection.First(t => t.UserType == 2);
            var single = testCtx.Set<SubscriptionsView>().FirstOrDefault(f => f.SubscriptionId == fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.IsTrue(single.IsTrial == false);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(single.UserType, 2);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.AreEqual(fakeApp.CheckStatus, single.CheckStatus);
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
            Assert.IsTrue(single.CheckCode == 0);
            Assert.AreEqual(fakeApp.CheckCode, single.CheckCode);
            Assert.AreEqual(fakeApp.CheckDateRecieved, single.CheckDateRecieved);
            Assert.AreEqual(fakeApp.CheckAmount, single.CheckAmount);
            Assert.AreEqual(single.PayPalId, 0);
            Assert.IsTrue(single.PayPalPaymentDate < new DateTime(1800, 1, 1));
            Assert.IsNull(single.PayPalPaymentStatus);
            Assert.AreEqual(single.PayPalPayment, 0);
        }

        [TestMethod]
        public void GetSinglePatientTrialSubscriptionView()
        {
            var fakeApp = FakeCollection.First(t => t.CheckId == 0 && t.PayPalId == 0);
            var single = testCtx.Set<SubscriptionsView>().FirstOrDefault(f => f.SubscriptionId == fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(single.SubscriptionType, 0);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.IsTrue(single.IsTrial == true);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(single.UserType, 1);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(single.PaymentMethod, 0);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(single.PaymentId, 0);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.IsTrue(single.CheckId == 0);
            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.IsTrue(single.CheckStatus == 0);
            Assert.AreEqual(fakeApp.CheckStatus, single.CheckStatus);
            Assert.IsTrue(String.IsNullOrEmpty(single.CheckNumber));
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
            Assert.IsTrue(single.CheckCode == 0);
            Assert.AreEqual(fakeApp.CheckCode, single.CheckCode);
            Assert.IsTrue(single.CheckDateRecieved == new DateTime(1800, 1, 1));
            Assert.AreEqual(fakeApp.CheckDateRecieved, single.CheckDateRecieved);
            Assert.IsTrue(single.CheckAmount == 0);
            Assert.AreEqual(fakeApp.CheckAmount, single.CheckAmount);
            Assert.AreEqual(single.PayPalId, 0);
            Assert.IsTrue(single.PayPalPaymentDate < new DateTime(1800, 1, 1));
            Assert.IsNull(single.PayPalPaymentStatus);
            Assert.AreEqual(single.PayPalPayment, 0);
        }

        [TestMethod]
        public void GetSinglePatientFreeDownloadSubscriptionView()
        {
            var fakeApp = FakeCollection.First(t => t.SubscriptionType == 8);
            var single = testCtx.Set<SubscriptionsView>().FirstOrDefault(f => f.SubscriptionId == fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(single.SubscriptionType, 8);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.IsTrue(single.IsTrial == false);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(single.UserType, 1);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(single.PaymentMethod, 0);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(single.PaymentId, 0);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.IsTrue(single.CheckId == 0);
            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.IsTrue(single.CheckStatus == 0);
            Assert.AreEqual(fakeApp.CheckStatus, single.CheckStatus);
            Assert.IsTrue(String.IsNullOrEmpty(single.CheckNumber));
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
            Assert.IsTrue(single.CheckCode == 0);
            Assert.AreEqual(fakeApp.CheckCode, single.CheckCode);
            Assert.IsTrue(single.CheckDateRecieved == new DateTime(1800, 1, 1));
            Assert.AreEqual(fakeApp.CheckDateRecieved, single.CheckDateRecieved);
            Assert.IsTrue(single.CheckAmount == 0);
            Assert.AreEqual(fakeApp.CheckAmount, single.CheckAmount);
            Assert.AreEqual(single.PayPalId, 0);
            Assert.IsTrue(single.PayPalPaymentDate < new DateTime(1800, 1, 1));
            Assert.IsNull(single.PayPalPaymentStatus);
            Assert.AreEqual(single.PayPalPayment, 0);
        }

        [TestMethod]
        public void GetSingleAdjustmentSubscriptionView()
        {
            var fakeApp = FakeCollection.First(t => t.SubscriptionType == 7);
            var single = testCtx.Set<SubscriptionsView>().FirstOrDefault(f => f.SubscriptionId == fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(single.SubscriptionType, 7);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.IsTrue(single.IsTrial == false);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(single.PaymentMethod, 4);
            Assert.AreEqual(fakeApp.PaymentMethod, single.PaymentMethod);
            Assert.AreEqual(single.PaymentId, 0);
            Assert.AreEqual(fakeApp.PaymentId, single.PaymentId);
            Assert.IsTrue(single.CheckId == 0);
            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.IsTrue(single.CheckStatus == 0);
            Assert.AreEqual(fakeApp.CheckStatus, single.CheckStatus);
            Assert.IsTrue(String.IsNullOrEmpty(single.CheckNumber));
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
            Assert.IsTrue(single.CheckCode == 0);
            Assert.AreEqual(fakeApp.CheckCode, single.CheckCode);
            Assert.IsTrue(single.CheckDateRecieved == new DateTime(1800, 1, 1));
            Assert.AreEqual(fakeApp.CheckDateRecieved, single.CheckDateRecieved);
            Assert.IsTrue(single.CheckAmount == 0);
            Assert.AreEqual(fakeApp.CheckAmount, single.CheckAmount);
            Assert.AreEqual(single.PayPalId, 0);
            Assert.IsTrue(single.PayPalPaymentDate < new DateTime(1800, 1, 1));
            Assert.IsNull(single.PayPalPaymentStatus);
            Assert.AreEqual(single.PayPalPayment, 0);
            }
        }
    }
