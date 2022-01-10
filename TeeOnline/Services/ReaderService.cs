namespace TeeOnline.Services
{
    public class ReaderService
    {
        private readonly TeeOnlineContext db;


        public ReaderService(TeeOnlineContext db)
        {
            this.db = db;
        }
        public void ReadCsv()
        {
            var personList = File.ReadAllLines("./Players.csv")
                .Skip(1)
                .Select(x => x.Split(";"))
                .Select(x => new Player
                {
                    FirstName = x[0],
                    LastName = x[1],
                    Handicap = double.Parse(x[2]),
                    HomeGolfClubGolfClubId = long.Parse(x[3]),
                    Email = $"{x[1]}.{x[0]}@sus.htl-grieskirchen.at",
                    Password = $"{x[1].Substring(0,3)}{x[0].Substring(0, 2)}"
                });
            db.Players.AddRange(personList);
            db.SaveChanges();
        }
    }
}
