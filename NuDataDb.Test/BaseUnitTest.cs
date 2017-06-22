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
    public abstract class BaseUnitTest
    {
        protected NuMedicsGlobalContext testCtx;

        public BaseUnitTest()
        {
            InitContext();
            
        }

        protected abstract void SetContextData();

        private void InitContext()
        {
            var builder = new DbContextOptionsBuilder<NuMedicsGlobalContext>().UseInMemoryDatabase();
            testCtx = new NuMedicsGlobalContext(builder.Options);
            SetContextData();
        }
    }
}
