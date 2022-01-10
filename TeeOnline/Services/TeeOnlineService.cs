using TeeOnline.Dtos;
using System.Linq;

namespace TeeOnline.Services
{
    public class TeeOnlineService
    {
        private readonly TeeOnlineContext db;

        public TeeOnlineService()
        {
        }

        public TeeOnlineService(TeeOnlineContext db)
        {
            this.db = db;
        }
        public PlayerDto? login(string email, string password)
        {
            var player = db.Players.Include(x => x.Bookings).ThenInclude(x => x.GolfClub).Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            if (player==null)return null;
            var bookingDtos = player.Bookings.Select(x => new BookingDto()
            {
                BookingId = x.BookingId,
                DateTime = x.DateTime,
                GolfClubId = x.GolfClubId,
                IsLocked = x.IsLocked
            })
            .ToList();
            var playerDto = new PlayerDto()
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Handicap = player.Handicap,
                HomeGolfClubGolfClub = new GolfClubDto()
                {
                    GolfClubId = player.HomeGolfClubGolfClubId,
                    Name = player?.HomeGolfClubGolfClub?.Name
                },
                Bookings = bookingDtos
            };
            return playerDto;

        }
    }
}
