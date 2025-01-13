using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALOyuncular: Baglanti
    {
        public static List<EntityOyuncular> OyuncuListesiGetir()
        {
            List<EntityOyuncular> oyuncuListesi = new List<EntityOyuncular>();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oyuncular ORDER BY ADSOYAD ASC", baglanti);

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
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
            baglanti.Close();
            return oyuncuListesi;
        }

        public static List<EntityOyuncular> OyuncuAra(string aramaMetni)
        {
            List<EntityOyuncular> oyuncular = new List<EntityOyuncular>();
            SqlCommand komut = new SqlCommand("select * from Tbl_Oyuncular Where ADSOYAD LIKE @p1 collate Turkish_CI_AS ORDER BY ADSOYAD ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", "%" + aramaMetni + "%");

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityOyuncular oyuncu = new EntityOyuncular
                {
                    Id = Convert.ToInt16(oku["ID"]),
                    AdSoyad = oku["ADSOYAD"].ToString(),
                    Resim = oku["RESIM"].ToString()
                };
                oyuncular.Add(oyuncu);
            }
            baglanti.Close();
            return oyuncular;
        }

        public static List<EntityOyuncular> GetOyuncuById(short id)
        {
            List<EntityOyuncular> oyuncular = new List<EntityOyuncular>();
            SqlCommand komut = new SqlCommand("select * from Tbl_Oyuncular WHERE ID=@P1", baglanti);

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.Parameters.AddWithValue("@p1", id);

            // Veriyi okuma işlemi
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityOyuncular oyuncu = new EntityOyuncular();
                oyuncu.Cinsiyet = oku["CINSIYET"].ToString();
                oyuncu.Biyografi = oku["BIYOGRAFI"].ToString();
                oyuncu.AdSoyad = oku["ADSOYAD"].ToString();
                oyuncular.Add(oyuncu);
            }
            oku.Close();

            // Baglantıyı kapatıyoruz
            baglanti.Close();
            return oyuncular;
        }

        public static bool OyuncuSil(short o)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Oyuncular Where ID= @p1", baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@P1", o);
            return komut.ExecuteNonQuery() > 0;
        }


        // Oyuncu eklemek için metot
        public static int AddOyuncu(EntityOyuncular oyuncu)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Oyuncular (ADSOYAD, CINSIYET, YAS, BIYOGRAFI, RESIM) VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            // Parametreleri ekle
            komut.Parameters.AddWithValue("@p1", oyuncu.AdSoyad);
            komut.Parameters.AddWithValue("@p2", oyuncu.Cinsiyet);
            komut.Parameters.AddWithValue("@p3", oyuncu.Yas);
            komut.Parameters.AddWithValue("@p4", oyuncu.Biyografi);
            komut.Parameters.AddWithValue("@p5", oyuncu.Resim);

            // Sorguyu çalıştır
            return komut.ExecuteNonQuery();
        }
    }
}
