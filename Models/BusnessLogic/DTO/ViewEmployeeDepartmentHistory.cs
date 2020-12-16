using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTO
{
    public class ViewEmployeeDepartmentHistory
    {
        public ViewEmployeeDepartmentHistory(EmployeeDepartmentHistory employee)
        {
            this.BusinessEntityID = employee.BusinessEntityID;
            this.DepartmentID = employee.DepartmentID;
            this.ShiftID = employee.ShiftID;
            this.StartDate = employee.StartDate;
            this.EndDate = employee.EndDate;
            this.ModifiedDate = employee.ModifiedDate;
        }
        public int BusinessEntityID { get; set; }
        public int DepartmentID { get; set; }
        public int ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
