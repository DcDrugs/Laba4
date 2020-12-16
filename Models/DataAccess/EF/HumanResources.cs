using System.Collections.Generic;
using System.Data;
using DAL.Entities;
using System.Linq;
using System;

namespace DAL.EF
{
    public class HumanResources
    {
        public List<Department> Departments { private set; get; }
        public List<Employee> Employees { private set; get; }
        public List<EmployeeDepartmentHistory> EmployeeDepartmentHistoryes { private set; get; }
        public List<EmployeePayHistory> EmployeePayHistoryes { private set; get; }
        public List<JobCandidate> JobCandidates { private set; get; }
        public List<Shift> Shifts { private set; get; }

        public void Load(DataSet data, string tableName)
        {
            switch(tableName)
            {
                case "HumanResources.Department":
                    Departments = GetDepartmentList(data.Tables[0]);
                    break;
                case "HumanResources.Employee":
                    Employees = GetEmployeeList(data.Tables[0]);
                    break;
                case "HumanResources.EmployeeDepartmentHistory":
                    EmployeeDepartmentHistoryes = GetEmployeeDepartmentHistoryList(data.Tables[0]);
                    break;
                case "HumanResources.EmployeePayHistory":
                    EmployeePayHistoryes = GetEmployeePayHistoryList(data.Tables[0]);
                    break;
                case "HumanResources.JobCandidate":
                    JobCandidates = GetJobCandidateList(data.Tables[0]);
                    break;
                case "HumanResources.Shift":
                    Shifts = GetShiftList(data.Tables[0]);
                    break;
                default:
                    throw new Exception("Unknown Table");

            }
        }
        private List<Department> GetDepartmentList(DataTable dt)
        {
            var dep = new List<Department>();

            dep = (from DataRow dr in dt.Rows
                           select new Department()
                           {
                               Id = Convert.ToInt32(dr["DepartmentID"]),
                               Name = dr["Name"].ToString(),
                               GroupName = dr["GroupName"].ToString(),
                               ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                           }).ToList();

            return dep;
        }


     
        private List<Employee> GetEmployeeList(DataTable dt)
        {
            var dep = new List<Employee>();

            dep = (from DataRow dr in dt.Rows
                   select new Employee()
                   {
                            Id = Convert.ToInt32(dr["BusinessEntityID"]),
                            NationalIIDNumber = dr["NationalIDNumber"].ToString(),
                            LoginID = dr["LoginID"].ToString(),
                            OrganizationNode = dr["OrganizationNode"].ToString(),
                            OrganizationLevel = dr["OrganizationLevel"].ToString(),
                            JobTitle = dr["JobTitle"].ToString(),
                            BirthDate = Convert.ToDateTime(dr["BirthDate"]),
                            MaritalStatus = dr["MaritalStatus"].ToString(),
                            Gender = dr["Gender"].ToString(),
                            HireDate = Convert.ToDateTime(dr["HireDate"]),
                            SalariedFlag = Convert.ToInt32(dr["SalariedFlag"]),
                            VacationHours = Convert.ToInt32(dr["VacationHours"]),
                            SickLeaveHours = Convert.ToInt32(dr["SickLeaveHours"]),
                            CurrentFlag =  Convert.ToInt32(dr["CurrentFlag"]),
                            rowguid = dr["rowguid"].ToString(),
                            ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                   }).ToList();

            return dep;
        }
        
        private List<EmployeeDepartmentHistory> GetEmployeeDepartmentHistoryList(DataTable dt)
        {
            var dep = new List<EmployeeDepartmentHistory>();

            dep = (from DataRow dr in dt.Rows
                   select new EmployeeDepartmentHistory()
                   {
                       BusinessEntityID = Convert.ToInt32(dr["BusinessEntityID"]),
                       DepartmentID = Convert.ToInt32(dr["DepartmentID"]),
                       ShiftID = Convert.ToInt32(dr["ShiftID"]),
                       StartDate = Convert.ToDateTime(dr["StartDate"]),
                       EndDate = dr["EndDate"].ToString(),
                       ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                   }).ToList();

            return dep;
        }

        private List<EmployeePayHistory> GetEmployeePayHistoryList(DataTable dt)
        {
            var dep = new List<EmployeePayHistory>();

            dep = (from DataRow dr in dt.Rows
                   select new EmployeePayHistory()
                   {
                       BusinessEntityID = Convert.ToInt32(dr["BusinessEntityID"]),
                       RateChangeDate = Convert.ToDateTime(dr["RateChangeDate"]),
                       Rate = dr["Rate"].ToString(),
                       PayFrequency = Convert.ToInt32(dr["PayFrequency"]),
                       ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                   }).ToList();

            return dep;
        }

        private List<JobCandidate> GetJobCandidateList(DataTable dt)
        {
            var dep = new List<JobCandidate>();

            dep = (from DataRow dr in dt.Rows
                   select new JobCandidate()
                   {
                       JobCandidateID = Convert.ToInt32(dr["JobCandidateID"]),
                       BusinessEntityID = dr["BusinessEntityID"].ToString(),
                       Resume = dr["Resume"].ToString(),
                       ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                   }).ToList();

            return dep;
        }

        private List<Shift> GetShiftList(DataTable dt)
        {
            var dep = new List<Shift>();

            dep = (from DataRow dr in dt.Rows
                   select new Shift()
                   {
                       ShiftID = Convert.ToInt32(dr["ShiftID"]),
                       Name = dr["Name"].ToString(),
                       StartTime = dr["StartTime"].ToString(),
                       EndTime = dr["EndTime"].ToString(),
                       ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                   }).ToList();

            return dep;
        }
    }
}
