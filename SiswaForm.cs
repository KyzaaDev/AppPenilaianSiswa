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
    public partial class SiswaForm : Form
    {
        public string imagePath;
        public SiswaForm()
        {
            InitializeComponent();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG (*.jpg)|*.jpg|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePath = ofd.FileName;
                    pbSiswa.ImageLocation = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadDataSiswa()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var data = await db.Siswas.Select(u => new
                    {
                        SiswaId = u.SiswaId,
                        Nisn = u.Nisn,
                        NamaSiswa = u.NamaSiswa,
                        Kelas = u.Kelas,
                        Jurusan = u.Jurusan,
                    }).ToListAsync();
                    dgvSiswa.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SiswaForm_Load(object sender, EventArgs e)
        {
            await LoadDataSiswa();
        }

        private bool Validate()
        {
            epSiswa.Clear();
            if (string.IsNullOrWhiteSpace(txtNISN.Text))
            {
                epSiswa.SetError(txtNISN, "NISN harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNamaSiswa.Text))
            {
                epSiswa.SetError(txtNamaSiswa, "Nama siswa harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbKelas.Text))
            {
                epSiswa.SetError(cbKelas, "Kelas harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtJurusan.Text))
            {
                epSiswa.SetError(txtJurusan, "Jurusan harus diisi!");
                return false;
            }
            if (imagePath == null)
            {
                epSiswa.SetError(btnFoto, "Pilh foto terlebih dahulu");
                return false;
            }

            return true;
        }

        private void ClearForms()
        {
            txtJurusan.Text = "";
            imagePath = "";
            txtNamaSiswa.Text = "";
            txtNISN.Text = "";
            pbSiswa.ImageLocation = "";
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            try
            {
                var siswaBaru = new Siswa
                {
                    Nisn = txtNISN.Text,
                    Jurusan = txtJurusan.Text,
                    NamaSiswa = txtNamaSiswa.Text,
                    Kelas = cbKelas.Text,
                    SiswaPicture = imagePath
                };

                using (var db = new AppDbContext())
                {
                    DialogResult res = MessageBox.Show($"Yakin ingin simpan data siswa?\n\nNISN: {siswaBaru.Nisn}\n\nJurusan: {siswaBaru.Jurusan}" +
                        $"\n\nNama Siswa: {siswaBaru.NamaSiswa}\n\nKelas: {siswaBaru.Kelas}", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (res != DialogResult.OK) return;
                    db.Siswas.Add(siswaBaru);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Data berhasil disimpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataSiswa();
                    ClearForms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            ClearForms();
        }
    }
}
