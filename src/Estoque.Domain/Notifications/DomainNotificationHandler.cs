using MediatR;

namespace Estoque.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        public List<DomainNotification> Notifications { get; private set; }

        public bool HasNotification { get { return Notifications.Any(); } }
        public bool HasNotNotification { get { return !Notifications.Any(); } }

        public DomainNotificationHandler()
        {
            Notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            Notifications.Add(notification);
            return Task.CompletedTask;
        }

        public void Dispose() => Notifications = new List<DomainNotification>();
    }
}
