using Hovis.Api.Data;
using Hovis.Api.Data.Models;
using Hovis.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Hovis.Api.Controllers
{
    public class ADUsersHolidayEntitlementController : ApiController
    {
        //todo: inject this
        private readonly HovisDbContext db = new HovisDbContext();

        // GET: api/ADUsers/?email=a@b.com
        [Route("api/adusers/holidayentitlement", Name = "GetADUsersHolidayEntitlementByQuery")]
        [ResponseType(typeof(ADUserHolidayEntitlementDTO))]
        public IHttpActionResult GetADUsersHolidayEntitlement()
        {
            var users = db.ADUsers.ToList();
            var usersEnt = db.ADUserHolidayEntitlement.ToList();

            var result = new List<ADUserHolidayEntitlement>();

            foreach (var user in users)
            {
                var userEntitlement = usersEnt.SingleOrDefault(x => x.EmployeeNumber.Equals(user.EmployeeNumber));

                result.Add(userEntitlement ?? new ADUserHolidayEntitlement { ADUser = user, EmployeeNumber = user.EmployeeNumber });
            }

            //   var result = (
            //       from
            //           userEntitlment in db.ADUserHolidayEntitlement
            //       join
            //           adUser in db.ADUsers
            //           on
            //           userEntitlment.EmployeeNumber equals adUser.EmployeeNumber
            //       select userEntitlment
            //       )
            //       .ToList();

            return Ok(result);
        }

        // GET: api/ADUsers/5/holidayentitlement
        [Route("api/adusers/{id:int}/holidayentitlement")]
        [ResponseType(typeof(ADUserHolidayEntitlementDTO))]
        public IHttpActionResult GetADUserHolidayEntitlement(int id)
        {
            var aDUser = db.ADUsers.Find(id);

            if (aDUser == null)
                return NotFound();

            return Ok(aDUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}