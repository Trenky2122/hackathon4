﻿using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Entrance;
using EntBa_Core.Database.Entities.EntrancePermissions;
using EntBa_Core.Database.Entities.Requests;
using EntBa_Core.Database.Entities.SystemUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntBa_Core.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {

        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public required DbSet<UserDbo> Users { get; set; }
        public required DbSet<AdministratorDbo> Administrators { get; set; }
        public required DbSet<UserLinkDbo> UserLinks { get; set; }
        public required DbSet<LicensePlate> LicensePlates { get; set; }
        public required DbSet<EntranceDbo> Entrances { get; set; }
        public required DbSet<EntrancePermissionDbo> EntrancePermissions { get; set; }
        public required DbSet<EntranceRequestDbo> EntranceRequests { get; set; }
        public required DbSet<CardDbo> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Database"));
        }
    }
}
