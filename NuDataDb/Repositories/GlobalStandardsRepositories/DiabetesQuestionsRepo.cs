using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class DiabetesQuestionsRepo : BaseRepo<DiabetesQuestions, GlobalStandardsContext>
    {
        public DiabetesQuestionsRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override DiabetesQuestions GetSingle(int id)
        {
            try
            {
                return ctx.DiabetesQuestions.FirstOrDefault(f => f.QuestionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DiabetesQuestions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DiabetesQuestions.FirstOrDefault(f => f.QuestionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DiabetesQuestions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
