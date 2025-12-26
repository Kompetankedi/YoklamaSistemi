namespace YoklamaSistem
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblYetki = new System.Windows.Forms.Label();
            this.btnKodOlustur = new System.Windows.Forms.Button();
            this.btnYoklamaGoruntule = new System.Windows.Forms.Button();
            this.btnOgrenciGiris = new System.Windows.Forms.Button();
            this.lblUretilenKod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblYetki
            // 
            this.lblYetki.AutoSize = true;
            this.lblYetki.Location = new System.Drawing.Point(12, 9);
            this.lblYetki.Name = "lblYetki";
            this.lblYetki.Size = new System.Drawing.Size(92, 21);
            this.lblYetki.TabIndex = 0;
            this.lblYetki.Text = "bekleniyor";
            // 
            // btnKodOlustur
            // 
            this.btnKodOlustur.Location = new System.Drawing.Point(169, 69);
            this.btnKodOlustur.Name = "btnKodOlustur";
            this.btnKodOlustur.Size = new System.Drawing.Size(111, 32);
            this.btnKodOlustur.TabIndex = 1;
            this.btnKodOlustur.Text = "Kod oluştur";
            this.btnKodOlustur.UseVisualStyleBackColor = true;
            this.btnKodOlustur.Click += new System.EventHandler(this.btnKodOlustur_Click);
            // 
            // btnYoklamaGoruntule
            // 
            this.btnYoklamaGoruntule.Location = new System.Drawing.Point(295, 69);
            this.btnYoklamaGoruntule.Name = "btnYoklamaGoruntule";
            this.btnYoklamaGoruntule.Size = new System.Drawing.Size(179, 32);
            this.btnYoklamaGoruntule.TabIndex = 2;
            this.btnYoklamaGoruntule.Text = "Yoklama Görüntüle";
            this.btnYoklamaGoruntule.UseVisualStyleBackColor = true;
            this.btnYoklamaGoruntule.Click += new System.EventHandler(this.btnYoklamaGoruntule_Click);
            // 
            // btnOgrenciGiris
            // 
            this.btnOgrenciGiris.Location = new System.Drawing.Point(25, 69);
            this.btnOgrenciGiris.Name = "btnOgrenciGiris";
            this.btnOgrenciGiris.Size = new System.Drawing.Size(128, 32);
            this.btnOgrenciGiris.TabIndex = 3;
            this.btnOgrenciGiris.Text = "Öğrenci Girişi";
            this.btnOgrenciGiris.UseVisualStyleBackColor = true;
            this.btnOgrenciGiris.Click += new System.EventHandler(this.btnOgrenciGiris_Click);
            // 
            // lblUretilenKod
            // 
            this.lblUretilenKod.AutoSize = true;
            this.lblUretilenKod.Location = new System.Drawing.Point(165, 122);
            this.lblUretilenKod.Name = "lblUretilenKod";
            this.lblUretilenKod.Size = new System.Drawing.Size(137, 21);
            this.lblUretilenKod.TabIndex = 4;
            this.lblUretilenKod.Text = "Kod bekleniyor...";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 172);
            this.Controls.Add(this.lblUretilenKod);
            this.Controls.Add(this.btnOgrenciGiris);
            this.Controls.Add(this.btnYoklamaGoruntule);
            this.Controls.Add(this.btnKodOlustur);
            this.Controls.Add(this.lblYetki);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Menu";
            this.Text = "Ana Ekran";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYetki;
        private System.Windows.Forms.Button btnKodOlustur;
        private System.Windows.Forms.Button btnYoklamaGoruntule;
        private System.Windows.Forms.Button btnOgrenciGiris;
        private System.Windows.Forms.Label lblUretilenKod;
    }
}