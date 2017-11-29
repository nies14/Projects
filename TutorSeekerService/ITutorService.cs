using System.Collections.Generic;
using TutorSeekerEntity;

namespace TutorSeekerService
{
    public interface ITutorService
    {
        IEnumerable<Tutor> GetAll(bool includeDepartment = false);
        Tutor Get(int id, bool includeDepartment = false);
        IEnumerable<Tutor> Search(string searchWord, string searchType, bool includeDepartment = false);
        int Insert(Tutor tutor);
        int Update(Tutor tutor);
        int Delete(int id);
        bool ValidateCredentials(Tutor tutor);
        //Tutor Get(int? id);
        // Tutor Search(int? searchWord, string searchType, bool includeDepartment = false);
    }
}
