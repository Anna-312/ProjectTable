using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Node
    {
        public string name;
        public Node next;
        public int number;
        public Node(string nm)
        {
            name = nm;
            next = null;
        }
    }
    class Base
    {
        protected Node first;
        public Base()
        {
            first = null;
        }
        public void Add(Node node)
        {
            Node cur;
            cur = first;
            if (cur == null)
            {
                first = node;
                first.number = 0;
            }
            else
            {
                while (cur.next != null)
                    cur = cur.next;
                cur.next = node;
                cur.next.number = cur.number + 1;
            }
        }
        public void Remove(Node node)
        {
            Node cur;
            cur = first;
            if (first == null)
                return;
            if (first == node)
            {
                first = node.next;
                return;
            }
            while (cur.next != node)
                cur = cur.next;
            cur.next = cur.next.next;
            while (cur.next != null)
            {
                cur.next.number = cur.number + 1;
                cur = cur.next;
            }
        }
        public Node Find(string nm)
        {
            Node cur;
            cur = first;
            while (cur.name != nm)
                cur = cur.next;
            return cur;
        }
        public Node this[int i]
        {
            get
            {
                Node cur;
                cur = first;
                while (cur.number != i)
                    cur = cur.next;
                return cur;
            }
        }
        public int Length()
        {
            Node cur;
            int k;
            k = 0;
            cur = first;
            while (cur != null)
            {
                k += 1;
                cur = cur.next;
            }
            return k;
        }
        public void Clear()
        {
            first = null;
        }
    }
    class Rows : Base
    {
        public Rows()
        {
            first = null;
        }
        public void Copy(Rows rows1)
        {
            Node cur, node;
            cur = rows1.first;
            while (cur != null)
            {
                node = new Node(cur.name);
                Add(node);
                cur = cur.next;
            }
        }
    }
    class Cols : Base
    {
        public Cols()
        {
            first = null;
        }
        public void Copy(Cols cols1)
        {
            Node cur, node;
            cur = cols1.first;
            while (cur != null)
            {
                node = new Node(cur.name);
                Add(node);
                cur = cur.next;
            }
        }

    }
    class Elem
    {
        public string inf;
        public int row;
        public int column;
        public Elem next;
        public Elem(string info, int r, int c)
        {
            inf = info;
            row = r;
            column = c;
            next = null;
        }
    }

    class Elems
    {
        Elem first;
        public Elems()
        {
            first = null;
        }

        public void Clear()
        {
            first = null;
        }
        public void Add(Elem elem)
        {
            Elem cur;
            cur = first;
            if (cur == null)
                first = elem;
            else
            {
                while (cur.next != null)
                    cur = cur.next;
                cur.next = elem;
            }
        }

        public void Copy(Elems elems1)
        {
            Elem cur, elem;
            cur = elems1.first;
            while (cur != null)
            {
                elem = new Elem(cur.inf, cur.row, cur.column);
                Add(elem);
                cur = cur.next;
            }
        }

        public Elem this[int i, int j]
        {
            get
            {
                Elem cur;
                cur = first;
                while (cur != null)
                {
                    if ((cur.row == i) && (cur.column == j))
                        return cur;
                    else
                        cur = cur.next;
                }
                return null;
            }
        }
        public void Dell(Elem elem)
        {
            Elem cur;
            cur = first;
            if (cur == null)
                return;
            if (first == elem)
            {
                first = elem.next;
                return;
            }
            while (cur.next != elem)
                cur = cur.next;
            cur.next = cur.next.next;
        }
        public void DellAllRow(int i)
        {
            Elem cur;
            cur = first;
            while (cur != null)
            {
                if (cur.row == i)
                    Dell(cur);
                else
                    if (cur.row > i)
                    cur.row -= 1;
                cur = cur.next;
            }
        }
        public void DellAllCol(int j)
        {
            Elem cur;
            cur = first;
            while (cur != null)
            {
                if (cur.column == j)
                    Dell(cur);
                else
                    if (cur.column > j)
                    cur.column -= 1;
                cur = cur.next;
            }
        }
    }
    class Table
    {
        Rows rows;
        Cols cols;
        Elems elems;
        public Table()
        {
            rows = new Rows();
            cols = new Cols();
            elems = new Elems();
        }
        public void AddRow(string name)
        {
            Node node = new Node(name);
            rows.Add(node);
        }
        public void AddCol(string name)
        {
            Node node = new Node(name);
            cols.Add(node);
        }
        public void AddElem(string info, int numRow, int numCol)
        {
            Elem elem = new Elem(info, numRow, numCol);
            elems.Add(elem);
        }
        public void Copy(Table table1)
        {
            rows.Copy(table1.rows);
            cols.Copy(table1.cols);
            elems.Copy(table1.elems);
        }
        public void RemoveRow(int i)
        {
            Node node;
            node = rows[i];
            elems.DellAllRow(i);
            rows.Remove(node);
        }
        public void RemoveCol(int i)
        {
            Node node;
            node = cols[i];
            elems.DellAllCol(i);
            cols.Remove(node);
        }
        public void Output()
        {
            Elem elem;
            int n, m;
            Console.WriteLine();
            n = rows.Length();
            m = cols.Length();
            Console.Write("{0, 20}", "-");
            for (int i = 0; i < m; i++)
                Console.Write("{0, 20}", cols[i].name);
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0, 20}", rows[i].name);
                for (int j = 0; j < m; j++)
                {
                    elem = elems[i, j];
                    if (elem != null)
                        Console.Write("{0, 20}", elem.inf);
                    else
                        Console.Write("{0, 20}", "-");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Clear()
        {
            rows.Clear();
            cols.Clear();
            elems.Clear();
        }
    }
}
