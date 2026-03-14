using AppPenilaianSiswa.DTOs.Kelas;
using AppPenilaianSiswa.DTOs.Siswas;
using AppPenilaianSiswa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPenilaianSiswa
{
    public partial class SiswaForm : Form
    {
        private readonly HttpClient _hc = new HttpClient();
        private string imagePath;
        private int SiswaId = 0;
        public SiswaForm()
        {
            _hc.BaseAddress = new Uri("http://192.168.1.2:5055/api/");
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
                HttpResponseMessage res = await _hc.GetAsync("Kelas");
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<List<KelasResponseDTO>>();
                    cbKelas.DataSource = data;
                    cbKelas.DisplayMember = "KelasName";
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
                HttpResponseMessage res = await _hc.GetAsync("Siswas/");
                if (res.IsSuccessStatusCode)
                {
                    var content = await res.Content.ReadFromJsonAsync<List<SiswaResponseDTO>>();
                    dgvSiswa.DataSource = content;
                    if (dgvSiswa.Columns.Contains("Picture"))
                    {
                        dgvSiswa.Columns["Picture"].Visible = false;
                    }
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
            SiswaId = 0;

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
                var siswaBaru = new SiswaCreateDTO
                {
                    Nisn = txtNISN.Text,
                    NamaSiswa = txtNamaSiswa.Text,
                    Picture = imagePath,
                    KelasId = Convert.ToInt32(cbKelas.SelectedValue)
                };

                var kelas = (KelasResponseDTO)cbKelas.SelectedItem;

                DialogResult res = MessageBox.Show($"Yakin ingin simpan data siswa?\n\nNISN: {siswaBaru.Nisn}\n\nJurusan: {kelas.Jurusan.JurusanName}" +
                $"\n\nNama Siswa: {siswaBaru.NamaSiswa}\n\nKelas: {kelas.KelasName}", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
            pbSiswa.ImageLocation = data.Cells["Picture"].Value.ToString();
            SiswaId = Convert.ToInt32(data.Cells["SiswaId"].Value);
        }


        private async void tmData_Tick(object sender, EventArgs e)
        {
            tmData.Stop();
            await LoadDataSiswa();
            tmData.Start();
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                    if (SiswaId == 0)
                    {
                        MessageBox.Show("Pilih data terlebih dahulu!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //var findSiswa = await db.Siswas.FirstOrDefaultAsync(u => u.SiswaId == SiswaId);
                    //if (findSiswa == null)
                    //{
                    //    MessageBox.Show("Data siswa tidak ada");
                    //    return;
                    //}

                    DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm != DialogResult.OK)
                    {
                        return;
                    }

                    //db.Siswas.Remove(findSiswa);
                    //await db.SaveChangesAsync();
                    MessageBox.Show("Data berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataSiswa();
                    ClearForms();
                                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
