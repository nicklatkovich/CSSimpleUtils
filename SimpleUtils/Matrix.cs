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
        }

        public Matrix(uint width, uint height, T defaultValue) : this(width, height) {
            Clear(defaultValue);
        }

        public void Clear(T clearValue) {
            for (uint i = 0u; i < _width; i++) {
                for (uint j = 0u; j < _height; j++) {
                    _arr[i, j] = clearValue;
                }
            }
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
    }
}
