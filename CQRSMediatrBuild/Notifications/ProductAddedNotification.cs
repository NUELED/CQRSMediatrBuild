using MediatR;

namespace CQRSMediatrBuild.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
   
}
