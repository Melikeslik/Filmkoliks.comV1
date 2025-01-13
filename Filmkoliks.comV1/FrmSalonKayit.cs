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
using System.Xml.Schema;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmSalonKayit : Form
    {
        public FrmSalonKayit()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            if (txtSalonAdi.Text != "" && cbKoltukSayisi.Text != "")
            {
                EntitySalonlar yeniSalon = new EntitySalonlar
                {
                    SalonAdi = txtSalonAdi.Text,
                    KoltukSayisi = cbKoltukSayisi.Text
                };

                // BL katmanına salon kaydetme isteğini gönderiyoruz
                BLSalonlar.SalonKaydet(yeniSalon);

                MessageBox.Show("SALON KAYDETME İŞLEMİ GERÇEKLEŞTİRİLDİ");
                txtSalonAdi.Text = "";
                cbKoltukSayisi.Text = "";
                txtSalonAdi.Focus();
                listeGetir();
            }
            else
            {
                MessageBox.Show("LÜTFEN BİR DEĞER GİRİNİZ!");
            }

        }

        private void FrmSalonKayit_Load(object sender, EventArgs e)
        {
            listeGetir();
        }

        void kOlustur()
        {
            for ( int i=1; i<=200; i++)
            {
                cbKoltukSayisi.Items.Add(i);
            }
        }

        void listeGetir()
        {
            List<EntitySalonlar> salonlar = BLSalonlar.BLSalonAdiGetir();
            foreach (var salon in salonlar)
            {
                salonListesi arac = new salonListesi();
                arac.lblSalonAdi.Text =salon.SalonAdi.ToString();
                arac.lblKoltukSayisi.Text = salon.KoltukSayisi.ToString();
                panelSalon.Controls.Add(arac);
            }
        }
    }
}
