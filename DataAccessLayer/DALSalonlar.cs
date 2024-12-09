using EntityLayer;
using System;
using System.Collections.Generic;
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
            }
            finally
            {
                baglanti.Close();
            }

            return salon;
        }
    }
}
