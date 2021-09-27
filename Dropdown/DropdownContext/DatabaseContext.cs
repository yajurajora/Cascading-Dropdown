using Dropdown.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropdown.DropdownContext
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Continents> tblContinents { get; set; }
        public DbSet<Countries> tblCountries { get; set; }
        public DbSet<Cities> tblCities { get; set; }
    }
}
