using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Centerstone.MobileAppService.Data
{
    public partial class HifContext : DbContext
    {
        public virtual DbSet<HifApplication> HifApplication { get; set; }
        public virtual DbSet<HouseholdMembers> HouseholdMembers { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<IncomeRules> IncomeRules { get; set; }
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

                entity.Property(e => e.BackupHeatCost).HasColumnType("bit");

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

                entity.Property(e => e.Email);

                entity.Property(e => e.TargetGroup1).HasColumnType("bit");

                entity.Property(e => e.TargetGroup2).HasColumnType("bit");

                entity.Property(e => e.UniqueAppId).IsRequired();

                entity.Property(e => e.UsedSurrogate).HasColumnType("bit");
            });

            modelBuilder.Entity<HouseholdMembers>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Disability).HasColumnType("bit");

                entity.Property(e => e.Ethnicity).HasMaxLength(50);

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HealthInsurance).HasColumnType("bit");

                entity.Property(e => e.IsPrimary).HasColumnType("bit");

                entity.Property(e => e.MilitaryVeteran).HasColumnType("bit");

                entity.Property(e => e.PaidAdult).HasColumnType("bit");

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

                entity.Property(e => e.ApplicantGuid).HasColumnName("ApplicantGUID");

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

                entity.Property(e => e.UniqueImageId).IsRequired();

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hif_Images_AppID");
            });

            modelBuilder.Entity<IncomeRules>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId)
                    .HasColumnName("RowID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HouseholdAdjust).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<IncomeTypes>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId).HasColumnName("RowID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ChildSupport).HasColumnType("bit");

                entity.Property(e => e.EarnedIncome).HasColumnType("bint");

                entity.Property(e => e.Ga)
                    .HasColumnName("GA")
                    .HasColumnType("bit");

                entity.Property(e => e.Military).HasColumnType("bit");

                entity.Property(e => e.Other).HasColumnType("bit");

                entity.Property(e => e.Pension).HasColumnType("bit");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.SelfEmployed).HasColumnType("bit");

                entity.Property(e => e.SocialSecurity).HasColumnType("bit");

                entity.Property(e => e.Ssi)
                    .HasColumnName("SSI")
                    .HasColumnType("bit");

                entity.Property(e => e.Tanf)
                    .HasColumnName("TANF")
                    .HasColumnType("bit");

                entity.Property(e => e.Unemployment).HasColumnType("bit");

                entity.Property(e => e.Va)
                    .HasColumnName("VA")
                    .HasColumnType("bit");

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
