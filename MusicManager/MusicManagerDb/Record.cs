using System;
using System.Collections.Generic;

namespace MusicManagerDb
{
    public partial class Record
    {
        public Record()
        {
            Songs = new HashSet<Song>();
        }

        public long RecordId { get; set; }
        public long ArtistId { get; set; }
        public string RecordTitle { get; set; } = null!;
        public long RecordTypeId { get; set; }
        public int? Year { get; set; }

        public virtual Artist Artist { get; set; } = null!;
        public virtual RecordType RecordType { get; set; } = null!;
        public virtual ICollection<Song> Songs { get; set; }
    }
}
