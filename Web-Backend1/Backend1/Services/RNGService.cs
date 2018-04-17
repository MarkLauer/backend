using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend1.Services
{
    public class RNGService : IRNGService
    {
        private Random rand = new Random();

        public int Number(int inf, int sup)
        {
            return rand.Next(inf, sup);
        }
    }
}
