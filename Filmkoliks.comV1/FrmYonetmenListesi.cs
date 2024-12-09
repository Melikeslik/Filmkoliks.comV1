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
using DataAccessLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmYonetmenListesi : Form
    {
        public FrmYonetmenListesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYonetmenListesi_Load(object sender, EventArgs e)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            ListePaneli.Controls.Clear();
            string sorgu = "select * from Tbl_Yonetmenler ORDER BY ADSOYAD ASC";
            
            SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                YonetmenListesi arac = new YonetmenListesi();
                arac.lblId.Text = oku["ID"].ToString();
                arac.lblAdSoyad.Text = oku["ADSOYAD"].ToString();
                arac.pBResimDetay.ImageLocation = oku["RESIM"].ToString();
                ListePaneli.Controls.Add(arac);
            }
            Baglanti.baglanti.Close();
        }

        private void txtAramaYap_TextChanged(object sender, EventArgs e)
        {
            ListePaneli.Controls.Clear();
            Baglanti.baglanti.Open();
            SqlCommand ara = new SqlCommand("select * from Tbl_Yonetmenler Where ADSOYAD LIKE '%"+ txtAramaYap.Text +"%' collate Turkish_CI_AS ORDER BY ADSOYAD ASC", Baglanti.baglanti);
            SqlDataReader oku = ara.ExecuteReader();
            while (oku.Read())
            {
                YonetmenListesi arac = new YonetmenListesi();
                arac.lblId.Text = oku["ID"].ToString();
                arac.lblAdSoyad.Text = oku["ADSOYAD"].ToString();
                arac.pBResimDetay.ImageLocation = oku["RESIM"].ToString();
                ListePaneli.Controls.Add(arac);
            }
            Baglanti.baglanti.Close();
        }
    }
}
