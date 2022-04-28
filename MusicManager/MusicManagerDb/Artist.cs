using System;
using System.Collections.Generic;

namespace MusicManagerDb
{
    public partial class Artist
    {
        public Artist()
        {
            Records = new HashSet<Record>();
        }

        public long ArtistId { get; set; }
        public string ArtistName { get; set; } = null!;

        public virtual ICollection<Record> Records { get; set; }
    }
}
