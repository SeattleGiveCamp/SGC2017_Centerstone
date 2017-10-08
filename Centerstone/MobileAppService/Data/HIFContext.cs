using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Centerstone.MobileAppService.Data
{
    public partial class HIFContext : DbContext
    {
        public virtual DbSet<HifApplication> HifApplication { get; set; }
        public virtual DbSet<HouseholdMembers> HouseholdMembers { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<IncomeTypes> IncomeTypes { get; set; }
        public virtual DbSet<StoredImages> StoredImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:centerstone-hif.database.windows.net,1433;Initial Catalog=centerstone-hif-sandbox;Persist Security Info=False;User ID=appSVC;Password=C0rnerSt0ne!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HifApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId);

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.BakupHeatCost).HasColumnType("binary(1)");

                entity.Property(e => e.HeatSource)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.HousingStatus).HasMaxLength(30);

                entity.Property(e => e.HousingType).HasMaxLength(30);

                entity.Property(e => e.LiveCity)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LiveState)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LiveStreetAddress).IsRequired();

                entity.Property(e => e.LiveZipCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.MailingCity).HasMaxLength(30);

                entity.Property(e => e.MailingState).HasMaxLength(30);

                entity.Property(e => e.MailingZipCode).HasMaxLength(30);

                entity.Property(e => e.MessagePhone).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.TargetGrouop2).HasColumnType("nchar(1)");

                entity.Property(e => e.TargetGroup1).HasColumnType("nchar(1)");

                entity.Property(e => e.UsedSurrogate).HasColumnType("binary(1)");
            });

            modelBuilder.Entity<HouseholdMembers>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Disability).HasColumnType("nchar(1)");

                entity.Property(e => e.Ethnicity).HasMaxLength(50);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HealthInsurance).HasColumnType("nchar(1)");

                entity.Property(e => e.IsPrimary).HasColumnType("nchar(1)");

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.MiddleInitial).HasColumnType("nchar(1)");

                entity.Property(e => e.MilitaryVeteran).HasColumnType("nchar(1)");

                entity.Property(e => e.PaidAdult).HasColumnType("nchar(1)");

                entity.Property(e => e.RelationToPrimary)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(11);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.HouseholdMembers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hif_Household_AppId");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hif_Images_AppID");
            });

            modelBuilder.Entity<IncomeTypes>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId).HasColumnName("RowID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ChildSupport).HasColumnType("binary(1)");

                entity.Property(e => e.EarnedIncome).HasColumnType("binary(1)");

                entity.Property(e => e.Ga)
                    .HasColumnName("GA")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.Military).HasColumnType("binary(1)");

                entity.Property(e => e.Other).HasColumnType("binary(1)");

                entity.Property(e => e.Pension).HasColumnType("binary(1)");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.SelfEmployed).HasColumnType("binary(1)");

                entity.Property(e => e.SocialSecurity).HasColumnType("binary(1)");

                entity.Property(e => e.Ssi)
                    .HasColumnName("SSI")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.Tanf)
                    .HasColumnName("TANF")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.Unemployment).HasColumnType("binary(1)");

                entity.Property(e => e.Va)
                    .HasColumnName("VA")
                    .HasColumnType("binary(1)");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.IncomeTypes)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Income_Hif_AppID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.IncomeTypes)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INCOME_Household_Person");
            });

            modelBuilder.Entity<StoredImages>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.ImageData)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.StoredImages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_StoredImages_ImageID");
            });
        }
    }
}
