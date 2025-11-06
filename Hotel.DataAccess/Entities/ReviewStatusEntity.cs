using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("ReviewStatuses")]
public class ReviewStatusEntity: BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<ReviewEntity> Reviews { get; set; }
}