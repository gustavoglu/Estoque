using MediatR;

namespace Estoque.Application.Requests
{
    public abstract class EntityRequest : IRequest
    {
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}

