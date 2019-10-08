using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.UnitOfWork
{
    interface  IUnitOfWork
    {
        Task CompleteAsync();

    }
}
