using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace online_school.Model
{
    public class Course
    {
        private int id;
        private String name;
        private String department;
        private String description;
        private int professor_id;

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
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Profesor_id
        {
            get { return professor_id; }
            set { professor_id = value; }
        }

        public Course(int id, String name, String department, String description, int professor_id)
        {
            this.id = id;
            this.name = name;
            this.department = department;
            this.description = description;
            this.professor_id = professor_id;
        }

        public Course(String name, String department, String description, int professor_id)
        {
            this.name = name;
            this.department = department;
            this.description = description;
            this.professor_id = professor_id;
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
            return id + "," + name + "," + department + " " + description + " " + professor_id;
        }
    }
}
