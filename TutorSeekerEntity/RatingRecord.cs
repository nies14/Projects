using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorSeekerEntity
{
    public class RatingRecord
    {
        public int RatingRecordId { get; set; }
        public string TutorName { get; set; }
        public string SeekerName { get; set; }

        public int Rating { get; set; }
    }
}
