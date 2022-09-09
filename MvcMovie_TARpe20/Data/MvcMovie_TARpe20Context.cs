using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie_TARpe20.Models;

namespace MvcMovie_TARpe20.Data
{
    public class MvcMovie_TARpe20Context : DbContext
    {
        public MvcMovie_TARpe20Context (DbContextOptions<MvcMovie_TARpe20Context> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie_TARpe20.Models.Movie> Movie { get; set; }

        public DbSet<MvcMovie_TARpe20.Models.Actor> Actor { get; set; }
        public object Actorselect { get; internal set; }
    }
}
