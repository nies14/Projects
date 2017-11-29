using System;
using System.Collections.Generic;
using TutorSeekerData;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public class TutorAdvertiseService : ITutorAdvertiseService
    {
        private ITutorAdvertiseDataAccess data;

        public TutorAdvertiseService(ITutorAdvertiseDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<TutorAdvertise> GetAll(bool includeDepartment = false)
        {
            return this.data.GetAll(includeDepartment);
        }



        public int Insert(TutorAdvertise TutorAdvertise)
        {
            return this.data.Insert(TutorAdvertise);
        }

        public int Update(TutorAdvertise TutorAdvertise)
        {
            return this.data.Update(TutorAdvertise);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public bool ValidateCredentials(TutorAdvertise TutorAdvertise)
        {
            throw new NotImplementedException();
        }

        public TutorAdvertise Get(int id, bool includeDepartment = false)
        {
            throw new NotImplementedException();
        }
    }
}
