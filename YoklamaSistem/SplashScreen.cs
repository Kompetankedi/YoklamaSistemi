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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 5;
        }
        string connectionString = @"Server=.\SQLExpress;Database=YoklamaSistemiDB;Integrated Security=True;";
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            try
            {
                lblStatus.Text = "Sistem başlatılıyor...";
                await UpdateProgress(20); // Hata aldığın yer burasıydı, metod aşağıda tanımlı

                lblStatus.Text = "Veritabanı kontrol ediliyor...";
                await UpdateProgress(40);

                // SQL bağlantısını test et
                var result = await CheckDatabaseConnection();

                if (result.IsSuccess)
                {
                    lblStatus.Text = "Bağlantı başarılı!";
                    await UpdateProgress(100);

                    await Task.Delay(500);

                    // Login formuna git
                    LoginForm login = new LoginForm();
                    this.Hide();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "HATA: Bağlantı kurulamadı!";
                    // Hata kodunu gösteren mesaj kutusu
                    MessageBox.Show("SQL Hatası: " + result.ErrorMessage, "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Mesaj kutusu kapandıktan sonra uygulamayı tamamen kapatır
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message);
            }
        }

        // 3. ADIM: Eksik olan UpdateProgress metodu (Sınıfın içinde ama Load'ın dışında olmalı)
        private async Task UpdateProgress(int targetValue)
        {
            while (progressBar1.Value < targetValue)
            {
                progressBar1.Value += 1;
                await Task.Delay(15); // İlerleme hızı
            }
        }

        // 4. ADIM: Eksik olan CheckDatabaseConnection metodu
        private async Task<(bool IsSuccess, string ErrorMessage)> CheckDatabaseConnection()
        {
            return await Task.Run(() =>
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        return (true, null);
                    }
                    catch (Exception ex)
                    {
                        return (false, ex.Message);
                    }
                }
            });
        }
    }
}