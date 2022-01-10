using TeeOnline.Dtos;
using System.Linq;

namespace TeeOnline.Services
{
    public class TeeOnlineService
    {
        private readonly TeeOnlineContext db;


        public TeeOnlineService(TeeOnlineContext db)
        {
            this.db = db;
        }
        public PlayerDto? login(string email, string password)
        {
            var player = db.Players
                .Include(x => x.Bookings)
                .Include(x => x.HomeGolfClubGolfClub)
                .Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            return convertPlayerToPlayerDto(player);
        }
        private PlayerDto convertPlayerToPlayerDto(Player player)
        {
            if (player == null) return null;
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
                Email = player.Email,
                Password = player.Password,
                HomeGolfClubGolfClub = new GolfClubDto()
                {
                    GolfClubId = player.HomeGolfClubGolfClubId,
                    Name = player?.HomeGolfClubGolfClub?.Name
                },
                Bookings = bookingDtos
            };
            return playerDto;
        }
        public List<PlayerDto> players()
        {
            Console.WriteLine($"TeeOnlineService::players --> {db.Players.Count()} players in db");
            return db.Players
                .Include(x=>x.Bookings)
                .Include(x=>x.HomeGolfClubGolfClub)
                .ToList()
                .Select(x => convertPlayerToPlayerDto(x)).ToList();
        }
        public List<GolfClubDto> golfClubs()
        {
            return db.GolfClubs.Select(x => new GolfClubDto { GolfClubId = x.GolfClubId, Name = x.Name }).ToList();
        }
    }
}
