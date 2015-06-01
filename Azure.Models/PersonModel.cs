using System;

namespace Azure.Models
{
    public class PersonModel
    {
        public int EmployeeId { get; set; }

        public int? DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? JoiningDate { get; set; }
    }
}