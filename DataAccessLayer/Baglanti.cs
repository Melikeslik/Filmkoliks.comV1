using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Baglanti
    {
        //connectionstring dediğimiz veritabanımızın yolunu projemize eklememiz gerekiyor.ve veritabanımızın yolunu programımıza söylememiz gerekiyor.
        //SqlConnection baglanti = new SqlConnection("Data Source=Veritabanımızın_Yolu;Initial Catalog=Veritabanımızın_Adı;Integrated Security=;True");
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");
    }
}
