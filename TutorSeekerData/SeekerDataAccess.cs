using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    class SeekerDataAccess:ISeekerDataAccess
    {
        private TutorSeekerDbContext context;

        public SeekerDataAccess(TutorSeekerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Seeker> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.Seekers.Include("Seeker").ToList();
            }
            else
            {
                return this.context.Seekers.ToList();
            }
        }

        public Seeker Get(int id, bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.Seekers.Include("Seeker").SingleOrDefault(x => x.SeekerId == id);
            }
            else
            {
                return this.context.Seekers.SingleOrDefault(x => x.SeekerId == id);
            }
        }

        public int Insert(Seeker Seeker)
        {
            this.context.Seekers.Add(Seeker);

            return this.context.SaveChanges();
        }

        public int Update(Seeker seeker)
        {
            Seeker adm = this.context.Seekers.SingleOrDefault(x => x.SeekerId == seeker.SeekerId);
            adm.SeekerName = seeker.SeekerName;
            adm.SeekerEmail = seeker.SeekerEmail;
            adm.SeekerPassword = seeker.SeekerPassword;
            adm.SeekerPhoto = seeker.SeekerPhoto;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Seeker adm = this.context.Seekers.SingleOrDefault(x => x.SeekerId == id);
            this.context.Seekers.Remove(adm);
            return this.context.SaveChanges();
        }
    }
}
