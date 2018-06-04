﻿using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class MaritalStatusRepo : BaseRepo<MaritalStatus, GlobalStandardsContext>
    {
        public MaritalStatusRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override MaritalStatus GetSingle(int id)
        {
            try
            {
                return ctx.MaritalStatus.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(MaritalStatus)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.MaritalStatus.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(MaritalStatus)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
