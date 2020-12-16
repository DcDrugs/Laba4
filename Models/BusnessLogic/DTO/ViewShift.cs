using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTO
{
    public class ViewShift
    {
        public ViewShift(Shift shift)
        {
            this.ShiftID = shift.ShiftID;
            this.Name = shift.Name;
            this.StartTime = shift.StartTime;
            this.EndTime = shift.EndTime;
            this.ModifiedDate = shift.ModifiedDate;
        }
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
