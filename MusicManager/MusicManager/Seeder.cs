using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MusicManagerDb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicManager
{
    public class Seeder : IHostedService
    {
        private readonly MusikManager db;

        public Seeder(MusikManager db)
        {
            this.db = db;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var p = new Person.PersonBuilder("Max", "Mustermann").Age(15).Build();
            var sing = Singleton.Instance;
            var sing2 = Singleton.Instance;
            if(sing == sing2)
            {
                Console.WriteLine("asdlknfhjkasödf");
            }
            db.Database.EnsureCreated();
            if (db.Artists.Count() > 0) return Task.CompletedTask;

            File.ReadAllLines("musicDbData.csv").Skip(1).ToList().ForEach(x =>
            {
                var splitted = x.Split(";");
                if (db.Artists.Where(x => x.ArtistName == splitted[0]).Count() == 0)
                {
                    db.Artists.Add(new Artist
                    {
                        ArtistName = splitted[0]
                    });
                    db.SaveChanges();
                }
                if (db.RecordTypes.Where(x => x.Descr == splitted[2]).Count() == 0)
                {
                    db.RecordTypes.Add(new RecordType
                    {
                        Descr = splitted[2]
                    });
                }
                db.SaveChanges();
                if (db.Records.Where(x => x.RecordTitle == splitted[1] && x.Year == int.Parse(splitted[3])).Count() == 0)
                {
                    db.Records.Add(new Record
                    {
                        RecordTitle = splitted[1],
                        Year = int.Parse(splitted[3]),
                        ArtistId = db.Artists.Where(x => x.ArtistName == splitted[0]).First().ArtistId,
                        RecordTypeId = db.RecordTypes.Where(x => x.Descr == splitted[2]).First().TypeId
                    }); ;
                }
                db.SaveChanges();
                if (db.Songs.Where(x => x.SongTitle == splitted[4]).Count() == 0)
                {
                    db.Songs.Add(new Song
                    {
                        SongTitle = splitted[4],
                        TrackNo = db.Songs.Where(x => x.Record.RecordTitle == splitted[2]).Count(),
                        RecordId = db.Records.Where(x => x.RecordTitle == splitted[1]).First().RecordId,

                    });
                }
                db.SaveChanges();
            });
            Console.WriteLine(db.Artists.Count());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    internal class MusikContext
    {
    }
}
