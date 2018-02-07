using ProjectLocator.Web.Emails.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjectLocator.Web.Emails.PostBoxs
{
    public interface IPostBox
    {
        void Send(Email email);
    }
}
