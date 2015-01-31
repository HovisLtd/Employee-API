using AutoMapper;
using Hovis.Api.Data;
using Hovis.Api.Models;
using Hovis.Api.Queries;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Hovis.Api.Controllers
{
    [TempHeaderAuthorizationFilterAttribute]
    public class ADUsersController : ApiController
    {
        //todo: inject this
        private readonly HovisDbContext db = new HovisDbContext();

        // GET: api/ADUsers/?email=a@b.com
        [Route("api/adusers", Name = "GetADUsersByQuery")]
        [ResponseType(typeof(ADUserDTO))]
        public IHttpActionResult GetADUsers([FromUri] ADUserQuery query)
        {
            //no query was passed in, return the lot
            if (query == null)
                return Ok(db.ADUsers);

            //could look at dynamic linq for this instead of manually building up the predicate
            var q = db.ADUsers
                .Include(e => e.HolidayEntitlement)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.Email))
                q = q.Where(x => x.Email == query.Email);

            if (!string.IsNullOrEmpty(query.FirstName))
                q = q.Where(x => x.FirstName == query.FirstName);

            if (!string.IsNullOrEmpty(query.LastName))
                q = q.Where(x => x.LastName == query.LastName);

            var result = q.ToList();

            //if we didn't get anything, return not found (404)
            if (!result.Any())
                return NotFound();

            var resultToReturn = Mapper.Map<IEnumerable<ADUserDTO>>(result);

            return Ok(resultToReturn);
        }

        // GET: api/ADUsers/5
        [Route("api/adusers/{id:int}")]
        [ResponseType(typeof(ADUserDTO))]
        public IHttpActionResult GetADUser(int id)
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