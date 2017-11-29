using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorSeeker.Models
{
    public class TutorWithRating
    {
        public int TutorId { get; set; }
        public string TutorName { get; set; }
        public string TutorPassword { get; set; }
        public string TutorEmail { get; set; }
        public string TutorPhone { get; set; }
        public string TutorGender { get; set; }
        public string TutorInstitute { get; set; }
        public string TutorDepartment { get; set; }
        public string TutorLocation { get; set; }
        public string TutorPreferedClass { get; set; }
        public string TutorPreferedSubject { get; set; }
        public string TutorPhoto { get; set; }
        public double TutorRating { get; set; }
    }
}