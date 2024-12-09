using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALKullanicilar: Baglanti
    {
        public static bool KullaniciGiris(EntityKullanicilar kullanici)
        {

            SqlCommand sorgula = new SqlCommand("SELECT * FROM Tbl_Kullanicilar WHERE KADI=@username AND KSIFRE=@password", baglanti);

            if (sorgula.Connection.State != ConnectionState.Open)
            {
                sorgula.Connection.Open();
            }

            sorgula.Parameters.AddWithValue("@username", kullanici.KAdi);
            sorgula.Parameters.AddWithValue("@password", kullanici.KSifre);

            SqlDataReader oku = sorgula.ExecuteReader();
            bool result = oku.Read(); // Kullanıcı bilgileri eşleşiyor mu kontrol et

            sorgula.Connection.Close();
            return result;
        }
    }
}
