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
    public class InstructionItemsRepoTest : BaseUnitTest<MeterDevicesDbContext, InstructionItems>
    {
        protected InstructionItemsRepo repo;

        protected override void SetContextData()
        {
            repo = new InstructionItemsRepo(testCtx);

            var f = new Faker<InstructionItems>()
                .RuleFor(r => r.Instruction, v => v.Lorem.Sentence())
                .RuleFor(r => r.MeterId, v => v.Random.Int(1, 76))
                .RuleFor(r => r.StepNumber, v => v.Random.Int(1, 4));

            var gen = f.Generate(3).OrderBy(o => o.Id).ToList();
            testCtx.InstructionItems.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleInstructionItem()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Id);

            Assert.AreEqual(fakeApp.Id, single.Id);
            Assert.AreEqual(fakeApp.Instruction, single.Instruction);
            Assert.AreEqual(fakeApp.MeterId, single.MeterId);
            Assert.AreEqual(fakeApp.StepNumber, single.StepNumber);
        }

        [TestMethod]
        public void GetSingleInstructionItemIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteInstructionItem()
        {
            var currentCnt = testCtx.InstructionItems.Count();

            var entity = testCtx.InstructionItems.First();
            repo.Delete(entity.Id);
            repo.Save();

            Assert.IsTrue(testCtx.InstructionItems.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteInstructionItemIdNotExist()
        {
            var currentCnt = testCtx.InstructionItems.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.InstructionItems.Count() == currentCnt);
        }
    }
}
