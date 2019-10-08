using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly WebApiContext context;

        public BaseRepository(WebApiContext context)
        {
            this.context = context;
        }
    }
}
