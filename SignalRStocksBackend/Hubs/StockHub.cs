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
            return base.OnDisconnectedAsync(exception);
        }
    }
}
