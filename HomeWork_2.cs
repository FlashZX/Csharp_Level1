// Насыров Игорь. г.Пермь. Домашка №2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2
{
    class Program
    {

        /// <summary>
        /// Mетод, возвращающий минимальное из трех чисел.
        /// </summary>
        static int minnum(int a, int b, int c)
        {
            int min = a;
            if (b < min) min = b;
            if (c < min) min = c;

            return min;
        }

        /// <summary>
        /// Mетод подсчета количества цифр числа.
        /// </summary>
        static int qnum(int n)
        {
            return (int)Math.Log10(n) + 1;
        }

        /// <summary>
        /// Проверка пароля
        /// </summary>
        static bool access(string login, string password)
        {
            bool passing;

            if (login == "root" && password == "GeekBrains")
                passing = true;
            else
                passing = false;
            
             return passing;
        }

        /// <summary>
        /// Рекурсивный метод. Выводим числа от а до b.
        /// </summary>
        private static void AtoB(int a, int b)
        {
            if(a <= b)
            {
                Console.WriteLine(a);
                AtoB(a + 1, b);
            }
        }

        static void Main(string[] args)
        {
            #region Задача 1 
            Console.WriteLine("Введите 3 числа");

            int min = minnum(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Console.WriteLine("Минимальное число = " + min);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задача 2
            Console.Write("Введите число: ");

            int num1 = int.Parse(Console.ReadLine());
            int num2 = qnum(num1);

            Console.WriteLine("Колличество цифр числа - " + num1 + " = " + num2);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задача 3
            //3.С клавиатуры вводятся числа, пока не будет введен 0.
            //Подсчитать сумму всех нечетных положительных чисел.
            int n = 1, sum = 0;

            Console.WriteLine("Введите нескоклько чисел, (число 0 - выход).");

            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n % 2 != 0 && n > 0) sum = sum + n;
            } while (n != 0);

            Console.WriteLine("Сумма всех нечетных, положительных чисел = " + sum);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задача 4
            string login, password;
            int attempts = 4;
            bool passing;

            do
            {
                Console.Write("Введите ваш логин: ");
                login = Console.ReadLine();
                Console.Write("Введите ваш пароль: ");
                password = Console.ReadLine();

                passing = access(login, password);
                attempts--;

                if (passing == true)
                    Console.WriteLine("Добро пожаловать в GeekBrains!");
                else
                    Console.WriteLine("Не верный логин, или пароль. Осталось попыток - " + (attempts - 1));

                if (attempts > 1) Console.ReadKey();
                Console.Clear();
            } while (attempts > 1);

            Console.WriteLine("Вы не прошли проверку, прощайте!");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задача 6 (Хорошие числа)
            int goodnum = 0;
            int minn = 1, maxn = 10000000;
            int t;
            int tnum;

            DateTime tim = DateTime.Now;

            for (int num = minn; num <= maxn; num++)
            {
                t = 0;
                tnum = num;
                while (tnum != 0)
                {
                    t += tnum % 10;
                    tnum /= 10;
                }
                if (num % t == 0) goodnum++;
            }

            Console.WriteLine(DateTime.Now - tim);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задача 7 Рекурсия
            AtoB(1, 15);

            Console.ReadKey();
            #endregion
        }


    }
}
