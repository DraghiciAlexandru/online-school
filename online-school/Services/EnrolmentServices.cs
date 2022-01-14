using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public void create(Enrolment enrolment) 
        {
            if (!enrolments.Contains(enrolment))
            {
                enrolmentRepo.create(enrolment);
            }
            else
            {
                throw new CourseEnroledExeception("Youre already enrolled");
            }
        }

        public List<Enrolment> getAll()
        {
            if (enrolments.Count == 0)
                return null;
            return enrolments;
        }

        public Enrolment isEnrolled(int student_id, int course_id)
        {
            return enrolmentRepo.isEnrolled(student_id, course_id);
        }

        public void deletebyDetails(Enrolment enrolment)
        {
            if (enrolment.Student_id > 0 && enrolment.Course_id > 0)
            {
                if (enrolments.Contains(enrolment))
                {
                    enrolmentRepo.deleteByDetails(enrolment.Student_id, enrolment.Course_id);
                }
                else
                {
                    throw new CourseEnroledExeception("Student is not enrolled in this course");
                }
            }
            else
            {
                throw new CourseEnroledExeception("Invalid enrolment");
            }
        }

        public Enrolment getById(int id)
        {
            if (id >= 1)
            {
                return enrolmentRepo.getById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid id");
            }
        }

        public List<Enrolment> getByStudent(int student_id)
        {
            if (student_id > 0) 
            {
                List<Enrolment> studentEnrolments = enrolmentRepo.getByStudentId(student_id);
                return studentEnrolments;
            }
            else
            {
                throw new CourseEnroledExeception("Invalid student id");
            }
        }

        public List<Enrolment> getByCourse(int course_id)
        {
            if (course_id > 0)
            {
                List<Enrolment> courseEnrolments = enrolmentRepo.getByCourseId(course_id);
                return courseEnrolments;
            }
            else
            {
                throw new CourseEnroledExeception("Invalid course id");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                enrolmentRepo.deleteById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid id");
            }
        }

        public void updateStudentById(int id, int student_id)
        {
            if (id > 0 && student_id > 0) 
            {
                enrolmentRepo.updateStudentById(id, student_id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }

        public void updateCourseById(int id, int course_id)
        {
            if (id > 0 && course_id > 0)
            {
                enrolmentRepo.updateCourseById(id, course_id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }

        public void updateCreatedById(int id, DateTime created_at)
        {
            if (id > 0 && !created_at.Equals(new DateTime())) 
            {
                enrolmentRepo.updateCreatedById(id, created_at);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }
    }
}
