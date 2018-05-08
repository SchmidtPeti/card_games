using cardgames.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgames
{
    public class kartyak
    {
        Random random;
        List<int> volt_index;
        public int player_one;
        public int player_two;
        public int done_palyer;
        public kartyak()
        {
            random = new Random();
            volt_index = new List<int>();
        }
        public readonly Image[] images = { Resources.kep__1_ ,Resources.kep__2_,Resources.kep__3_,Resources.kep__4_,Resources.kep__5_,Resources.kep__6_,Resources.kep__7_,Resources.kep__8_,Resources.kep__9_,Resources.kep__10_,Resources.kep__11_,Resources.kep__12_,Resources.kep__13_,Resources.kep__14_,Resources.kep__15_,
            Resources.kep__16_,Resources.kep__17_,Resources.kep__18_,Resources.kep__19_,Resources.kep__20_,Resources.kep__21_,Resources.kep__22_,Resources.kep__23_,Resources.kep__24_,Resources.kep__25_,Resources.kep__26_,Resources.kep__27_,Resources.kep__28_,Resources.kep__29_,Resources.kep__30_,Resources.kep__31_,
            Resources.kep__32_,Resources.kep__33_,Resources.kep__34_,Resources.kep__35_,Resources.kep__36_,Resources.kep__37_,Resources.kep__38_,Resources.kep__39_,Resources.kep__40_,Resources.kep__41_,Resources.kep__42_,Resources.kep__43_,Resources.kep__44_,Resources.kep__45_,Resources.kep__46_,Resources.kep__47_,
            Resources.kep__48_,Resources.kep__49_,Resources.kep__50_,Resources.kep__51_,Resources.kep__52_};
        public readonly int[] values = { 2,3,2,3,2,3,2,
                                         3,4,4,4,4,5,5,
                                         5,5,6,6,6,6,7,
                                         7,7,7,8,8,8,8,
                                         9,9,9,9,10,10,10,
                                         10,11,11,11,11,10,10,
                                         10,10,10,10,10,10,10,
                                         10,10,10};
        public Image get_rnd_pic()
        {
            UJRAGENERALAS:
            int rnd_index = random.Next(0, 52);
            if (!volt_index.Contains(rnd_index))
            {
                volt_index.Add(rnd_index);
            }
            else
            {
                goto UJRAGENERALAS;
            }
            Image image = images[rnd_index];
            return image;
        }
        public int get_pic_value(Image image)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (image == images[i])
                {
                    return values[i];
                }
            }
            return 0;
        }
        public void new_Game()
        {
            volt_index.Clear();
        }
    }
}
