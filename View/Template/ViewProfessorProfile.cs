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
    public class ViewProfessorProfile : Panel
    {
        private ProfessorServices professorServices;
        private EnrolmentServices enrolmentServices;
        private Professor professor;

        public ViewProfessorProfile(Professor professor)
        {
            professorServices = new ProfessorServices();
            enrolmentServices = new EnrolmentServices();
            this.professor = professor;

            layout();
        }

        private void layout()
        {
            this.Size = new Size(1620, 945);
            this.Location = new Point(0, 0);
            this.Name = "viewProfessor";
            this.AutoScroll = true;

            setProfessorName();
            setDescription();
            setProfessorImage();
            setCourses();
            setFlowCourse();
        }

        private void setProfessorName()
        {
            Label lblName = new Label();

            lblName.AutoSize = false;
            lblName.Size = new Size(500, 70);
            lblName.Text = professor.Name;
            lblName.Location = new Point(100, 50);

            lblName.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Regular);
            lblName.ForeColor = Color.FromArgb(114, 137, 218);

            Controls.Add(lblName);
        }

        private void setDescription()
        {
            Label lblDescriere = new Label();

            lblDescriere.AutoSize = false;
            lblDescriere.Size = new Size(810, 700);
            lblDescriere.Text = "Professor description:" + Environment.NewLine + Environment.NewLine;
            lblDescriere.Text += professor.Description;
            lblDescriere.Location = new Point(700, 50);

            lblDescriere.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lblDescriere.ForeColor = Color.White;

            Controls.Add(lblDescriere);
        }

        private void setProfessorImage()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(400, 600);
            pic.Location = new Point(100, 150);

            MemoryStream m = new MemoryStream(professor.Image);

            pic.BackgroundImage = Image.FromStream(m);
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(pic);
        }

        private void setCourses()
        {
            Label lblCourse = new Label();

            lblCourse.AutoSize = false;
            lblCourse.Size = new Size(500, 50);
            lblCourse.Text = "Courses:";
            lblCourse.Location = new Point(50, 800);

            lblCourse.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            lblCourse.ForeColor = Color.FromArgb(114, 137, 218);

            Controls.Add(lblCourse);
        }

        private void setFlowCourse()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();

            flow.Size = new Size(1450, 500);
            flow.Location = new Point(100, 850);
            flow.AutoScroll = true;

            loadAllCourses(flow);

            this.Controls.Add(flow);
        }

        private void loadAllCourses(FlowLayoutPanel flow)
        {
            CourseServices courseServices = new CourseServices();

            List<Course> cours = courseServices.getByProfessor(professor.Id);

            foreach (Course x in cours)
            {
                CardCourse cardTest = new CardCourse(x);
                cardTest.Margin = new Padding(10);
                cardTest.Click += CardTest_Click;
                cardTest.LblNume.Click += LblNume_Click;
                flow.Controls.Add(cardTest);
            }
        }

        private void LblNume_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            CardCourse card = lbl.Parent as CardCourse;
            ViewDetails view = new ViewDetails(card.Course);
            this.Controls.Clear();
            this.Controls.Add(view);
        }

        private void CardTest_Click(object sender, EventArgs e)
        {
            CardCourse card = sender as CardCourse;
            ViewDetails view = new ViewDetails(card.Course);
            this.Controls.Clear();
            this.Controls.Add(view);
        }
    }
}
