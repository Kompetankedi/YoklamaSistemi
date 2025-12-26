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
using System.Runtime.InteropServices; 
using Excel = Microsoft.Office.Interop.Excel;

namespace YoklamaSistem
{
    public partial class HocaPaneliForm : Form
    {
        public HocaPaneliForm()
        {
            InitializeComponent();
        }
        string connectionString = @"Server=.\SQLExpress;Database=YoklamaSistemiDB;Integrated Security=True;";
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Tarihe ve TeacherID'ye göre filtreleme yapıyoruz
                // SQL'de 'katilis_tarihi' kolonunu seçilen tarihle (Yıl-Ay-Gün) kıyaslıyoruz
                string query = @"SELECT K.studentID AS [Okul No], K.name AS [Ad], K.surname AS [Soyad], 
                         K.katilis_tarihi AS [Giriş Saati], Y.ders_kodu AS [Kullanılan Kod]
                         FROM Katilimcilar K
                         INNER JOIN YoklamaKodlari Y ON K.yoklama_kod_id = Y.id
                         WHERE Y.olusturan_hoca_id = @tid 
                         AND CAST(K.katilis_tarihi AS DATE) = @secilenTarih";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tid", UserSession.TeacherID);
                cmd.Parameters.AddWithValue("@secilenTarih", dtpYoklamaTarihi.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvGelenler.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Seçilen tarihte katılım kaydı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void HocaPaneliForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            lblHocaBilgi.Text = $"Hoş Geldiniz: {UserSession.Name}  {UserSession.Surname} (Öğretmen NO: {UserSession.TeacherID})";
            #region Form açıldığında hocanın aktif kodlarını combobox'a doldurur
            // Form açıldığında hocanın aktif kodlarını ComboBox'a doldurur
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, ders_kodu,olusturan_hoca_id FROM YoklamaKodlari WHERE olusturan_hoca_id = @tid AND durum = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tid", UserSession.TeacherID);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // ComboBox'ta ders kodunu gösterip, değer olarak ID'sini tutuyoruz
                    cmbGecmisKodlar.Items.Add(new { Text = dr["ders_kodu"].ToString(), Value = dr["id"] });
                }
                cmbGecmisKodlar.DisplayMember = "Text";
                cmbGecmisKodlar.ValueMember = "Value";
            }
            #endregion
        }

        private void btnYoklamaBitir_Click(object sender, EventArgs e)
        {
            if (cmbGecmisKodlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kapatmak istediğiniz kodu seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili öğenin içindeki ID'yi alıyoruz
            dynamic selectedItem = cmbGecmisKodlar.SelectedItem;
            int seciliKodId = selectedItem.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE YoklamaKodlari SET durum = 0 WHERE id = @id";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@id", seciliKodId);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Seçili yoklama kodu başarıyla sonlandırıldı.", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi güncellemek için ComboBox'tan kaldıralım
                cmbGecmisKodlar.Items.Remove(cmbGecmisKodlar.SelectedItem);
                cmbGecmisKodlar.Text = "";
            }
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            if (dgvGelenler.Rows.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel yüklü değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Cursor = Cursors.WaitCursor; // İşlem başladığında fareyi meşgul yap

            Excel.Workbooks workbooks = excelApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Yoklama Listesi";

            try
            {
                // 1. Sütun Başlıklarını Aktar
                for (int i = 1; i <= dgvGelenler.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dgvGelenler.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Font.Bold = true;
                    worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // 2. Verileri Aktar
                for (int i = 0; i < dgvGelenler.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvGelenler.Columns.Count; j++)
                    {
                        if (dgvGelenler.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvGelenler.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // 3. Görsel Düzenleme
                worksheet.Columns.AutoFit(); // Sütunları içeriğe göre genişlet
                excelApp.Visible = true; // Excel'i görünür yap

                MessageBox.Show("Liste başarıyla aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default; // Fareyi normale döndür

                // Bellek Temizliği (Arka planda Excel'in açık kalmaması için)
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(workbooks);
                Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
