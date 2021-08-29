using eDentalClinicWebAPI.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public partial class eDentalClinicContext : DbContext
    {
        public eDentalClinicContext(DbContextOptions<eDentalClinicContext> options) : base(options)
        {

        }

        public DbSet<DentalClinic> DentalClinic { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchTreatment> BranchTreatments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
              .HasOne<DentalClinic>(e => e.DentalClinic)
              .WithMany(d => d.Users)
              .HasForeignKey(e => e.DentalClinicID);
            modelBuilder.Entity<User>().HasOne<City>(e => e.City).WithMany(d => d.Users).HasForeignKey(e => e.CityID);
            modelBuilder.Entity<User>().HasOne<Gender>(e => e.Gender).WithMany(d => d.Users).HasForeignKey(e => e.GenderID);
            modelBuilder.Entity<User>().HasIndex(uq => uq.Username).IsUnique();

            modelBuilder.Entity<Dentist>().HasOne<DentalClinic>(e => e.DentalClinic).WithMany(d => d.Dentists).HasForeignKey(e => e.DentalClinicID);
            modelBuilder.Entity<Dentist>().HasOne<Branch>(e => e.Branch).WithMany(d => d.Dentists).HasForeignKey(e => e.BranchID);

            modelBuilder.Entity<UserRole>()
            .HasOne<User>(e => e.User)
            .WithMany(p => p.UserRoles);
            modelBuilder.Entity<UserRole>()
            .HasOne<Role>(e => e.Role)
            .WithMany(p => p.UserRoles);



            modelBuilder.Entity<User>().HasOne<City>(e => e.City).WithMany(d => d.Users).HasForeignKey(e => e.CityID);

            modelBuilder.Entity<User>().HasOne<Gender>(e => e.Gender).WithMany(d => d.Users).HasForeignKey(e => e.GenderID);

            modelBuilder.Entity<Rating>().HasKey(e => new { e.RatingID });
            modelBuilder.Entity<Rating>().HasOne<User>(e => e.User).WithMany(p => p.Ratings);
            modelBuilder.Entity<Rating>().HasOne<Dentist>(e => e.Dentist).WithMany(p => p.Ratings);

            modelBuilder.Entity<Appointment>().HasKey(e => new { e.AppointmentID });
            modelBuilder.Entity<Appointment>().HasOne<User>(e => e.User).WithMany(p => p.Appointments);
            modelBuilder.Entity<Appointment>()
          .HasOne<Dentist>(e => e.Dentist)
          .WithMany(p => p.Appointments);
            modelBuilder.Entity<Appointment>().HasOne<Treatment>(e => e.Treatment).WithMany(p => p.Appointments);
            

            modelBuilder.Entity<BranchTreatment>().HasOne<Branch>(e => e.Branch).WithMany(p => p.BranchTreatments);
            modelBuilder.Entity<BranchTreatment>().HasOne<Treatment>(e => e.Treatment).WithMany(p => p.BranchTreatments);

            modelBuilder.Entity<Topic>().HasOne<User>(e => e.User).WithMany(d => d.Topics).HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Comment>().HasOne<User>(e => e.User).WithMany(d => d.Comments).HasForeignKey(e => e.UserID);
            modelBuilder.Entity<Comment>().HasOne<Topic>(e => e.Topic).WithMany(d => d.Comments).HasForeignKey(e => e.TopicID);

            modelBuilder.Entity<Notification>().HasOne<User>(e => e.User).WithMany(d => d.Notifications).HasForeignKey(e => e.UserID);
            modelBuilder.Entity<Payment>().HasOne<User>(e => e.User).WithMany(d => d.Payments).HasForeignKey(e => e.UserID);
            modelBuilder.Entity<Payment>().HasOne<Treatment>(e => e.Treatment).WithMany(d => d.Payments).HasForeignKey(e => e.TreatmentID);

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
