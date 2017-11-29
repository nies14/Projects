using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerData;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    class SeekerService:ISeekerService
    {
        private ISeekerDataAccess data;

        public SeekerService(ISeekerDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<Seeker> GetAll(bool includeDepartment = false)
        {
            return this.data.GetAll(includeDepartment);
        }

        public Seeker Get(int id, bool includeDepartment = false)
        {
            return this.data.Get(id, includeDepartment);
        }

        public int Insert(Seeker Seeker)
        {
            return this.data.Insert(Seeker);
        }

        public int Update(Seeker Seeker)
        {
            return this.data.Update(Seeker);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public bool ValidateCredentials(Seeker Seeker)
        {
            throw new NotImplementedException();
        }
    }
}
