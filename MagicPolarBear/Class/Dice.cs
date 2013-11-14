using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPolarBear.Class
{
   
    public class Dice
    {

        public static string Rnd()
        {
            return R(6)+1.ToString();
        }
        public static string Rnd(int sides)
        {
            return R(sides).ToString();
        }
        private static int R(int sides)
        {
            Random rnd = new Random();
            int num = rnd.Next(sides);

            return num;
        }
    
    }
}
