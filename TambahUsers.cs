using AppPenilaianSiswa.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class TambahUsers : Form
    {
        public TambahUsers()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtNama.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private async Task LoadCbRole()
        {
            using(var db = new AppDbContext())
            {
                var roleInfo = await db.Roles.Select(a => new
                {
                    RoleId = a.RoleId,
                    RoleName = a.RoleName,
                }).ToListAsync();
                cbRole.DataSource = roleInfo;
                cbRole.DisplayMember = "RoleName";
                cbRole.ValueMember = "RoleId";
            }
        }

        private async void TambahUsers_Load(object sender, EventArgs e)
        {
            await LoadCbRole();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            using(var db = new AppDbContext())
            {
                var newUser = new Operator
                {
                    Username = txtUsername.Text,
                    Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
                    RoleId = Convert.ToInt32(cbRole.SelectedValue),
                    Nama = txtNama.Text,
                };

                DialogResult confirm = MessageBox.Show($"Yakin ingin menambah data User?\n\n Username: {txtUsername.Text}, \n\n Password: {txtPassword.Text}, \n\n Role: {cbRole.Text}", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (confirm != DialogResult.OK) return;

                db.Users.Add(newUser);
                await db.SaveChangesAsync();
                MessageBox.Show("Data berhasil disimpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
        }
    }
}
