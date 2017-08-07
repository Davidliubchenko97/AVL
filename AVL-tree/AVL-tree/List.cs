using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_tree
{
    class List
    {
        private object[] innerArray = new object[0];
        public int Length
        {
            get
            {
                return innerArray.Length;
            }
        }
        public void Add(object item)
        {
            var temp = new object[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                temp[i] = innerArray[i];
            }
            temp[Length] = item;
            innerArray = temp;
        }
        public void RemoveAt(int index)
        {
            var temp = new object[Length - 1];
            for (int i = 0, j = 0; i < Length && j < temp.Length; i++, j++)
            {
                if (i == index)
                    i++;
                temp[j] = innerArray[i];
            }
            innerArray = temp;

        }
        public void Remove(object item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (innerArray[i] == item || (innerArray[i].Equals(item)))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void RemoveAll(object item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (innerArray[i] == item || (innerArray[i].Equals(item)))
                {
                    RemoveAt(i);
                }
            }
        }
        public void Clear()
        {
            var temp = new object[0];
            innerArray = temp;
        }
        public bool Contains(object item)
        {
            bool boolContains = false;
            for (int i = 0; i < Length; i++)
            {
                if (innerArray[i] == item || (innerArray[i].Equals(item)))
                {
                    boolContains = true;
                }
            }
            return boolContains;
        }
        public void Insert(object item, int index)
        {
            var temp = new object[Length + 1];
            if (index >= Length)
            {
                Add(item);
            }
            else
            {
                for (int i = 0, j = 0; i < temp.Length && j < Length; i++, j++)
                {
                    if (i == index)
                    {
                        temp[i] = item;
                        i++;
                    }
                    temp[i] = innerArray[j];
                }
                innerArray = temp;
            }
        }
        public object this[int index]
        {
            get
            {
                return innerArray[index];
            }
        }
        internal object[] ToArray()
        {
            return innerArray;
        }
    }
}



