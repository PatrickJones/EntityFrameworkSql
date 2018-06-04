using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class GenderRepo : BaseRepo<Gender, GlobalStandardsContext>
    {
        public GenderRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override Gender GetSingle(int id)
        {
            try
            {
                return ctx.Gender.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Gender)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Gender.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Gender)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
