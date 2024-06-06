using Microsoft.AspNetCore.Identity.UI.Services;

namespace BLL.Utilities
{
    public class EmailSender : IEmailSender
    {
        //TODO
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}