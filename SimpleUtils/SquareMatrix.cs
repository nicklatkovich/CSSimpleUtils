using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    class SquareMatrix<T> : Matrix<T> {

        public SquareMatrix(uint size) : base(size, size) {
        }

        public static void SetIdentity<K>(SquareMatrix<K> matrix, K oneTemplate, K zeroTemplate) {
            for (uint i = 0u; i < matrix.Size; i++) {
                for (uint j = 0u; j < matrix.Size; j++) {
                    matrix[i, j] = i == j ? oneTemplate : zeroTemplate;
                }
            }
        }

        public static void SetIdentity(SquareMatrix<bool> matrix) => SetIdentity(matrix, true, false);

        public new uint Size => Width;
    }
}
