using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public abstract class BaseUnitTest<C,T> where C : DbContext where T : class
    {
        private C test_Ctx;
        internal List<T> FakeCollection = new List<T>();
        protected string DbName { get; set; }
        public C testCtx { get { return (C)test_Ctx; } }


        public BaseUnitTest()
        {
            // Use the name of the type as the name of the EF in-memory database
            DbName = typeof(T).Name;
            InitContext();
        }

        public BaseUnitTest(string dbName)
        {
            DbName = dbName;
            InitContext();
        }

        protected abstract void SetContextData();

        private void InitContext()
        {
            if (typeof(C).Equals(typeof(NuMedicsGlobalContext)))
            {
                var nbuilder = new DbContextOptionsBuilder<NuMedicsGlobalContext>().UseInMemoryDatabase(DbName);
                var con = new NuMedicsGlobalContext(nbuilder.Options);
                test_Ctx = con as C;
            }

            if (typeof(C).Equals(typeof(MeterDevicesDbContext)))
            {
                var nbuilder = new DbContextOptionsBuilder<MeterDevicesDbContext>().UseInMemoryDatabase(DbName);
                var con = new MeterDevicesDbContext(nbuilder.Options);
                test_Ctx = con as C;
            }

            SetContextData();
        }
    }
}
