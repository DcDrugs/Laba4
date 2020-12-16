using System.Data;
using DAL.EF;
using BLL.DTO;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Repositories;

namespace BusinessLogic
{
    public class TablesManager
    {
        HumanResources _humanResources;

        public TablesManager(DataSet dataSet, string tableName)
        {
            _humanResources = new HumanResources();
            _humanResources.Load(dataSet, tableName);
        }

        public IRepository<ViewDepartment> GetDepartments()
        {
            var newDep = new List<ViewDepartment>();
            foreach (var dep in _humanResources.Departments)
                newDep.Add(new ViewDepartment(dep));
            return new DepartmentRepository(newDep);
        }

        public IRepository<ViewEmployee> GetEmployee()
        {
            var newDep = new List<ViewEmployee>();
            foreach (var dep in _humanResources.Employees)
                newDep.Add(new ViewEmployee(dep));
            return new EmployeeRepository(newDep);
        }

        public IRepository<ViewEmployeeDepartmentHistory> GetEmployeeDepartmentHistory()
        {
            var newDep = new List<ViewEmployeeDepartmentHistory>();
            foreach (var dep in _humanResources.EmployeeDepartmentHistoryes)
                newDep.Add(new ViewEmployeeDepartmentHistory(dep));
            return new EmployeeDepartmentHistoryRepository(newDep);
        }

        public IRepository<ViewEmployeePayHistory> GetEmployeePayHistory()
        {
            var newDep = new List<ViewEmployeePayHistory>();
            foreach (var dep in _humanResources.EmployeePayHistoryes)
                newDep.Add(new ViewEmployeePayHistory(dep));
            return new EmployeePayHistoryRepository(newDep);
        }
        public IRepository<ViewJobCandidate> GetJobCandidate()
        {
            var newDep = new List<ViewJobCandidate>();
            foreach (var dep in _humanResources.JobCandidates)
                newDep.Add(new ViewJobCandidate(dep));
            return new JobCandidateRepository(newDep);
        }

        public IRepository<ViewShift> GetShift()
        {
            var newDep = new List<ViewShift>();
            foreach (var dep in _humanResources.Shifts)
                newDep.Add(new ViewShift(dep));
            return new ShiftRepository(newDep);
        }
    }
}
