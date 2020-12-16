using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Repositories
{
    public class EmployeePayHistoryRepository : IRepository<ViewEmployeePayHistory>
    {
        private List<ViewEmployeePayHistory> db;

        public EmployeePayHistoryRepository(List<ViewEmployeePayHistory> Departments)
        {
            this.db = Departments;
        }

        public IEnumerable<ViewEmployeePayHistory> GetAll()
        {
            return db;
        }
    }
}
