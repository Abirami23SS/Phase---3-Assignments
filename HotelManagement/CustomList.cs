using System;
using System.Collections;


namespace HotelManagement
{
    public class CustomList<Type> : IEnumerable, IEnumerator
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }
        private Type[] _array;

        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        void Growsize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }
        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                Growsize();
            }
            _array[_count] = element;
            _count++;
        }
        public void AddRange(CustomList<Type> element)
        {
            _capacity = _count + element.Count;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = element[i];
            }
            int k = 0;
            for (int i = _count; i <= _count + element.Count; i++)
            {
                temp[i] = element[i];
                k++;
            }
            _array = temp;
            _count = _count + element.Count;
        }
        public bool Contains(Type element)
        {
            bool temp = false;
            foreach (Type data in _array)
            {
                if (data.Equals(element))
                {
                    temp = true;
                    break;
                }
            }
            return temp;
        }
        public int IndexOf(Type element)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (element.Equals(_array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void Insert(int position, Type element)
        {
            _capacity = _capacity + 1;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count + 1; i++)
            {
                if (i < position)
                {
                    temp[i] = _array[i];
                }
                else if (i == position)
                {
                    temp[i] = element;
                }
                else
                {
                    temp[i] = _array[i - 1];
                }
            }
            _count++;
            _array = temp;
        }

        int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if (position < Count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current { get { return _array[position]; } }
    }
}