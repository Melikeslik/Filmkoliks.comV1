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
        public static List<EntityYonetmenler> BLYonetmenListele()
        {
            return DALYonetmenler.YonetmenListesi();
        }

        public static List<EntityYonetmenler> BLYonetmenAra(string aramaMetni)
        {
            if (string.IsNullOrEmpty(aramaMetni))
            {
                return DALYonetmenler.YonetmenListesi();
            }
            else
            {
                return DALYonetmenler.YonetmenAra(aramaMetni);
            }
        }

        public static List<EntityYonetmenler> BLYonetmenListeleById(short id)
        {
            return DALYonetmenler.YonetmenListesiById(id);
        }

        public static bool BLYonetmenSil(short yon)
        {
            if (yon >= 1)
            {
                return DALYonetmenler.YonetmenSil(yon);
            }
            else
            {
                return false;
            }
        }

        public static int BLAddYonetmen(EntityYonetmenler yonetmen)
        {
            // DAL metodunu çağır
            return DALYonetmenler.AddYonetmen(yonetmen);
        }
    }
}
