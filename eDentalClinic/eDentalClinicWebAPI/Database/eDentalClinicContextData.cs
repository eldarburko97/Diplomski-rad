using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eDentalClinicWebAPI.Helper;
using Microsoft.EntityFrameworkCore;

namespace eDentalClinicWebAPI.Database
{
    public partial class eDentalClinicContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DentalClinic>().HasData(new DentalClinic()
            {
                DentalClinicID = 1,
                Name = "Dental clinic Ćatić",
                Address = "Kulina Bana 18",
                Phone = "030 254-440",
                Email = "catic@mail.com"
            });

            // CITY

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 1,
                Name = "Sarajevo"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 2,
                Name = "Mostar"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 3,
                Name = "Bugojno"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 4,
                Name = "G.Vakuf"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 5,
                Name = "D.Vakuf"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 6,
                Name = "Travnik"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 7,
                Name = "Prozor"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = 8,
                Name = "Jajce"
            });

            
            // Gender

            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderID = 1,
                Type = "Male"
            });

            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderID = 2,
                Type = "Female"
            });
            
            // Treatment

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 1,
                Name = "Pregled",
                Price = 20,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment3.png")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 2,
                Name = "Vađenje zuba",
                Price = 25,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment1.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 3,
                Name = "Popravljanje zuba",
                Price = 30,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment2.jpeg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 4,
                Name = "Hiruško vađenje zuba",
                Price = 50,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment1.jpg")
            });
            

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 5,
                Name = "Sinus lift",
                Price = 60,
                TimeRequired = 1,
                 Image = File.ReadAllBytes("Images/treatment4.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 6,
                Name = "Uklanjanje cisti",
                Price = 40,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment10.png")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 7,
                Name = "Fiksna ortodontsa terapija",
                Price = 1500,
                TimeRequired = 2,
                 Image = File.ReadAllBytes("Images/treatmetn5.png")
            });

            

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 8,
                Name = "Mobilna ortodontsa terapija",
                Price = 350,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment6.png")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment()
            {
                TreatmentID = 9,
                Name = "Terapija folijama",
                Price = 100,
                TimeRequired = 1,
                Image = File.ReadAllBytes("Images/treatment11.png")
            });

            // Branch
            
            modelBuilder.Entity<Branch>().HasData(new Branch()
            {
                BranchID = 1,
                Name = "Opća stomatologija",
                Title = "dr. stomatologije",
            });

            modelBuilder.Entity<Branch>().HasData(new Branch()
            {
                BranchID = 2,
                Name = "Oralna hirurgija",
                Title = "dr spec. oralne hirurgije",
            });

            modelBuilder.Entity<Branch>().HasData(new Branch()
            {
                BranchID = 3,
                Name = "Ortodoncija",
                Title = "dr spec. ortodoncije",
            });

            // BranchTreatment

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 1,
                BranchID = 1,         // Opća stomatologija
                TreatmentID = 1,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 2,
                BranchID = 1,
                TreatmentID = 2,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 3,
                BranchID = 1,
                TreatmentID = 3,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 4,
                BranchID = 2,
                TreatmentID = 1,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 5,
                BranchID = 2,
                TreatmentID = 2,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 6,
                BranchID = 2,
                TreatmentID = 3,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 7,
                BranchID = 2,
                TreatmentID = 4,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 8,
                BranchID = 2,
                TreatmentID = 5,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 9,
                BranchID = 2,
                TreatmentID = 6,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 10,
                BranchID = 3,
                TreatmentID = 7,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 11,
                BranchID = 3,
                TreatmentID = 8,
            });

            modelBuilder.Entity<BranchTreatment>().HasData(new BranchTreatment()
            {
                BranchTreatmentID = 12,
                BranchID = 3,
                TreatmentID = 9,
            });

            // Dentist
            

            modelBuilder.Entity<Dentist>().HasData(new Dentist()
            {
                DentistID = 1,
                DentalClinicID = 1,
                FirstName = "Besko",
                LastName = "Sadagić",
                Phone = "062765123",
                Email = "besko@mail.com",
                Address = "Jaklic bb",
                BirthDate = new DateTime(1970, 01, 13),
                Image = File.ReadAllBytes("Images/Dentist7.jpg"),
                BranchID = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna" +
                " aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                " Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                Active = true
            });

            modelBuilder.Entity<Dentist>().HasData(new Dentist()
            {
                DentistID = 2,
                DentalClinicID = 1,
                FirstName = "Adnan",
                LastName = "Frljak",
                Phone = "062156783",
                Email = "adnan@mail.com",
                Address = "Lamele",
                BirthDate = new DateTime(1992, 07, 20),
                Image = File.ReadAllBytes("Images/Dentist6.jpg"),
                BranchID = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna" +
               " aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
               " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
               " Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                Active = true
            });

            modelBuilder.Entity<Dentist>().HasData(new Dentist()
            {
                DentistID = 3,
                DentalClinicID = 1,
                FirstName = "Đana",
                LastName = "Ćatić",
                Phone = "062456123",
                Email = "đana@mail.com",
                Address = "Nugle",
                BirthDate = new DateTime(1993, 04, 16),
                Image = File.ReadAllBytes("Images/Dentist2.jpg"),
                BranchID = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna" +
              " aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
              " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
              " Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                Active = true
            });

            // Role

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleID = 1,
                Name = "Administrator"
            });

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleID = 2,
                Name = "Client"
            });

            // Client

            User u1 = new User
            {
                UserID = 1,
                DentalClinicID = 1,
                CityID = 3,
                GenderID = 1,
                FirstName = "Mobile1",
                LastName = "Client1",
                Username = "client1",
                Phone = "062456982",
                Email = "mobile1@mail.com",
                Address = "Sultan Ahmedova bb",
                BirthDate = new DateTime(1997, 07, 15),
                Image = File.ReadAllBytes("Images/userDefault.png")
            };
            u1.PasswordSalt = HashGenerator.GenerateSalt();
            u1.PasswordHash = HashGenerator.GenerateHash(u1.PasswordSalt, "test");
            modelBuilder.Entity<User>().HasData(u1);

            User u2 = new User
            {
                UserID = 2,
                DentalClinicID = 1,
                CityID = 4,
                GenderID = 2,
                FirstName = "Mobile2",
                LastName = "Client2",
                Username = "client2",
                Phone = "062123756",
                Email = "mobile2@mail.com",
                Address = "Nugle 2 4/b",
                BirthDate = new DateTime(2001, 02, 09),
                Image = File.ReadAllBytes("Images/userDefault.png")
            };
            u2.PasswordSalt = HashGenerator.GenerateSalt();
            u2.PasswordHash = HashGenerator.GenerateHash(u2.PasswordSalt, "test");
            modelBuilder.Entity<User>().HasData(u2);

            User u3 = new User
            {
                UserID = 3,
                DentalClinicID = 1,
                CityID = 5,
                GenderID = 1,
                FirstName = "Mobile3",
                LastName = "Client3",
                Username = "client3",
                Phone = "062567234",
                Email = "mobile3@mail.com",
                Address = "Kulina Bana bb",
                BirthDate = new DateTime(1999, 05, 05),
                Image = File.ReadAllBytes("Images/userDefault.png")
            };
            u3.PasswordSalt = HashGenerator.GenerateSalt();
            u3.PasswordHash = HashGenerator.GenerateHash(u3.PasswordSalt, "test");
            modelBuilder.Entity<User>().HasData(u3);

            // Administrator

            User u4 = new User
            {
                UserID = 4,
                DentalClinicID = 1,
                CityID = 3,
                GenderID = 1,
                FirstName = "User",
                LastName = "Desktop",
                Username = "desktop",
                Phone = "062654763",
                Email = "desktop@mail.com",
                Address = "Nugle 2 4/b",
                BirthDate = new DateTime(1993, 02, 21),
                Image = File.ReadAllBytes("Images/userDefault.png")
            };
            u4.PasswordSalt = HashGenerator.GenerateSalt();
            u4.PasswordHash = HashGenerator.GenerateHash(u4.PasswordSalt, "test");
            modelBuilder.Entity<User>().HasData(u4);


            // UserRole

            modelBuilder.Entity<UserRole>().HasData(new UserRole()
            {
                UserRoleID = 1,
                UserID = 1,
                RoleID = 2
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole()
            {
                UserRoleID = 2,
                UserID = 2,
                RoleID = 2
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole()
            {
                UserRoleID = 3,
                UserID = 3,
                RoleID = 2
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole()
            {
                UserRoleID = 4,
                UserID = 4,
                RoleID = 1
            });

            
            // Appointment

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 1,
                UserID = 1,
                DentistID = 1,
                TreatmentID = 1,
                StartDate = new DateTime(2021, 02, 08,09,0,0),
                EndDate = new DateTime(2021, 02, 08, 10, 0, 0),
                RatingStatus = true,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 2,
                UserID = 2,
                DentistID = 2,
                TreatmentID = 1,
                StartDate = new DateTime(2021, 02, 08, 09, 0, 0),
                EndDate = new DateTime(2021, 02, 08, 10, 0, 0),
                RatingStatus = true,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 3,
                UserID = 3,
                DentistID = 3,
                TreatmentID = 1,
                StartDate = new DateTime(2021, 02, 08, 09, 0, 0),
                EndDate = new DateTime(2021, 02, 08, 10, 0, 0),
                RatingStatus = true,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 4,
                UserID = 1,
                DentistID = 1,
                TreatmentID = 3,
                StartDate = new DateTime(2021, 02, 15, 12, 0, 0),
                EndDate = new DateTime(2021, 02, 15, 13, 0, 0),
                RatingStatus = true,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 5,
                UserID = 2,
                DentistID = 2,
                TreatmentID = 6,
                StartDate = new DateTime(2021, 02, 17, 13, 0, 0),
                EndDate = new DateTime(2021, 02, 17, 14, 0, 0),
                RatingStatus = true,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 6,
                UserID = 1,
                DentistID = 2,
                TreatmentID = 1,
                StartDate = new DateTime(2021, 03, 06, 12, 0, 0),
                EndDate = new DateTime(2021, 03, 06, 13, 0, 0),
                RatingStatus = true,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment()
            {
                AppointmentID = 7,
                UserID = 2,
                DentistID = 1,
                TreatmentID = 1,
                StartDate = new DateTime(2021, 03, 08, 13, 0, 0),
                EndDate = new DateTime(2021, 03, 08, 14, 0, 0),
                RatingStatus = true,
            });

            // Rating

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 1,
                UserID = 1,
                DentistID = 1,
                DentistRating = 9,
                RatingDate = new DateTime(2021, 02, 08),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 2,
                UserID = 2,
                DentistID = 2,
                DentistRating = 10,
                RatingDate = new DateTime(2021, 02, 08),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 3,
                UserID = 3,
                DentistID = 3,
                DentistRating = 10,
                RatingDate = new DateTime(2021, 02, 08),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 4,
                UserID = 1,
                DentistID = 1,
                DentistRating = 8,
                RatingDate = new DateTime(2021, 02, 15),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 5,
                UserID = 2,
                DentistID = 2,
                DentistRating = 9,
                RatingDate = new DateTime(2021, 02, 17),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 6,
                UserID = 1,
                DentistID = 2,
                DentistRating = 7,
                RatingDate = new DateTime(2021, 03, 06),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingID = 7,
                UserID = 2,
                DentistID = 1,
                DentistRating = 8,
                RatingDate = new DateTime(2021, 03, 08),
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor"
            });

            // Topic

            modelBuilder.Entity<Topic>().HasData(new Topic()
            {
                TopicID = 1,
                UserID = 1,
                Subject = "Test",
                Description = "Test",
                Text = "Test",
                Date = new DateTime(2021, 03, 08),
            });

            // Comment

            modelBuilder.Entity<Comment>().HasData(new Comment()
            {
                CommentID = 1,
                UserID = 2,
                TopicID = 1,
                Text = "Test",
                Date = new DateTime(2021, 03, 08),
            });

            // Payment

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 1,
                UserID = 1,
                TreatmentID = 1,
                Amount = 20,
                Date = new DateTime(2021, 02, 08),
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 2,
                UserID = 2,
                TreatmentID = 1,
                Amount = 20,
                Date = new DateTime(2021, 02, 08),
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 3,
                UserID = 3,
                TreatmentID = 1,
                Amount = 20,
                Date = new DateTime(2021, 02, 08),
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 4,
                UserID = 1,
                TreatmentID = 3,
                Amount = 30,
                Date = new DateTime(2021, 02, 15),
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 5,
                UserID = 2,
                TreatmentID = 6,
                Amount = 40,
                Date = new DateTime(2021, 02, 17),
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 6,
                UserID = 1,
                TreatmentID = 1,
                Amount = 20,
                Date = new DateTime(2021, 03, 06),
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                PaymentID = 7,
                UserID = 2,
                TreatmentID = 1,
                Amount = 20,
                Date = new DateTime(2021, 03, 08),
            });

            // Notification

            modelBuilder.Entity<Notification>().HasData(new Notification()
            {
                NotificationID = 1,
                Title = "Test",
                Text = "Test",
                NotificationDate = new DateTime(2021, 03, 08),
                UserID = 4,
            });
        }
    }
}
