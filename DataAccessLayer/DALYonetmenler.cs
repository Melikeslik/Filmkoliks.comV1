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
    public class DALYonetmenler: Baglanti
    {

        public static List<EntityYonetmenler> YonetmenListesi()
        {
            List<EntityYonetmenler> yonetmenler = new List<EntityYonetmenler>();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yonetmenler ORDER BY ADSOYAD ASC", baglanti);

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityYonetmenler yonetmen = new EntityYonetmenler
                {
                    Id = Convert.ToInt16(oku["ID"]),
                    AdSoyad = oku["ADSOYAD"].ToString(),
                    Cinsiyet = oku["CINSIYET"].ToString(),
                    Yas = oku["YAS"].ToString(),
                    Biyografi = oku["BIYOGRAFI"].ToString(),
                    Resim = oku["RESIM"].ToString()
                };
                yonetmenler.Add(yonetmen);
            }
            baglanti.Close();
            return yonetmenler;
        }

        public static List<EntityYonetmenler> YonetmenAra(string aramaMetni)
        {
            List<EntityYonetmenler> yonetmenler = new List<EntityYonetmenler>();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yonetmenler Where ADSOYAD LIKE @p1 collate Turkish_CI_AS ORDER BY ADSOYAD ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", "%" + aramaMetni + "%");

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityYonetmenler yonetmen = new EntityYonetmenler
                {
                    Id = Convert.ToInt16(oku["ID"]),
                    AdSoyad = oku["ADSOYAD"].ToString(),
                    Resim = oku["RESIM"].ToString()
                };
                yonetmenler.Add(yonetmen);
            }
            baglanti.Close();
            return yonetmenler;
        }

        //YonetmenListesi.cs için:
        public static List<EntityYonetmenler> YonetmenListesiById(short id)
        {
            List<EntityYonetmenler> yonetmenler = new List<EntityYonetmenler>();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yonetmenler WHERE ID=@P1", baglanti);

            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }
            
            komut.Parameters.AddWithValue("@p1", id);

            // Veriyi okuma işlemi
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityYonetmenler yonetmen = new EntityYonetmenler();
                yonetmen.Cinsiyet = oku["CINSIYET"].ToString();
                yonetmen.Biyografi = oku["BIYOGRAFI"].ToString();
                yonetmen.AdSoyad = oku["ADSOYAD"].ToString();
                yonetmenler.Add(yonetmen);
            }
            oku.Close();

            // Baglantıyı kapatıyoruz
            baglanti.Close();
            return yonetmenler;
        }

        public static bool YonetmenSil(short y)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Yonetmenler Where ID= @p1", baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@P1", y);
            return komut.ExecuteNonQuery() > 0;
        }

        public static int AddYonetmen(EntityYonetmenler yonetmen)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Yonetmenler (ADSOYAD, CINSIYET,YAS,BIYOGRAFI,RESIM) VALUES (@p1,@p2,@p3,@p4,@p5)", baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            // Parametreleri ekle
            komut.Parameters.AddWithValue("@p1", yonetmen.AdSoyad);
            komut.Parameters.AddWithValue("@p2", yonetmen.Cinsiyet);
            komut.Parameters.AddWithValue("@p3", yonetmen.Yas);
            komut.Parameters.AddWithValue("@p4", yonetmen.Biyografi);
            komut.Parameters.AddWithValue("@p5", yonetmen.Resim);

            // Sorguyu çalıştır
            return komut.ExecuteNonQuery();
        }
    }
}
