using Microsoft.AspNetCore.SignalR;
using SignalRStocksBackend.DTOs;

namespace SignalRStocksBackend.Hubs
{
    public class StockHub: Hub
    {
        private int usercounter;
        public void BuyShare(TransactionDto transaction)
        {
            Clients.All.SendAsync("buy", transaction);
        }
        public void LoggedIn(NameDto name)
        {
            usercounter++;
            Console.WriteLine(name.Name);
            Clients.All.SendAsync("loggedIn", name.Name);
        }

    }
}
