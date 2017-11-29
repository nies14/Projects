using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TutorSeekerData;
using TutorSeekerEntity;
using TutorSeekerService;

namespace TutorSeeker.Controllers
{
    public class SeekerController : Controller
    {
        ISeekerService service = ServiceFactory.GetSeekerService();
        Random rand = new Random();
        static string seeker_tempImage = null;
        public const string Alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public ActionResult Login()
        {
            if (Session["Seekerid"] != null)
            {
                return RedirectToAction("Index", "Seeker");
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
                var query = from p in context.Seekers
                            where p.SeekerEmail == email && p.SeekerPassword == password
                            select p;

                // This will raise an exception if entity not found
                // Use SingleOrDefault instead
                var seekerID = query.SingleOrDefault();

                //Console.WriteLine(admin.AdminId);

                if (seekerID == null)
                {
                    ViewBag.errorMessage = "username or password does not match";
                }
                else
                {
                    Session["Seekerid"] = seekerID.SeekerId;
                    Session["SeekerName"] = seekerID.SeekerName;
                    return RedirectToAction("Index", "Seeker", new { id = seekerID.SeekerId });
                }
            }
            return View();
        }
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["Seekerid"] != null)
            {
                Seeker seeker = ServiceFactory.GetSeekerService().Get(Convert.ToInt32(Session["Seekerid"]));

                return View(seeker);
            }

            else
                return RedirectToAction("Login");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Seeker seeker, HttpPostedFileBase file)
        {
            if (file != null)
            {

                string randNum = GenerateString(12);
                randNum = rand.Next(0, 1000000).ToString("D6") + randNum;
                ///////////////////////////
                string pic = System.IO.Path.GetFileName(file.FileName);
                string picExtension = System.IO.Path.GetExtension(file.ContentType);
                pic = randNum + "-" + pic;
                string path = System.IO.Path.Combine(Server.MapPath("~/Upload/"), pic);
                // file is uploaded
                file.SaveAs(path);
                seeker.SeekerPhoto = pic;
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB

                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            else
            {

                seeker.SeekerPhoto = "Seeker_image.jpg";
            }



            if (ServiceFactory.GetSeekerService().Insert(seeker) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(seeker);
            }
        }


        //generate random nuber and leter
        public string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }


        public ActionResult Details(int id)
        {
            if (Session["Seekerid"] != null)
            {
                Seeker seeker = ServiceFactory.GetSeekerService().Get(id);
                return View(seeker);
            }

            else
                return RedirectToAction("Login");
        }

        // GET: Seeker/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Seekerid"] != null)
            {
                Seeker seeker = ServiceFactory.GetSeekerService().Get(id);
                seeker_tempImage = seeker.SeekerPhoto;
                return View(seeker);
            }

            else
                return RedirectToAction("Login");
        }

        // POST: Seeker/Edit/5
        [HttpPost]
        public ActionResult Edit(Seeker seeker, HttpPostedFileBase file)
        {
            if (file != null)
            {

                string randNum = GenerateString(12);
                randNum = rand.Next(0, 1000000).ToString("D6") + randNum;
                ///////////////////////////
                string pic = System.IO.Path.GetFileName(file.FileName);
                string picExtension = System.IO.Path.GetExtension(file.ContentType);
                pic = randNum + "-" + pic;
                string path = System.IO.Path.Combine(Server.MapPath("~/Upload/"), pic);
                // file is uploaded
                file.SaveAs(path);
                seeker.SeekerPhoto = pic;
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB

                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            else
            {
                seeker.SeekerPhoto = seeker_tempImage;
            }
            int i = ServiceFactory.GetSeekerService().Update(seeker);
            return RedirectToAction("Index");
        }

        // GET: Seeker/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Seekerid"] != null)
            {
                Seeker seeker = ServiceFactory.GetSeekerService().Get(id);
                return View(seeker);
            }

            else
                return RedirectToAction("Login");
        }
        // POST: Seeker/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            if (ServiceFactory.GetSeekerService().Delete(id) > 0)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }
        public ActionResult TutorList()
        {
            if (Session["Seekerid"] != null)
            {
                ITutorService ser = ServiceFactory.GetTutorService();
                return View(ser.GetAll());
            }

            else
                return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Seeker");
            // return View();
        }


        public ActionResult ShowAdd()
        {
            if (Session["Seekerid"] != null)
            {
                ISeekerAdvertiseService ser = ServiceFactory.GetSeekerAdvertiseService();
                IEnumerable<SeekerAdvertise> sadlist = ser.GetAll(true); // true = including department

                List<SeekerAdvertise> viewAddList = new List<SeekerAdvertise>();

                foreach (SeekerAdvertise sad in sadlist)
                {
                    if (Session["SeekerName"].ToString() == sad.SeekerName)
                    {
                        SeekerAdvertise advertise = new SeekerAdvertise()
                        {
                            SeekerAdvertiseId = sad.SeekerAdvertiseId,
                            SeekerName = sad.SeekerName,
                            SeekerArea = sad.SeekerArea,
                            SeekerSubject = sad.SeekerSubject
                        };
                        viewAddList.Add(advertise);
                    }

                }

                return View(viewAddList);
            }
            else
                return RedirectToAction("Login");
        }
        public ActionResult PostAdd()
        {
            if (Session["Seekerid"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult PostAdd(SeekerAdvertise seeker)
        {
            if (Session["Seekerid"] != null)
            {
                if (ServiceFactory.GetSeekerAdvertiseService().Insert(seeker) > 0)
                {
                    return RedirectToAction("ShowAdd");
                }

                else
                {
                    return View(seeker);
                }
            }
            else
                return RedirectToAction("Login");

        }

        public ActionResult DeleteAdvertise(int id)
        {
            if (Session["Seekerid"] != null)
            {
                //SeekerAdvertise seeker = ServiceFactory.GetSeekerAdvertiseService().Get(id);
                if (ServiceFactory.GetSeekerAdvertiseService().Delete(id) > 0)
                {
                    return RedirectToAction("ShowAdd");
                }
                else
                    return RedirectToAction("ShowAdd");
            }

            else
                return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Rating(int TutorID, int value)
        {
            if (Session["Seekerid"] != null)
            {
                Tutor tutor = ServiceFactory.GetTutorService().Get(TutorID);
                ViewBag.TutorName = tutor.TutorName;
                ViewBag.RatingValue = value;
                return View();
            }

            else
                return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Rating(RatingRecord seeker, FormCollection collection)
        {
            string tutor_name = collection["TutorName"];
            string seeker_Name = collection["SeekerName"];
            string ratingValue = collection["RatingValue"];
            if (Session["Seekerid"] != null)
            {
                seeker.TutorName = tutor_name;
                seeker.SeekerName = seeker_Name;
                seeker.Rating = Convert.ToInt32(ratingValue);

                if (ServiceFactory.GetRatingRecordService().Insert(seeker) > 0)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return View(seeker);
                }
            }
            else
                return RedirectToAction("Login");
        }
    }
}
