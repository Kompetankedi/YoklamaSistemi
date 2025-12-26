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
    public partial class OgrenciPaneli : Form
    {
        public OgrenciPaneli()
        {
            InitializeComponent();
        }
        string connectionString = @"Server=.\SQLExpress;Database=YoklamaSistemiDB;Integrated Security=True;";
        private void btnYoklamayaKatil_Click(object sender, EventArgs e)
        {
            string girilenKod = txtYoklamaKodu.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(girilenKod))
            {
                MessageBox.Show("Lütfen hocanızın verdiği kodu giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. ADIM: Kod veritabanında var mı ve AKTİF mi? (durum = 1)
                    string kodSorgu = "SELECT id FROM YoklamaKodlari WHERE ders_kodu = @kod AND durum = 1";
                    SqlCommand cmdKod = new SqlCommand(kodSorgu, conn);
                    cmdKod.Parameters.AddWithValue("@kod", girilenKod);

                    object kodIdResult = cmdKod.ExecuteScalar();

                    if (kodIdResult != null)
                    {
                        int yoklamaID = Convert.ToInt32(kodIdResult);

                        // 2. ADIM: Daha önce bu kodla yoklama verilmiş mi kontrolü (Mükerrer kaydı önler)
                        string kontrolSorgu = "SELECT COUNT(*) FROM Katilimcilar WHERE studentID = @sid AND yoklama_kod_id = @yid";
                        SqlCommand cmdKontrol = new SqlCommand(kontrolSorgu, conn);
                        cmdKontrol.Parameters.AddWithValue("@sid", UserSession.StudentID);
                        cmdKontrol.Parameters.AddWithValue("@yid", yoklamaID);

                        int varMi = (int)cmdKontrol.ExecuteScalar();

                        if (varMi > 0)
                        {
                            MessageBox.Show("Bu ders için zaten yoklama vermişsiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // 3. ADIM: Kaydı gerçekleştir
                        string insertQuery = @"INSERT INTO Katilimcilar (studentID, name, surname, yoklama_kod_id, katilis_tarihi) 
                                               VALUES (@sid, @name, @surname, @yid, GETDATE())";

                        SqlCommand insCmd = new SqlCommand(insertQuery, conn);
                        insCmd.Parameters.AddWithValue("@sid", UserSession.StudentID);
                        insCmd.Parameters.AddWithValue("@name", UserSession.Name);
                        insCmd.Parameters.AddWithValue("@surname", UserSession.Surname);
                        insCmd.Parameters.AddWithValue("@yid", yoklamaID);

                        insCmd.ExecuteNonQuery();

                        MessageBox.Show("Yoklamanız başarıyla alındı. Derste iyi eğlenceler!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Formu kapatıp ana menüye dönebilir
                    }
                    else
                    {
                        MessageBox.Show("Hatalı veya süresi dolmuş kod girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void OgrenciPaneli_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}

