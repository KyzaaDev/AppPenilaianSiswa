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

        private async Task LoadKelas()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var kelas = await db.Kelas.Include(k => k.Jurusan).ToListAsync();
                    cbKelas.DataSource = kelas;
                    cbKelas.DisplayMember = "NamaKelas";
                    cbKelas.ValueMember = "KelasId";
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
                    var data = await db.Siswas.Include(u => u.Kelas).ThenInclude(u => u.Jurusan).Select(u => new
                    {
                        SiswaId = u.SiswaId,
                        Nisn = u.Nisn,
                        NamaSiswa = u.NamaSiswa,
                        Kelas = u.Kelas.NamaKelas,
                        Jurusan = u.Kelas.Jurusan.NamaJurusan,
                        gambarSiswa = u.SiswaPicture
                    }).ToListAsync();
                    dgvSiswa.DataSource = data;
                    dgvSiswa.Columns["gambarSiswa"].Visible = false;
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
            await LoadKelas();
            tmData.Interval = 5000; // Set interval to 5 second
            tmData.Start();
        }

        private bool ValidateInput()
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
            if (imagePath == null)
            {
                epSiswa.SetError(btnFoto, "Pilh foto terlebih dahulu");
                return false;
            }

            return true;
        }

        private void ClearForms()
        {
            imagePath = "";
            txtNamaSiswa.Text = "";
            txtNISN.Text = "";
            pbSiswa.ImageLocation = "";
            cbKelas.SelectedIndex = -1;

            // aktifin lagi input
            txtNamaSiswa.Enabled = true;
            txtNISN.Enabled = true;
            cbKelas.Enabled = true;
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                var siswaBaru = new Siswa
                {
                    Nisn = txtNISN.Text,
                    NamaSiswa = txtNamaSiswa.Text,
                    KelasId = Convert.ToInt32(cbKelas.SelectedValue),
                    SiswaPicture = imagePath
                };

                var kelas = (Kelas)cbKelas.SelectedItem;

                using (var db = new AppDbContext())
                {
                    DialogResult res = MessageBox.Show($"Yakin ingin simpan data siswa?\n\nNISN: {siswaBaru.Nisn}\n\nJurusan: {kelas.Jurusan.NamaJurusan}" +
                        $"\n\nNama Siswa: {siswaBaru.NamaSiswa}\n\nKelas: {kelas.NamaKelas}", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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

        private void dgvSiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow data = dgvSiswa.Rows[e.RowIndex];

            txtNamaSiswa.Enabled = false;
            txtNISN.Enabled = false;
            cbKelas.Enabled = false;

            txtNamaSiswa.Text = data.Cells["NamaSiswa"].Value.ToString();
            txtNISN.Text = data.Cells["Nisn"].Value.ToString();
            cbKelas.Text = data.Cells["Kelas"].Value.ToString();
            pbSiswa.ImageLocation = data.Cells["gambarSiswa"].Value.ToString();
        }

        
        private async void tmData_Tick(object sender, EventArgs e)
        {
            tmData.Stop();
            await LoadDataSiswa();
            tmData.Start();
        }
    }
}
