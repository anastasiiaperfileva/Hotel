using System.ComponentModel.DataAnnotations.Schema;
using Hotel.DataAccess.Primitives;

namespace Hotel.DataAccess.Entities;

[Table("Users")]
public class UserEntity:BaseEntity
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    
    public virtual ICollection<BookingEntity> Bookings { get; set; }
    public virtual ICollection<ReviewEntity> Reviews { get; set; }
    public virtual ICollection<AnnouncementEntity> Announcements { get; set; }
}