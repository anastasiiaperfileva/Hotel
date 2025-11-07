using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("UserStatuses")]
public class UserStatusEntity:BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<UserEntity> Users { get; set; }
}