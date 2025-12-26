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
            string query = "SELECT root, name, surname, studentID, teacherID FROM logins WHERE loginName=@user AND loginPass=@pass";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUser.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    UserSession.UserName = txtUser.Text;
                    UserSession.RootStatus = (Convert.ToInt32(dr["root"]) == 1) ? "enable" : "disable";
                    UserSession.Name = dr["name"].ToString();
                    UserSession.Surname = dr["surname"].ToString();

                    // Öğrenci ise StudentID, Öğretmen ise TeacherID doldurulur
                    UserSession.StudentID = dr["studentID"] != DBNull.Value ? Convert.ToInt64(dr["studentID"]) : 0;
                    UserSession.TeacherID = dr["teacherID"] != DBNull.Value ? Convert.ToInt64(dr["teacherID"]) : 0;

                    MessageBox.Show($"Hoş Geldiniz: {UserSession.Name} {UserSession.Surname}");

                    Menu main = new Menu();
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}