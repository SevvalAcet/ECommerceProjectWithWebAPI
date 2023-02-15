using Entities.Abstract;

namespace Entities.Concrete.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity, IDisplayEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IUpdatedUserId { get ; set; }
        public DateTime? IUpdatedDate { get; set ; }
        public int DisplayOrder { get ; set; }
        public bool IsDisplay { get; set ; }
    }
}
