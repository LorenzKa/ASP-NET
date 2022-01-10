using TeeOnline.Dtos;

namespace TeeOnline
{
    public class PlayerDto
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double Handicap { get; set; }

        public GolfClubDto HomeGolfClubGolfClub { get; set; }

        public ICollection<BookingDto> Bookings { get; set; }
    }
}
