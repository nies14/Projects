using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    class AdminDataAccess:IAdminDataAccess
    {
        private TutorSeekerDbContext context;

        public AdminDataAccess(TutorSeekerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Admin> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.Admins.Include("Admin").ToList();
            }
            else
            {
                return this.context.Admins.ToList();
            }
        }

        public Admin Get(int id, bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.Admins.Include("Admin").SingleOrDefault(x => x.AdminId == id);
            }
            else
            {
                return this.context.Admins.SingleOrDefault(x => x.AdminId == id);
            }
        }

        public int Insert(Admin admin)
        {
            this.context.Admins.Add(admin);

            return this.context.SaveChanges();
        }

        public int Update(Admin admin)
        {
            Admin adm = this.context.Admins.SingleOrDefault(x => x.AdminId == admin.AdminId);
            adm.AdminName = admin.AdminName;
            adm.AdminEmail = admin.AdminEmail;
            adm.AdminPassword = admin.AdminPassword;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Admin adm = this.context.Admins.SingleOrDefault(x => x.AdminId == id);
            this.context.Admins.Remove(adm);

            return this.context.SaveChanges();
        }
    }
}
