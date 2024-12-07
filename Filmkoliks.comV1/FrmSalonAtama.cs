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

namespace Filmkoliks.comV1
{
    public partial class FrmSalonAtama : Form
    {
        public FrmSalonAtama()
        {
            InitializeComponent();
        }
        //connectionstring
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");
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
            string sorgu = "select * from Tbl_Filmler ORDER BY ADI ASC";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string gelenTarih = oku["TARIH"].ToString();

                DateTime fTarih = Convert.ToDateTime(gelenTarih);
                DateTime bugun = DateTime.Today;

                TimeSpan timeSpan = fTarih - bugun;
                if (timeSpan.TotalDays >= 0)
                {
                    cbFilmAdi.Items.Add(oku["ADI"].ToString());
                }
            }
            baglanti.Close();
        }

        void salonAdiGetir()
        {
            string sorgu = "select * from Tbl_Salonlar ORDER BY SALONADI ASC";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

            cbSalon.Items.Add(oku["SALONADI"].ToString());

            }
            baglanti.Close();
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

                //
                string sorgu = "select DISTINCT SAAT from Tbl_Kontrol WHERE TARIH=@tarih AND SALONADI=@salonadi";
                string tarih = nGun.Value + "-" + nAy.Value + "-" + nYil.Value;
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@tarih", tarih);
                komut.Parameters.AddWithValue("@salonadi", cbSalon.Text.ToString());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    cbDoluSaatler.Items.Add(oku["SAAT"].ToString());
                }
                baglanti.Close();

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
            string sorgu = "insert into Tbl_Kontrol (FILMADI, TARIH, SAAT, SALONADI) Values (@filmadi, @tarih, @saat, @salonadi)";
            string tarih = nGun.Value + "-" + nAy.Value + "-" + nYil.Value;
            baglanti.Open();
            SqlCommand ekle = new SqlCommand(sorgu, baglanti);
            ekle.Parameters.AddWithValue("@filmadi", cbFilmAdi.Text);
            ekle.Parameters.AddWithValue("@tarih", tarih);
            ekle.Parameters.AddWithValue("@saat", lblSecilen.Text);
            ekle.Parameters.AddWithValue("salonadi", cbSalon.Text);
            ekle.ExecuteNonQuery();

            baglanti.Close();
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

        private void cbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbFilmAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
