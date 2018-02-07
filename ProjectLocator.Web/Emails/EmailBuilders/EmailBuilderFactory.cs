using ProjectLocator.Web.Emails.EmailBuilders.ConfirmAccount;
using ProjectLocator.Web.Emails.EmailBuilders.NullObject;
using ProjectLocator.Web.Exceptions.ApplicationExceptions;
using ProjectLocator.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLocator.Web.Emails.EmailBuilders
{
    public enum EmailBuilderType
    {
        NullObject,
        ConfirmAccount
    }

    public interface IEmailBuilderFactory
    {
        EmailBuilder<T> Create<T>(EmailBuilderType emailBuilderType);
    }

    public class EmailBuilderFactory : IEmailBuilderFactory
    {
        private IViewRenderService _viewRenderService;

        public EmailBuilderFactory(IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }

        public EmailBuilder<T> Create<T>(EmailBuilderType emailBuilderType)
        {
            switch (emailBuilderType)
            {
                case EmailBuilderType.ConfirmAccount:
                    return new ConfirmAccountEmailBuilder<T>(_viewRenderService);
                case EmailBuilderType.NullObject:
                    return new NullObjectEmailBuilder<T>();
                default:
                    throw new EmailException($"{nameof(EmailBuilderFactory)} do not specify that type of {nameof(EmailBuilderType)}: {emailBuilderType.ToString()}");
            }
        }
    }
}
