using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoklamaSistem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        string connectionString = @"Server=.\SQLExpress;Database=YoklamaSistemiDB;Integrated Security=True;";
        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT root FROM logins WHERE loginName=@user AND loginPass=@pass";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUser.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Tek bir değer (root) döneceği için Scalar kullandık

                    if (result != null)
                    {
                        // Root kontrolü
                        int rootValue = Convert.ToInt32(result);

                        // Talebine göre: 1 ise enable, 0 ise disable
                        UserSession.UserName = txtUser.Text;
                        UserSession.RootStatus = (rootValue == 1) ? "enable" : "disable";

                        MessageBox.Show($"Giriş Başarılı! Yetki: {UserSession.RootStatus}", "Hoş Geldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ana Menüye Geçiş
                        Menu main = new Menu();
                        this.Hide();
                        main.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
    }
}
