using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class SecurityQuestionsRepo : BaseRepo<SecurityQuestions, GlobalStandardsContext>
    {
        public SecurityQuestionsRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override SecurityQuestions GetSingle(int id)
        {
            try
            {
                return ctx.SecurityQuestions.FirstOrDefault(f => f.QuestionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SecurityQuestions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SecurityQuestions.FirstOrDefault(f => f.QuestionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SecurityQuestions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
