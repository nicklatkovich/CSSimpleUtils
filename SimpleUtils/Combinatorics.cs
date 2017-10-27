using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    public static class Combinatorics {

        public static List<List<T>> GetSubsets<T>(this List<T> from) {
            var result = new List<List<T>>( );
            var count = from.Count;
            var items = from.ToArray( );
            for (ulong i = 0, iTo = (ulong)Math.Pow(2, count); i < iTo; i++) {
                var newResultElement = new List<T>( );
                for (sbyte bitNumber = 0; bitNumber < count; bitNumber++) {
                    var bit = Utils.GetBit(i, bitNumber);
                    if (bit) {
                        newResultElement.Add(items[bitNumber]);
                    }
                }
                result.Add(newResultElement);
            }
            return result;
        }

        public static List<List<T>> GetCombinations<T>(this List<T> from, int @base) {
            var result = new List<List<T>>( );
            var subsets = from.GetSubsets( );
            foreach (var subset in subsets) {
                if (subset.Count == @base) {
                    result.Add(subset);
                }
            }
            return result;
        }
    }

    public static class Subsets { public static List<List<T>> Generate<T>(List<T> from) => from.GetSubsets( ); }
    public static class Combinations {
        public static List<List<T>> Generate<T>(List<T> from, int @base) => from.GetCombinations(@base);
    }
}
