using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public interface ISeekerAdvertiseService
    {
        IEnumerable<SeekerAdvertise> GetAll(bool includeDepartment = false);
        SeekerAdvertise Get(int id, bool includeDepartment = false);
        int Insert(SeekerAdvertise SeekerAdvertise);
        int Update(SeekerAdvertise SeekerAdvertise);
        int Delete(int id);
        bool ValidateCredentials(SeekerAdvertise SeekerAdvertise);
    }
}
