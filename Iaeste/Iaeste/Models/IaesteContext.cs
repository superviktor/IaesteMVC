
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iaeste.Models
{
    public class IaesteContext:DbContext
    {
        public DbSet<Gallery> gallery { get; set; }
    }
}
