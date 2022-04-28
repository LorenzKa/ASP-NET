using System;
using System.Collections.Generic;

namespace MusicManagerDb
{
    public partial class Song
    {
        public long SongId { get; set; }
        public string SongTitle { get; set; } = null!;
        public long RecordId { get; set; }
        public int TrackNo { get; set; }

        public virtual Record Record { get; set; } = null!;
    }
}
