using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTO
{
    public class ViewJobCandidate
    {
        public ViewJobCandidate(JobCandidate job)
        {
            this.JobCandidateID = job.JobCandidateID;
            this.BusinessEntityID = job.BusinessEntityID;
            this.Resume = job.Resume;
            this.ModifiedDate = job.ModifiedDate;
        }
        public int JobCandidateID { get; set; }
        public string BusinessEntityID { get; set; }
        public string Resume { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
