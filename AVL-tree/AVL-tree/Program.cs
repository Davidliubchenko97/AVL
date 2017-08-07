using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_tree
{
    class Program
    {
        class IntComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                return (int)x - (int)y;
            }
        }

        class RevIntComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                return (int)y - (int)x;
            }
        }
        static void Main(string[] args)
        {
            var tree = new Tree(new IntComparer());
            // var tree = new Tree(new RevIntComparer()); сортировка от большего к меньшему
            var arr = new int[] { 20, 2, 10, -5, 15, 28, 45, -4, 0, 3 };
            for (int i = 0; i < arr.Length; i++)
            {
                tree.Add(arr[i]);
            }

            var res = tree.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }

        }
    }
}
