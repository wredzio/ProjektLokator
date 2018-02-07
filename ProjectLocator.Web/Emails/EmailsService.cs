using ProjectLocator.Web.Emails.EmailBuilders;
using ProjectLocator.Web.Emails.PostBoxs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLocator.Web.Emails
{
    public static class EmailsService
    {
        public static void AddEmailsService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEmailBuilderFactory, EmailBuilderFactory>();
            serviceCollection.AddSingleton<IPostBox, PostBox>();
        }
    }
}
