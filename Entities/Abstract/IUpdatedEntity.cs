namespace Entities.Abstract
{
    public interface IUpdatedEntity
    {
        int IUpdatedUserId { get; set; }
        DateTime? IUpdatedDate { get; set; }
    }
}
