using AppPenilaianSiswa.DTOs.Auths;
using AppPenilaianSiswa.DTOs.MessageRes;
using AppPenilaianSiswa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppPenilaianSiswa
{
    public partial class Login : Form
    {
        private readonly HttpClient _hc = new HttpClient();
        public Login()
        {
            _hc.BaseAddress = new Uri("http://192.168.1.2:5055/api/");
            InitializeComponent();
        }

        private bool Validate()
        {
            epLogin.Clear();
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                epLogin.SetError(txtUsername,"Userame harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epLogin.SetError(txtPassword, "Password harus diisi!");
                return false;
            }

            return true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnLogin.Enabled = false;
                if (!Validate()) return;

                var login = new LoginRequestDTO
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                };

                HttpResponseMessage res = await _hc.PostAsJsonAsync("Auths/login", login);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<AuthResponseDTO>();

                    Session.OperatorId = data.OperatorId;
                    Session.Username = data.Username;
                    //Session.Name = user.Nama;
                    Session.OperatorId = data.OperatorId;
                    Session.Role = data.Role;

                    if (data.Role.ToLower() != "admin")
                    {
                        MessageBox.Show("Ini masih dalam tahap pengembangan!");
                        return;
                    }

                    new Dashboard().Show();
                    this.Hide();
                } else if (res.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var error = await res.Content.ReadFromJsonAsync<MessageRes>();
                    var errorMessage = error.message;
                    MessageBox.Show(errorMessage, "Notif", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
            
        }
    }
}
