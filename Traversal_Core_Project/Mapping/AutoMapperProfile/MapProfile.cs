using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.FeatureDTOs;
using EntityLayer.Concrete;
using Traversal_Core_Project.Areas.Admin.Models;

namespace Traversal_Core_Project.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Create_Announcement_DTO, Announcement>().ReverseMap();

            CreateMap<Update_Announcement_DTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementList_DTO, Announcement>().ReverseMap();

            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();

            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();

            CreateMap<List_Feature_DTO, Feature>().ReverseMap();

            CreateMap<Create_Feature_DTO, Feature>().ReverseMap();

            CreateMap<Update_Feature_DTO, Feature>().ReverseMap();

        }
    }
}
