using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using online_school.Model;
using online_school.Repo;

namespace online_school.Services
{
    public class StudentServices
    {
        private StudentRepo studentRepo;

        public static Student loged;

        private List<Student> students;
        public StudentServices()
        {
            studentRepo = new StudentRepo();
            students = studentRepo.getAll();
        }

        public void create(Student student)
        {
            if (!students.Contains(student))
            {
                studentRepo.create(student);
            }
            else
            {
                throw new CourseEnroledExeception("Student already exists");
            }
        }

        public List<Student> getAll()
        {
            if (students.Count == 0)
                return null;
            return students;
        }

        public Student getByName(string last_name, string first_name)
        {
            if (students.Contains(new Student(first_name, last_name, "email@gmail.com", 0, "pass"))) 
            {
                return studentRepo.getByName(last_name, first_name);
            }
            else
            {
                throw new CourseEnroledExeception("Student does not exist");
            }
        }

        public Student getById(int id)
        {
            if (id >= 1)
            {
                return studentRepo.getById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid student id 2");
            }
        }

        public Student getByEmail(String email)
        {
            return studentRepo.getByEmail(email);
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                studentRepo.deleteById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid student id 3");
            }
        }

        public void deleteByName(string last_name, string first_name)
        {
            if (last_name.Trim(' ').Length > 0 && first_name.Trim(' ').Length > 0)
            {
                if (students.Contains(new Student(first_name, last_name, "email@gmail.com", 0, "pass"))) 
                    studentRepo.deleteByName(last_name, first_name);
                else
                {
                    throw new CourseEnroledExeception("Name does not exist");
                }
            }
            else
            {
                throw new CourseEnroledExeception("Invalid name");
            }
        }

        public void updateFirst_NameById(int id, string first_name)
        {
            if (id > 0 && first_name.Trim(' ').Length > 0)
            {
                studentRepo.updateFirst_NameById(id, first_name);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }

        public void updateLast_NameById(int id, string lasr_name)
        {
            if (id > 0 && lasr_name.Trim(' ').Length > 0)
            {
                studentRepo.updateLast_NameById(id, lasr_name);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }

        public void updateEmailById(int id, string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);

                if (id > 0)
                {
                    int flag = 0;
                    for (int i = 0; i < students.Count; i++)
                        if (students[i].Email == email)
                            flag = 1;
                    if (flag == 0)
                        studentRepo.updateEmailById(id, email);
                    else
                    {
                        throw new CourseEnroledExeception("Email already exists");
                    }
                }
                else
                {
                    throw new CourseEnroledExeception("Invalid id");
                }
            }
            catch
            {
                throw new CourseEnroledExeception("Invalid email");
            }
        }

        public void updateAgeById(int id, int age)
        {
            if (id > 0 && age > 0)
            {
                studentRepo.updateAgeById(id, age);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid data");
            }
        }


    }
}
