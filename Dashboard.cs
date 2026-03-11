using AppPenilaianSiswa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPenilaianSiswa
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblUsername.Text += Session.Username;
        }

        private void dataSiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SiswaForm().Show();
            this.Close();
        }
    }
}
