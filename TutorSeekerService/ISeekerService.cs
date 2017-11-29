using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public interface ISeekerService
    {
        IEnumerable<Seeker> GetAll(bool includeDepartment = false);
        Seeker Get(int id, bool includeDepartment = false);
        int Insert(Seeker seeker);
        int Update(Seeker seeker);
        int Delete(int id);
        bool ValidateCredentials(Seeker seeker);
    }
}
