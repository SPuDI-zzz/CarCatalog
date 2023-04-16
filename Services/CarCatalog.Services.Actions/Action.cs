namespace CarCatalog.Services.Actions;

using CarCatalog.Consts;
using CarCatalog.Services.EmailSender;
using CarCatalog.Services.RabbitMq;
using System.Threading.Tasks;

public class Action : IAction
{
    private readonly IRabbitMq rabbitMq;

    public Action(IRabbitMq rabbitMq)
    {
        this.rabbitMq = rabbitMq;
    }

    public async Task SendEmail(EmailModel email)
    {
        await rabbitMq.PushAsync(RabbitMqTaskQueueNames.SEND_EMAIL, email);
    }
}
