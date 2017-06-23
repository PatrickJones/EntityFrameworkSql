using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public abstract class BaseUnitTest<T> where T : class
    {
        protected NuMedicsGlobalContext testCtx;
        protected List<T> FakeCollection = new List<T>();

        public BaseUnitTest()
        {
            InitContext();
            
        }

        protected abstract void SetContextData();

        private void InitContext()
        {
            // Use the name of the type as the name of the EF in-memory database
            var dbName = typeof(T).Name;
            // Set configuration to use in-memory database
            var builder = new DbContextOptionsBuilder<NuMedicsGlobalContext>().UseInMemoryDatabase(dbName);
            
            testCtx = new NuMedicsGlobalContext(builder.Options);
            SetContextData();
        }
    }
}
