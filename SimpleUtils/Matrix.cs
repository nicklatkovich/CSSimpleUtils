using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtils {
    public class Matrix<T> {

        private uint _width;
        private uint _height;
        private T[ , ] _arr;
        private MatrixColumn<T>[ ] _columns;
        public IReadOnlyCollection<MatrixColumn<T>> Columns { get; protected set; }

        public uint Width {
            get => _width;
            set => throw new NotImplementedException( );
        }

        public uint Height {
            get => _height;
            set => throw new NotImplementedException( );
        }

        public UPoint Size => new UPoint(_width, _height);

        public Matrix(uint width, uint height) {
            _width = width;
            _height = height;
            _arr = new T[width, height];
            _columns = new MatrixColumn<T>[width];
            for (uint i = 0u; i < width; i++) {
                _columns[i] = new MatrixColumn<T>(this, i);
            }
            Columns = Array.AsReadOnly(_columns);
        }

        public Matrix(uint width, uint height, T defaultValue) : this(width, height) {
            Clear(defaultValue);
        }

        public static Matrix<T> HorizontalConcatenation(Matrix<T> left, Matrix<T> right) {
            if (left._height != right._height) {
                throw new IndexOutOfRangeException("Matrix height does not match");
            }
            Matrix<T> result = new Matrix<T>(left._width + right._width, left._height);
            left.CopyTo(result);
            right.CopyTo(result, new UPoint(left._width, 0));
            return result;
        }

        public void CopyTo(Matrix<T> other, UPoint to = default(UPoint)) {
            for (uint i = to.X, iTo = i + _width, iFrom = 0u; i < iTo; i++, iFrom++) {
                for (uint j = to.Y, jTo = j + _height, jFrom = 0u; j < jTo; j++, jFrom++) {
                    other[i, j] = this[iFrom, jFrom];
                }
            }
        }

        public void Clear(T clearValue) {
            for (uint i = 0u; i < _width; i++) {
                for (uint j = 0u; j < _height; j++) {
                    _arr[i, j] = clearValue;
                }
            }
        }

        public override bool Equals(object obj) {
            throw new NotImplementedException( );
        }

        public override int GetHashCode( ) {
            var hashCode = 1960150395;
            hashCode = hashCode * -1521134295 + _width.GetHashCode( );
            hashCode = hashCode * -1521134295 + _height.GetHashCode( );
            // TODO: make generation of GHC by elements
            throw new NotImplementedException( );
            //return hashCode;
        }

        public T this[uint i, uint j] {
            get => _arr[i, j];
            set {
                _arr[i, j] = value;
            }
        }

        public T this[UPoint point] {
            get => this[point.X, point.Y];
            set => this[point.X, point.Y] = value;
        }

        public bool HaveSameColumns {
            get {
                for (uint i = 0u; i < _width; i++) {
                    for (uint j = i + 1; j < _width; j++) {
                        if (_columns[i] == _columns[j]) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
