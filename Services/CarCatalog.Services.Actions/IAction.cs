namespace CarCatalog.Services.Actions;

using CarCatalog.Services.EmailSender;
using System.Threading.Tasks;

public interface IAction
{
    Task SendEmail(EmailModel email);
}
