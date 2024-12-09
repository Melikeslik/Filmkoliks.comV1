using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;
using DataAccessLayer;


namespace Filmkoliks.comV1
{
    public partial class FrmAcilis : Form
    {
        public FrmAcilis()
        {
            InitializeComponent();
            this.KeyPreview = true; // Formun klavye olaylarını dinlemesini sağla
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // Kullanıcı Giriş İşlemlerini Gerçekleştireceğiz!
            // select update insert delete
            // şart ya da koşul cümlemiz WHERE idi.

            
            // Kullanıcı bilgilerini alıyoruz
            EntityKullanicilar kullanici = new EntityKullanicilar
            {
                KAdi = txtKullaniciAdi.Text,
                KSifre = txtSifre.Text
            };

            // BL katmanı üzerinden giriş yapıyoruz
            bool girisBasarili = BLKullanicilar.GirisYap(kullanici);

            if (girisBasarili)
            {
                FrmAnaform frm = new FrmAnaform();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Formu temizliyoruz
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Focus(); // İmleci kullanıcı adı kutusuna getir
        }

        // Enter tuşuna basıldığında giriş yapılmasını sağlayacak event
        private void FrmAcilis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGirisYap.PerformClick(); // Giriş butonunu tetikle
                e.Handled = true; // Enter olayını işlenmiş olarak işaretle
                e.SuppressKeyPress = true; // Enter tuşunun varsayılan işlemini engelle
            }
        }
    }
}
