using Microsoft.AspNetCore.SignalR;
using SignalRStocksBackend.DTOs;
using SignalRStocksBackend.Entities;

namespace SignalRStocksBackend.Hubs
{
    public class StockHub: Hub
    {
        private StockContext db;
        public StockHub(StockContext db)
        {
            this.db = db;
        }
        private int usercounter;
        public void Transaction(TransactionDto transaction)
        {
            Console.WriteLine(transaction.ShareName);
            Console.WriteLine(db.Users.Count());
            if (transaction.IsUserBuy)
            {
                var user = db.Users.Find(x => x.Name == transaction.Username);
                user.Cash = user.Cash - (transaction.Amount * transaction.Price);
                var userShare = db.UserShares.FirstOrDefault(x =>
                    x.Share.Name == transaction.ShareName && x.User.Name == transaction.Username);
                if (userShare == null)
                {
                    db.UserShares.Add(new UserShare()
                    {
                        Amount = transaction.Amount,
                        Id = db.Transactions.Count,
                        Share = db.Shares.Find(x => x.Name == transaction.ShareName),
                        User = user
                    });
                }
                else
                {
                    userShare.Amount = userShare.Amount + transaction.Amount;
                }
                
                db.SaveChanges();
                Clients.All.SendAsync("buy", transaction);
            }
            else
            {
                var user = db.Users.Find(x => x.Name == transaction.Username);
                user.Cash = user.Cash + (transaction.Amount * transaction.Price);
                var userShare = db.UserShares.Find(x =>
                    x.User.Name == transaction.Username && x.Share.Name == transaction.ShareName);
                
                userShare.Amount = userShare.Amount - transaction.Amount;
                if (userShare.Amount == 0)
                {
                    db.UserShares.Remove(userShare);
                }
                Clients.All.SendAsync("sell", transaction);
                db.SaveChanges();
            }
        }
        public void LoggedIn(NameDto name)
        {
            usercounter++;
            name.UserCounter = usercounter;
            Clients.All.SendAsync("loggedIn", name);
        }
        public void LoggedOut(NameDto name)
        {
            --usercounter;
            name.UserCounter = usercounter;
            Clients.All.SendAsync("loggedOut", name);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            --usercounter;
            var name = new NameDto();
            name.Name = "unknown";
            name.UserCounter = usercounter;
            Clients.All.SendAsync("loggedOut", name);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
