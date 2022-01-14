using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using online_school.Model;
using online_school.Services;

namespace View.Template
{
    class ViewAllCourses : Panel
    {
        private FlowLayoutPanel[] dep;
        private CourseServices courseServices;
        private List<String> depList;

        public ViewAllCourses()
        {
            courseServices = new CourseServices();
            depList = courseServices.getAllDepartments();
            dep = new FlowLayoutPanel[depList.Count];

            for (int i = 0; i < depList.Count; i++)
                dep[i] = new FlowLayoutPanel();

            layout();
        }

        public void layout()
        {
            this.Size = new Size(1620, 945);
            this.AutoScroll = true;

            loadDep();
        }

        public void loadDep()
        {
            for (int i = 0; i < depList.Count; i++)
            {
                dep[i].Name = depList[i];
                dep[i].Size = new Size(500, 900);
                dep[i].Location = new Point(500 * i, 0);
                dep[i].AutoScroll = true;

                CardDepartment card = new CardDepartment(depList[i]);
                card.Margin = new Padding(10);
                dep[i].Controls.Add(card);

                loadAllCourses(dep[i], depList[i]);

                this.Controls.Add(dep[i]);
            }
        }

        private void loadAllCourses(FlowLayoutPanel flow, String depart)
        {
            List<Course> courses = courseServices.getDepartment(depart);

            foreach (Course x in courses)
            {
                CardCourse cardTest = new CardCourse(x);
                cardTest.Click += CardTest_Click;
                cardTest.LblNume.Click += LblNume_Click;
                cardTest.Margin = new Padding(10);
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
