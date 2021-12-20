using System;
using System.Collections.Generic;

namespace PersonsDb
{
    public partial class Person
    {
        public long Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Born { get; set; } = null!;
        public string? Tel { get; set; }
        public long AdressId { get; set; }

        public virtual Adress Adress { get; set; } = null!;
    }
}
