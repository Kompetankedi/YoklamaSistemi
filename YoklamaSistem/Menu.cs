using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Menu_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            if (UserSession.RootStatus == "enable")
            {
                // Admin paneli butonunu aktif et
                btnAdminPanel.Enabled = true;
                lblYetki.Text = "Yetki: Admin";
            }
            else
            {
                // Admin panelini gizle veya devre dışı bırak
                btnAdminPanel.Enabled = false;
                lblYetki.Text = "Yetki: Standart Kullanıcı";
            }
        }
    }
}
