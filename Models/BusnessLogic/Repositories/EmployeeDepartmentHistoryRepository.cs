using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Repositories
{
    public class EmployeeDepartmentHistoryRepository : IRepository<ViewEmployeeDepartmentHistory>
    {
        private List<ViewEmployeeDepartmentHistory> db;

        public EmployeeDepartmentHistoryRepository(List<ViewEmployeeDepartmentHistory> Departments)
        {
            this.db = Departments;
        }

        public IEnumerable<ViewEmployeeDepartmentHistory> GetAll()
        {
            return db;
        }
    }
}
