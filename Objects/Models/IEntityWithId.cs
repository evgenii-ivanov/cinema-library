using System.ComponentModel.DataAnnotations;

namespace Objects.Models
{
    public interface IEntityWithId : IEntity
    {
        [Key]
        int Id
        {
            get;
            set;
        }
    }
}
