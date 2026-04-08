using AppPenilaianSiswa.Data;
using AppPenilaianSiswa.DTOs.Kelas;
using AppPenilaianSiswa.DTOs.MessageRes;
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
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            using (var context = new AppDbContext())
            {
                try
                {

                    cbKelas.DataSource = await context.Kelas.Include(j => j.Jurusan).ToListAsync();
                    cbKelas.DisplayMember = "NamaKelas";
                    cbKelas.ValueMember = "KelasId";                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }


        private async Task LoadDataSiswa()
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    dgvSiswa.DataSource = await context.Siswas.Select(s => new
                    {
                        SiswaId = s.SiswaId,
                        NamaSiswa = s.NamaSiswa,
                        Nisn = s.Nisn,
                        Kelas = s.Kelas.NamaKelas,
                        Jurusan = s.Kelas.Jurusan.NamaJurusan,
                        Picture = s.SiswaPicture,
                    }).ToListAsync();



                    if (dgvSiswa.Columns.Contains("Picture"))
                    {
                        dgvSiswa.Columns["Picture"].Visible = false;
                    }
                    if (dgvSiswa.Columns.Contains("KelasId"))
                    {
                        dgvSiswa.Columns["KelasId"].Visible = false;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private async void SiswaForm_Load(object sender, EventArgs e)
        {
            await LoadDataSiswa();
            await LoadKelas();
            btnUpdate.Visible = false;
            btnBatal.Visible = false;
            lblNotif.Visible = false;
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
            if (imagePath == "")
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
            using (var context = new AppDbContext())
            {
                try
                {
                    var siswaBaru = new Siswa
                    {
                        Nisn = txtNISN.Text,
                        NamaSiswa = txtNamaSiswa.Text,
                        SiswaPicture = imagePath,
                        KelasId = Convert.ToInt32(cbKelas.SelectedValue)
                    };

                    var kelas = (Kelas)cbKelas.SelectedItem;

                    DialogResult res = MessageBox.Show($"Yakin ingin simpan data siswa?\n\nNISN: {siswaBaru.Nisn}\n\nJurusan: {kelas.Jurusan.NamaJurusan}" +
                    $"\n\nNama Siswa: {siswaBaru.NamaSiswa}\n\nKelas: {kelas.NamaKelas}", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (res == DialogResult.OK)
                    {
                        context.Siswas.Add(siswaBaru);
                        await context.SaveChangesAsync();

                        MessageBox.Show("Data berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataSiswa();
                        ClearForms();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            ClearForms();
            btnFoto.Enabled = true;
        }

        private void dgvSiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow data = dgvSiswa.Rows[e.RowIndex];

            txtNamaSiswa.Enabled = false;
            txtNISN.Enabled = false;
            btnFoto.Enabled = false;
            cbKelas.Enabled = false;

            txtNamaSiswa.Text = data.Cells["NamaSiswa"].Value.ToString();
            txtNISN.Text = data.Cells["Nisn"].Value.ToString();
            cbKelas.Text = data.Cells["Kelas"].Value.ToString();
            pbSiswa.ImageLocation = data.Cells["Picture"].Value.ToString();
            imagePath = data.Cells["Picture"].Value.ToString();
            SiswaId = Convert.ToInt32(data.Cells["SiswaId"].Value);
        }


        private async void tmData_Tick(object sender, EventArgs e)
        {
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    if (SiswaId == 0)
                    {
                        MessageBox.Show("Pilih data terlebih dahulu!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm != DialogResult.OK)
                    {
                        return;
                    }

                    var dataSiswa = await context.Siswas.FirstOrDefaultAsync(id => id.SiswaId == SiswaId);
                    if (dataSiswa != null)
                    {
                        context.Siswas.Remove(dataSiswa);
                        await context.SaveChangesAsync();
                        await LoadDataSiswa();
                        return;
                    }

                    MessageBox.Show($"Tidak ditemukan siswa dengan id {SiswaId}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                var kelas = (KelasResponseDTO)cbKelas.SelectedItem;

                var siswaUpdate = new SiswaUpdateDTO
                {
                    Nisn = txtNISN.Text,
                    NamaSiswa = txtNamaSiswa.Text,
                    KelasId = Convert.ToInt16(kelas.KelasId),
                    Picture = imagePath
                };

                DialogResult conf = MessageBox.Show("Yakin ingin mengupdate data?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (conf != DialogResult.OK) return;

                // update
                HttpResponseMessage res = await _hc.PutAsJsonAsync($"Siswas/{SiswaId}", siswaUpdate);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data berhasil diupdate!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataSiswa();
                    ClearForms();
                }
                else
                {
                    var raw = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Status: {res.StatusCode}\nResponse: {raw}");
                }

                // enable all button
                btnEdit.Enabled = true;
                btnTambah.Enabled = true;
                btnHapus.Enabled = true;
                btnSimpan.Enabled = true;
                btnBatal.Visible = false;
                btnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (SiswaId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //enable all textbox
            txtNamaSiswa.Enabled = true;
            txtNISN.Enabled = true;
            btnFoto.Enabled = true;
            cbKelas.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Visible = true;
            btnBatal.Visible = true;

            //disable all button
            btnTambah.Enabled = false;
            btnHapus.Enabled = false;
            btnSimpan.Enabled = false;

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {

            ClearForms();
            btnTambah.Enabled = true;
            btnHapus.Enabled = true;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = true;

            btnEdit.Visible = true;
            btnBatal.Visible = false;
            btnEdit.Visible = true;
            btnUpdate.Visible = false;

        }

        private async void txtNama_TextChanged(object sender, EventArgs e)
        {

            using (var context = new AppDbContext())
            {
                try
                {
                    await Task.Delay(300);                    
                    if (!string.IsNullOrWhiteSpace(txtNama.Text))
                    {

                        var dataSiswa = await context.Siswas
                            .Where(ns => ns.NamaSiswa.Contains(txtNama.Text))
                            .Select(s => new
                            {
                                SiswaId = s.SiswaId,
                                NamaSiswa = s.NamaSiswa,
                                Nisn = s.Nisn,
                                Kelas = s.Kelas.NamaKelas,
                                Jurusan = s.Kelas.Jurusan.NamaJurusan,
                                Picture = s.SiswaPicture,
                            })
                            .ToListAsync();

                        if (!dataSiswa.Any())
                        {
                            lblNotif.Visible = true;
                            dgvSiswa.DataSource = dataSiswa;
                        }
                        else
                        {
                            lblNotif.Visible = false;
                            dgvSiswa.DataSource = dataSiswa;
                        }
                    }
                    else
                    {
                        lblNotif.Visible = false;
                        await LoadDataSiswa();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}
