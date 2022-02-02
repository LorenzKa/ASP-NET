using Microsoft.AspNetCore.Mvc;
using SignalRStocksBackend.DTOs;
using SignalRStocksBackend.Entities;

namespace SignalRStocksBackend.Services;

public class StockService
{
    private readonly StockContext db;

    public StockService(StockContext db)
    {
        this.db = db;
    }

    public List<ShareDto> GetShares()
    {
        Console.WriteLine("here");
        return db.Shares.Select(x => new ShareDto().CopyPropertiesFrom(x)).ToList();
    }

    public UserDto GetUser(string name)
    {
        var user =  db.Users.Where(x => x.Name == name).FirstOrDefault();
        if(user != null)
        {
            return new UserDto().CopyPropertiesFrom(user);
        }
        db.Users.Add(new User
        {
            Name = name,
            Cash = new Random().Next(1000, 10000),
            Id = db.Users.Count()
        });
        db.SaveChanges();
        return new UserDto().CopyPropertiesFrom(db.Users.Where(x => x.Name == name).First());
    }
}
