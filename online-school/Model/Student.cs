using System;
using System.Collections.Generic;
using System.Text;

namespace online_school.Model
{
    public class Student
    {
        private int id;
        private String first_name;
        private String last_name;
        private String email;
        private int age;

        public int Id
        {
            get { return id; }
        }
        public String First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }
        public String Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Student(int id, String first_name, String last_name, String email, int age)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.age = age;
        }
        public Student(String first_name, String last_name, String email, int age)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.age = age;
        }

        public override bool Equals(object? obj)
        {
            Student other=obj as Student;
            if ((this.id == other.id) || (this.first_name == other.first_name && this.last_name == other.last_name) ||
                (this.email == other.email))  
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + first_name + "," + last_name + "," + email + "," + age;
        }
    }
}
