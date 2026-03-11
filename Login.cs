using AppPenilaianSiswa.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppPenilaianSiswa
{
    public partial class Login : Form
    {
        public Login()
        {
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
            btnLogin.Enabled = false;
            try
            {
                if (!Validate()) return;

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                using (var db = new AppDbContext())
                {
                    var user = await db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username);
                    if (user == null)
                    {
                        MessageBox.Show($"Tidak ada user dengan username {username}", "Gagal login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                    if (!isValid)
                    {
                        MessageBox.Show("Username atau password salah!", "Gagal login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Session.Username = user.Username;
                    Session.Name = user.Nama;
                    Session.Role = user.Role.RoleName;

                    if (Session.Role.ToLower() != "admin")
                    {
                        MessageBox.Show("Masih dalam tahap pengembangan");
                        return;
                    }

                    new Dashboard().Show();
                    this.Hide();
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
