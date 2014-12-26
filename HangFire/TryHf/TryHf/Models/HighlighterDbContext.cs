using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Hangfire.Highlighter.Models;

namespace TryHf.Models
{
    public class HighlighterDbContext : DbContext
    {
        public DbSet<CodeSnippet> CodeSnippets { get; set; }
        public HighlighterDbContext()
            : base("HighlighterDb")
        {
        }
    }
}