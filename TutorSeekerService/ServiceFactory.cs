using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerData;
using TutorSeekerService;

namespace TutorSeekerService
{
    public abstract class ServiceFactory
    {
        public static IAdminService GetAdminService()
        {
            return new AdminService(DataAccessFactory.GetAdminDataAccess());
        }

        public static ITutorService GetTutorService()
        {
            return new TutorService(DataAccessFactory.GetTutorDataAccess());
        }

        public static ISeekerService GetSeekerService()
        {
            return new SeekerService(DataAccessFactory.GetSeekerDataAccess());
        }

        public static ISeekerAdvertiseService GetSeekerAdvertiseService()
        {
            return new SeekerAdvertiseService(DataAccessFactory.GetSeekerAdvertiseDataAccess());
        }

        public static ITutorAdvertiseService GetTutorAdvertiseService()
        {
            return new TutorAdvertiseService(DataAccessFactory.GetTutorAdvertiseDataAccess());
        }

        public static IRatingRecordService GetRatingRecordService()
        {
            return new RatingRecordService(DataAccessFactory.GetRatingRecordDataAccess());
        }

    }
}
