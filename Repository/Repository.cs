using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    namespace ITI_Exam
    {
        public class Repository<T> where T : ICloneable, IComparable<T>
        {
            private T[] _items { get; set; } = new T[2];
            private int _count;
            private int _length = 2;

            public int Count { get { return _count; } }

            public virtual void Add(T item)
            {
                if (item is null)
                    throw new ArgumentNullException("ELement can not be null.");

                if (_length == _count)
                {
                    _length = _length * 2;
                    T[] newArr = new T[_length];

                    for (int i = 0; i < _count; i++)
                        newArr[i] = _items[i];

                    _items = newArr;
                }

                _items[_count++] = item;
            }
            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= _count)
                        throw new IndexOutOfRangeException("Invalid index.");

                    return _items[index];
                }
            }


            public virtual void Remove(T item)
            {
                if (item is null)
                    throw new ArgumentNullException(nameof(item));

                int index = -1;

                for (int i = 0; i < _count; i++)
                {
                    if (_items[i].CompareTo(item) == 0)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                    return;

                for (int i = index; i < _count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }

                _items[_count - 1] = default!;
                _count--;
            }


            public virtual void Sort()
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    for (int j = 0; j < _count - i - 1; j++)
                    {
                        if (_items[j].CompareTo(_items[j + 1]) > 0)
                        {
                            T temp = _items[j];
                            _items[j] = _items[j + 1];
                            _items[j + 1] = temp;
                        }
                    }
                }
            }

            public virtual List<T> GetAll()
            {
                List<T> list = new List<T>();

                for (int i = 0; i < _count; i++)
                    list.Add(_items[i]);

                return list;
            }

        }
    }
}
