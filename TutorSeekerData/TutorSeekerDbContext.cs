using System.Data.Entity;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public class TutorSeekerDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Seeker> Seekers { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<RatingRecord> RatingRecords { get; set; }
        public DbSet<CommentRecord> CommentRecords { get; set; }
        public DbSet<SeekerAdvertise> SeekerAdvertises { get; set; }
        public DbSet<TutorAdvertise> TutorAdvertises { get; set; }
    }
}
