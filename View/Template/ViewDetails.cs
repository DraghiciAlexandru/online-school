using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using online_school.Model;
using online_school.Services;

namespace View.Template
{
    public class ViewDetails : Panel
    {
        private ProfessorServices professorServices;
        private EnrolmentServices enrolmentServices;
        private Course course;
        private Professor professor;
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
            professorServices = new ProfessorServices();
            enrolmentServices = new EnrolmentServices();
            this.course = course;
            this.professor = professorServices.getById(course.Profesor_id);

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
            setProfessorName();
            setDescription();
            setCourseImage();
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

            btnAttendCourse.Click += BtnAttendCourse_Click;

            Controls.Add(btnAttendCourse);
        }

        private void BtnAttendCourse_Click(object sender, EventArgs e)
        {
            enrolmentServices.create(new Enrolment(StudentServices.loged.Id, course.Id, DateTime.Now));
            btnCancelCourse.Enabled = true;
            btnAttendCourse.Enabled = false;
            enrolmentServices = new EnrolmentServices();
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

            btnCancelCourse.Click += BtnCancelCourse_Click;

            Controls.Add(btnCancelCourse);
        }

        private void BtnCancelCourse_Click(object sender, EventArgs e)
        {
            enrolmentServices.deletebyDetails(new Enrolment(StudentServices.loged.Id, course.Id, DateTime.Now));
            btnCancelCourse.Enabled = false;
            btnAttendCourse.Enabled = true;
            enrolmentServices = new EnrolmentServices();
        }

        private void setCourseName()
        {
            Label lblTitlu = new Label();

            lblTitlu.AutoSize = false;
            lblTitlu.Size = new Size(500, 70);
            lblTitlu.Text = course.Name;
            lblTitlu.Location = new Point(30, 150);

            lblTitlu.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Regular);
            lblTitlu.ForeColor = Color.FromArgb(114, 137, 218);

            Controls.Add(lblTitlu);
        }

        private void setProfessorName()
        {
            Label lblProf = new Label();

            lblProf.AutoSize = false;
            lblProf.Size = new Size(500, 70);
            lblProf.Text = "Professor: " + professor.Name;
            lblProf.Location = new Point(30, 230);

            lblProf.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            lblProf.ForeColor = Color.FromArgb(114, 137, 218);

            lblProf.Click += LblProf_Click;

            Controls.Add(lblProf);
        }

        private void LblProf_Click(object sender, EventArgs e)
        {
            ViewProfessorProfile view = new ViewProfessorProfile(professor);
            this.Parent.Controls.Add(view);
            this.Parent.Controls.Remove(this);
        }

        private void setDescription()
        {
            Label lblDescriere = new Label();

            lblDescriere.AutoSize = false;
            lblDescriere.Size = new Size(1560, 700);
            lblDescriere.Text = "Course description:" + Environment.NewLine + Environment.NewLine;
            lblDescriere.Text += course.Description;
            lblDescriere.Location = new Point(30, 300);

            lblDescriere.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lblDescriere.ForeColor = Color.White;

            Controls.Add(lblDescriere);
        }

        private void setCourseImage()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(500, 300);
            pic.Location = new Point(1000, 30);


            PhotosServices photosServices = new PhotosServices();
            MemoryStream m = new MemoryStream(photosServices.getByCourseId(course.Id).Image);

            pic.BackgroundImage = Image.FromStream(m);
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(pic);
        }
    }
}
