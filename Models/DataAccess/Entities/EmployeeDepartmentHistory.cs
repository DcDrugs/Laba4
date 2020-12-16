using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class EmployeeDepartmentHistory
    {
        public int BusinessEntityID { get; set; }
        public int DepartmentID { get; set; }
        public int ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
