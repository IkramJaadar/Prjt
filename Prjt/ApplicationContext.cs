using Microsoft.EntityFrameworkCore;
using Prjt.Models;

namespace Prjt
{
    public class ApplicationContext : DbContext

    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Coiffeur> Coiffeurs { get; set; }

        public DbSet<Payement> Payments { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
    }
}
