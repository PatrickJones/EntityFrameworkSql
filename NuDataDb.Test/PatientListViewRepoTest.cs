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
    public class PatientListViewRepoTest : BaseUnitTest<NuMedicsGlobalContext, PatientListView>
    {
        protected PatientListViewRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientListViewRepo(testCtx);

            var b = new Faker<PatientListView>()
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Username, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.InstitutionName, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.Firstname, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.Lastname, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.Middlename, f => f.Random.Word().Substring(0, 3))
                .RuleFor(r => r.Email, f => f.Internet.ExampleEmail())
                .RuleFor(r => r.DateofBirth, f => f.Date.Past())
                .RuleFor(r => r.MRID, f => f.Random.Word().Substring(0, 3));

            var bs = b.Generate(3).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Set<PatientListView>().AddRange(bs);
            int added = testCtx.SaveChanges();
        }

    }
}
