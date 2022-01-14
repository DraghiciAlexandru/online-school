using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace online_school.Model
{
    public class Enrolment
    {
        private int id;
        private int student_id;
        private int course_id;
        private DateTime created_at;

        public int Id
        {
            get { return id; }
        }
        public int Student_id
        {
            get { return student_id; }
            set { student_id = value; }
        }
        public int Course_id
        {
            get { return course_id; }
            set { course_id = value; }
        }
        public DateTime Created_at
        {
            get { return created_at; }
            set { created_at = value; }
        }

        public Enrolment(int id, int student_id, int course_id, DateTime created_at)
        {
            this.id = id;
            this.student_id = student_id;
            this.course_id = course_id;
            this.created_at = created_at;
        }
        public Enrolment(int student_id, int course_id, DateTime created_at)
        {
            this.student_id = student_id;
            this.course_id = course_id;
            this.created_at = created_at;
        }

        public override bool Equals(object? obj)
        {
            Enrolment other = obj as Enrolment;
            if ((this.id == other.id) || (this.student_id == other.student_id && this.course_id == other.course_id)) 
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + student_id + "," + course_id + "," + created_at.ToShortTimeString();
        }
    }
}
