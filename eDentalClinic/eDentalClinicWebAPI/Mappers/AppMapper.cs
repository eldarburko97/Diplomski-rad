using AutoMapper;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Mappers
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Database.Dentist, eDentalClinic.Model.Dentist>().ReverseMap();
            CreateMap<Database.Dentist, DentistInsertRequest>().ReverseMap();
            CreateMap<Database.Branch, eDentalClinic.Model.Branch>().ReverseMap();
            CreateMap<Database.Branch, BranchInsertRequest>().ReverseMap();
            CreateMap<Database.Treatment, eDentalClinic.Model.Treatment>().ReverseMap();
            CreateMap<Database.Treatment, TreatmentInsertRequest>().ReverseMap();
            CreateMap<Database.BranchTreatment, eDentalClinic.Model.BranchTreatment>().ReverseMap();
            CreateMap<Database.BranchTreatment, BranchTreatmentInsertRequest>().ReverseMap();
            CreateMap<Database.Gender, eDentalClinic.Model.Gender>().ReverseMap();
            CreateMap<Database.Gender, GenderInsertRequest>().ReverseMap();
            CreateMap<Database.User, eDentalClinic.Model.User>().ReverseMap();
            CreateMap<Database.User, UserInsertRequest>().ReverseMap();
            CreateMap<Database.Topic, TopicInsertRequest>().ReverseMap();
            CreateMap<Database.Topic, eDentalClinic.Model.Topic>().ReverseMap();
            CreateMap<Database.Comment, eDentalClinic.Model.Comment>().ReverseMap();
            CreateMap<Database.Comment, CommentInsertRequest>().ReverseMap();
            CreateMap<Database.Appointment, eDentalClinic.Model.Appointment>().ReverseMap();
            CreateMap<Database.Appointment, AppointmentInsertRequest>().ReverseMap();
            CreateMap<Database.UserRole, eDentalClinic.Model.UserRole>().ReverseMap();
            CreateMap<Database.UserRole, UserRoleInsertRequest>().ReverseMap();
            CreateMap<Database.Rating, eDentalClinic.Model.Rating>().ReverseMap();
            CreateMap<Database.Rating, RatingInsertRequest>().ReverseMap();
            CreateMap<Database.Payment, eDentalClinic.Model.Payment>().ReverseMap();
            CreateMap<Database.Payment, PaymentInsertRequest>().ReverseMap();
            CreateMap<Database.Notification, eDentalClinic.Model.Notification>().ReverseMap();
            CreateMap<Database.Notification, NotificationInsertRequest>().ReverseMap();
        }
    }
}
