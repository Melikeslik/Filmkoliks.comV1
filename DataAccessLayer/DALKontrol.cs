using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALKontrol: Baglanti
    {
        public static List<EntityKontrol> SaatleriGetir(string filmAdi, string tarih)
        {
            List<EntityKontrol> saatListesi = new List<EntityKontrol>();
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");

            string sorgu = "SELECT DISTINCT SAAT FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@filmAdi", filmAdi);
            komut.Parameters.AddWithValue("@tarih", tarih);

            try
            {
                baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    EntityKontrol kontrol = new EntityKontrol
                    {
                        Saat = oku["SAAT"].ToString()
                    };
                    saatListesi.Add(kontrol);
                }
            }
            finally
            {
                baglanti.Close();
            }

            return saatListesi;
        }

        // Güncelleme işlemi
        public static int KontrolGuncelle(EntityKontrol kontrol, string gelenKoltuk)
        {
            string sorgu = "UPDATE Tbl_Kontrol SET KOLTUKLAR=@numara WHERE FILMADI=@filmadi AND TARIH=@tarih AND SAAT=@saat AND SALONADI=@salonadi";
            SqlCommand guncelle = new SqlCommand(sorgu, baglanti);

            if (gelenKoltuk == "")
            {
                guncelle.Parameters.AddWithValue("@numara", kontrol.Koltuklar);
            }
            else
            {
                guncelle.Parameters.AddWithValue("@numara", gelenKoltuk + "," + kontrol.Koltuklar);
            }

            guncelle.Parameters.AddWithValue("@filmadi", kontrol.FilmAdi);
            guncelle.Parameters.AddWithValue("@tarih", kontrol.Tarih);
            guncelle.Parameters.AddWithValue("@saat", kontrol.Saat);
            guncelle.Parameters.AddWithValue("@salonadi", kontrol.SalonAdi);

            if (baglanti.State != System.Data.ConnectionState.Open)
            {
                baglanti.Open();
            }

            int sonuc = guncelle.ExecuteNonQuery();
            baglanti.Close();

            return sonuc;
        }

        // Salonları getiren metot
        public static List<string> GetSalonlar(EntityKontrol kontrol)
        {
            List<string> salonlar = new List<string>();

            string sorgu = "SELECT DISTINCT SALONADI FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih AND SAAT=@saat";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@filmAdi", kontrol.FilmAdi);
            komut.Parameters.AddWithValue("@tarih", kontrol.Tarih);
            komut.Parameters.AddWithValue("@saat", kontrol.Saat);

            if (baglanti.State != System.Data.ConnectionState.Open)
            {
                baglanti.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                salonlar.Add(oku["SALONADI"].ToString());
            }

            baglanti.Close();

            return salonlar;
        }

        public static List<EntityKontrol> KoltukBilgisiGetir(string filmAdi, string tarih, string saat, string salonAdi)
        {
            List<EntityKontrol> koltukListesi = new List<EntityKontrol>();

            string sorgu = "SELECT * FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih AND SAAT=@saat AND SALONADI=@salonAdi";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@filmAdi", filmAdi);
            komut.Parameters.AddWithValue("@tarih", tarih);
            komut.Parameters.AddWithValue("@saat", saat);
            komut.Parameters.AddWithValue("@salonAdi", salonAdi);

            try
            {
                baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    EntityKontrol kontrol = new EntityKontrol
                    {
                        FilmAdi = oku["FILMADI"].ToString(),
                        Tarih = oku["TARIH"].ToString(),
                        Saat = oku["SAAT"].ToString(),
                        SalonAdi = oku["SALONADI"].ToString(),
                        Koltuklar = oku["KOLTUKLAR"].ToString()
                    };
                    koltukListesi.Add(kontrol);
                }
            }
            finally
            {
                baglanti.Close();
            }

            return koltukListesi;
        }
    }
}
