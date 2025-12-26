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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        string connectionString = @"Server=.\SQLExpress;Database=YoklamaSistemiDB;Integrated Security=True;";
        private void Menu_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            if (UserSession.RootStatus == "enable")
            {
                btnKodOlustur.Visible = true;
                btnYoklamaGoruntule.Visible = true;
                btnOgrenciGiris.Visible = false;
                lblUretilenKod.Visible = true;
                lblYetki.Text = "Yetki: Admin; Öğretmen NO: "+UserSession.TeacherID;
            }
            else
            {
                btnKodOlustur.Visible = false;
                btnYoklamaGoruntule.Visible = false;
                btnOgrenciGiris.Visible = true;
                lblYetki.Text = "Yetki: Standart Kullanıcı";
                lblUretilenKod.Visible = false;
            }
        }

        private void btnKodOlustur_Click(object sender, EventArgs e)
        {
            string finalCode = "";
            int codeLength = 5; 
            bool isUnique = false;
            int attemptCount = 0; 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                while (!isUnique)
                {
                    
                    finalCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, codeLength).ToUpper();

                    
                    string checkQuery = "SELECT COUNT(*) FROM YoklamaKodlari WHERE ders_kodu = @kod AND durum = 1";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@kod", finalCode);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        isUnique = true;
                    }
                    else
                    {
                        attemptCount++;
                        
                        if (attemptCount >= 5)
                        {
                            codeLength++;
                            attemptCount = 0;
                        }
                    }
                }

                string insertQuery = "INSERT INTO YoklamaKodlari (ders_kodu,olusturan_hoca_id, durum) VALUES (@kod,@TeacherID, 1)";
                SqlCommand insCmd = new SqlCommand(insertQuery, conn);
                insCmd.Parameters.AddWithValue("@kod", finalCode);
                insCmd.Parameters.AddWithValue("@TeacherID", UserSession.TeacherID);
                insCmd.ExecuteNonQuery();

                lblUretilenKod.Text = "Yoklama Kodu: " + finalCode;
                MessageBox.Show($"Kod başarıyla oluşturuldu: {finalCode}\nUzunluk: {codeLength} karakter.");
            }
        }

        private void btnOgrenciGiris_Click(object sender, EventArgs e)
        {
            OgrenciPaneli ogrenciPaneli = new OgrenciPaneli();
            ogrenciPaneli.ShowDialog();
        }

        private void btnYoklamaGoruntule_Click(object sender, EventArgs e)
        {
            HocaPaneliForm hocaPaneli = new HocaPaneliForm();
            hocaPaneli.ShowDialog();
        }
    }
}
