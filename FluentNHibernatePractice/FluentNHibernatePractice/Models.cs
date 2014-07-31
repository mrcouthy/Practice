using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernatePractice
{
    public class Department
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
    }

    ///Case study
    /// Error No persister for: FluentNHibernatePractic means mapping file not given
}
