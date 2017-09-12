using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NuDataDb.Repositories;
using Bogus;
using System.Collections;
using System.Collections.Generic;

namespace NuDataDb.Test
{
    //[TestClass]
    public class UnitTest1 : BaseUnitTest<NuMedicsGlobalContext,AppSettings>
    {
        //List<AppSettings> FakeAppSettings = new List<AppSettings>();
        //NuMedicsGlobalContext ctx;

        //public UnitTest1()
        //{
        //    InitContext();
        //}

        //private void InitContext()
        //{
        //    var builder = new DbContextOptionsBuilder<NuMedicsGlobalContext>().UseInMemoryDatabase();
        //    var nCtx = new NuMedicsGlobalContext(builder.Options);

        //    var apps = Enumerable.Range(1, 3).Select(s => new AppSettings {
        //        ApplicationId = Guid.NewGuid(),
        //        Description = $"Description {s}",
        //        LastUpdatedByUser = Guid.NewGuid(),
        //        Name = $"Name {s}",
        //        Value = $"Value {s}"
        //    });

        //    nCtx.AppSettings.AddRange(apps);
        //    int added = nCtx.SaveChanges();
        //    ctx = nCtx;
        //}

        //[TestMethod]
        public void TestMethod1()
        {
            string expected = FakeCollection.First().Name;
            var repo = new AppSettingsRepo(testCtx);
            var app = repo.Get().First();

            Assert.AreEqual(expected, app.Name);
        }

        protected override void SetContextData()
        {
            var b = new Faker<AppSettings>()
                .RuleFor(r => r.AppSettingId, f => f.UniqueIndex)
                .RuleFor(r => r.Description, f => f.Lorem.Sentence(5))
                .RuleFor(r => r.LastUpdatedbyUser, f => f.Random.Uuid())
                .RuleFor(r => r.Name, f => f.Lorem.Word())
                .RuleFor(r => r.Value, f => f.Lorem.Word());

            var bs = b.Generate(3).OrderBy(o => o.Name).ThenBy(o => o.Value).ToList();
            FakeCollection.AddRange(bs);

            //var apps = Enumerable.Range(1, 3).Select(s => new AppSettings
            //{
            //    ApplicationId = Guid.NewGuid(),
            //    Description = $"Description {s}",
            //    LastUpdatedByUser = Guid.NewGuid(),
            //    Name = $"Name {s}",
            //    Value = $"Value {s}"
            //});

            testCtx.AppSettings.AddRange(bs);
            int added = testCtx.SaveChanges();
        }
    }
}
