using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GeekBrainsTests;
using MyList;
using AlgorithmsAndDataStructures;

namespace Algorithms.Lesson_2
{
    class Lesson_2
    {
        public static string LessonName = "2. HomeWork_Lesson_2";

        public static void OutputHomework()
        {
            MyLinkedList linkedList = new MyLinkedList();

            Console.WriteLine("Текущие колличество элементов в списке: " + linkedList.GetCount());
            Console.WriteLine("Добавим 5 элементов: 1, 2, 3, 4, 5");
            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(3);
            linkedList.AddNode(4);
            linkedList.AddNode(5);
            Console.WriteLine("Текущие колличество элементов в списке: " + linkedList.GetCount());

            Console.WriteLine("Добавим новый элемент со значением 6 после элемента со значением 5");
            Node newNode = new Node();
            newNode.Value = 6;
            linkedList.AddNodeAfter(newNode, 5);
            Console.WriteLine("Элементов в списке: " + linkedList.GetCount());

            Console.WriteLine("Удалим 3-ий элемент ");
            linkedList.RemoveNode(3);
            Console.WriteLine("Текущие колличество элементов в списке: " + linkedList.GetCount());

            linkedList.FindNode(4);
        }
    }
}
