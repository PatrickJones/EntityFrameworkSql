using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class LanguagesRepo : BaseRepo<Languages, GlobalStandardsContext>
    {
        public LanguagesRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override Languages GetSingle(int id)
        {
            try
            {
                return ctx.Languages.FirstOrDefault(f => f.LanguageId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Languages)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Languages.FirstOrDefault(f => f.LanguageId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Languages)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
