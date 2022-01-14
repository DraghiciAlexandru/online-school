using System;
using System.Collections.Generic;
using System.Text;

namespace online_school.Model
{
    public class Professor
    {
        private int id;
        private byte[] image;
        private String description;
        private String name;

        public int Id
        {
            get { return id; }
        }
        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Professor(int id, byte[] image, String description, String name)
        {
            this.id = id;
            this.image = image;
            this.description = description;
            this.name = name;
        }

        public Professor(byte[] image, String description, String name)
        {
            this.image = image;
            this.description = description;
            this.name = name;
        }

        public override bool Equals(object? obj)
        {
            Professor other = obj as Professor;
            if (this.id == other.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + " " + image + " " + description + " " + name;
        }
    }
}
