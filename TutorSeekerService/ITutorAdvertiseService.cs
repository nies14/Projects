using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public interface ITutorAdvertiseService
    {
        IEnumerable<TutorAdvertise> GetAll(bool includeDepartment = false);
        TutorAdvertise Get(int id, bool includeDepartment = false);
        int Insert(TutorAdvertise TutorAdvertise);
        int Update(TutorAdvertise TutorAdvertise);
        int Delete(int id);
        bool ValidateCredentials(TutorAdvertise TutorAdvertise);
    }
}
