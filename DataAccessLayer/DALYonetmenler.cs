using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALYonetmenler
    {
        public static List<EntityYonetmenler> YonetmenListesiGetir()
        {
            List<EntityYonetmenler> yonetmenListesi = new List<EntityYonetmenler>();
            string sorgu = "SELECT * FROM Tbl_Yonetmenler ORDER BY ADSOYAD ASC";

            using (SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti))
            {
                if (komut.Connection.State != System.Data.ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    EntityYonetmenler yonetmen = new EntityYonetmenler
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Cinsiyet = oku["CINSIYET"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString(),
                        Resim = oku["RESIM"].ToString()
                    };
                    yonetmenListesi.Add(yonetmen);
                }
                oku.Close();
            }

            return yonetmenListesi;
        }

        public static List<EntityYonetmenler> YonetmenAra(string aranan)
        {
            List<EntityYonetmenler> yonetmenListesi = new List<EntityYonetmenler>();
            string sorgu = "SELECT * FROM Tbl_Yonetmenler WHERE ADSOYAD LIKE @aranan COLLATE TURKISH_CI_AS ORDER BY ADSOYAD ASC";

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
                    EntityYonetmenler yonetmen = new EntityYonetmenler
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString(),
                        Resim = oku["RESIM"].ToString()
                    };
                    yonetmenListesi.Add(yonetmen);
                }
                oku.Close();
            }

            return yonetmenListesi;
        }

        // Yonetmen bilgilerini çekme
        public static EntityYonetmenler YonetmenGetir(short id)
        {
            EntityYonetmenler yonetmen = null;
            string sorgu = "SELECT * FROM Tbl_Yonetmenler WHERE ID=@id";

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
                    yonetmen = new EntityYonetmenler
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

            return yonetmen;
        }

        // Yonetmen silme işlemi
        public static bool YonetmenSil(short id)
        {
            string sorgu = "DELETE FROM Tbl_Yonetmenler WHERE ID = @id";
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

        // Yonetmen biyografisini ve adını getiren metot
        public static EntityYonetmenler GetYonetmenById(short id)
        {
            string sorgu = "SELECT * FROM Tbl_Yonetmenler WHERE ID = @id";
            EntityYonetmenler yonetmen = null;

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
                    yonetmen = new EntityYonetmenler
                    {
                        Id = id,
                        AdSoyad = oku["ADSOYAD"].ToString(),
                        Biyografi = oku["BIYOGRAFI"].ToString()
                    };
                }
            }

            return yonetmen;
        }
    }
}
