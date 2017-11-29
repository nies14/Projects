using System.ComponentModel.DataAnnotations;

namespace TutorSeekerEntity
{
    public class Seeker
    {
        public int SeekerId { get; set; }
        [Required]
        [StringLength(160, MinimumLength = 3)]
        public string SeekerName { get; set; }
        [Required]
        public string SeekerPassword { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}")]
        public string SeekerEmail { get; set; }
        [Required]
        public string SeekerPhoto { get; set; }
    }
}
