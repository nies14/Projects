using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public interface IRatingRecordDataAccess
    {
        IEnumerable<RatingRecord> GetAll(bool includeDepartment = false);
        RatingRecord Get(int id, bool includeDepartment = false);
        int Insert(RatingRecord ratingRecord);
        //int Update(RatingRecord ratingRecord);
        int Delete(int id);
    }
}
