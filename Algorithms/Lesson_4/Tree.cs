using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_4
{
    public class Tree
    {
        public static string LessonName = "4. HomeWork_Lesson_4";

        static Node Root { get; set; }

        public static int CurrentTop = 1; // Для отрисовки..


        public static void AddItem(int value)
        {
            if (Root == null)
            {
                Root = new Node();
                Root.Value = value;

                return;
            }
            Add(value, Root);
        }

        private static void Add(int value, Node node) // Проверка на добавление в левую или правую часть дерева
        {
            if (node == null) throw new InvalidOperationException();

            if (value < node.Value) // Если меньше корня
            {
                if (node.Left == null) // Если узел пустой
                {
                    node.Left = new Node();
                    node.Left.Value = value;

                    return;
                }

                Add(value, node.Left);
            }


            if (value >= node.Value) // Если больше корня или равно
            {
                if (node.Right == null)
                {
                    node.Right = new Node();
                    node.Right.Value = value;

                    return;
                }

                Add(value, node.Right);

            }
        }

         static Node GetNodeByValue(int value)
        {
            return DoFindNodeByValue(value, Root);
        }

        private static Node DoFindNodeByValue(int value, Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }
            if (node.Value == value)
            {
                return node;
            }

            if (node.Value > value)
            {
                if (node.Left == null)
                {
                    return null;
                }
                return DoFindNodeByValue(value, node.Left);
            }
            else
            {
                if (node.Right == null)
                {
                    return null;
                }
                return DoFindNodeByValue(value, node.Right);
            }
        }

         Node GetRoot()
        {
            return Root;
        }

        public static void PrintTree()
        {
            if (Root == null)
            {
                return;
            }
            int treeLength = GetLength(Root);
            double maxWidth = Math.Pow(2, treeLength - 1) * 3;
            double initialX = maxWidth / 2;
            DoPrintTree((int)initialX, CurrentTop + 1, Root);
        }

        private static void DoPrintTree(int x, int y, Node node)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(node.Value);
            Console.CursorTop = ++y;
            Console.CursorLeft -= 2;
            Console.Write('/');
            Console.CursorLeft += 1;
            Console.Write('\\');
            Console.CursorTop = ++y;
            CurrentTop = y + 2;


            if (node.Left != null)
                DoPrintTree(x - 2, y, node.Left);
            if (node.Right != null)
                DoPrintTree(x + 2, y, node.Right);
        }


        private static int GetLength(Node node, int counter = 0)
        {
            if (node == null)
            {
                return counter;
            }
            if (node.Left == null && node.Right == null)
            {
                return counter + 1;
            }
            if (node.Left == null)
            {
                return GetLength(node.Right, counter + 1);
            }
            if (node.Right == null)
            {
                return GetLength(node.Left, counter + 1);
            }
            return Math.Max(GetLength(node.Left, counter + 1), GetLength(node.Right, counter + 1));
        }

        public static void RemoveItem(int value)
        {
            DoRemoveItem(value, Root);
        }

        private static void DoRemoveItem(int value, Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }
            if (node.Value == value && node == Root)
            {
                Root = null;
                return;
            }
            if (node.Value > value)
            {
                if (node.Left == null)
                {
                    return;
                }
                if (node.Left.Value == value)
                {
                    node.Left = null;
                    return;
                }
                DoRemoveItem(value, node.Left);
            }
            else
            {
                if (node.Right == null)
                {
                    return;
                }
                if (node.Right.Value == value)
                {
                    node.Right = null;
                    return;
                }
                DoRemoveItem(value, node.Right);
            }

        }

        public static void OutputHomework()
        {

            Console.WriteLine("Добавим несколько элементов в дерево и выведем на консоль..");

            Tree.AddItem(10);
            Tree.AddItem(7);
            Tree.AddItem(11);
            Tree.AddItem(4);
            Tree.AddItem(8);
            Tree.AddItem(20);
            Tree.AddItem(2);
            Tree.AddItem(5);
            Tree.AddItem(18);


            Tree.PrintTree();

            Console.WriteLine();

            Console.WriteLine("Удалим элементы со значением 4 и 20 ");

            Console.WriteLine();

            Tree.RemoveItem(4);
            Tree.RemoveItem(20);

            Tree.PrintTree();

            var node = new Node();
            node = Tree.GetNodeByValue(7); // получить узел по значению
        }
    }
}
