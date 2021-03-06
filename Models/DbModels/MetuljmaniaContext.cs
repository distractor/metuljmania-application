// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MetuljmaniaDatabase.Models.DbModels
{
    public partial class MetuljmaniaContext : DbContext
    {
        public MetuljmaniaContext()
        {
        }

        public MetuljmaniaContext(DbContextOptions<MetuljmaniaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Pilot> Pilot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C.UTF-8");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UploadedDate).HasColumnType("date");

                entity.HasOne(d => d.Pilot)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.PilotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PilotId");
            });

            modelBuilder.Entity<Pilot>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Civlid)
                    .HasMaxLength(50)
                    .HasColumnName("CIVLID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fai)
                    .HasMaxLength(50)
                    .HasColumnName("FAI");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Glider).HasMaxLength(100);

                entity.Property(e => e.GliderColor).HasMaxLength(50);

                entity.Property(e => e.InsuranceCompany).HasMaxLength(50);

                entity.Property(e => e.LastName).HasColumnType("character varying");

                entity.Property(e => e.Licence).HasMaxLength(100);

                entity.Property(e => e.MobilePhone).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Nation).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PolicyNumber).HasMaxLength(100);

                entity.Property(e => e.SafetyClass).HasMaxLength(50);

                entity.Property(e => e.Sponsors).HasMaxLength(500);

                entity.Property(e => e.Team).HasMaxLength(100);

                entity.HasOne(d => d.CheckFile)
                    .WithMany(p => p.PilotCheckFile)
                    .HasForeignKey(d => d.CheckFileId)
                    .HasConstraintName("CheckFileId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Pilot)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EventId");

                entity.HasOne(d => d.IppiFile)
                    .WithMany(p => p.PilotIppiFile)
                    .HasForeignKey(d => d.IppiFileId)
                    .HasConstraintName("IppiFileId");

                entity.HasOne(d => d.LicenceFile)
                    .WithMany(p => p.PilotLicenceFile)
                    .HasForeignKey(d => d.LicenceFileId)
                    .HasConstraintName("LicenceFileId");

                entity.HasOne(d => d.SignedApplicationFile)
                    .WithMany(p => p.PilotSignedApplicationFile)
                    .HasForeignKey(d => d.SignedApplicationFileId)
                    .HasConstraintName("SignedFileId");

                entity.HasOne(d => d.UnSignedApplicationFile)
                    .WithMany(p => p.PilotUnSignedApplicationFile)
                    .HasForeignKey(d => d.UnSignedApplicationFileId)
                    .HasConstraintName("UnSignedFileId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}