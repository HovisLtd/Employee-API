namespace Hovis.Api.Models
{
    public class ADUserDTO
    {
        public int EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string TelephoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string PhysicalDeliveryOffice { get; set; }

        public int ManagerId { get; set; }

        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }

        public string Company { get; set; }

        public string DistinguishedName { get; set; }

        public string LastLogonDate { get; set; }

        public string LastSync { get; set; }

        public string Webpage { get; set; }

        public string SamAccountName { get; set; }

        public int FinancialAuthLevel { get; set; }

        public string FunctionalDir { get; set; }

        public string FunctionalDirEmail { get; set; }

        public string HRBusinessPartner { get; set; }

        public string HRBusinessPartnerEmail { get; set; }

        public string Department { get; set; }

        public int HeadOfDepartmentId { get; set; }

        public string HeadOfDepartmentFirstName { get; set; }

        public string HeadOfDepartmentLastName { get; set; }

        public string HeadOfDepartmentEmailAddress { get; set; }

        public ADUserHolidayEntitlementDTO HolidayEntitlement { get; set; }
    }
}