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
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmSalonAtama : Form
    {
        public FrmSalonAtama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSalonAtama_Load(object sender, EventArgs e)
        {
            filmAdiGetir();
            bugununTarihi();
            salonAdiGetir();
        }

        void filmAdiGetir()
        {
            List<EntityFilmler> filmler = BLFilmler.GetAllFilmler();
            foreach (var film in filmler)
            {
                string gelenTarih = film.Tarih;

                DateTime fTarih = Convert.ToDateTime(gelenTarih);
                DateTime bugun = DateTime.Today;

                TimeSpan timeSpan = fTarih - bugun;
                if (timeSpan.TotalDays >= 0)
                {
                    cbFilmAdi.Items.Add(film.Adi.ToString());
                }
            }
        }

        void salonAdiGetir()
        {
            List<EntitySalonlar> salonlar = BLSalonlar.BLSalonAdiGetir();
            foreach (var salon in salonlar)
            {
                cbSalon.Items.Add(salon.SalonAdi.ToString());
            }
        }

        void bugununTarihi()
        {
            nGun.Value = DateTime.Today.Day;
            nAy.Value = DateTime.Today.Month;
            nYil.Value = DateTime.Today.Year;
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            if (btnOlustur.Text == "TAMAMLA")
            {
                string tarih = nGun.Value + "-" + nAy.Value + "-" + nYil.Value;
                string salonAdi = cbSalon.Text.ToString();

                // BL üzerinden dolu saatleri getiriyoruz
                List<EntityKontrol> doluSaatler = BLKontrol.DoluSaatleriGetir(tarih, salonAdi);

                // ComboBox'a dolu saatleri ekliyoruz
                cbDoluSaatler.Items.Clear();
                foreach (EntityKontrol saat in doluSaatler)
                {
                    cbDoluSaatler.Items.Add(saat.Saat);
                }

                seansKONTROL();

                btnOlustur.Text = "OLUŞTUR";
            }
            else
            {
                kaydet();
                temizle();
                btnOlustur.Text = "TAMAMLA";
            }
        }
        void kaydet()
        {
            string tarih = nGun.Value + "-" + nAy.Value + "-" + nYil.Value;
            // Yeni bir EntityKontrol nesnesi oluşturuyoruz ve kaydediyoruz
            EntityKontrol entityKontrol = new EntityKontrol
            {
                FilmAdi = cbFilmAdi.Text,
                Tarih = tarih,
                Saat = lblSecilen.Text,
                SalonAdi = cbSalon.Text
            };

            BLKontrol.BLSeansKaydet(entityKontrol);

            MessageBox.Show("SALON ATAMA İŞLEMİ GERÇEKLEŞTİRİLDİ");
        }

        private void SeansSaatler( object sender, EventArgs e)
        {
            // foreach
            foreach( RadioButton item in panelSEANS.Controls)
            {
                if(item.Checked) //true
                {
                    lblSecilen.Text = item.Text.ToString();
                }
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        void temizle()
        {
            cbFilmAdi.Items.Clear();
            cbSalon.Items.Clear();
            cbDoluSaatler.Items.Clear();
            lblSecilen.Text = "";
            bugununTarihi();
            filmAdiGetir();
            salonAdiGetir();
            panelSEANS.Controls.Clear();
            btnOlustur.Text = "TAMAMLA";
        }

        void seansKONTROL()
           {
          
            panelSEANS.Controls.Clear();

            for (int i = 10; i <= 22; i++) //saat 10.00 için 
            {
                for (int j = 0; j <= 30; j += 30) //dakika 10.30
                {
                    RadioButton rnd = new RadioButton();
                    rnd.BackColor = Color.YellowGreen;
                    rnd.FlatStyle = FlatStyle.Flat;
                    rnd.Width = 70;
                    rnd.Font = new System.Drawing.Font("Segoe UI Semibold", 12);
                    rnd.CheckedChanged += new EventHandler(SeansSaatler);
                    if (j == 0)
                    {
                        rnd.Text = i.ToString() + ":" + j.ToString() + "0";
                    }
                    else
                    {
                        rnd.Text = i.ToString() + ":" + j.ToString();
                    }
                    if (cbDoluSaatler.Items.Contains(rnd.Text))
                    {
                        rnd.Visible = false;
                    }

                    panelSEANS.Controls.Add(rnd);
                }
            }
        }
    }
}
