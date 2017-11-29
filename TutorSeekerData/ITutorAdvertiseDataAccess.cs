using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public interface ITutorAdvertiseDataAccess
    {
        IEnumerable<TutorAdvertise> GetAll(bool includeDepartment = false);
        TutorAdvertise Get(int id, bool includeDepartment = false);
        int Insert(TutorAdvertise tutorAdd);
        int Update(TutorAdvertise tutorAdd);
        int Delete(int id);
    }
}
