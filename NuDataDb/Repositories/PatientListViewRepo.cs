using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NuDataDb.Repositories
{
    public class PatientListViewRepo : BaseRepo<PatientListView, NuMedicsGlobalContext>
    {
        public PatientListViewRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<PatientListView> GetAsQueryable()
        {
            return ctx.Set<PatientListView>().FromSql("SELECT * FROM PatientListView").AsQueryable<PatientListView>();
        }

        public override IEnumerable<PatientListView> Get()
        {
            return ctx.Set<PatientListView>().FromSql("SELECT * FROM PatientListView");
        }

        public IEnumerable<PatientListView> Get(Guid institutionId)
        {
            return ctx.Set<PatientListView>().FromSql($"dbo.PatientListSP @InstitutionId = {institutionId}");
        }
    }
}
