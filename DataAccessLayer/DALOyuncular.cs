using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALOyuncular
    {
        public static List<EntityOyuncular> OyuncuListesiGetir()
        {
            List<EntityOyuncular> oyuncuListesi = new List<EntityOyuncular>();
            string sorgu = "SELECT * FROM Tbl_Oyuncular ORDER BY ADSOYAD ASC";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntityOyuncular oyuncu = new EntityOyuncular
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Cinsiyet = oku["CINSIYET"].ToString(),
                        Yas = oku["YAS"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString(),
                        Resim = oku["RESIM"].ToString()
                    };
                    oyuncuListesi.Add(oyuncu);
                }
                oku.Close();
            }

            return oyuncuListesi;
        }

        public static List<EntityOyuncular> OyuncuAra(string aranan)
        {
            List<EntityOyuncular> oyuncuListesi = new List<EntityOyuncular>();
            string sorgu = "SELECT * FROM Tbl_Oyuncular WHERE ADSOYAD LIKE @aranan ORDER BY ADSOYAD ASC";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                komut.Parameters.AddWithValue("@aranan", "%" + aranan + "%");

                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntityOyuncular oyuncu = new EntityOyuncular
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Cinsiyet = oku["CINSIYET"].ToString(),
                        Yas = oku["YAS"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString(),
                        Resim = oku["RESIM"].ToString()
                    };
                    oyuncuListesi.Add(oyuncu);
                }
                oku.Close();
            }

            return oyuncuListesi;
        }

        // Oyuncu bilgilerini çekme
        public static EntityOyuncular OyuncuGetir(short id)
        {
            EntityOyuncular oyuncu = null;
            string sorgu = "SELECT * FROM Tbl_Oyuncular WHERE ID=@id";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                komut.Parameters.AddWithValue("@id", id);

                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    oyuncu = new EntityOyuncular
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Cinsiyet = oku["CINSIYET"].ToString(),
                        Yas = oku["YAS"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString(),
                        Resim = oku["RESIM"].ToString()
                    };
                }
            }

            return oyuncu;
        }

        // Oyuncu silme işlemi
        public static bool OyuncuSil(short id)
        {
            string sorgu = "DELETE FROM Tbl_Oyuncular WHERE ID = @id";
            bool result = false;

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                komut.Parameters.AddWithValue("@id", id);

                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                int rowsAffected = komut.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    result = true; // Silme başarılı
                }
            }

            return result;
        }

        // Oyuncunun biyografisini ve adını getiren metot
        public static EntityOyuncular GetOyuncuById(short id)
        {
            string sorgu = "SELECT * FROM Tbl_Oyuncular WHERE ID = @id";
            EntityOyuncular oyuncu = null;

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                komut.Parameters.AddWithValue("@id", id);
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    oyuncu = new EntityOyuncular
                    {
                        Id = id,
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString()
                    };
                }
            }

            return oyuncu;
        }

        // Oyuncu eklemek için metot
        public static void AddOyuncu(EntityOyuncular oyuncu)
        {
            string sorgu = "INSERT INTO Tbl_Oyuncular (ADSOYAD, CINSIYET, YAS, BIYOGRAFI, RESIM) VALUES (@p1, @p2, @p3, @p4, @p5)";

            // SQL komutunu oluştur
            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                // Parametreleri ekle
                komut.Parameters.AddWithValue("@p1", oyuncu.AdSoyad);
                komut.Parameters.AddWithValue("@p2", oyuncu.Cinsiyet);
                komut.Parameters.AddWithValue("@p3", oyuncu.Yas);
                komut.Parameters.AddWithValue("@p4", oyuncu.Biyografi);
                komut.Parameters.AddWithValue("@p5", oyuncu.Resim);

                // Bağlantıyı aç
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                // Sorguyu çalıştır
                komut.ExecuteNonQuery();
            }
        }
    }
}
