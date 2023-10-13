using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Вторая_задача1
{
    internal class Program
    {
        public static void ReadInt(out int x, string n)
        {
            bool isInputCorrect = false;
            do
            {
                Console.Clear();
                Console.Write("Вводимое число должно равно или больше нуля. Введите " + n + ": ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out x))
                {
                    x = Convert.ToInt32(input);
                    if (x>-1)
                    isInputCorrect = true;
                }
            }
            while (!isInputCorrect);
            Console.Clear();
        }

        public static void FillArrayTask1(ref double[] userArray, int n)
        {
                double x;
                Console.Clear();
                for (int i = 0; i != n; i++)
                {
                    bool isInputCorrect = false;
                    Console.Clear();
                    Console.Write("Введите число #" + (i + 1) + ": ");
                    do
                    {
                        string input = Console.ReadLine();
                        if (double.TryParse(input, out x))
                        {
                        x = Convert.ToDouble(input);
                        userArray[i] = x;
                        isInputCorrect = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Повторите ввод числа " + (i + 1) + ": ");
                        }
                    }
                    while (!isInputCorrect);
                }
        }

        public static void Task1(ref double[] userArray, ref int n)
        {
            string menu;
            do
            {
                Console.Clear();
                Console.WriteLine("Постановка задачи: 1.Дана последовательность из n целых чисел. Найти среднее арифметическое этой последовательности.");
                Console.WriteLine("Для запуска процесса инициализации ввода n введите n.");
                Console.WriteLine("Для ввода чисел массива длиной " + n + " введите array.");
                if (n != 0)
                {
                    Console.Write("Данные массива: ");
                    for (int i = 0; i != n-1; i++)
                        Console.Write(userArray[i] + ", ");
                    Console.WriteLine(userArray[n-1] + ".");
                    double average = 0;
                    for (int y = 0; y != n; y++)
                        average = average + userArray[y];
                    Console.WriteLine("Средняя арифметическое введённой последовательности равно: " + Math.Round(average / n, 2));
                }
                else
                    Console.WriteLine("Последовательность пока пуста.");
                Console.WriteLine();
                Console.WriteLine("Для выхода к основному меню введите return или 0");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "array":
                        {
                            FillArrayTask1(ref userArray, n);
                        }
                        break;
                    case "n":
                        {
                            ReadInt(out n, "n");
                            Array.Resize(ref userArray, n);
                        }
                        break;
                }
            }
            while (menu != "0" && menu != "return");
        }

        public static void FillArrayTask2(ref double[] userArray, ref int length)
        {
            double x;
            length = 0;
            do
            {
                bool isInputCorrect = false;
                Console.Clear();
                Console.Write("Введите число: ");
                do
                {
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out x))
                    {
                        x = Convert.ToDouble(input);
                        length++;
                        Array.Resize(ref userArray, length);
                        userArray[length-1] = x;
                        isInputCorrect = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Повторите ввод числа: ");
                    }
                }
                while (!isInputCorrect);
            }
            while (x != 0);        
        }
        
        public static void Task2(ref double[] userArray)
        {
            string menu;
            int length=0;
            do
            {
                int negatives = 0;
                int positives = 0;
                Console.Clear();
                Console.WriteLine("Дана последовательность целых чисел, за которой следует 0.Определить, каких чисел в этой последовательности больше: положительных или отрицательных");
                for (int n = 0; n != length; n++)
                {
                    if (n == length - 1) 
                    { 
                        Console.WriteLine("0.");
                        break;
                    }
                    Console.Write(userArray[n] + "; ");
                }
                if (length!=0)                
                        for (int n=0; n != length; n++)
                    {
                        if (userArray[n] > 0)
                            positives++;
                        if (userArray[n] < 0)
                            negatives++;
                    }
                if ((positives == negatives) && (positives+negatives!=0))
                    Console.WriteLine("Отрицательных и положительныхъ чисел равное количество");
                else
                if (positives > negatives)
                    Console.WriteLine("Положительных чисел в введённой последовательности больше, чем отрицательных.");
                else
                if(negatives > positives)
                    Console.WriteLine("Отрицательных чисел  ввведённой последовательности больше, чем положительных.");
                else                 
                    Console.WriteLine("Последовательность пуста.");
                Console.WriteLine();
                Console.WriteLine("Для ввода элементов массива введите array. Для выхода в предыдущее меню введите 0.");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "array":
                        FillArrayTask2(ref userArray, ref length);
                        break;
                }

            }
            while (menu != "0");
        }

        public static void Task3()
        {
            int n=0;
            int summ = 0;
            bool isSignPositive = true;
            string menu;
            string doShowSequence = "no";
            do
            {
                summ = 0;
                Console.Clear();
                Console.WriteLine("Дана послоедовательность из n постоянно увеличивающихся на один чисел: первое с плюсом, второе с минусом, третье с плюсом и тд.");
                Console.WriteLine("Необходимо найти сумму этих чисел.");
                Console.WriteLine("Введите n для перехода к вводу n. Сейчас n равна: " + n);                
                if (n != 0)
                {
                    for (int i = 1; i != n * 2; i++)
                    {
                        switch (isSignPositive)
                        {
                            case (true):
                                summ += i;
                                isSignPositive = false;
                                break;

                            case (false):
                                summ -= i;
                                isSignPositive = true;
                                break;
                        }
                    }
                    isSignPositive = true;

                    Console.WriteLine("Сумма последовательности: " + summ);

                    if (doShowSequence == "yes")
                    {
                        Console.Write("Последовательность: ");
                        for (int i = 1; i != n * 2; i++)
                        {
                            switch (isSignPositive)
                            {
                                case (true):
                                    if (i != 1)
                                        Console.Write("+");
                                    Console.Write(i);
                                    isSignPositive = false;                                    
                                    break;

                                case (false):
                                    Console.Write(-i);
                                    isSignPositive = true;
                                    break;
                            }
                        }
                        Console.WriteLine();
                    }
                    if (doShowSequence == "no")
                        Console.WriteLine("Функция отображения последовательности отключена.");
                }
                else
                    Console.WriteLine("Последовательность пока пуста.");

                isSignPositive = true;
                Console.WriteLine();
                Console.WriteLine("Введите yes или no, чтобы отобразить данную в задании последовательность.");
                Console.WriteLine("Для выхода в предыдущее меню введите 0.");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case ("yes"):
                        doShowSequence = "yes";
                        break;
                        
                    case("no"):

                        doShowSequence = "no";                       
                        break;

                    case ("n"):
                        ReadInt(out n, "n");
                        break;

                }
                isSignPositive = true;
            } while (menu != "0");
        }

            static void Main(string[] args)
        {
            string menu;
            int n = 0;
            double[] userArrayTask1 = new double[0];
            double[] userArrayTask2 = new double[0]; 
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            do
            {
                Console.Clear();
                Console.WriteLine("1.Дана последовательность из n целых чисел. Найти среднее арифметическое этой последовательности.");
                Console.WriteLine("34.Дана последовательность целых чисел, за которой следует 0.  Определить, каких чисел в этой последовательности больше: положительных или отрицательных.");
                Console.WriteLine("35. S = 1 - 2 + 3 - 4 + 5... пользователь вводит всего n слагаемых;");
                Console.WriteLine();
                Console.WriteLine("Для перемещения по заданиям введите 1, 2 или 3. Для выхода - 0");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            Task1(ref userArrayTask1, ref n);
                        }
                        break;
                    case "2":
                        {
                            Task2(ref userArrayTask2);
                        }
                        break;
                    case "3":
                        {
                            Task3();
                        }
                        break;
                    case "0":
                        {
                            Environment.Exit(0);
                        }
                        break;
                }                
            }
            while (menu != "0");
        }
    }
}