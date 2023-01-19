using System.Collections.Generic;
using System.Text;

namespace TodoApp.EmailService.Services
{
    public interface IEmailSender
    {
        public string ErrMsg { get;  }

        public int SendEmail(string email, string subject, string content);
    }
}
