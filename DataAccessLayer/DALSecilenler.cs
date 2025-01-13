using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALSecilenler : Baglanti
    {

        // Tüm seçilenleri silen metod
        public static void SecilenleriSil()
        {
            string sorgu = "DELETE FROM Tbl_Secilenler";

            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.ExecuteNonQuery();

                komut.Connection.Close();
            }
        }

        public static List<EntitySecilenler> SecilenYonetmenleriGetir()
        {
            List<EntitySecilenler> secilenlerListesi = new List<EntitySecilenler>();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Secilenler WHERE TUR = 'YONETMEN'", baglanti);

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntitySecilenler secilen = new EntitySecilenler();
                secilen.Kisi = oku["KISI"].ToString();
                secilen.Tur = "YONETMEN";
                secilenlerListesi.Add(secilen);
            }
            oku.Close();

            return secilenlerListesi;
        }

        // Seçilen oyuncuları getiren metod
        public static List<EntitySecilenler> SecilenOyunculariGetir()
        {
            List<EntitySecilenler> secilenlerListesi = new List<EntitySecilenler>();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Secilenler WHERE TUR = 'OYUNCU'", baglanti);

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntitySecilenler secilen = new EntitySecilenler();
                secilen.Kisi = oku["KISI"].ToString();
                secilen.Tur = "OYUNCU";
                secilenlerListesi.Add(secilen);
            }
            oku.Close();

            return secilenlerListesi;
        }

        // Belirtilen KISI ve TUR'e göre bir kayıt var mı diye kontrol eden metod
        public static bool SecilenOyuncuVarMi(string kisi)
        {
            string sorgu = "SELECT * FROM Tbl_Secilenler WHERE KISI = @kisi AND TUR = @tur";
            bool sonuc = false;

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@kisi", kisi);
            komut.Parameters.AddWithValue("@tur", "OYUNCU");

            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                sonuc = true; // Eğer kayıt varsa true dön
            }
            oku.Close();
            komut.Connection.Close();

            return sonuc;
        }

        public static bool SecilenYonetmenVarMi(string kisi)
        {
            string sorgu = "SELECT * FROM Tbl_Secilenler WHERE KISI = @kisi AND TUR = @tur";
            bool sonuc = false;

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@kisi", kisi);
            komut.Parameters.AddWithValue("@tur", "YONETMEN");

            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                sonuc = true;
            }
            oku.Close();
            komut.Connection.Close();
            return sonuc;
        }

        // Oyuncu ve yönetmen ekleme metodunu oluşturuyoruz
        public static void SecilenOyuncuEkle(string kisi)
        {
            string sorgu = "INSERT INTO Tbl_Secilenler (KISI, TUR) VALUES (@kisi, @tur)";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.Parameters.AddWithValue("@kisi", kisi);
                komut.Parameters.AddWithValue("@tur", "OYUNCU");


                komut.ExecuteNonQuery();

                komut.Connection.Close();
            }
        }
        public static void SecilenYonetmenEkle(string kisi)
        {
            string sorgu = "INSERT INTO Tbl_Secilenler (KISI, TUR) VALUES (@kisi, @tur)";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@kisi", kisi);
                komut.Parameters.AddWithValue("@tur", "YONETMEN");

                komut.ExecuteNonQuery();

                komut.Connection.Close();
            }
        }

        // Oyuncu ve yönetmen silme metodunu oluşturuyoruz
        public static void SecilenOyuncuSil(string kisi)
        {
            string sorgu = "DELETE FROM Tbl_Secilenler WHERE KISI=@kisi AND TUR=@tur";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@kisi", kisi);
                komut.Parameters.AddWithValue("@tur", "OYUNCU");

                komut.ExecuteNonQuery();

                komut.Connection.Close();
            }
        }

        public static void SecilenYonetmenSil(string kisi)
        {
            string sorgu = "DELETE FROM Tbl_Secilenler WHERE KISI=@kisi AND TUR=@tur";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@kisi", kisi);
                komut.Parameters.AddWithValue("@tur", "YONETMEN");

                komut.ExecuteNonQuery();

                komut.Connection.Close();
            }
        }
    }
}
