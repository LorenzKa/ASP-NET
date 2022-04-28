using System;
using System.Collections.Generic;

namespace MusicManagerDb
{
    public partial class RecordType
    {
        public RecordType()
        {
            Records = new HashSet<Record>();
        }

        public long TypeId { get; set; }
        public string Descr { get; set; } = null!;

        public virtual ICollection<Record> Records { get; set; }
    }
}
