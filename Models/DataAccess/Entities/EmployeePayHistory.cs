using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class EmployeePayHistory
    {
        public int BusinessEntityID { get; set; }
        public DateTime RateChangeDate { get; set; }
        public string Rate { get; set; }
        public int PayFrequency { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
