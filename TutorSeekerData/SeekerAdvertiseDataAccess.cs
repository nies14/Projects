using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    class SeekerAdvertiseDataAccess:ISeekerAdvertiseDataAccess
    {
        private TutorSeekerDbContext context;

        public SeekerAdvertiseDataAccess(TutorSeekerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SeekerAdvertise> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.SeekerAdvertises.ToList();
            }
            else
            {
                return this.context.SeekerAdvertises.ToList();
            }
        }

        public SeekerAdvertise Get(int id, bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.SeekerAdvertises.Include("SeekerAdvertise").SingleOrDefault(x => x.SeekerAdvertiseId == id);
            }
            else
            {
                return this.context.SeekerAdvertises.SingleOrDefault(x => x.SeekerAdvertiseId == id);
            }
        }

        public int Insert(SeekerAdvertise SeekerAdvertise)
        {
            this.context.SeekerAdvertises.Add(SeekerAdvertise);

            return this.context.SaveChanges();
        }

        public int Update(SeekerAdvertise SeekerAdvertise)
        {
            SeekerAdvertise sadd = this.context.SeekerAdvertises.SingleOrDefault(x => x.SeekerAdvertiseId == SeekerAdvertise.SeekerAdvertiseId);
            sadd.SeekerName = SeekerAdvertise.SeekerName;
            sadd.SeekerSubject = SeekerAdvertise.SeekerSubject;
            sadd.SeekerArea = SeekerAdvertise.SeekerArea;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            SeekerAdvertise adm = this.context.SeekerAdvertises.SingleOrDefault(x => x.SeekerAdvertiseId == id);
            this.context.SeekerAdvertises.Remove(adm);

            return this.context.SaveChanges();
        }
    }
}
