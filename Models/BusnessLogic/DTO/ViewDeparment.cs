using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTO
{
    public class ViewDepartment 
    {
        public ViewDepartment(Department dep)
        {
            this.Id = dep.Id;
            this.Name = dep.Name;
            this.GroupName = dep.GroupName;
            this.ModifiedDate = dep.ModifiedDate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
