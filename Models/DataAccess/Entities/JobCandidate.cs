using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class JobCandidate
    {
        public int JobCandidateID { get; set; }
        public string BusinessEntityID { get; set; }
        public string Resume { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
