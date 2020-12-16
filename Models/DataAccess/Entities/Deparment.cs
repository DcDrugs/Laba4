using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Department 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
