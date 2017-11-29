using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TutorSeekerData;
using TutorSeekerEntity;
using TutorSeekerService;

namespace TutorSeeker.Controllers
{
    public class AdminController : Controller
    {
        IAdminService service = ServiceFactory.GetAdminService();
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Adminid"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            //  string var1 = collection["var1"];
            string email = collection["email"];
            string password = collection["password"];

            using (var context = new TutorSeekerDbContext())
            {
                var query = from p in context.Admins
                            where p.AdminEmail == email && p.AdminPassword == password
                            select p;

                // This will raise an exception if entity not found
                // Use SingleOrDefault instead
                var adminID = query.SingleOrDefault();

                //Console.WriteLine(admin.AdminId);

                if (adminID == null)
                {
                    ViewBag.errorMessage = "username or password does not match";
                }
                else {
                    Session["Adminid"] = adminID.AdminId;
                    Session["AdminName"] = adminID.AdminName;
                    return RedirectToAction("Index", "admin", new { id = adminID.AdminId });
                }
            }
            return View();
        }


        public ActionResult Index()
        {
            if (Session["Adminid"] != null)
                return View(service.GetAll());
            else
                return RedirectToAction("Login");

        }


        //[HttpGet]
        //public ActionResult Dashboard()
        //{

        //    int id = Convert.ToInt32(Session["id"]);


        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    TutorSeekerDbContext db = new TutorSeekerDbContext();
        //    Admin admin = db.Admins.Find(id);
        //    if (admin == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(admin);

        //}

        public ActionResult Create()
        {
            if (Session["Adminid"] != null)
                return View();
            else
                return RedirectToAction("Login");

        }

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ServiceFactory.GetAdminService().Insert(admin) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(admin);
            }
        }

        public ActionResult Details(int id)
        {
            if (Session["Adminid"] != null)
            {
                Admin admin = ServiceFactory.GetAdminService().Get(id);
                return View(admin);
            }
            else
                return RedirectToAction("Login");

        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Adminid"] != null)
            {
                Admin admin = ServiceFactory.GetAdminService().Get(id);
                return View(admin);
            }
            else
                return RedirectToAction("Login");
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            int i = ServiceFactory.GetAdminService().Update(admin);
            return RedirectToAction("Index");
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Adminid"] != null)
            {
                Admin admin = ServiceFactory.GetAdminService().Get(id);
                return View(admin);
            }
            else
                return RedirectToAction("Login");
        }
        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            if (ServiceFactory.GetAdminService().Delete(id) > 0)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Admin");
            // return View();
        }
        public ActionResult TutorList()
        {
            if (Session["Adminid"] != null)
            {
                ITutorService ser = ServiceFactory.GetTutorService();
                return View(ser.GetAll());
            }

            else
                return RedirectToAction("Login");
        }

        public ActionResult SeekerList()
        {
            if (Session["Adminid"] != null)
            {
                ISeekerService ser = ServiceFactory.GetSeekerService();
                return View(ser.GetAll());
            }
            else
                return RedirectToAction("Login");
        }

        public ActionResult TutorAdvertise()
        {
            if (Session["Adminid"] != null)
            {
                ITutorAdvertiseService ser = ServiceFactory.GetTutorAdvertiseService();
                return View(ser.GetAll());
            }
            else
                return RedirectToAction("Login");
        }

        public ActionResult SeekerAdvertise()
        {
            if (Session["Adminid"] != null)
            {
                ISeekerAdvertiseService ser = ServiceFactory.GetSeekerAdvertiseService();
                return View(ser.GetAll());
            }
            else
                return RedirectToAction("Login");
        }
    }
}