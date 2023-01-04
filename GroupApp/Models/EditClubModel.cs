using GroupApp.Data.Enum;

namespace GroupApp.Models
{
    public class EditClubModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string? AppUserId { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ClubCategory ClubCategory { get; set; }
    }
}
