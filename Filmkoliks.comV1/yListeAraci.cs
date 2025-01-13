using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class yListeAraci : UserControl
    {
        public yListeAraci()
        {
            InitializeComponent();
        }

        private void lblAdi_Click(object sender, EventArgs e)
        {
            // Eğer label'ın rengi eski ise, yani oyuncu daha önce seçilmemişse
            if (lblAdi.ForeColor == Color.FromArgb(17, 28, 43))
            {
                // Rengi değiştiriyoruz
                lblAdi.ForeColor = Color.FromArgb(249, 164, 26);
                pictureBox1.Image = (System.Drawing.Image)(Properties.Resources.sariPlus);

                // Oyuncuyu veritabanına ekliyoruz
                BLSecilenler.SecilenYonetmenEkle(lblAdi.Text);
            }
            else
            {
                // Eğer oyuncu zaten seçilmişse, silme işlemi yapılır
                lblAdi.ForeColor = Color.FromArgb(17, 28, 43);
                pictureBox1.Image = (System.Drawing.Image)Properties.Resources.plusDark;

                // Oyuncuyu veritabanından siliyoruz
                BLSecilenler.SecilenYonetmenSil(lblAdi.Text);
            }
        }

        private void lblAdi_MouseMove(object sender, MouseEventArgs e)
        {
            lblAdi.Font = new Font(lblAdi.Font.Name, 12, FontStyle.Underline); //Labelin altını çiz.
        }

        private void lblAdi_MouseLeave(object sender, EventArgs e)
        {
            lblAdi.Font = new Font(lblAdi.Font.Name, 12, FontStyle.Regular); //Eski haline döndermiş oluyoruz.

        }

        private void yListeAraci_Load(object sender, EventArgs e)
        {
            // BL katmanından, oyuncunun seçili olup olmadığını kontrol ediyoruz
            bool secilenVarMi = BLSecilenler.SecilenYonetmenVarMi(lblAdi.Text);

            // Duruma göre label'ın rengi ve resim değiştiriliyor
            if (secilenVarMi)
            {
                lblAdi.ForeColor = Color.FromArgb(249, 164, 26);
                pictureBox1.Image = (System.Drawing.Image)(Properties.Resources.sariPlus);
            }
            else
            {
                lblAdi.ForeColor = Color.FromArgb(17, 28, 43);
                pictureBox1.Image = (System.Drawing.Image)Properties.Resources.plusDark;
            }
        }
    }
}
