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
        private FlowLayoutPanel Main;

        public FrmViewTest()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new FlowLayoutPanel();


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
            setMain(Main);
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

        private void setMain(Panel main)
        {
            main.Location = new Point(0, 75);
            main.Size = new Size(1920, 945);
            main.Padding = new Padding(50);

            loadCourses(main);

            this.Controls.Add(main);
        }

        private void loadCourses(Panel main)
        {
            CourseServices courseServices = new CourseServices();

            List<Course> courses = courseServices.getAll();

            foreach(Course x in courses)
            {
                CardTest cardTest = new CardTest(x);
                main.Controls.Add(cardTest);
            }
        }
    }
}
