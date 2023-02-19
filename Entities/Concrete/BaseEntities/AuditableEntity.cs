using Entities.Abstract;

namespace Entities.Concrete.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity, IDisplayEntity
    {
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUserId { get ; set; }
        public DateTime? UpdatedDate { get; set ; }
        public int? DisplayOrder { get ; set; }
        public bool? IsDisplay { get; set ; }
    }
}
