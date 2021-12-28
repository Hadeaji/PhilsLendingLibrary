using PhilsLendingLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsLendingLibrary.Classes
{
    public class Backpack<T> : IBag<T>
    {
        private List<T> Storage = new List<T>();

        public int Count => Storage.Count;
        public void Pack(T item)
        {
            Storage.Add(item);
        }

        public T Unpack(int index)
        {
            T item = Storage[index];
            Storage.RemoveAt(index);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in Storage)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
