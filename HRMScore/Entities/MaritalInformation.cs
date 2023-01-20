using HRMScore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities
{
    public class MaritalInformation: BaseEntity
    {
        public string? SpouseName { get; set; }
        public string? SpousePhoneNumber { get; set; }
        public string? SpouseProfession { get; set; }
        public string? ResidentialAddress { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
