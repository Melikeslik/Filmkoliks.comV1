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
    public class DALBiletler: Baglanti
    {
        public static EntityBiletler BiletGetir(string biletNo)
        {
            SqlCommand komut1 = new SqlCommand("SELECT * FROM Tbl_Biletler WHERE BKOD=@kod", baglanti);
            komut1.Parameters.AddWithValue("@kod", biletNo);

            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }

            SqlDataReader dr = komut1.ExecuteReader();
            EntityBiletler bilet = null;

            if (dr.Read())
            {
                bilet = new EntityBiletler
                {
                    Id = short.Parse(dr["ID"].ToString()),
                    BKod = dr["BKOD"].ToString(),
                    AdSoyad = dr["ADSOYAD"].ToString(),
                    TelNo = dr["TELNO"].ToString(),
                    KoltukNo = dr["KOLTUKNO"].ToString(),
                    FilmAdi = dr["FILMADI"].ToString(),
                    Tarih = dr["TARIH"].ToString(),
                    Saat = dr["SAAT"].ToString(),
                    Salon = dr["SALON"].ToString(),
                    Tur = dr["TUR"].ToString(),
                    IslemSaati = dr["ISLEMSAATI"].ToString()
                };
            }

            dr.Close();
            return bilet;
        }

        public static int BiletEkle(EntityBiletler ekle)
        {
            SqlCommand komutKayit = new SqlCommand("INSERT INTO Tbl_Biletler (BKOD, ADSOYAD, TELNO, KOLTUKNO, FILMADI, TARIH, SAAT, SALON, TUR, ISLEMSAATI) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", baglanti);
            if (komutKayit.Connection.State != ConnectionState.Open)
            {
                komutKayit.Connection.Open();
            }
            komutKayit.Parameters.AddWithValue("@p1", ekle.BKod);
            komutKayit.Parameters.AddWithValue("@p2", ekle.AdSoyad);
            komutKayit.Parameters.AddWithValue("@p3", ekle.TelNo);
            komutKayit.Parameters.AddWithValue("@p4", ekle.KoltukNo);
            komutKayit.Parameters.AddWithValue("@p5", ekle.FilmAdi);
            komutKayit.Parameters.AddWithValue("@p6", ekle.Tarih);
            komutKayit.Parameters.AddWithValue("@p7", ekle.Saat);
            komutKayit.Parameters.AddWithValue("@p8", ekle.Salon);
            komutKayit.Parameters.AddWithValue("@p9", ekle.Tur);
            komutKayit.Parameters.AddWithValue("@p10", DateTime.Now.ToString());
            return komutKayit.ExecuteNonQuery();
        }

        public static bool BiletGuncelle(EntityKontrol guncelle)
        {
            SqlCommand komutGuncelle = new SqlCommand("UPDATE Tbl_Kontrol SET KOLTUKLAR=@numara WHERE FILMADI=@filmadi AND TARIH=@tarih AND SAAT=@saat AND SALONADI=@salonadi", baglanti);
            if (komutGuncelle.Connection.State != ConnectionState.Open)
            {
                komutGuncelle.Connection.Open();
            }
            komutGuncelle.Parameters.AddWithValue("@numara", guncelle.Koltuklar);

            komutGuncelle.Parameters.AddWithValue("@filmadi", guncelle.FilmAdi);
            komutGuncelle.Parameters.AddWithValue("@tarih", guncelle.Tarih);
            komutGuncelle.Parameters.AddWithValue("@saat", guncelle.Saat);
            komutGuncelle.Parameters.AddWithValue("@salonadi", guncelle.SalonAdi);
            return komutGuncelle.ExecuteNonQuery() > 0;
        }
    }
}