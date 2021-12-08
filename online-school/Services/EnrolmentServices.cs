using System;
using System.Collections.Generic;
using System.Text;
using online_school.Model;
using online_school.Repo;

namespace online_school.Services
{
    public class EnrolmentServices
    {
        private EnrolmentRepo enrolmentRepo;

        private List<Enrolment> enrolments;
        public EnrolmentServices()
        {
            enrolmentRepo = new EnrolmentRepo();
            enrolments = enrolmentRepo.getAll();
        }

        //ce

        public void create(Enrolment enrolment) 
        {
            if (!enrolments.Contains(enrolment))
            {
                enrolmentRepo.create(enrolment);
            }
            else
            {
                throw  new CourseEnroledExeception("Youre already enlrolled");
            }

            
        }

        public List<Enrolment> getAll()
        {
            if (enrolments.Count == 0)
                return null;
            return enrolments;
        }

        public void deletebyDetails(Enrolment enrolment)
        {
            if (enrolments.Contains(enrolment))
            {
                enrolmentRepo.deleteByDetails(enrolment.Student_id, enrolment.Course_id);
            }
        }

    }
}
