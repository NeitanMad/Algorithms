using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GeekBrainsTests;
using MyList;
using Algorithms.Lesson_2;
using Algorithms.Lesson_3;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

namespace AlgorithmsAndDataStructures
{
    class Program
    {

        public static void Info()
        {
            StringBuilder NameOfTask = new StringBuilder();
            NameOfTask.Append(Lesson_1.LessonName + "\n" + Lesson_2.LessonName + "\n" + PointBenchmark.LessonName + "\n");
            Console.WriteLine("Введите номер домашнего задания что бы откррыть его.");
            Console.WriteLine("Доступные домашние работы: \n" + NameOfTask);
        }

        public static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

        public static void EnterComand()
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder Command = new StringBuilder();
            char key;
            Console.Write("№ работы: ");
            do
            {
                key = Console.ReadKey().KeyChar;

                if (key != 8 && key != 13) // не BackSpace && не Enter
                {
                    Command.Append(key);
                }
                (int currentLeft, int currentTop) = GetCursorPosition();

                if (key == (char)8)
                {
                    if (Command.Length > 0)
                    {
                        Command.Remove(Command.Length - 1, 1);
                    }

                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                    }
                }

            } while (key != (char)13);

            // Console.WriteLine(Command);
            ParseCommandString(Command.ToString());

        }

        static void ParseCommandString(string Command)
        {
            string[] commandParams = Command.ToLower().Split(' ');
            if (commandParams.Length > 0)
            {

                switch (commandParams[0])
                {
                    case "1":

                        Lesson_1.OutputHomework();

                        break;

                    case "2":

                        Lesson_2.OutputHomework();

                        break;

                    case "3":

                        BenchmarkRunner.Run<PointBenchmark.BenchmarkForClassAndStruct>();

                        break;

                    default:
                        Console.WriteLine("Некоректый ввод.");
                        EnterComand();

                        break;
                }

            }
        }

        public static void Start()
        {
            Info();
            EnterComand();
        }

        static void Main(string[] args)
        {
            Start();
        }
    }
}
