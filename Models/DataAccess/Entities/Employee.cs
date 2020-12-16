using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string NationalIIDNumber { get; set; }
        public string LoginID { get; set; }
        public string OrganizationNode { get; set; }
        public string OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public int SalariedFlag { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public int CurrentFlag { get; set; }
        public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
