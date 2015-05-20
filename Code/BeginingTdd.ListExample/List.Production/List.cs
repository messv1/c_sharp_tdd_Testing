using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.Production
{
    public class List<T>
    {
        private int _count;
        private T[] _internalArray;
        private int p;

        public List()
        {
            _internalArray = new T[8];
        }

        public List(int initalCapacity)
        {
            _internalArray = new T[initalCapacity];
        }

        public int Count { get { return _count ; } }

        public void Add(T item)
        {
            if (_count == Capacity)
            { EnlargeArray(); }

            _internalArray[_count] = item;
            _count++;
        }

        private void EnlargeArray()
        {
            var newArray = new T[2 * Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                newArray[i] = _internalArray[i];
            }
            _internalArray = newArray;
        }

        public T this[int index]
        {
            get { return _internalArray[index]; }
        }

        public int Capacity { get { return _internalArray.Length; } }
    }
}
