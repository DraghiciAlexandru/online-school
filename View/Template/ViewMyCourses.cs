using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using online_school.Model;
using online_school.Services;

namespace View.Template
{
    class ViewMyCourses : Panel
    {
        private FlowLayoutPanel courses;
        private CourseServices courseServices;
        private EnrolmentServices enrolmentServices;

        public ViewMyCourses()
        {
            courseServices = new CourseServices();
            enrolmentServices = new EnrolmentServices();
            courses = new FlowLayoutPanel();

            layout();
        }

        public void layout()
        {
            this.Size = new Size(1620, 945);
            this.AutoScroll = true;
            this.Name = "viewMyCourses";

            loadCourses();
        }

        public void loadCourses()
        {
            courses.Size = new Size(1620, 945);
            courses.Location = new Point(0, 0);
            courses.AutoScroll = true;


            loadAllCourses(courses);

            this.Controls.Add(courses);
        }

        private void loadAllCourses(FlowLayoutPanel flow)
        {
            List<Enrolment> enrolments = enrolmentServices.getByStudent(StudentServices.loged.Id);

            foreach (Enrolment x in enrolments)
            {
                CardCourse cardTest = new CardCourse(courseServices.getById(x.Course_id));
                cardTest.Margin = new Padding(10);
                cardTest.Click += CardTest_Click;
                flow.Controls.Add(cardTest);
            }
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
