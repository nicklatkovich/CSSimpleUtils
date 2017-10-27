using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    public static class Utils {

        public static bool GetBit(ulong number, sbyte bitNumber) {
            return (number >> bitNumber) % 2 == 0;
        }
    }
}
