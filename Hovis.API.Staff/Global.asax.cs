using AutoMapper;
using Hovis.Api.Data;
using Hovis.Api.Data.Models;
using Hovis.Api.Models;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using ADUser = Hovis.Api.Data.Models.ADUser;

namespace Hovis.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ///todo: move this
            Mapper.CreateMap<ADUser, ADUserDTO>();
            Mapper.CreateMap<ADUserHolidayEntitlement, ADUserHolidayEntitlementDTO>();

            //don't try and create the database, it already exists
            Database.SetInitializer<HovisDbContext>(null);
        }
    }
}