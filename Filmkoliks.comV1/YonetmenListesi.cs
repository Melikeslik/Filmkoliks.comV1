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
    public partial class YonetmenListesi : UserControl
    {
        public YonetmenListesi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");

        private void YonetmenListesi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from Tbl_Yonetmenler WHERE ID=@P1";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", lblId.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblCinsiyet.Text = oku["CINSIYET"].ToString();
            }
            baglanti.Close();

            if (lblCinsiyet.Text == "0")
            {
                //erkek
                pbCinsiyet.Image = (System.Drawing.Image)(Properties.Resources.erkek);
            }
            else
            {
                //kadın
                pbCinsiyet.Image = (System.Drawing.Image)(Properties.Resources.kadin);
            }

        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from Tbl_Yonetmenler WHERE ID=@P1";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", lblId.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("BİYOGRAFİ: " + oku["BIYOGRAFI"].ToString(), oku["ADSOYAD"].ToString());
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from Tbl_Yonetmenler Where ID= @p1", baglanti);
            sil.Parameters.AddWithValue("@p1", lblId.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(lblAdSoyad.Text + " Kişisine Ait Kayıt Silinmiştir!");
            this.Hide(); // UserControl aracımızı gizledik.Tüm araçlar gizlenmeyecektir. Sadece silmiş olduğumuz satır ekrandan kaldırılır.
        }
    }
}
