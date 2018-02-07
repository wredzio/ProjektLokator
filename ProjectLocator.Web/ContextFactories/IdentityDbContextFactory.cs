using ProjectLocator.Database.Contexts.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLocator.Web.ContextFactories
{
    public class IdentityDbContextFactory : DesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityDbContextFactory()
        {
            _databaseName = "IdentityConnection";
        }
    }
}
