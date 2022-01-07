using online_school.Model;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using View.Template;

namespace View
{
    class FrmViewTest : Form
    {
        private Panel Header;
        private Panel Aside;
        private Panel Main;

        private FlowLayoutPanel Content;

        public FrmViewTest()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();
            Content = new FlowLayoutPanel();

            layout();
        }

        public void layout()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.Size = Screen.FromHandle(this.Handle).WorkingArea.Size;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(44, 47, 51);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            

            setHeader(Header);
            setAside(Aside);
            setMain(Main);
            setPanelContent(Content);
        }

        public void setHeader(Panel header)
        {
            header.Size = new Size(1920, 75);
            header.Location = new Point(0, 0);
            header.BackColor = Color.FromArgb(114, 137, 218);

            setClose(header);

            this.Controls.Add(header);
        }

        public void setClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Text = "Exit";
            btnClose.Size = new Size(40, 40);
            btnClose.Location = new Point(1870, 5);

            btnClose.Click += BtnClose_Click;

            header.Controls.Add(btnClose);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setAside(Panel aside)
        {
            aside.Size = new Size(300, 945);
            aside.Location = new Point(0, 75);
            aside.BackColor = Color.FromArgb(35, 39, 42);
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);

            setBtnMyCourses(aside);

            this.Controls.Add(aside);
        }

        private void setMain(Panel main)
        {
            main.Location = new Point(300, 75);
            main.Size = new Size(1620, 945);
            main.Padding = new Padding(50);
            

            this.Controls.Add(main);
        }

        private void setPanelContent(FlowLayoutPanel content)
        {
            content.Size = Main.Size;
            content.Location = new Point(0, 0);
            content.Visible = false;
            content.BackColor = Color.FromArgb(44, 47, 51);

            Main.Controls.Add(content);
        }

        private void setBtnMyCourses(Panel aside)
        {
            Button btnMyCourses = new Button();
            btnMyCourses.Name = "btnMyCourses";
            btnMyCourses.FlatStyle = FlatStyle.Flat;
            btnMyCourses.FlatAppearance.BorderSize = 0;
            btnMyCourses.Location = new Point(0, 0);
            btnMyCourses.Size = new Size(300, 100);

            btnMyCourses.Text = "My Courses";
            btnMyCourses.ForeColor = Color.White;

            btnMyCourses.Click += BtnMyCourses_Click;

            aside.Controls.Add(btnMyCourses);
        }

        private void BtnMyCourses_Click(object sender, EventArgs e)
        {
            loadCourses(Content);
            Content.Visible = true;
        }

        private void loadCourses(FlowLayoutPanel flow)
        {
            CourseServices courseServices = new CourseServices();
            EnrolmentServices enrolmentServices = new EnrolmentServices();

            List<Course> courses = courseServices.getAll();

            foreach(Course x in courses)
            {
                CardCourse cardTest = new CardCourse(x);
                try
                {
                    //cardTest.LblNrPers.Text += enrolmentServices.getByCourse(x.Id).Count.ToString();
                }
                catch
                {
                    //cardTest.LblNrPers.Text += "0";
                }
                flow.Controls.Add(cardTest);
            }
        }
    }
}
