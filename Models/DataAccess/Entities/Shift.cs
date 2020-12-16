using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
