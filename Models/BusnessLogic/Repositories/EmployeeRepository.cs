using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Repositories
{
    public class EmployeeRepository : IRepository<ViewEmployee>
    {
        private List<ViewEmployee> db;

        public EmployeeRepository(List<ViewEmployee> Departments)
        {
            this.db = Departments;
        }

        public IEnumerable<ViewEmployee> GetAll()
        {
            return db;
        }
    }
}
