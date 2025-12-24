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
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.btnYoklama = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblYetki
            // 
            this.lblYetki.AutoSize = true;
            this.lblYetki.Location = new System.Drawing.Point(12, 9);
            this.lblYetki.Name = "lblYetki";
            this.lblYetki.Size = new System.Drawing.Size(112, 28);
            this.lblYetki.TabIndex = 0;
            this.lblYetki.Text = "bekleniyor";
            // 
            // btnAdminPanel
            // 
            this.btnAdminPanel.Location = new System.Drawing.Point(304, 73);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(136, 47);
            this.btnAdminPanel.TabIndex = 1;
            this.btnAdminPanel.Text = "Öğrenciler";
            this.btnAdminPanel.UseVisualStyleBackColor = true;
            // 
            // btnYoklama
            // 
            this.btnYoklama.Location = new System.Drawing.Point(77, 73);
            this.btnYoklama.Name = "btnYoklama";
            this.btnYoklama.Size = new System.Drawing.Size(136, 47);
            this.btnYoklama.TabIndex = 2;
            this.btnYoklama.Text = "Yoklama";
            this.btnYoklama.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 172);
            this.Controls.Add(this.btnYoklama);
            this.Controls.Add(this.btnAdminPanel);
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
        private System.Windows.Forms.Button btnAdminPanel;
        private System.Windows.Forms.Button btnYoklama;
    }
}