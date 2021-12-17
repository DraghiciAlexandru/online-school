using online_school.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View.Template
{
    class CardTest : Panel
    {
        private Course course;

        public Course Course
        {
            get { return course; }
        }

        public CardTest(Course course)
        {
            this.course = course;
            layout();
        }

        public void layout()
        {
            this.Size = new Size(500, 200);
            this.BackColor = Color.FromArgb(153, 170, 181);

            setNume();
        }

        public void setNume()
        {
            Label lblNume = new Label();
            lblNume.Name = "lblNume";
            lblNume.Text = course.Name;
            lblNume.Location = new Point(15, 12);
            lblNume.AutoSize = false;
            lblNume.Size = new Size(400, 40);

            lblNume.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            this.Controls.Add(lblNume);
        }


    }
}
