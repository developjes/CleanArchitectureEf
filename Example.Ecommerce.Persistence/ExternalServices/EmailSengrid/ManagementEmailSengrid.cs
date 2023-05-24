using Example.Ecommerce.Application.Interface.Persistence.EmailSendGrid;
using Example.Ecommerce.Domain.ExternalServices.EmailSendGrid;
using Example.Ecommerce.Persistence.Models.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Example.Ecommerce.Persistence.ExternalServices.EmailSengrid;

public class ManagementEmailSengrid : IManagementEmailSengrid
{
    public SendGridSettings SengridSettings { get; }
    public ILogger<ManagementEmailSengrid> Logger { get; }

    public ManagementEmailSengrid(IOptions<SendGridSettings> sendGridSettings, ILogger<ManagementEmailSengrid> logger)
    {
        SengridSettings = sendGridSettings.Value;
        Logger = logger;
    }

    public async Task<bool> SendEmail(EmailDataRequest email, string token)
    {
        SendGridClient client = new(SengridSettings.Key);
        EmailAddress from = new(SengridSettings.Email);
        EmailAddress to = new(email.To, email.To);

        string subject = email.Subject!;
        string plainTextContent = email.Body!;
        string htmlContent = $"{email.Body} {SengridSettings.BaseUrlClient}/password/reset/{token}";

        SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        try
        {
            Response response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            Logger.LogError("El email no pudo enviarse, existen errores");
            return false;
        }
    }
}