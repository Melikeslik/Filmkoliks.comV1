using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALFilmler: Baglanti
    {

        public static List<EntityFilmler> FilmListesiGetir()
        {
            List<EntityFilmler> filmListesi = new List<EntityFilmler>();
            string sorgu = "SELECT ADI, TARIH FROM Tbl_Filmler ORDER BY ADI ASC";

            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
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

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
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
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
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

        public static EntityFilmler FilmDetayGetir(short id)
        {
            EntityFilmler film = null;

            string sorgu = "SELECT * FROM Tbl_Filmler WHERE ID=@p1";
            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                komut.Parameters.AddWithValue("@p1", id);

                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    film = new EntityFilmler
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        Adi = oku["ADI"].ToString(),
                        Turu = oku["TURU"].ToString(),
                        Ozellikleri = oku["OZELLIKLERI"].ToString(),
                        Yonetmen = oku["YONETMEN"].ToString(),
                        Oyuncu = oku["OYUNCU"].ToString(),
                        Detay = oku["DETAY"].ToString(),
                        Puan = oku["PUAN"].ToString(),
                        Afis = oku["AFIS"].ToString(),
                        Tarih = oku["TARIH"].ToString()
                    };
                }

                oku.Close();
            }

            return film;
        }

        // Veritabanına film ekleyen metod
        public static int FilmEkle(EntityFilmler film)
        {
            string sorgu = "INSERT INTO Tbl_Filmler (ADI, TURU, OZELLIKLERI, YONETMEN, OYUNCU, DETAY, PUAN, AFIS, TARIH) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8, @P9)";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.Parameters.AddWithValue("@P1", film.Adi);
                komut.Parameters.AddWithValue("@P2", film.Turu);
                komut.Parameters.AddWithValue("@P3", film.Ozellikleri);
                komut.Parameters.AddWithValue("@P4", film.Yonetmen);
                komut.Parameters.AddWithValue("@P5", film.Oyuncu);
                komut.Parameters.AddWithValue("@P6", film.Detay);
                komut.Parameters.AddWithValue("@P7", film.Puan);
                komut.Parameters.AddWithValue("@P8", film.Afis);
                komut.Parameters.AddWithValue("@P9", film.Tarih);

                int sonuc = komut.ExecuteNonQuery();
                komut.Connection.Close();
                return sonuc;  // Eklenen satır sayısını döndürüyoruz
            }
        }

        // Filmler tablosundaki tüm verileri alacak metot
        public static List<EntityFilmler> GetAllFilmler()
        {
            List<EntityFilmler> filmlerListesi = new List<EntityFilmler>();
            string sorgu = "SELECT * FROM Tbl_Filmler ORDER BY ADI ASC";
            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntityFilmler film = new EntityFilmler
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        Adi = oku["ADI"].ToString(),
                        Afis = oku["AFIS"].ToString()
                    };
                    filmlerListesi.Add(film);
                }
            }
            return filmlerListesi;
        }

        // Arama yapılacak metinle eşleşen filmleri almak için metot
        public static List<EntityFilmler> GetFilmlerBySearch(string searchText)
        {
            List<EntityFilmler> filmlerListesi = new List<EntityFilmler>();
            string sorgu = "SELECT * FROM Tbl_Filmler WHERE ADI LIKE @searchText collate Turkish_CI_AS ORDER BY ADI ASC";

            // Bağlantı nesnesi ve SQL komutunun kullanımı
            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                // Parametreyi ekle
                komut.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                // Eğer bağlantı kapalıysa aç
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                } 

                // Sorguyu çalıştır ve veriyi oku
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    // EntityFilmler nesnesini oluştur
                    EntityFilmler film = new EntityFilmler
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        Adi = oku["ADI"].ToString(),
                        Afis = oku["AFIS"].ToString()
                    };
                    // Listeye ekle
                    filmlerListesi.Add(film);
                }
            }
            // Filmleri döndür
            return filmlerListesi;
        }
    }
}
