using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    public static class Rand {

        private static Random _rand = new Random( );

        public static bool BRand( ) => _rand.Next(2) == 0;

    }
}
