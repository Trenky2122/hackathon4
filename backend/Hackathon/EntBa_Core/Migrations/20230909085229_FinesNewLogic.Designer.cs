﻿// <auto-generated />
using System;
using EntBa_Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntBa_Core.Migrations
{
    [DbContext(typeof(EntBaDbContext))]
    [Migration("20230909085229_FinesNewLogic")]
    partial class FinesNewLogic
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntBa_Core.Database.Entities.Entrance.EntranceDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("EntranceCameraBack")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("EntranceCameraFront")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("ExitCameraBack")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("ExitCameraFront")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LicensePlateId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlateId");

                    b.HasIndex("PermissionId");

                    b.ToTable("Entrances");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.EntrancePermissions.EntrancePermissionDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EntranceRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("LicensePlateId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ValidFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("ValidTo")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EntranceRequestId");

                    b.HasIndex("LicensePlateId");

                    b.ToTable("EntrancePermissions");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.FileDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("FileDbo");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Fines.NonUserFineDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LicensePlateCountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NonUserFines");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Fines.RegisteredUserFineDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserFines");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.LicensePlateDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("PlateText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LicensePlates");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Requests.EntranceRequestDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AllowedPlaces")
                        .HasColumnType("text");

                    b.Property<bool>("IsYearly")
                        .HasColumnType("boolean");

                    b.Property<int>("RequestState")
                        .HasColumnType("integer");

                    b.Property<int>("RequestType")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EntranceRequests");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.SystemUsers.AdministratorDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PwdHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.SystemUsers.CardDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CardType")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.SystemUsers.UserDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PwdHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.SystemUsers.UserLinkDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LinkGiud")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("UserLinks");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.TaxDutyDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<bool>("AppealRequested")
                        .HasColumnType("boolean");

                    b.Property<int>("TaxDutyState")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ValidFrom")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TaxDuties");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Entrance.EntranceDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.LicensePlateDbo", "LicensePlate")
                        .WithMany()
                        .HasForeignKey("LicensePlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntBa_Core.Database.Entities.EntrancePermissions.EntrancePermissionDbo", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicensePlate");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.EntrancePermissions.EntrancePermissionDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.Requests.EntranceRequestDbo", "EntranceRequest")
                        .WithMany()
                        .HasForeignKey("EntranceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntBa_Core.Database.Entities.LicensePlateDbo", "LicensePlateDbo")
                        .WithMany()
                        .HasForeignKey("LicensePlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntranceRequest");

                    b.Navigation("LicensePlateDbo");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.FileDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.Requests.EntranceRequestDbo", "Request")
                        .WithMany("Files")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Fines.RegisteredUserFineDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.SystemUsers.UserDbo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.LicensePlateDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.SystemUsers.UserDbo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Requests.EntranceRequestDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.SystemUsers.UserDbo", "UserDbo")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDbo");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.SystemUsers.CardDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.SystemUsers.UserDbo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.TaxDutyDbo", b =>
                {
                    b.HasOne("EntBa_Core.Database.Entities.SystemUsers.UserDbo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntBa_Core.Database.Entities.Requests.EntranceRequestDbo", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
