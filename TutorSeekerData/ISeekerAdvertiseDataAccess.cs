using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public interface ISeekerAdvertiseDataAccess
    {
        IEnumerable<SeekerAdvertise> GetAll(bool includeDepartment = false);
        SeekerAdvertise Get(int id, bool includeDepartment = false);
        int Insert(SeekerAdvertise seekerAdd);
        int Update(SeekerAdvertise seekerAdd);
        int Delete(int id);
    }
}
