using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public interface IAdminDataAccess
    {
        IEnumerable<Admin> GetAll(bool includeDepartment = false);
        Admin Get(int id, bool includeDepartment = false);
        int Insert(Admin admin);
        int Update(Admin admin);
        int Delete(int id);
    }
}
