using Example.Ecommerce.Domain.ExternalServices.EmailSendGrid;

namespace Example.Ecommerce.Application.Interface.Persistence.EmailSendGrid;

public interface IManagementEmailSengrid
{
    Task<bool> SendEmail(EmailDataRequest email, string token);
}