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
            }
        }

        public static List<EntitySecilenler> SecilenYonetmenleriGetir()
        {
            List<EntitySecilenler> secilenlerListesi = new List<EntitySecilenler>();
            string sorgu = "SELECT * FROM Tbl_Secilenler WHERE TUR = 'YÖNETMEN'";

            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntitySecilenler secilen = new EntitySecilenler
                    {
                        Kisi = oku["KISI"].ToString(),
                        Tur = oku["TUR"].ToString()
                    };
                    secilenlerListesi.Add(secilen);
                }
                oku.Close();
            }

            return secilenlerListesi;
        }

        // Seçilen oyuncuları getiren metod
        public static List<EntitySecilenler> SecilenOyunculariGetir()
        {
            List<EntitySecilenler> secilenlerListesi = new List<EntitySecilenler>();
            string sorgu = "SELECT * FROM Tbl_Secilenler WHERE TUR = 'OYUNCU'";

            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntitySecilenler secilen = new EntitySecilenler
                    {
                        Kisi = oku["KISI"].ToString(),
                        Tur = oku["TUR"].ToString()
                    };
                    secilenlerListesi.Add(secilen);
                }
                oku.Close();
            }

            return secilenlerListesi;
        }

        // Belirtilen KISI ve TUR'ye göre bir kayıt var mı diye kontrol eden metod
        public static bool SecilenOyuncuVarMi(string kisi)
        {
            string sorgu = "SELECT * FROM Tbl_Secilenler WHERE KISI = @kisi AND TUR = @tur";
            bool sonuc = false;

            using (SqlConnection conn = new SqlConnection(Baglanti.baglanti.ConnectionString))
            {
                conn.Open(); // Bağlantıyı aç

                using (SqlCommand komut = new SqlCommand(sorgu, conn))
                {
                    komut.Parameters.AddWithValue("@kisi", kisi);
                    komut.Parameters.AddWithValue("@tur", "OYUNCU");

                    using (SqlDataReader oku = komut.ExecuteReader())
                    {
                        if (oku.Read())
                        {
                            sonuc = true; // Eğer kayıt varsa true dön
                        }
                    }
                }
            }

            return sonuc;
        }

        public static bool SecilenYonetmenVarMi(string kisi)
        {
            string sorgu = "SELECT * FROM Tbl_Secilenler WHERE KISI = @kisi AND TUR = @tur";
            bool sonuc = false;

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {

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
            }

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
            }
        }
    }
}
