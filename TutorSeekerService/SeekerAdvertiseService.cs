using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerData;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    class SeekerAdvertiseService:ISeekerAdvertiseService
    {
        private ISeekerAdvertiseDataAccess data;

        public SeekerAdvertiseService(ISeekerAdvertiseDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<SeekerAdvertise> GetAll(bool includeDepartment = false)
        {
            return this.data.GetAll(includeDepartment);
        }

        public SeekerAdvertise Get(int id, bool includeDepartment = false)
        {
            return this.data.Get(id, includeDepartment);
        }

        public int Insert(SeekerAdvertise SeekerAdvertise)
        {
            return this.data.Insert(SeekerAdvertise);
        }

        public int Update(SeekerAdvertise SeekerAdvertise)
        {
            return this.data.Update(SeekerAdvertise);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public bool ValidateCredentials(SeekerAdvertise SeekerAdvertise)
        {
            throw new NotImplementedException();
        }
    }
}
