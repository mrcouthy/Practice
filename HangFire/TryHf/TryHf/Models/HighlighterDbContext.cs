﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TryHf.Models
{
    public class HighlighterDbContext : DbContext
    {
        public HighlighterDbContext()
            : base("HighlighterDb")
        {
        }
    }
}