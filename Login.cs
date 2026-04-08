using AppPenilaianSiswa.Data;
using AppPenilaianSiswa.DTOs.Auths;
using AppPenilaianSiswa.DTOs.MessageRes;
using AppPenilaianSiswa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppPenilaianSiswa
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool ValidateLoginInput()
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

        private void ClearForm()
        {
            txtPassword.Clear();
            txtUsername.Clear();
            txtUsername.Focus();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    btnLogin.Enabled = false;
                    if (!ValidateLoginInput()) return;

                    string username = txtUsername.Text;
                    string password = txtPassword.Text;

                    var login = await context.Operators.Include(r => r.Role).FirstOrDefaultAsync(o => o.Username == username && o.Password == password);

                    if (login != null)
                    {
                        Session.OperatorId = login.OperatorId;
                        Session.Username = login.Username;
                        Session.Name = login.Nama;
                        Session.Role = login.Role.RoleName;

                        if (login.Role.RoleName.ToLower() == "admin")
                        {
                            new Dashboard().Show();
                            this.Hide();   
                        }                        
                    }else
                    {
                        MessageBox.Show("Username atau password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearForm();
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
}
