using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//sql veritabanına ait kütüphaneyi eklemen ve bunu programa belirtmen gerekiyor.
using System.Data.SqlClient;


namespace Filmkoliks.comV1
{
    public partial class FrmAcilis : Form
    {
        public FrmAcilis()
        {
            InitializeComponent();
        }

        //connectionstring dediğimiz veritabanımızın yolunu projemize eklememiz gerekiyor.ve veritabanımızın yolunu programımıza söylememiz gerekiyor.
        //SqlConnection baglanti = new SqlConnection("Data Source=Veritabanımızın_Yolu;Initial Catalog=Veritabanımızın_Adı;Integrated Security=;True");
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // Kullanıcı Giriş İşlemlerini Gerçekleştireceğiz!
            // select update insert delete
            // şart ya da koşul cümlemiz WHERE idi.

            baglanti.Open();
            SqlCommand sorgula = new SqlCommand("select * from Tbl_Kullanicilar WHERE KADI=@username AND KSİFRE=@password", baglanti);
            sorgula.Parameters.AddWithValue("@username", txtKullaniciAdi.Text);
            sorgula.Parameters.AddWithValue("@password", txtSifre.Text);
            SqlDataReader oku = sorgula.ExecuteReader();
            
            if (oku.Read()) //okuma işlemi başarılı ise. Yani girmiş olduğumuz veriler veritabanında mevcut ise veya bilgiler eşleşiyor ise ya da bilgiler doğru ise yapılacak işlemler.
            {
                //MessageBox.Show("Giriş İşlemi Başarılı");
                FrmAnaform frm = new FrmAnaform();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE HATALI");
            }
            baglanti.Close();

            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Focus(); //imleci konumlandır.



                //veritabanına bağlanma işlemi sorgulama
               // baglanti.Open();
              //if (baglanti.State == ConnectionState.Open)
             // {
            //    MessageBox.Show("İşlem Başarılı");
           //  }
          // baglanti.Close();
        }

        private void FrmAcilis_Load(object sender, EventArgs e)
        {

        }
    }
}
