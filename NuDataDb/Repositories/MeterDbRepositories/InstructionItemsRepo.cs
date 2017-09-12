using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class InstructionItemsRepo : BaseRepo<InstructionItems, MeterDevicesDbContext>
    {
        protected InstructionItemsRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override InstructionItems GetSingle(int id)
        {
            try
            {
                return ctx.InstructionItems.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InstructionItems)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InstructionItems.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InstructionItems)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
