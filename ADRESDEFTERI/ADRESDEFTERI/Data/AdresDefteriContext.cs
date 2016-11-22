using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ADRESDEFTERI.Data
{
    public class AdresDefteriContext : DbContext
    {

        public DbSet<AdresDefteri> AdresDefteri { get; set; }

        public DbSet<Ilce> Ilce { get; set; }

        public DbSet<Il> Il { get; set; }

        public DbSet<Ulke> Ulke { get; set; }
        
        public static AdresDefteriContext Create()
        {
            return new AdresDefteriContext();
        }

    }
}