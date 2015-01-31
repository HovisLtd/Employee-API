namespace Hovis.Api.Models
{
    public class ADUserHolidayEntitlementDTO
    {
        public int EmployeeNumber { get; set; }

        public ADUserDTO ADUser { get; set; }

        public int PeriodStartDay { get; set; }

        public int PeriodStartMonth { get; set; }

        public int PeriodEndDay { get; set; }

        public int PeriodEndMonth { get; set; }

        public decimal StandardEntitlement { get; set; }
    }
}