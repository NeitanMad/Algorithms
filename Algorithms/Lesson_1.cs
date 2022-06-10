using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    class Lesson_1
    {
        public static string LessonName = "1. HomeWork_Lesson_1";


        public static void OutputHomework()
        {
            string exit;
            NumberCheck();
            FunctionComplexity();
            Fibonachi();
            Console.Write("Конец домашней работы. Вернуться в начало? Y/N  ");
            exit = Console.ReadLine().ToLower();
            if (exit == "y")
            {
                Console.WriteLine("\n===========================================");
                Program.Start();
            }

        }

        public static void NumberCheck()
        {
            int d = 0;
            int i = 2;

            Console.WriteLine("Задание 1. Проверка на простое число.");
            Console.Write("Введите целое положительное число: ");
            int number = int.Parse(Console.ReadLine());

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                Console.WriteLine($"Число {number} простое\n");
            }
            else
            {
                Console.WriteLine($"Число {number} непростое\n");
            }
        }

        public static void FunctionComplexity()
        {
            Console.WriteLine("Задание 2. Расчитать сложность функции.");
            Console.WriteLine("Сложность функции: O(N^3)\n");
        }

        public static void Fibonachi()
        {
            Console.WriteLine("Задание 3. Вычисления числа Фибоначчи.\n");
            Console.Write("(Рекурсия) Введите номер элемента последовательности: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine($"Элемент под номером {a} = {FibonachiRecursive(a)}\n");
            Console.Write("(Цикл) Введите номер элемента последовательности: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Элемент под номером {b} = {FibonachiCycle(b)}");

        }
        public static int FibonachiRecursive(int n)
        {
            if (n == 0 || n == 1) return n;

            return FibonachiRecursive(n - 1) + FibonachiRecursive(n - 2);

        }

        public static int FibonachiCycle(int n)
        {
            int result = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = result;
                result = b;
                b += tmp;
            }

            return result;
        }

    }
}
