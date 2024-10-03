using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUoW;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUoW;
using BusinessLayer.FluentValidation.AnnouncementValidations;
using BusinessLayer.FluentValidation.FeatureValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.FeatureDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            services.AddScoped<Context>();

            services.ConfigureApplicationCookie(x =>
            {
                x.AccessDeniedPath = "/Login/SignIn";
                x.LoginPath = "/Login/SignIn";
            });

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IAbout2Service, About2Manager>();
            services.AddScoped<IAbout2Dal, EfAbout2Dal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IFeature2Service, Feature2Manager>();
            services.AddScoped<IFeature2Dal, EfFeature2Dal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<INewsLetterDal, EfNewsLetterDal>();

            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal, EfSubAboutDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IExcelService,  ExcelManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IBankAccountService, BankAccountManager>();
            services.AddScoped<IBankAccountDal, EfBankAccountDal>();

            services.AddScoped<IUoWDal, UoWDal>();

            

        }

        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Create_Announcement_DTO>, Add_Announcement_Validator>();
            services.AddTransient<IValidator<Update_Announcement_DTO>, Update_Announcement_Validator>();

            services.AddTransient<IValidator<Create_Feature_DTO>, Create_Feature_Validator>();
            services.AddTransient<IValidator<Update_Feature_DTO>, Update_Feature_Validator>();
            

        }
    }
}
