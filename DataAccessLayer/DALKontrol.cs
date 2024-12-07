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
    public class DALKontrol
    {
        public static List<EntityKontrol> SaatleriGetir(string filmAdi, string tarih)
        {
            List<EntityKontrol> saatlerListesi = new List<EntityKontrol>();
            string sorgu = "SELECT DISTINCT SAAT FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih";
            SqlCommand komut = new SqlCommand(sorgu, Baglanti.baglanti);
            komut.Parameters.AddWithValue("@filmAdi", filmAdi);
            komut.Parameters.AddWithValue("@tarih", tarih);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityKontrol kontrol = new EntityKontrol
                {
                    Saat = oku["SAAT"].ToString(),
                    FilmAdi = filmAdi, // Veritabanında her zaman filmAdi ve tarih gelecek.
                    Tarih = tarih
                };
                saatlerListesi.Add(kontrol);
            }

            oku.Close();
            return saatlerListesi;
        }
    }
}
