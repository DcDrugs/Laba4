using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Repositories
{
    public class DepartmentRepository : IRepository<ViewDepartment>
    {
        private List<ViewDepartment> db;

        public DepartmentRepository(List<ViewDepartment> Departments)
        {
            this.db = Departments;
        }

        public IEnumerable<ViewDepartment> GetAll()
        {
            return db;
        }
    }
}
