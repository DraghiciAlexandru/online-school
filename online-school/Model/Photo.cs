using System;
using System.Collections.Generic;
using System.Text;
using MySqlX.XDevAPI.Common;

namespace online_school.Model
{
    public class Photo
    {
        private int id;
        private byte[] image;
        private int course_id;

        public int Id
        {
            get { return id; }
        }
        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }
        public int Course_id
        {
            get { return course_id; }
            set { course_id = value; }
        }

        public Photo(int id, byte[] image, int course_id)
        {
            this.id = id;
            this.image = image;
            this.course_id = course_id;
        }

        public Photo(byte[] image, int course_id)
        {
            this.image = image;
            this.course_id = course_id;
        }

        public override bool Equals(object? obj)
        {
            Photo other = obj as Photo;
            if (this.id == other.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + course_id;
        }
    }
}
