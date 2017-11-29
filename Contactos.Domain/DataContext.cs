using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Domain
{
    public class DataContext : DbContext
    {
       public DataContext() : base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Contactos.Domain.PerfilGeneral> PerfilGenerals { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.Models.Phone> Phones { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.Models.Url> Urls { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.Models.Addresses> Addresses { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.BussinessPerfils> BussinessPerfils { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.Models.Emails> Emails { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.Models.SocialPerfils> SocialPerfils { get; set; }

        public System.Data.Entity.DbSet<Contactos.Domain.Models.Phone1> Phone1 { get; set; }
    }
}
