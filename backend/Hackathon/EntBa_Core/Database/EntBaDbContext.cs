using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Entrance;
using EntBa_Core.Database.Entities.EntrancePermissions;
using EntBa_Core.Database.Entities.Fines;
using EntBa_Core.Database.Entities.Fines.Abstractions;
using EntBa_Core.Database.Entities.Requests;
using EntBa_Core.Database.Entities.SystemUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntBa_Core.Database
{
    public class EntBaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        private readonly IConfiguration Configuration;

        public EntBaDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public required DbSet<UserDbo> Users { get; set; }
        public required DbSet<AdministratorDbo> Administrators { get; set; }
        public required DbSet<UserLinkDbo> UserLinks { get; set; }
        public required DbSet<LicensePlateDbo> LicensePlates { get; set; }
        public required DbSet<EntranceDbo> Entrances { get; set; }
        public required DbSet<EntrancePermissionDbo> EntrancePermissions { get; set; }
        public required DbSet<EntranceRequestDbo> EntranceRequests { get; set; }
        public required DbSet<CardDbo> Cards { get; set; }
        public required DbSet<TaxDutyDbo> TaxDuties { get; set; }
        public required DbSet<RegisteredUserFineDbo> UserFines { get; set; }
        public required DbSet<NonUserFineDbo> NonUserFines { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Database"));
        }
    }
}
