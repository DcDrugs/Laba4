using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Repositories
{
    public class ShiftRepository : IRepository<ViewShift>
    {
        private List<ViewShift> db;

        public ShiftRepository(List<ViewShift> Departments)
        {
            this.db = Departments;
        }

        public IEnumerable<ViewShift> GetAll()
        {
            return db;
        }
    }
}
