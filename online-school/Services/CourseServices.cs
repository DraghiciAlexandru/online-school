using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using online_school.Model;
using online_school.Repo;

namespace online_school.Services
{
    public class CourseServices
    {
        private CourseRepo courseRepo;
        private List<Course> courses;

        public CourseServices()
        {
            courseRepo = new CourseRepo();
            courses = courseRepo.getAll();
        }

        public List<Course> getAll()
        {
            if (courses.Count == 0)
                return null;
            return courses;
        }

        public void create(Course course)
        {
            if (!courses.Contains(course))
            {
                courseRepo.create(course);
            }
            else
            {
                throw new CourseEnroledExeception("Course exists");
            }
        }

        public Course getByName(string name)
        {
            if (name.Trim(' ').Length > 0)
            {
                if (courses.Contains(new Course(name, "dep", "des", 1))) 
                    return courseRepo.getByName(name);
                else
                {
                    throw new CourseEnroledExeception("Course does not exists");
                }
            }
            else
            {
                throw new CourseEnroledExeception("Invalid course id");
            }
        }

        public Course getById(int id)
        {
            if (id > 0)
            {
                return courseRepo.getById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid course id");
            }
        }

        public List<String> getAllDepartments()
        {
            return courseRepo.getAllDepartments();
        }

        public List<Course> getDepartment(String department)
        {
            return courseRepo.getDepartment(department);
        }

        public List<Course> getByProfessor(int professor_id)
        {
            return courseRepo.getByProfessor(professor_id);
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                courseRepo.deleteById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid course id");
            }
        }

        public void deleteByName(string name)
        {
            if (name.Trim(' ').Length > 0)
            {
                courseRepo.deleteByName(name);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid name");
            }
        }

        public void updateNameById(int id, string name)
        {
            if (id > 0 && name.Trim(' ').Length > 0)
            {
                courseRepo.updateNameById(id, name);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }

        public void updateDepById(int id, string departmnet)
        {
            if (id > 0 && departmnet.Trim(' ').Length > 0)
            {
                courseRepo.updateDepById(id, departmnet);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }

        public void updateDescription(int id, String description)
        {
            if (id > 0 && description.Trim(' ').Length > 0)
            {
                courseRepo.updateDescription(id, description);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }
    }
}
