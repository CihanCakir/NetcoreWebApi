using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.UnitOfWork
{
     

    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApiContext context;

        public UnitOfWork(WebApiContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            this.context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
            //Unit Of Work Pattern bu kadar Basit
        }
    }
}
