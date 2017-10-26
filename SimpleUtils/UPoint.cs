using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    public struct UPoint {

        public uint X;
        public uint Y;

        public UPoint(uint x, uint y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            if (obj is UPoint == false) {
                return false;
            }
            return this == (UPoint)obj;
        }
        public override int GetHashCode( ) => (int)(X * 27644437u ^ Y);

        public static bool operator ==(UPoint self, UPoint other) => self.X == other.X && self.Y == other.Y;
        public static bool operator !=(UPoint self, UPoint other) => !(self == other);
    }
}
