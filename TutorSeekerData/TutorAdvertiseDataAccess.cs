using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerData;
using TutorSeekerEntity;

namespace TutorTutorData
{
    class TutorAdvertiseDataAccess:ITutorAdvertiseDataAccess
    {
        private TutorSeekerDbContext context;

        public TutorAdvertiseDataAccess(TutorSeekerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TutorAdvertise> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.TutorAdvertises.ToList();
            }
            else
            {
                return this.context.TutorAdvertises.ToList();
            }
        }

        public TutorAdvertise Get(int id, bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.TutorAdvertises.Include("TutorAdvertise").SingleOrDefault(x => x.TutorAdvertiseId == id);
            }
            else
            {
                return this.context.TutorAdvertises.SingleOrDefault(x => x.TutorAdvertiseId == id);
            }
        }

        public int Insert(TutorAdvertise TutorAdvertise)
        {
            this.context.TutorAdvertises.Add(TutorAdvertise);

            return this.context.SaveChanges();
        }

        public int Update(TutorAdvertise TutorAdvertise)
        {
            TutorAdvertise sadd = this.context.TutorAdvertises.SingleOrDefault(x => x.TutorAdvertiseId == TutorAdvertise.TutorAdvertiseId);
            sadd.TutorName = TutorAdvertise.TutorName;
            sadd.TutorSubject = TutorAdvertise.TutorSubject;
            sadd.TutorArea = TutorAdvertise.TutorArea;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            TutorAdvertise adm = this.context.TutorAdvertises.SingleOrDefault(x => x.TutorAdvertiseId == id);
            this.context.TutorAdvertises.Remove(adm);

            return this.context.SaveChanges();
        }
    }
}
