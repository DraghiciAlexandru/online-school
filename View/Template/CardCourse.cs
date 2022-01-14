using online_school.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View.Template
{
    class CardCourse : Panel
    {
        private Course course;
        private Label lblNume;

        public Course Course
        {
            get { return course; }
        }

        public Label LblNume
        {
            get { return lblNume; }
            set { lblNume = value; }
        }

        public CardCourse(Course course)
        {
            this.course = course;
            layout();
        }

        public void layout()
        {
            this.Size = new Size(450, 200);
            this.BackColor = Color.FromArgb(153, 170, 181);

            setNume();
        }

        public void setNume()
        {
            lblNume = new Label();
            lblNume.Name = "lblNume";
            lblNume.Text = course.Name;
            lblNume.AutoSize = false;
            lblNume.Size = new Size(400, 100);
            lblNume.Location = new Point(10, 50);
            lblNume.TextAlign = ContentAlignment.MiddleCenter;

            lblNume.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            lblNume.ForeColor = Color.White;

            this.Controls.Add(lblNume);
        }
    }
}
