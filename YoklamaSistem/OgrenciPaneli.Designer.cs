namespace YoklamaSistem
{
    partial class OgrenciPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciPaneli));
            this.btnKatil = new System.Windows.Forms.Button();
            this.txtYoklamaKodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKatil
            // 
            this.btnKatil.Location = new System.Drawing.Point(169, 47);
            this.btnKatil.Name = "btnKatil";
            this.btnKatil.Size = new System.Drawing.Size(88, 28);
            this.btnKatil.TabIndex = 0;
            this.btnKatil.Text = "Burda!!";
            this.btnKatil.UseVisualStyleBackColor = true;
            this.btnKatil.Click += new System.EventHandler(this.btnYoklamayaKatil_Click);
            // 
            // txtYoklamaKodu
            // 
            this.txtYoklamaKodu.Location = new System.Drawing.Point(138, 12);
            this.txtYoklamaKodu.Name = "txtYoklamaKodu";
            this.txtYoklamaKodu.Size = new System.Drawing.Size(119, 29);
            this.txtYoklamaKodu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Yoklama Kodu";
            // 
            // OgrenciPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYoklamaKodu);
            this.Controls.Add(this.btnKatil);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "OgrenciPaneli";
            this.Text = "Öğrenci Paneli";
            this.Load += new System.EventHandler(this.OgrenciPaneli_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKatil;
        private System.Windows.Forms.TextBox txtYoklamaKodu;
        private System.Windows.Forms.Label label1;
    }
}