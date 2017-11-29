using System.Collections.Generic;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    public interface ITutorDataAccess
    {
        IEnumerable<Tutor> GetAll(bool includeDepartment = false);
        Tutor Get(int id, bool includeDepartment = false);
        IEnumerable<Tutor> Search(string searchWord, string searchType, bool includeDepartment = false);
        int Insert(Tutor tutor);
        int Update(Tutor tutor);
        int Delete(int id);
    }
}
