namespace YoklamaSistem
{
    partial class HocaPaneliForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HocaPaneliForm));
            this.dtpYoklamaTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbGecmisKodlar = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.dgvGelenler = new System.Windows.Forms.DataGridView();
            this.lblHocaBilgi = new System.Windows.Forms.Label();
            this.btnExcelAktar = new System.Windows.Forms.Button();
            this.btnYoklamaBitir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGelenler)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpYoklamaTarihi
            // 
            this.dtpYoklamaTarihi.Location = new System.Drawing.Point(1, 31);
            this.dtpYoklamaTarihi.Name = "dtpYoklamaTarihi";
            this.dtpYoklamaTarihi.Size = new System.Drawing.Size(244, 29);
            this.dtpYoklamaTarihi.TabIndex = 0;
            // 
            // cmbGecmisKodlar
            // 
            this.cmbGecmisKodlar.FormattingEnabled = true;
            this.cmbGecmisKodlar.Location = new System.Drawing.Point(1, 66);
            this.cmbGecmisKodlar.Name = "cmbGecmisKodlar";
            this.cmbGecmisKodlar.Size = new System.Drawing.Size(145, 29);
            this.cmbGecmisKodlar.TabIndex = 1;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrele.Location = new System.Drawing.Point(470, 3);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFiltrele.Size = new System.Drawing.Size(165, 28);
            this.btnFiltrele.TabIndex = 2;
            this.btnFiltrele.Text = "Yoklamaları Getir";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // dgvGelenler
            // 
            this.dgvGelenler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGelenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGelenler.Location = new System.Drawing.Point(1, 184);
            this.dgvGelenler.Name = "dgvGelenler";
            this.dgvGelenler.Size = new System.Drawing.Size(647, 144);
            this.dgvGelenler.TabIndex = 3;
            // 
            // lblHocaBilgi
            // 
            this.lblHocaBilgi.AutoSize = true;
            this.lblHocaBilgi.Location = new System.Drawing.Point(12, 7);
            this.lblHocaBilgi.Name = "lblHocaBilgi";
            this.lblHocaBilgi.Size = new System.Drawing.Size(321, 21);
            this.lblHocaBilgi.TabIndex = 4;
            this.lblHocaBilgi.Text = "Hoş geldiniz, [Hoca Adı] - ID: [TeacherID]";
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelAktar.Location = new System.Drawing.Point(470, 37);
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.Size = new System.Drawing.Size(165, 58);
            this.btnExcelAktar.TabIndex = 5;
            this.btnExcelAktar.Text = "Listeyi Excel\'e Aktar";
            this.btnExcelAktar.UseVisualStyleBackColor = true;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);
            // 
            // btnYoklamaBitir
            // 
            this.btnYoklamaBitir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYoklamaBitir.Location = new System.Drawing.Point(470, 101);
            this.btnYoklamaBitir.Name = "btnYoklamaBitir";
            this.btnYoklamaBitir.Size = new System.Drawing.Size(165, 53);
            this.btnYoklamaBitir.TabIndex = 6;
            this.btnYoklamaBitir.Text = "Seçili Yoklamayı Kapat";
            this.btnYoklamaBitir.UseVisualStyleBackColor = true;
            this.btnYoklamaBitir.Click += new System.EventHandler(this.btnYoklamaBitir_Click);
            // 
            // HocaPaneliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 324);
            this.Controls.Add(this.btnYoklamaBitir);
            this.Controls.Add(this.btnExcelAktar);
            this.Controls.Add(this.lblHocaBilgi);
            this.Controls.Add(this.dgvGelenler);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.cmbGecmisKodlar);
            this.Controls.Add(this.dtpYoklamaTarihi);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "HocaPaneliForm";
            this.Text = "Yoklama Listesi";
            this.Load += new System.EventHandler(this.HocaPaneliForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGelenler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpYoklamaTarihi;
        private System.Windows.Forms.ComboBox cmbGecmisKodlar;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.DataGridView dgvGelenler;
        private System.Windows.Forms.Label lblHocaBilgi;
        private System.Windows.Forms.Button btnExcelAktar;
        private System.Windows.Forms.Button btnYoklamaBitir;
    }
}