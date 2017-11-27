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
    public class EmailUsernameViewRepoTest : BaseUnitTest<NuMedicsGlobalContext, EmailUsernameView>
    {
        protected EmailUsernameViewRepo repo;

        protected override void SetContextData()
        {
            repo = new EmailUsernameViewRepo(testCtx);

            var b = new Faker<EmailUsernameView>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 1)
                .RuleFor(r => r.CreationDate, f => f.Date.Past())
                .RuleFor(r => r.ClinicianEmail, f => f.Internet.ExampleEmail());

            var c = new Faker<EmailUsernameView>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => 2)
                .RuleFor(r => r.CreationDate, f => f.Date.Past())
                .RuleFor(r => r.PatientEmail, f => f.Internet.ExampleEmail());

            var bs = b.Generate(3).ToList();
            var bc = c.Generate(3).ToList();
            FakeCollection.AddRange(bs);
            FakeCollection.AddRange(bc);

            testCtx.Set<EmailUsernameView>().AddRange(bs);
            testCtx.Set<EmailUsernameView>().AddRange(bc);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleClinicianEmailUsernameView()
        {
            var fakeApp = FakeCollection.First(d => d.UserType == 1);
            var single = testCtx.Set<EmailUsernameView>().FirstOrDefault(f => f.UserId == fakeApp.UserId);


            Assert.IsTrue(single.UserId != Guid.Empty);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.CreationDate, single.CreationDate);
            Assert.IsTrue(String.IsNullOrEmpty(single.PatientEmail));
            Assert.IsFalse(String.IsNullOrEmpty(single.ClinicianEmail));
            Assert.AreEqual(fakeApp.ClinicianEmail, single.ClinicianEmail);
        }

        [TestMethod]
        public void GetSinglePatientEmailUsernameView()
        {
            var fakeApp = FakeCollection.First(d => d.UserType == 2);
            var single = testCtx.Set<EmailUsernameView>().FirstOrDefault(f => f.UserId == fakeApp.UserId);

            Assert.IsTrue(single.UserId != Guid.Empty);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.CreationDate, single.CreationDate);
            Assert.IsFalse(String.IsNullOrEmpty(single.PatientEmail));
            Assert.AreEqual(fakeApp.PatientEmail, single.PatientEmail);
            Assert.IsTrue(String.IsNullOrEmpty(single.ClinicianEmail));
        }
    }
}
