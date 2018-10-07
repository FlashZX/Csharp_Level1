//Насыров Игорь, г.Пермь. Домашка № 6.
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_6
{
    class Program
    {
        //---------------------------Задача 1------------------------------------------------
        /// <summary>
        /// Делегат с сигнатурой double (double, double)
        /// </summary>
        public delegate double Fun(double x, double a);

        /// <summary>
        /// Метод для построения графика по функции
        /// </summary>
        /// <param name="fun"></param>
        /// <param name="x"></param>
        /// <param name="b"></param>
        public static void Table(Fun fun, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, fun(x, x));
                x++;
            }
            Console.WriteLine("---------------------");
        }
        
        /// <summary>
        /// Метод для передачи в Table
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double MyFunc(double a, double x)
        {
            return a * (x * x);
        }
        
        //---------------------------Задача 2-------------------------------------------
        /// <summary>
        /// Делегат с сигнатурой double (double)
        /// </summary>
        public delegate double function(double x);

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x - 10 * x + 50;
        }

        /// <summary>
        /// Метод записи в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <param name="fun"></param>
        public static void SaveFunc(string fileName, double a, double b, double h, function fun)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(fun(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// Метод загрузки из файла и нахождения минимума
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();

            return min;
        }

        static void Main(string[] args)
        {

            #region Задание 1 
            //Изменить программу вывода функции так, чтобы можно было передавать функции типа double(double, double).
            //Продемонстрировать работу на функции с функцией a*x ^ 2 и функцией a* sin(x).
            
            Console.WriteLine("Таблица функции a*x^2:");
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции a*sin(x):");
            //анонимный метод
            Table(delegate (double x, double a) { return a * Math.Sin(x); }, -2, 2);

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 2
            //Модифицировать программу нахождения минимума функции так, 
			//чтобы можно было передавать функцию в виде делегата.
			
            function[] F = { F1, F2 }; //массив делегатов с разными функциями

            Console.WriteLine("Сделайте выбор: 1 - функция F1, 2 - функция F2");
            int index = int.Parse(Console.ReadLine());
            SaveFunc("data.bin", -100, 100, 0.5, F[index - 1]);

            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
            #endregion
        }
    }
}