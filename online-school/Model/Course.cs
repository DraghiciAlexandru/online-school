using System;
using System.Collections.Generic;
using System.Text;

namespace online_school.Model
{
    public class Course
    {
        private int id;
        private String name;
        private String department;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Department
        {
            get { return department; }
            set { name = value; }
        }

        public Course(int id, String name, String department)
        {
            this.id = id;
            this.name = name;
            this.department = department;
        }

        public Course(String name, String department)
        {
            this.name = name;
            this.department = department;
        }

        public override bool Equals(object? obj)
        {
            Course other=obj as Course;
            if (this.id == other.id || this.name == other.name) 
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + name + "," + department;
        }
    }
}
