using Core.Entities.Abstract;

namespace Core.Entity.Concrete
{
    public class BaseEntity : IEntity
    {
        public int? Id { get; set; }
    }
}
