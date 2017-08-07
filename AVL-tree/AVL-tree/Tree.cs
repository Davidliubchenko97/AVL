using System;
using System.Collections;


namespace AVL_tree
{
    public class Tree
    {
        private object[] innerArray = new object[0];
        public int Length
        {
            get
            {
                return innerArray.Length;
            }
        }
        public void AddList(object item)
        {
            var temp = new object[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                temp[i] = innerArray[i];
            }
            temp[Length] = item;
            innerArray = temp;
        }
        public bool ContainsList(object value)
        {
            bool boolContains = false;
            for (int i = 0; i < Length; i++)
            {
                if (innerArray[i] == value || (innerArray[i].Equals(value)))
                {
                    boolContains = true;
                }
            }
            return boolContains;
        }
        public void Clearlist()
        {
            var temp = new object[0];
            innerArray = temp;
        }
        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public object Value { get; private set; }

            public Node(object value)
            {
                Value = value;
            }
        }

        private IComparer comparer;

        private Node Root { get; set; }
        public Tree(IComparer comparer)
        {
            this.comparer = comparer;
        }
        public void Clear()
        {
            var node = new Node(null);
            if (Root == null)
            {
                return;
            }
            else
            {
                ClearInner(Root, node);
            }
        }
        private void ClearInner(Node parrent, Node current)
        {
            if (parrent.Right == null)
            {
                parrent = null;
            }
            else
            {
                ClearInner(parrent.Right, current);
            }
            if (parrent.Left == null)
            {
                parrent = null;
            }
            else
            {
                ClearInner(parrent.Left, current);
            }


        }
        public void Add(object value)
        {
            var node = new Node(value);
            if (Root == null)
            {
                Root = node;
                AddList(node);
            }
            else
            {
                AddInner(Root, node);
            }
        }
        private void AddInner(Node parrent, Node current)
        {
            var res = comparer.Compare(parrent.Value, current.Value);
            if (res > 0)                //Left
            {
                if (parrent.Left == null)
                {
                    AddList(current);
                    parrent.Left = current;
                }
                else
                {
                    AddInner(parrent.Left, current);
                }
            }
            else if (res < 0)  //Right
            {
                if (parrent.Right == null)
                {
                    AddList(current);
                    parrent.Right = current;
                }
                else
                {
                    AddInner(parrent.Right, current);
                }
            }

        }

        public object[] ToArray()
        {
            var result = new List();
            Build(result, Root);
            return result.ToArray();
        }
        private void Build(List result, Node current)
        {
            if (current.Left != null)
                Build(result, current.Left);
            result.Add(current.Value);
            if (current.Right != null)
                Build(result, current.Right);
        }
    }
}
