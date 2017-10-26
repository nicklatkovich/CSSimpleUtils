using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    public class MatrixColumn<T> {
        public Matrix<T> Matrix { get; protected set; }
        public uint Index { get; protected set; }

        internal MatrixColumn(Matrix<T> matrix, uint index) {
            Matrix = matrix;
            Index = index;
        }

        public T this[uint index] {
            get => Matrix[Index, index];
            set => Matrix[Index, index] = value;
        }

        public uint Size => Matrix.Height;

        public static bool operator ==(MatrixColumn<T> self, MatrixColumn<T> other) {
            if (self.Size != other.Size) {
                return false;
            }
            for (uint i = 0u; i < self.Size; i++) {
                if (!self[i].Equals(other[i])) {
                    return false;
                }
            }
            return true;
        }
        public static bool operator !=(MatrixColumn<T> self, MatrixColumn<T> other) => !(self == other);

        public override bool Equals(object other) {
            var column = other as MatrixColumn<T>;
            return column != null && this == column;
        }

        public override int GetHashCode( ) {
            var hashCode = 1132412180;
            hashCode = hashCode * -1521134295 + Matrix.GetHashCode( );
            hashCode = hashCode * -1521134295 + Index.GetHashCode( );
            return hashCode;
        }
    }
}
