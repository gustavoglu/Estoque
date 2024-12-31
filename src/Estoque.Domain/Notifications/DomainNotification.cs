using MediatR;

namespace Estoque.Domain.Notifications
{
    public class DomainNotification : INotification
    {
        public DomainNotification(string type, string value)
        {
            Value = value;
            Type = type;
        }

        public string Value { get; set; }
        public string Type { get; set; }
    }
}
