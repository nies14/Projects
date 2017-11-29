using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerData;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public class RatingRecordService:IRatingRecordService
    {
        private IRatingRecordDataAccess data;

        public RatingRecordService(IRatingRecordDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<RatingRecord> GetAll(bool includeDepartment = false)
        {
            return this.data.GetAll(includeDepartment);
        }

        public RatingRecord Get(int id, bool includeDepartment = false)
        {
            return this.data.Get(id, includeDepartment);
        }

        public int Insert(RatingRecord RatingRecord)
        {
            return this.data.Insert(RatingRecord);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
    }
}
