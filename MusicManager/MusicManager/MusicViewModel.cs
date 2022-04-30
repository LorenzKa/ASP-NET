using Microsoft.EntityFrameworkCore;
using MusicManagerDb;
using MvvmTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MusicManager
{
    public class MusicViewModel : ObservableObject
    {
        public MusikManager db;
        private string artistCount = "Nr Interpreten: 0";
        public MusicViewModel() { }
        public MusicViewModel(MusikManager db)
        {
            this.db = db;
            Artists = db.Artists.Include(x => x.Records).ThenInclude(x => x.Songs).AsObservableCollection();
        }

        public string ArtistCount
        {
            get => artistCount;
            set
            {
                artistCount = value;
                NotifyPropertyChanged(nameof(ArtistCount));
            }
        }
        public Artist selectedArtist;
        public Artist SelectedArtist
        {
            get => selectedArtist;
            set
            {
                selectedArtist = value;
                Records = db.Records.Where(x => x.ArtistId == value.ArtistId).ToList();
                NotifyPropertyChanged(nameof(SelectedArtist));
            }
        }
        public ObservableCollection<Artist> artists;
        public ObservableCollection<Artist> Artists
        {
            get => artists;
            set
            {
                artists = value;
                NotifyPropertyChanged(nameof(Artists));
                ArtistCount = $"Nr Interpreten: {db.Artists.Count()}";
            }
        }
        public List<Song> songs;
        public List<Song> Songs
        {
            get => songs;
            set
            {
                songs = value;
                NotifyPropertyChanged(nameof(Songs));
            }
        }
        public List<Record> records;
        public List<Record> Records
        {
            get => records;
            set
            {
                records = value;
                NotifyPropertyChanged(nameof(Records));
            }
        }
        public Record selectedRecord;
        public Record SelectedRecord
        {
            get => selectedRecord;
            set
            {
                selectedRecord = value;
                Songs = db.Songs.Where(x => x.RecordId == value.RecordId).ToList();
                NotifyPropertyChanged(nameof(SelectedRecord));
            }
        }
        public ObservableCollection<MenuItem> treeView;
        public ObservableCollection<MenuItem> TreeView
        {
            get => treeView;
            set
            {
                treeView = value;
            }
        }
        


    }
}
