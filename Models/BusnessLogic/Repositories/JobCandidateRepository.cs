using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Repositories
{
    public class JobCandidateRepository : IRepository<ViewJobCandidate>
    {
        private List<ViewJobCandidate> db;

        public JobCandidateRepository(List<ViewJobCandidate> Departments)
        {
            this.db = Departments;
        }

        public IEnumerable<ViewJobCandidate> GetAll()
        {
            return db;
        }
    }
}
