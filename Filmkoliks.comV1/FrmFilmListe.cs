using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmFilmListe : Form
    {
        public FrmFilmListe()
        {
            InitializeComponent();
        }

        //connectionstring
        //SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void FrmFilmListe_Load(object sender, EventArgs e)
        //{
        //    ListePaneli.Controls.Clear();
        //    string sorgu = "SELECT * FROM Tbl_Filmler ORDER BY ADI ASC";
        //    baglanti.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
        //    SqlDataReader oku = komut.ExecuteReader();
        //    while (oku.Read())
        //    {
        //        FilmListesi arac = new FilmListesi();
        //        arac.lblFilmAdi.Text = oku["ADI"].ToString();
        //        arac.pBResim.ImageLocation = oku["AFIS"].ToString();
        //        arac.lblIdNo.Text = oku["ID"].ToString();
        //        ListePaneli.Controls.Add(arac);
        //    }
        //    baglanti.Close();
        //}
        private void FrmFilmListe_Load(object sender, EventArgs e)
        {
            // Film listesini iş mantığı üzerinden al
            var filmlerListesi = BLFilmler.GetAllFilmler();

            // Listeyi temizle
            ListePaneli.Controls.Clear();

            // Her bir film için UI elemanlarını ekle
            foreach (var film in filmlerListesi)
            {
                FilmListesi arac = new FilmListesi();
                arac.lblFilmAdi.Text = film.Adi;
                arac.pBResim.ImageLocation = film.Afis;
                arac.lblIdNo.Text = film.Id.ToString();
                ListePaneli.Controls.Add(arac);
            }
        }

        //private void txtAramaYap_TextChanged(object sender, EventArgs e)
        //{
        //    ListePaneli.Controls.Clear();
        //    baglanti.Open();
        //    SqlCommand ara = new SqlCommand("select * from Tbl_Filmler Where ADI LIKE '%" + txtAramaYap.Text + "%' collate Turkish_CI_AS ORDER BY ADI ASC", baglanti);
        //    SqlDataReader oku = ara.ExecuteReader();
        //    while (oku.Read())
        //    {
        //        FilmListesi arac = new FilmListesi();
        //        arac.lblFilmAdi.Text = oku["ADI"].ToString();
        //        arac.pBResim.ImageLocation = oku["AFIS"].ToString();
        //        arac.lblIdNo.Text = oku["ID"].ToString();
        //        ListePaneli.Controls.Add(arac);
        //    }
        //    baglanti.Close();

        //}
        private void txtAramaYap_TextChanged(object sender, EventArgs e)
        {
            // Arama metnini al
            string searchText = txtAramaYap.Text;

            // Listeyi temizle
            ListePaneli.Controls.Clear();

            // İş mantığına bağlı olarak arama işlemini yap
            var filmlerListesi = BLFilmler.GetFilmlerBySearch(searchText);

            // Her bir film için UI elemanlarını ekle
            foreach (var film in filmlerListesi)
            {
                FilmListesi arac = new FilmListesi();
                arac.lblFilmAdi.Text = film.Adi;
                arac.pBResim.ImageLocation = film.Afis;
                arac.lblIdNo.Text = film.Id.ToString();
                ListePaneli.Controls.Add(arac);
            }
        }
    }
}
