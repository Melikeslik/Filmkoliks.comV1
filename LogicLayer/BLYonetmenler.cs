using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLYonetmenler
    {
        public static List<EntityYonetmenler> BLYonetmenListesiGetir()
        {
            // DAL katmanından yönetmen listesini alıyoruz
            return DALYonetmenler.YonetmenListesiGetir();
        }

        public static List<EntityYonetmenler> BLYonetmenAra(string aranan)
        {
            // DAL katmanından yönetmen arama sonuçlarını alıyoruz
            return DALYonetmenler.YonetmenAra(aranan);
        }

        // Yönetmen bilgilerini alıyoruz
        public static EntityYonetmenler YonetmenGetir(short id)
        {
            return DALYonetmenler.YonetmenGetir(id);
        }

        // Yönetmen silme işlemi
        public static bool YonetmenSil(short id)
        {
            return DALYonetmenler.YonetmenSil(id);
        }

        // Yonetmen bilgilerini getiren metot
        public static EntityYonetmenler GetYonetmenById(short id)
        {
            return DALYonetmenler.GetYonetmenById(id);
        }
    }
}
