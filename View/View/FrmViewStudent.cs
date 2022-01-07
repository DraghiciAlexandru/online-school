﻿using online_school.Model;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities.Collections;
using View.Template;

namespace View.View
{
    public class FrmViewStudent : Form
    {
        private Panel Header;
        private Panel Aside;
        private Panel Main;

        private FlowLayoutPanel Content;

        public FrmViewStudent()
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

            header.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            setSignIn(header);
            setSignUp(header);
            setClose(header);

            this.Controls.Add(header);
        }

        public void setHeaderLoged(Panel header)
        {
            header.Size = new Size(1920, 75);
            header.Location = new Point(0, 0);
            header.BackColor = Color.FromArgb(114, 137, 218);

            header.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            setSignOut(header);
            setClose(header);

            this.Controls.Add(header);
        }

        public void setSignOut(Panel header)
        {
            Button btnSignOut = new Button();
            btnSignOut.Name = "btnSignOut";
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.Location = new Point(1750, 0);
            btnSignOut.Size = new Size(100, 75);

            btnSignOut.Text = "Sign Out";
            btnSignOut.ForeColor = Color.White;

            btnSignOut.Click += BtnSignOut_Click;

            header.Controls.Add(btnSignOut);
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            Aside.Controls.Clear();
            Main.Controls.Clear();
            setAside(Aside);
            setMain(Main);
            setHeader(Header);
            StudentServices.loged = null;
            Header.Controls.Remove(sender as Button);
        }

        public void setSignIn(Panel header)
        {
            Button btnSignIn = new Button();
            btnSignIn.Name = "btnSignIn";
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.Location = new Point(1650, 0);
            btnSignIn.Size = new Size(100, 75);

            btnSignIn.Text = "Sign In";
            btnSignIn.ForeColor = Color.White;

            btnSignIn.Click += BtnSignIn_Click;

            header.Controls.Add(btnSignIn);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            Aside.Visible = false;
            Main.Visible = false;
            ViewLogin view = new ViewLogin();
            view.Location = new Point(0, 75);

            view.BtnSignIn.Click += BtnSignIn_Click1;
            view.BtnCancel.Click += BtnCancel_Click;

            Controls.Add(view);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ViewLogin view = new ViewLogin();
            foreach (Control x in Controls)
            {
                if (x.Name == "viewLogin")
                {
                    view = x as ViewLogin;
                }
            }

            setAside(Aside);
            Aside.Show();
            setMain(Main);
            Main.Visible = true;

            Controls.Remove(view);
        }

        private void BtnSignIn_Click1(object sender, EventArgs e)
        {
            ViewLogin view = new ViewLogin();

            StudentServices studentServices = new StudentServices();


            foreach (Control x in Controls)
            {
                if (x.Name == "viewLogin")
                {
                    view = x as ViewLogin;
                }
            }

            if (view.TxtEmail.Text.Trim(' ') != "" && view.TxtPassword.Text.Trim(' ') != "") 
            {
                if (studentServices.getByEmail(view.TxtEmail.Text) != null)
                {
                    if (studentServices.getByEmail(view.TxtEmail.Text).Password == view.TxtPassword.Text)
                    {
                        StudentServices.loged = studentServices.getByEmail(view.TxtEmail.Text);
                        setAsideLoged(Aside);
                        Aside.Show();
                        setMain(Main);
                        Main.Visible = true;
                        Header.Controls.Clear();
                        setHeaderLoged(Header);
                        Controls.Remove(view);
                    }
                }
            }
        }

        public void setSignUp(Panel header)
        {
            Button btnSignUp = new Button();
            btnSignUp.Name = "btnSignUp";
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.Location = new Point(1750, 0);
            btnSignUp.Size = new Size(100, 75);

            btnSignUp.Text = "Sign Up";
            btnSignUp.ForeColor = Color.White;

            header.Controls.Add(btnSignUp);
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
            aside.Controls.Clear();
            aside.Size = new Size(300, 945);
            aside.Location = new Point(0, 75);
            aside.BackColor = Color.FromArgb(35, 39, 42);
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);

            setBtnCourses(aside);

            this.Controls.Add(aside);
        }

        private void setAsideLoged(Panel aside)
        {
            aside.Controls.Clear();
            aside.Size = new Size(300, 945);
            aside.Location = new Point(0, 75);
            aside.BackColor = Color.FromArgb(35, 39, 42);
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);

            setBtnMyCourses(aside);
            setBtnCourses(aside);

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

            btnMyCourses.Dock = DockStyle.Top;

            btnMyCourses.Text = "My Courses";
            btnMyCourses.ForeColor = Color.White;

            btnMyCourses.Click += BtnMyCourses_Click;

            aside.Controls.Add(btnMyCourses);
        }

        private void BtnMyCourses_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Main.Controls.Clear();
            ViewMyCourses view=new ViewMyCourses();
            Main.Controls.Add(view);
            Content.Visible = true;
            Content.AutoScroll = true;
        }

        private void setBtnCourses(Panel aside)
        {
            Button btnCourses = new Button();
            btnCourses.Name = "btnCourses";
            btnCourses.FlatStyle = FlatStyle.Flat;
            btnCourses.FlatAppearance.BorderSize = 0;
            btnCourses.Location = new Point(0, 100);
            btnCourses.Size = new Size(300, 100);

            btnCourses.Dock = DockStyle.Top;

            btnCourses.Text = "All Courses";
            btnCourses.ForeColor = Color.White;

            btnCourses.Click += BtnCourses_Click;

            aside.Controls.Add(btnCourses);
        }

        private void BtnCourses_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            ViewAllCourses view = new ViewAllCourses();
            Main.Controls.Add(view);
        }
    }
}
