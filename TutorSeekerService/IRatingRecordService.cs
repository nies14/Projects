using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public interface IRatingRecordService
    {
        IEnumerable<RatingRecord> GetAll(bool includeDepartment = false);
        RatingRecord Get(int id, bool includeDepartment = false);
        int Insert(RatingRecord RatingRecord);
        int Delete(int id);
    }
}
