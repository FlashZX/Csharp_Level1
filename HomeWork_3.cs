// Насыров Игорь. Домашнее задание № 3.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork_3
{
    /// <summary>
    /// Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
    /// Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
    /// Написать программу, демонстрирующую все разработанные элементы класса
    /// </summary>
    class Drob
    {
        public double c;
        public double z;

        public Drob(double ch, double zn)
        {
            c = ch;
            z = zn;
        }
        public override string ToString()
        {
            return c.ToString() + "/" + z.ToString();
        }
        public static Drob operator +(Drob a, Drob b)
        {
             return new Drob(a.c * b.z + a.z * b.c, a.z * b.z);
        }
        public static Drob operator -(Drob a, Drob b)
        {
            return new Drob(a.c * b.z - a.z * b.c, a.z * b.z);
        }
        public static Drob operator *(Drob a, Drob b)
        {
            return new Drob(a.c * b.c, a.z * b.z);
        }
        public static Drob operator /(Drob a, Drob b)
        {
            return new Drob(a.c / b.c, a.z / b.z);
        }
    }

    struct Complex
    {
        public double im;
        public double re;
 
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public Complex Minus(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public Complex Divis(Complex x)
        {
            Complex y;
            y.im = re / x.im + im / x.re;
            y.re = re / x.re - im / x.im;
            return y;
        }
        public override string ToString()
        {
            return re + "." + im + "i";
        }
    }


    class Program
    {
        /// <summary>
        /// подсчитать сумму всех нечетных положительных чисел, числа и сумму вывести на экран, используя tryParse;
        /// Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
        /// При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
        /// </summary>
        public static int parse()
        {
            int n, sum = 0;

            do
            {
                bool result = int.TryParse(Console.ReadLine(), out n);

                if (!result)
                {
                    Console.WriteLine("Введены не корректные данные!");
                    Console.ReadKey();
                }
                else
                    if (n % 2 != 0 && n > 0) sum = sum + n;
            } while (n != 0);

            return sum;
        }

        static void Main(string[] args)
        {

            #region Задание 1
            Complex complex1;
            complex1.re = 1;
            complex1.im = 1;
            Complex complex2;
            complex2.re = 2;
            complex2.im = 2;

            Complex result = complex1.Plus(complex2);
            Console.WriteLine(result.ToString());

            result = complex1.Multi(complex2);
            Console.WriteLine(result.ToString());

            result = complex1.Minus(complex2);
            Console.WriteLine(result.ToString());

            result = complex1.Divis(complex2);
            Console.WriteLine(result.ToString());

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 2
            int sum = 0;

            Console.WriteLine("Введите нескоклько чисел, (число 0 - остановка ввода).");
            sum = parse();
            Console.WriteLine("Сумма всех нечетных, положительных чисел = " + sum);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 3 (дроби)
            Console.Write("Введите числитель первой дроби: ");
            int dr1_ch = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель первой дроби: ");
            int dr1_zn = int.Parse(Console.ReadLine());
            Console.Write("Введите числитель второй дроби: ");
            int dr2_ch = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель второй дроби: ");
            int dr2_zn = int.Parse(Console.ReadLine());
            Console.Clear();

            Drob drob1 = new Drob(dr1_ch, dr1_zn);
            Drob drob2 = new Drob(dr2_ch, dr2_zn);

            // Drob drob1 = new Drob(3, 4);
            // Drob drob2 = new Drob(2, 8);

            Console.Write("Введите действие (+ - * /): ");
            char c = Convert.ToChar(Console.ReadLine());

            switch (c)
            {
                case '+': Console.WriteLine("Результат: " + (drob1 + drob2)); break;
                case '-': Console.WriteLine("Результат: " + (drob1 - drob2)); break;
                case '*': Console.WriteLine("Результат: " + (drob1 * drob2)); break;
                case '/': Console.WriteLine("Результат: " + (drob1 / drob2)); break;
            }
            Console.ReadKey();
            #endregion
        }
    }
}
