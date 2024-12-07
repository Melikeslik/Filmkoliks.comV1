using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALFilmler
    {
        //public static List<EntityFilmler> FilmListesiGetir()
        //{
        //    List<EntityFilmler> filmListesi = new List<EntityFilmler>();

        //    SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Filmler ORDER BY ADI ASC", Baglanti.baglanti);

        //    if (komut.Connection.State != ConnectionState.Open)
        //    {
        //        komut.Connection.Open();
        //    }

        //    SqlDataReader dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        EntityFilmler film = new EntityFilmler();
        //        film.Adi = dr["ADI"].ToString();
        //        film.Tarih = dr["TARIH"].ToString();
        //        filmListesi.Add(film);
        //    }

        //    dr.Close();
        //    return filmListesi;
        //}

        public static List<EntityFilmler> FilmListesiGetir()
        {
            List<EntityFilmler> filmListesi = new List<EntityFilmler>();
            string sorgu = "SELECT ADI, TARIH FROM Tbl_Filmler ORDER BY ADI ASC";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntityFilmler film = new EntityFilmler
                    {
                        Adi = oku["ADI"].ToString(),
                        // Tarihi DateTime olarak dönüştürüyoruz
                        Tarih = Convert.ToDateTime(oku["TARIH"]).ToString()
                    };
                    filmListesi.Add(film);
                }
                oku.Close();
            }

            return filmListesi;
        }


        // Bu metod, belirli bir film adı için tarihler listesini döndürecek
        public static List<string> TarihListesiGetir(string filmAdi)
        {
            List<string> tarihListesi = new List<string>();

            string sorgu = "SELECT DISTINCT TARIH FROM Tbl_Kontrol WHERE FILMADI=@filmAdi";

            SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti);
            komut.Parameters.AddWithValue("@filmAdi", filmAdi);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                tarihListesi.Add(oku["TARIH"].ToString());
            }

            oku.Close();
            return tarihListesi;
        }

        // Bilet numarasını sorgulayan metod
        public static bool BiletSorgula(string barkodNo)
        {
            string sorgu = "SELECT * FROM Tbl_Biletler WHERE BKOD=@no";
            SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti);
            komut.Parameters.AddWithValue("@no", barkodNo);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            bool sonuc = oku.Read();  // Eğer kayıt varsa true döner, yoksa false döner
            oku.Close();

            return sonuc;
        }
    }
}
