using Hovis.Api.Data.Models;
using Hovis.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Hovis.Api.Controllers
{
    [TempHeaderAuthorizationFilter]
    public class DepartmentsController : ApiController
    {
        private IEnumerable<Department> db;

        public DepartmentsController()
        {
            db = new[]
            {
                new Department
                {
                    Id = 1,
                    Name = "IT",
                    HeadOfDepartmentEmail = "a@b.com",
                    HeadOfDepartmentFirstName = "John",
                    HeadOfDepartmentId = 1234,
                    HeadOfDepartmentLastName = "Smith"
                },
                new Department
                {
                    Id = 2,
                    Name = "HR",
                    HeadOfDepartmentEmail = "x@y.com",
                    HeadOfDepartmentFirstName = "Kelly",
                    HeadOfDepartmentId = 5345,
                    HeadOfDepartmentLastName = "Jones"
                }
            };
        }

        // GET: api/ADUsers/?email=a@b.com
        [Route("api/departments", Name = "GetByQuery")]
        [ResponseType(typeof(ADUserDTO))]
        public IHttpActionResult Get([FromUri] DepartmentQuery query)
        {
            //no query was passed in, return the lot
            if (query == null)
                return Ok(db);

            var q = db.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                q = q.Where(x => x.Name.ToLower() == query.Name.ToLower());

            return Ok(q.ToList());
        }

        // GET: api/department
        [Route("api/departments/{id:int}")]
        [ResponseType(typeof(DepartmentDTO))]
        public IHttpActionResult Get(int id)
        {
            var dept = db.SingleOrDefault(x => x.Id.Equals(id));

            if (dept == null)
                return NotFound();

            return Ok(dept);
        }
    }

    public class DepartmentQuery
    {
        public string Name { get; set; }
    }
}