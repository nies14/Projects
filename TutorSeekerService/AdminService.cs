using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;
using TutorSeekerData;

namespace TutorSeekerService
{
    class AdminService : IAdminService
    {
        private IAdminDataAccess data;

        public AdminService(IAdminDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<Admin> GetAll(bool includeDepartment = false)
        {
            return this.data.GetAll(includeDepartment);
        }

        public Admin Get(int id, bool includeDepartment = false)
        {
            return this.data.Get(id, includeDepartment);
        }

        public int Insert(Admin admin)
        {
            return this.data.Insert(admin);
        }

        public int Update(Admin admin)
        {
            return this.data.Update(admin);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
       
        public bool ValidateCredentials(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
