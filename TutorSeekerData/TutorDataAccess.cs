using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using TutorSeekerEntity;

namespace TutorSeekerData
{
    internal class TutorDataAccess : ITutorDataAccess
    {
        private TutorSeekerDbContext context;

        public TutorDataAccess(TutorSeekerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tutor> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.Tutors.ToList();
            }
            else
            {
                return this.context.Tutors.ToList();
            }
        }

        //get data by category-wise
        public IEnumerable<Tutor> Search(string searchWord, string searchType, bool includeDepartment = false)
        {
            if (searchType == "Search By Location")
            {
                if (includeDepartment)
                {
                    return this.context.Tutors.Include("Tutor").Where(x => x.TutorLocation.ToUpper() == searchWord.ToUpper()).ToList();
                }
                else
                {
                    return this.context.Tutors.Where(x => x.TutorLocation.ToUpper() == searchWord.ToUpper()).ToList();
                }
            }
            else if (searchType == "Search By Subject")
            {
                if (includeDepartment)
                {
                    return this.context.Tutors.Include("Tutor").Where(x => x.TutorPreferedSubject.ToUpper() == searchWord.ToUpper()).ToList();
                }
                else
                {
                    return this.context.Tutors.Where(x => x.TutorPreferedSubject.ToUpper() == searchWord.ToUpper()).ToList();
                }
            }
            else if (searchType == "Search By Class")
            {
                if (includeDepartment)
                {
                    //return this.context.Tutors.Include("Tutor").Where(x => x.TutorPreferedClass.ToUpper() == searchWord.ToUpper()).ToList();
                    return this.context.Tutors.Include("Tutor").Where(x => x.TutorPreferedClass.Contains(searchWord)).ToList();
                }
                else
                {
                    //return this.context.Tutors.Where(x => x.TutorPreferedClass.ToUpper() == searchWord.ToUpper()).ToList();
                    return this.context.Tutors.Where(x => x.TutorPreferedClass.Contains(searchWord)).ToList();
                }
            }
            else if (searchType == "Search By Department")
            {
                if (includeDepartment)
                {
                    return this.context.Tutors.Include("Tutor").Where(x => x.TutorDepartment.ToUpper() == searchWord.ToUpper()).ToList();
                }
                else
                {
                    return this.context.Tutors.Where(x => x.TutorDepartment.ToUpper() == searchWord.ToUpper()).ToList();
                }
            }
            else if (searchType == "Search By University")
            {
                if (includeDepartment)
                {
                    return this.context.Tutors.Include("Tutor").Where(x => x.TutorInstitute.ToUpper() == searchWord.ToUpper()).ToList();
                }
                else
                {
                    return this.context.Tutors.Where(x => x.TutorInstitute.ToUpper() == searchWord.ToUpper());
                }
            }
            else
            {
                if (includeDepartment)
                {
                    return this.context.Tutors.Include("Tutor").Where(x => x.TutorGender.ToString().ToUpper() == searchWord.ToUpper()).ToList();
                }
                else
                {
                    return this.context.Tutors.Where(x => x.TutorGender.ToString().ToUpper() == searchWord.ToUpper());
                }
            }
        }

        public Tutor Get(int id, bool includeDepartment = false)
        {
            if (includeDepartment)
            {
                return this.context.Tutors.Include("Tutor").SingleOrDefault(x => x.TutorId == id);
            }
            else
            {
                return this.context.Tutors.SingleOrDefault(x => x.TutorId == id);
            }
        }

        public int Insert(Tutor tutor)
        {
            this.context.Tutors.Add(tutor);
            return this.context.SaveChanges();
        }

        public int Update(Tutor tutor)
        {
            Tutor tut = this.context.Tutors.SingleOrDefault(x => x.TutorId == tutor.TutorId);
            tut.TutorId = tutor.TutorId;
            tut.TutorName = tutor.TutorName;
            tut.TutorEmail = tutor.TutorEmail;
            tut.TutorPassword = tutor.TutorPassword;
            tut.TutorDepartment = tutor.TutorDepartment;
            tut.TutorGender = tutor.TutorGender;
            tut.TutorInstitute = tutor.TutorInstitute;
            tut.TutorLocation = tutor.TutorLocation;
            tut.TutorPhone = tutor.TutorPhone;
            tut.TutorPhoto = tutor.TutorPhoto;
            tut.TutorPreferedClass = tutor.TutorPreferedClass;
            tut.TutorPreferedSubject = tutor.TutorPreferedSubject;
            tut.TutorRatingTotal = tutor.TutorRatingTotal;

            try
            {
                return this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return -1;
            }
        }

        public int Delete(int id)
        {
            Tutor tut = this.context.Tutors.SingleOrDefault(x => x.TutorId == id);
            this.context.Tutors.Remove(tut);

            return this.context.SaveChanges();
        }
    }
}