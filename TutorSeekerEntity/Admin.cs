using System.ComponentModel.DataAnnotations;

namespace TutorSeekerEntity
{
    public class Admin
    {
        public string AdminName { get; set; }
        public int AdminId { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}")]
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
    }
}
