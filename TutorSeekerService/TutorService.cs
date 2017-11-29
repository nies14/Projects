using System;
using System.Collections.Generic;
using TutorSeekerData;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    class TutorService : ITutorService
    {
        private ITutorDataAccess data;

        public TutorService(ITutorDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<Tutor> GetAll(bool includeDepartment = false)
        {
            return this.data.GetAll(includeDepartment);
        }

        public Tutor Get(int id, bool includeDepartment = false)
        {
            return this.data.Get(id, includeDepartment);
        }

        public IEnumerable<Tutor> Search(string searchWord, string searchType, bool includeDepartment = false)
        {
            return this.data.Search(searchWord, searchType, includeDepartment);
            //throw new NotImplementedException();
        }


        public int Insert(Tutor tutor)
        {
            return this.data.Insert(tutor);
        }

        public int Update(Tutor tutor)
        {
            return this.data.Update(tutor);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public bool ValidateCredentials(Tutor tutor)
        {
            throw new NotImplementedException();
        }




        public Tutor Get(int? id)
        {
            throw new NotImplementedException();
        }

        //public Tutor Search(int? searchWord, string searchType, bool includeDepartment = false)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
