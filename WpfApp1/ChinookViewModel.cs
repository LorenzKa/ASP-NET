using ChinookDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1;

namespace Chinook
{
    public class ChinookViewModel : ObservableObject
    {
        public ObservableCollection<Artist> Artists { get; private set; } = new();
        private ChinookContext db;
        public ChinookViewModel() { }
        public ChinookViewModel(ChinookContext db)
        {
            this.db = db;
            Artists = new ObservableCollection<Artist>(db.Artists.ToList());
        }

        private string newArtist = "Dummy";
        public string NewArtist
        {
            get => newArtist;
            set
            {
                newArtist = value;
                OnPropertyChanged();
            }
        }
        private List<string> songs = new();
        public List<string> Songs
        {
            get => songs;
            set
            {
                songs = value;
                OnPropertyChanged();
            }
        }
        private Artist selectedArtist;
        public Artist SelectedArtist
        {
            get => selectedArtist;
            set
            {
                selectedArtist = value;
                //Songs.Clear();
                //Songs.Add(db.Albums.Include(x => x.Artist).ToList().First());
                OnPropertyChanged();
                Songs = db.Albums.Include(x => x.Artist).Take(10).Select(x => x.Title).ToList();
                Console.WriteLine(Songs.Count);
                
            }
        }
        public ICommand AddArtistCommand => new RelayCommand<string>(DoAddArtist, x => NewArtist.Trim().Length > 0);
        private void DoAddArtist(string obj)
        {
            Artists.Add(new Artist { Name = NewArtist });
            NewArtist = "";
        }
    }
}
