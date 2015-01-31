using System.Collections.Generic;

namespace Hovis.Api.Queries
{
    public class ADUserQuery
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> FieldsToReturn { get; set; }
    }
}