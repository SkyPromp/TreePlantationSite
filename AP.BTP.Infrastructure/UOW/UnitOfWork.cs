using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext ctxt;

        public UnitOfWork(BTPContext ctxt)
        {
            this.ctxt = ctxt;
        }

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
