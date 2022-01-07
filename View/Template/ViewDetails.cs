using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using online_school.Model;
using online_school.Services;

namespace View.Template
{
    public class ViewDetails : Panel
    {
        private StudentServices studentServices;
        private EnrolmentServices enrolmentServices;
        private Course course;
        private Button btnAttendCourse;
        private Button btnCancelCourse;

        public Button BtnAttendCourse
        {
            get { return btnAttendCourse; }
            set { btnAttendCourse = value; }
        }

        public Button BtnCancelCourse
        {
            get { return btnCancelCourse; }
            set { btnCancelCourse = value; }
        }


        public ViewDetails(Course course)
        {
            studentServices = new StudentServices();
            enrolmentServices = new EnrolmentServices();
            this.course = course;

            layout();
        }

        private void layout()
        {
            this.Size = new Size(1620, 945);
            this.Location = new Point(0, 0);
            this.Name = "viewDetails";

            setAttendCourse();
            setCancelCourse();
            setCourseName();
        }

        private void setAttendCourse()
        {
            btnAttendCourse = new Button();
            btnAttendCourse.Name = "btnAttendCourse";
            btnAttendCourse.FlatStyle = FlatStyle.Flat;
            btnAttendCourse.FlatAppearance.BorderSize = 0;
            btnAttendCourse.Location = new Point(30, 30);
            btnAttendCourse.Size = new Size(300, 50);

            btnAttendCourse.Text = "Attend Course";
            btnAttendCourse.ForeColor = Color.White;

            btnAttendCourse.BackColor = Color.FromArgb(114, 137, 218);

            btnAttendCourse.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            if (StudentServices.loged == null)
                btnAttendCourse.Enabled = false;
            else
            {
                if (enrolmentServices.isEnrolled(StudentServices.loged.Id, course.Id) != null)
                    btnAttendCourse.Enabled = false;
            }

            Controls.Add(btnAttendCourse);
        }

        private void setCancelCourse()
        {
            btnCancelCourse = new Button();
            btnCancelCourse.Name = "btnCancelCourse";
            btnCancelCourse.FlatStyle = FlatStyle.Flat;
            btnCancelCourse.FlatAppearance.BorderSize = 0;
            btnCancelCourse.Location = new Point(350, 30);
            btnCancelCourse.Size = new Size(300, 50);

            btnCancelCourse.Text = "Cancel Course";
            btnCancelCourse.ForeColor = Color.White;

            btnCancelCourse.BackColor = Color.FromArgb(114, 137, 218);

            btnCancelCourse.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            if (StudentServices.loged == null)
                btnCancelCourse.Enabled = false;
            else
            {
                if (enrolmentServices.isEnrolled(StudentServices.loged.Id, course.Id) == null)
                    btnCancelCourse.Enabled = false;
            }

            Controls.Add(btnCancelCourse);
        }

        private void setCourseName()
        {
            Label lblTitlu = new Label();

            lblTitlu.AutoSize = false;
            lblTitlu.Size = new Size(500, 70);
            lblTitlu.Text = course.Name;
            lblTitlu.Location = new Point(30, 250);

            lblTitlu.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Regular);
            lblTitlu.ForeColor = Color.FromArgb(114, 137, 218);

            Controls.Add(lblTitlu);
        }
    }
}
