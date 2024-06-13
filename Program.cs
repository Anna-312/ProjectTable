using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool entered = false;
            bool coped = false;
            Table table = new Table();
            Table table1 = new Table();
            void start()
            {
                int num;
                Console.WriteLine("Выберите действие:\n1 - Ввести таблицу\n2 - Вывести таблицу\n3 - Добавить строку\n4 - Добавить столбец\n5 - Добавить элемент\n6 - Исключить строку\n7 - Исключить столбец\n8 - Скопировать таблицу\n9 - Выход");
                num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                    input();
                else
                    if (num == 2)
                    output();
                else
                        if (num == 3)
                    addRow();
                else
                            if (num == 4)
                    addCol();
                else
                                if (num == 5)
                    addElem();
                else
                                    if (num == 6)
                    removeRow();
                else
                    if (num == 7)
                    removeCol();
                else
                    if (num == 8)
                    copyTable();
            }
            void input()
            {
                int m, n, k;
                string name, info;

                if (entered)
                    table.Clear();
                entered = true;
                if (coped)
                    table1.Clear();
                coped = false;
                Console.WriteLine("Введите количество строк:");
                m = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < m; i++)
                {
                    Console.WriteLine("Введите название строки:");
                    name = Console.ReadLine();
                    table.AddRow(name);
                }
                Console.WriteLine("Введите количество стoлбцов:");
                n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите название столбца:");
                    name = Console.ReadLine();
                    table.AddCol(name);
                }
                Console.WriteLine("Введите количество элементов:");
                k = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < k; i++)
                {
                    int a, b;
                    Console.WriteLine("Введите номер строки элемента:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите номер столбца элемента:");
                    b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите содержание элемента:");
                    info = Console.ReadLine();
                    table.AddElem(info, a, b);
                }
                start();
            }

            void output()
            {
                if (entered)
                    table.Output();
                else
                    Console.WriteLine("Таблица не введена!");
                if (coped)
                {
                    Console.WriteLine("Скопированная таблица:");
                    table1.Output();
                }
                start();
            }
            void addRow()
            {
                if (!entered)
                    Console.WriteLine("Таблица не введена!");
                else
                {
                    string name;
                    Console.WriteLine("Введите название строки:");
                    name = Console.ReadLine();
                    table.AddRow(name);
                }
                start();
            }
            void addCol()
            {
                if (!entered)
                    Console.WriteLine("Таблица не введена!");
                else
                {
                    string name;

                    Console.WriteLine("Введите название столбца:");
                    name = Console.ReadLine();
                    table.AddCol(name);
                }
                start();
            }
            void addElem()
            {
                if (!entered)
                {
                    Console.WriteLine("Таблица не введена!");
                }
                else
                {
                    string info;
                    int a, b;
                    Console.WriteLine("Введите номер строки элемента:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите номер столбца элемента:");
                    b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите содержимое элемента:");
                    info = Console.ReadLine();
                    table.AddElem(info, a, b);
                }
                start();
            }
            void removeRow()
            {
                if (!entered)
                    Console.WriteLine("Таблица не введена!");
                else
                {
                    int n;
                    Console.WriteLine("Введите номер строки:");
                    n = Convert.ToInt32(Console.ReadLine());
                    table.RemoveRow(n);
                }
                start();
            }

            void removeCol()
            {
                if (!entered)
                    Console.WriteLine("Таблица не введена!");
                else
                {
                    int n;
                    Console.WriteLine("Введите номер столбца:");
                    n = Convert.ToInt32(Console.ReadLine());
                    table.RemoveCol(n);
                }
                start();
            }
            void copyTable()
            {
                if (entered)
                {
                    table1.Copy(table);
                    coped = true;
                }
                else
                    Console.WriteLine("Таблица не введена!");
                start();
            }
            start();
        }
    }
}
