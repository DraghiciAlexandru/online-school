using online_school.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View.Template
{
    class CardDepartment : Panel
    {
        private String depart;
        private Label lblNume;

        public string Depart
        {
            get { return depart; }
        }

        public CardDepartment(String department)
        {
            this.depart = department;
            layout();
        }

        public void layout()
        {
            this.Size = new Size(450, 60);
            this.BackColor = Color.FromArgb(114, 137, 218);

            setNume();
        }

        public void setNume()
        {
            lblNume = new Label();
            lblNume.Name = "lblNume";
            lblNume.Text = depart;
            lblNume.AutoSize = false;
            lblNume.Size = new Size(400, 40);
            lblNume.Location = new Point(25, 10);
            lblNume.TextAlign = ContentAlignment.MiddleCenter;

            lblNume.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);

            lblNume.ForeColor = Color.White;

            this.Controls.Add(lblNume);
        }

    }
}
