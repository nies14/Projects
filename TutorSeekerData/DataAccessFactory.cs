using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorTutorData;

namespace TutorSeekerData
{
    public abstract class DataAccessFactory
    {
        public static IAdminDataAccess GetAdminDataAccess()
        {
            return new AdminDataAccess(new TutorSeekerDbContext());
        }

        public static ITutorDataAccess GetTutorDataAccess()
        {
            return new TutorDataAccess(new TutorSeekerDbContext());
        }

        public static ISeekerDataAccess GetSeekerDataAccess()
        {
            return new SeekerDataAccess(new TutorSeekerDbContext());
        }

        public static ISeekerAdvertiseDataAccess GetSeekerAdvertiseDataAccess()
        {
            return new SeekerAdvertiseDataAccess(new TutorSeekerDbContext());
        }

        public static ITutorAdvertiseDataAccess GetTutorAdvertiseDataAccess()
        {
            return new TutorAdvertiseDataAccess(new TutorSeekerDbContext());
        }

        public static IRatingRecordDataAccess GetRatingRecordDataAccess()
        {
            return new RatingRecordDataAccess(new TutorSeekerDbContext());
        }
    }
}
