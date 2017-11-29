using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TutorSeekerData;
using TutorSeekerEntity;
using TutorSeekerService;

namespace TutorSeeker.Controllers
{
    public class HomeController : Controller
    {
        private ITutorService service = ServiceFactory.GetTutorService();
        private TutorSeekerDbContext db = new TutorSeekerDbContext();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //Session["id"] = 1;
            return View(service.GetAll());
        }

        // post: Home
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string searchWord = collection["SearchBox"];
            //int searchWord = 10;
            string searchType = collection["Searchtype"];

            if (searchWord == "")
            {
                return View(service.GetAll());
            }
            else
            {
                ITutorService ser = ServiceFactory.GetTutorService();
                IEnumerable<Tutor> sadlist = ser.Search(searchWord, searchType); // true = including department

                List<Tutor> viewAddList = new List<Tutor>();

                foreach (Tutor sad in sadlist)
                {
                    string tutorName = sad.TutorName;
                    int id = sad.TutorId;
                    double d = calculateRating(tutorName);

                    Tutor advertise = new Tutor()
                    {
                        TutorId = sad.TutorId,
                        TutorName = sad.TutorName,
                        TutorEmail = sad.TutorEmail,
                        TutorInstitute = sad.TutorInstitute,
                        TutorLocation = sad.TutorLocation,
                        TutorDepartment = sad.TutorDepartment,
                        TutorPhone = sad.TutorPhone,
                        TutorPhoto = sad.TutorPhoto,
                        TutorPreferedClass = sad.TutorPreferedClass,
                        TutorPreferedSubject = sad.TutorPreferedSubject,
                        TutorGender = sad.TutorGender,
                        TutorPassword = sad.TutorPassword,
                        //TutorRatingTotal = sad.TutorRatingTotal,
                        TutorRatingTotal = d
                    };

                    viewAddList.Add(advertise);
                }

                return View(viewAddList);
            }
        }

        // GET: Tutor/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            Tutor tutor = ServiceFactory.GetTutorService().Get(id);

            tutor.TutorRatingTotal = calculateRating(tutor.TutorName);

            // int i = ServiceFactory.GetTutorService().Update(tutor);
            return View(tutor);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            int val1 = System.Convert.ToInt32(form["RatingBox"]);
            int val2 = System.Convert.ToInt32(form["RatingValue"]);
            return RedirectToAction("Rating", "Seeker", new { TutorID = val1, value = val2 });
        }

        // rating count
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

        // GET: Tutor/Details/5
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            string name = collection["name"];
            string email = collection["email"];
            string phone = collection["phone"];
            string message = collection["message"];
            SendMail(name, email, phone, message);
            return View();
        }

        protected void SendMail(string name, string email, string phone, string message)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "codebusket@gmail.com";
            // any address where the email will be sending
            var toAddress = "codebusket@gmail.com";
            //Password of your gmail address
            const string fromPassword = "ilovecodebusket";
            // Passing the values and make a email formate to display
            string subject = "Question From TutorSeeker.com";
            string body = "From: " + name + "\n";
            body += "Email: " + email + "\n";
            body += "Phone: " + phone + "\n";
            body += "Question: \n" + message + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }
    }
}