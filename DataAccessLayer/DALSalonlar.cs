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
    public class DALSalonlar: Baglanti
    {
        public static EntitySalonlar SalonBilgisiGetir(string salonAdi)
        {
            EntitySalonlar salon = null;

            string sorgu = "SELECT * FROM Tbl_Salonlar WHERE SALONADI=@salonAdi";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@salonAdi", salonAdi);

            try
            {
                baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    salon = new EntitySalonlar
                    {
                        Id = Convert.ToInt16(oku["ID"]),
                        SalonAdi = oku["SALONADI"].ToString(),
                        KoltukSayisi = oku["KOLTUKSAYISI"].ToString()
                    };
                }
                oku.Close();
            }
            finally
            {
                baglanti.Close();
            }

            return salon;
        }

        public static List<EntitySalonlar> SalonAdiGetir()
        {
            List<EntitySalonlar> salonlar = new List<EntitySalonlar>();
            SqlCommand komut = new SqlCommand("select * from Tbl_Salonlar ORDER BY SALONADI ASC", baglanti);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntitySalonlar salon = new EntitySalonlar();
                salon.Id = Convert.ToInt16(oku["ID"]);
                salon.SalonAdi = oku["SALONADI"].ToString();
                salon.KoltukSayisi = oku["KOLTUKSAYISI"].ToString();
                salonlar.Add(salon);
            }
            oku.Close();
            return salonlar;
        }

        // Salon kaydetme metodu
        public static void SalonKaydet(EntitySalonlar entitySalon)
        {
            string sorgu = "INSERT INTO Tbl_Salonlar (SALONADI, KOLTUKSAYISI) VALUES (@p1, @p2)";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@p1", entitySalon.SalonAdi);
            komut.Parameters.AddWithValue("@p2", entitySalon.KoltukSayisi);
            komut.ExecuteNonQuery();
        }
    }
}
