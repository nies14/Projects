using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorSeekerEntity
{
    public class SeekerAdvertise
    {
        public int SeekerAdvertiseId { get; set; }
        [Required]
        public string SeekerName { get; set; }
        [Required]
        public string SeekerSubject { get; set; }
        [Required]
        public string SeekerArea { get; set; }
    }
}
