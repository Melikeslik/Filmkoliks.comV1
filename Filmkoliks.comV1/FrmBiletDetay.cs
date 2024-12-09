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
using DataAccessLayer;
using LogicLayer;
using System.Data.SqlClient;

namespace Filmkoliks.comV1
{
    public partial class FrmBiletDetay : Form
    {
        public FrmBiletDetay()
        {
            InitializeComponent();
        }
        public string biletNo = "";

        private void FrmBiletDetay_Load(object sender, EventArgs e)
        {
            lblBiletNo.Text = biletNo;
            lblBiletNo2.Text = biletNo;
            barkodNoOlustur();
            bilgiGetir();

        }

        void bilgiGetir()
        {
            // Logic katmanına BKOD ile bilet sorgulama isteği gönderiyoruz
            EntityBiletler bilet = BLBiletler.BLBiletGetir(biletNo);

            if (bilet != null)
            {
                // Bilet bulundu, formdaki alanları dolduruyoruz
                lblFilmAdi.Text = bilet.FilmAdi;
                lblFilmAdi2.Text = bilet.FilmAdi;
                lblTelNo.Text = bilet.TelNo;
                lblAdSoyad.Text = bilet.AdSoyad;
                lblBiletTuru.Text = bilet.Tur;
                lblSalonAdi.Text = bilet.Salon;
                lblSalon2.Text = bilet.Salon;
                lblTarih2.Text = bilet.Tarih + " " + bilet.Saat;
                lblTarihSaat.Text = bilet.Tarih + " " + bilet.Saat;
                lblIslemTarihi.Text = bilet.IslemSaati;
                lblKoltuklar.Text = bilet.KoltukNo;
                lblKoltuk2.Text = bilet.KoltukNo;
            }
            else
            {
                // Bilet bulunamadı
                MessageBox.Show("Bu kod ile bilet bulunamadı.");
            }
        }
        void barkodNoOlustur()
        {
            Random rastgele = new Random();
            string karakterler = "123456789012345678901234567890123456789012345678901234567890123456789";
            string kod = "";

            for (int i = 1; i < 11; i++) 
            {
                kod += karakterler[rastgele.Next(karakterler.Length)];
            }
            lblBarkod1.Text = kod.ToString();
            lblBarkod2.Text = kod.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
