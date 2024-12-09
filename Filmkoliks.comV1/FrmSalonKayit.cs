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

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            if (txtSalonAdi.Text != "" && cbKoltukSayisi.Text != "")
            {
                Baglanti.baglanti.Open();
                SqlCommand kaydet = new SqlCommand("insert into Tbl_Salonlar (SALONADI, KOLTUKSAYISI) VALUES (@P1, @P2)" , Baglanti.baglanti);
                kaydet.Parameters.AddWithValue("@p1", txtSalonAdi.Text);
                kaydet.Parameters.AddWithValue("@p2", cbKoltukSayisi.Text);
                kaydet.ExecuteNonQuery();
                Baglanti.baglanti.Close();
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
       
        private void panelSalon_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            panelSalon.Controls.Clear();
            Baglanti.baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Salonlar ORDER BY SALONADI ASC", Baglanti.baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                salonListesi arac = new salonListesi();
                arac.lblSalonAdi.Text = oku["SALONADI"].ToString();
                arac.lblKoltukSayisi.Text = oku["KOLTUKSAYISI"].ToString();
                panelSalon.Controls.Add(arac);
            }
            Baglanti.baglanti.Close();
        }
    }
}
