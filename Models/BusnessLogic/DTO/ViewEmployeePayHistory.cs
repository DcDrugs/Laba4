using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTO
{
    public class ViewEmployeePayHistory
    {
        public ViewEmployeePayHistory(EmployeePayHistory employee)
        {
            this.BusinessEntityID = employee.BusinessEntityID;
            this.RateChangeDate = employee.RateChangeDate;
            this.Rate = employee.Rate;
            this.PayFrequency = employee.PayFrequency;
            this.ModifiedDate = employee.ModifiedDate;
        }
        public int BusinessEntityID { get; set; }
        public DateTime RateChangeDate { get; set; }
        public string Rate { get; set; }
        public int PayFrequency { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
