using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class BloodDonorContext : DbContext
    {
        public BloodDonorContext()
        {
        }

        public BloodDonorContext(DbContextOptions<BloodDonorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloodRequest> BloodRequests { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<VolunteerHealth> VolunteerHealths { get; set; }
        public virtual DbSet<VolunteerInCampaign> VolunteerInCampaigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString;
                IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
                connectionString = config["ConnectionStrings:DefaultConnection"];
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BloodRequest>(entity =>
            {
                entity.ToTable("BloodRequest");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.ReceiverIdentityNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiverName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReceiverPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VolunteerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.BloodRequests)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BloodRequest_Organization");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.BloodRequests)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BloodRequest_Volunteer");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.AddressDetails).HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Campaign_Organization");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.AddressDetails).HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.Phone);

                entity.ToTable("Volunteer");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AddressDetails).HasMaxLength(100);

                entity.Property(e => e.BloodType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastDonatedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VolunteerHealth>(entity =>
            {
                entity.ToTable("VolunteerHealth");

                entity.Property(e => e.DiseaseDescription).HasColumnType("ntext");

                entity.Property(e => e.DiseaseName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<VolunteerInCampaign>(entity =>
            {
                entity.ToTable("VolunteerInCampaign");

                entity.Property(e => e.BloodType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DonatedDate).HasColumnType("datetime");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.VolunteerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.VolunteerInCampaigns)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerInCampaign_Campaign");

                entity.HasOne(d => d.VolunteerHealth)
                    .WithMany(p => p.VolunteerInCampaigns)
                    .HasForeignKey(d => d.VolunteerHealthId)
                    .HasConstraintName("FK_VolunteerInCampaign_VolunteerHealth");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerInCampaigns)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerInCampaign_Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
