using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLOyuncular
    {
        public static List<EntityOyuncular> BLOyuncuListesiGetir()
        {
            // DAL katmanından oyuncu listesini alıyoruz
            return DALOyuncular.OyuncuListesiGetir();
        }

        public static List<EntityOyuncular> BLOyuncuAra(string aranan)
        {
            // DAL katmanından oyuncu arama sonuçlarını alıyoruz
            if (string.IsNullOrEmpty(aranan))
            {
                return DALOyuncular.OyuncuListesiGetir();
            }
            else
            {
                return DALOyuncular.OyuncuAra(aranan);
            }
        }

        // Oyuncu silme işlemi
        public static bool BLOyuncuSil(short id)
        {
            return DALOyuncular.OyuncuSil(id);
        }

        public static List<EntityOyuncular> BLGetOyuncuById(short id)
        {
            return DALOyuncular.GetOyuncuById(id);
        }

        //Oyuncu eklemek için metot
        public static int BLAddOyuncu(EntityOyuncular oyuncu)
        {
            // DAL metodunu çağır
            return DALOyuncular.AddOyuncu(oyuncu);
        }
    }
}
