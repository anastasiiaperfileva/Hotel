using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("AnnouncementStatuses")]
public class AnnouncementStatusEntity : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<AnnouncementEntity> Announcements { get; set; }
}