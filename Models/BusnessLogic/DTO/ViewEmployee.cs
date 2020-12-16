using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTO
{
    public class ViewEmployee
    {
        public ViewEmployee(Employee employee)
        {
            this.Id = employee.Id;
            this.NationalIIDNumber = employee.NationalIIDNumber;
            this.LoginID = employee.LoginID;
            this.OrganizationNode = employee.OrganizationNode;
            this.OrganizationLevel = employee.OrganizationLevel;
            this.JobTitle = employee.JobTitle;
            this.BirthDate = employee.BirthDate;
            this.MaritalStatus = employee.MaritalStatus;
            this.Gender = employee.Gender;
            this.HireDate = employee.HireDate;
            this.SalariedFlag = employee.SalariedFlag;
            this.VacationHours = employee.VacationHours;
            this.SickLeaveHours = employee.SickLeaveHours;
            this.CurrentFlag = employee.CurrentFlag;
            this.rowguid = employee.rowguid;
            this.ModifiedDate = employee.ModifiedDate;
        }
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
