using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public class RatingRecordDataAccess:IRatingRecordDataAccess
    {
        private TutorSeekerDbContext context;

        public RatingRecordDataAccess(TutorSeekerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RatingRecord> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.RatingRecords.ToList();
            }
            else
            {
                return this.context.RatingRecords.ToList();
            }
        }

        public RatingRecord Get(int id, bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.RatingRecords.Include("RatingRecord").SingleOrDefault(x => x.RatingRecordId == id);
            }
            else
            {
                return this.context.RatingRecords.SingleOrDefault(x => x.RatingRecordId == id);
            }
        }

        public int Insert(RatingRecord RatingRecord)
        {
            this.context.RatingRecords.Add(RatingRecord);

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            RatingRecord adm = this.context.RatingRecords.SingleOrDefault(x => x.RatingRecordId == id);
            this.context.RatingRecords.Remove(adm);

            return this.context.SaveChanges();
        }
    }
}
