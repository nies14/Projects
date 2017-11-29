using System.ComponentModel.DataAnnotations;

namespace TutorSeekerEntity
{
    public class Tutor
    {
        public int TutorId { get; set; }
        [Required]
        [StringLength(160, MinimumLength = 3)]
        public string TutorName { get; set; }
        [Required]
        public string TutorPassword { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}")]
        public string TutorEmail { get; set; }
        [Required]
        public string TutorPhone { get; set; }
        [Required]
        public string TutorGender { get; set; }
        [Required]
        public string TutorInstitute { get; set; }
        [Required]
        public string TutorDepartment { get; set; }
        [Required]
        public string TutorLocation { get; set; }
        [Required]
        public string TutorPreferedClass { get; set; }
        [Required]
        public string TutorPreferedSubject { get; set; }
        [Required]
        public string TutorPhoto { get; set; }
        public double TutorRatingTotal { get; set; }
    }
}
