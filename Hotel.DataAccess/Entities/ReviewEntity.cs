using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("Reviews")]
public class ReviewEntity: BaseEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int HotelId { get; set; }
    public HotelEntity Hotel { get; set; }
    
    public string Text { get; set; }
    public int Rating { get; set; }
    public DateTime PublishedAt { get; set; }
    
    public int ReviewStatusId { get; set; }
    public ReviewStatusEntity ReviewStatus { get; set; }
}