namespace Entities.Abstract
{
    public interface IDisplayEntity
    {
        public int? DisplayOrder { get; set; }
        bool? IsDisplay { get; set; }
    }
}
