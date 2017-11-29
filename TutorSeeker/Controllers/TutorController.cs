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
    public class TutorController : Controller
    {
        ITutorService service = ServiceFactory.GetTutorService();
        Random rand = new Random();
        static string tempImage = null;
        public const string Alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public ActionResult Login()
        {
            if (Session["Tutorid"] != null)
            {
                return RedirectToAction("Index", "Tutor");
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
                var query = from p in context.Tutors
                            where p.TutorEmail == email && p.TutorPassword == password
                            select p;

                // This will raise an exception if entity not found
                // Use SingleOrDefault instead
                var tutorID = query.SingleOrDefault();

                //Console.WriteLine(admin.AdminId);

                if (tutorID == null)
                {
                    ViewBag.errorMessage = "username or password does not match";
                }
                else
                {
                    Session["Tutorid"] = tutorID.TutorId;
                    Session["TutorName"] = tutorID.TutorName;
                    return RedirectToAction("Index", "Tutor", new { id = tutorID.TutorId });
                }
            }
            return View();
        }

        // GET: Employee
        public ActionResult Index()
        {
            if (Session["Tutorid"] != null)
            {

                Tutor tutor = ServiceFactory.GetTutorService().Get(Convert.ToInt32(Session["Tutorid"]));
                tutor.TutorRatingTotal = calculateRating(tutor.TutorName);
                return View(tutor);
            }

            else
                return RedirectToAction("Login");
        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Tutor tut, HttpPostedFileBase file)
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
                tut.TutorPhoto = pic;
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

                tut.TutorPhoto = "Tutor_image.jpg";
            }

            if (ServiceFactory.GetTutorService().Insert(tut) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(tut);
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
            if (Session["Tutorid"] != null)
            {
                Tutor tutor = ServiceFactory.GetTutorService().Get(id);
                tutor.TutorRatingTotal = calculateRating(tutor.TutorName);
                return View(tutor);
            }
            else
                return RedirectToAction("Login");

        }


        private double calculateRating(string name)
        {
            double rating = 0, res = 0;
            //if (Session["Seekerid"] != null)
            // {
            int cnt = 0;
            IRatingRecordService ser = ServiceFactory.GetRatingRecordService();
            IEnumerable<RatingRecord> sadlist = ser.GetAll(true); // true = including department

            List<RatingRecord> viewAddList = new List<RatingRecord>();

            foreach (RatingRecord sad in sadlist)
            {
                if (name == sad.TutorName)
                {
                    cnt++;
                    rating += sad.Rating;
                }

            }
            res = (double)rating / (double)cnt;
            Session["rating"] = res;

            //Response.Write(res);
            // }
            return res;
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Tutorid"] != null)
            {
                Tutor tutor = ServiceFactory.GetTutorService().Get(id);
                tempImage = tutor.TutorPhoto;
                return View(tutor);
            }

            else
                return RedirectToAction("Login");
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Tutor tutor, HttpPostedFileBase file)
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
                tutor.TutorPhoto = pic;
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
                tutor.TutorPhoto = tempImage;
            }

            int i = ServiceFactory.GetTutorService().Update(tutor);
            return RedirectToAction("Index");
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Tutorid"] != null)
            {
                Tutor tutor = ServiceFactory.GetTutorService().Get(id);
                return View(tutor);
            }
            else
                return RedirectToAction("Login");

        }
        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            if (ServiceFactory.GetTutorService().Delete(id) > 0)
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
            return RedirectToAction("Login", "Tutor");
            // return View();
        }

        public ActionResult ShowAdd()
        {
            if (Session["Tutorid"] != null)
            {
                ITutorAdvertiseService ser = ServiceFactory.GetTutorAdvertiseService();
                IEnumerable<TutorAdvertise> sadlist = ser.GetAll(true); // true = including department

                List<TutorAdvertise> viewAddList = new List<TutorAdvertise>();

                foreach (TutorAdvertise sad in sadlist)
                {
                    if (Session["TutorName"].ToString() == sad.TutorName)
                    {
                        TutorAdvertise advertise = new TutorAdvertise()
                        {
                            TutorAdvertiseId = sad.TutorAdvertiseId,
                            TutorName = sad.TutorName,
                            TutorArea = sad.TutorArea,
                            TutorSubject = sad.TutorSubject
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
            if (Session["Tutorid"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult PostAdd(TutorAdvertise seeker)
        {
            if (Session["Tutorid"] != null)
            {
                if (ServiceFactory.GetTutorAdvertiseService().Insert(seeker) > 0)
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
            if (Session["Tutorid"] != null)
            {
                //TutorAdvertise tutor = ServiceFactory.GetTutorAdvertiseService().Get(id);
                if (ServiceFactory.GetTutorAdvertiseService().Delete(id) > 0)
                {
                    return RedirectToAction("ShowAdd");
                }
                else
                    return RedirectToAction("ShowAdd");
            }

            else
                return RedirectToAction("Login");
        }
    }
}
