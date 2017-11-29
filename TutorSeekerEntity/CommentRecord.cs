using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSeekerEntity
{
    public class CommentRecord
    {
        public int CommentRecordId { get; set; }
        public int SeekerId { get; set; }
        public int TutorId { get; set; }
        public string Comment { get; set; }
        [ForeignKey("SeekerId")]
        public Seeker Seeker { get; set; }
        [ForeignKey("TutorId")]
        public Tutor Tutor { get; set; }
    }
}
