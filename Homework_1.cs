// Насыров Игорь.  ДОМАШНЕЕ ЗАДАНИЕ №1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domashka_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Анкета
            string name, lastname, age, growth, weight;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            lastname = Console.ReadLine();

            Console.WriteLine("Сколько вам лет?");
            age = Console.ReadLine();

            Console.WriteLine("Какой у вас рост?");
            growth = Console.ReadLine();

            Console.WriteLine("Какой у вас вес?");
            weight = Console.ReadLine();

            Console.WriteLine("\n\nПациент: " + name + " " + lastname + ". Возраст: " + age + " Лет. Рост: " + growth + " Вес: " + weight);
            Console.ReadKey();
            #endregion

            #region Индекс массы тела
            double m = Convert.ToDouble(weight);
            double h = Convert.ToDouble(growth);

            h = h / 100;
            double i = m / (h * h);
            Console.WriteLine("Идекс массы тела, при росте: " + growth + "см. = {0:0.00}", i);
            Console.ReadKey();
            Console.Clear();
            #endregion
            
            #region расстояние между точками

            int x1 = 10, y1 = 10, x2 = 26, y2 = 32;
            /*Console.WriteLine("Введите координату X первой точки");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y первой точки");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату X второй точки");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y второй точки");
            y2 = Convert.ToInt32(Console.ReadLine());*/

            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между точками = {0:0.00} ", r);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region обмен значениями 2х переменных
            //С 3й переменной
            int a = 10, b = 20;
            int t = a;

            a = b; // В a записываем b
            b = t; // В b записываем сохраненное a

			//без 3й переменной
            int a = 11, b = 24; 

            a = a + b;
            b = b - a;
            b = -b;
            a = a - b;
            #endregion

            #region В центре экрана
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Игорь Насыров, г. Пермь.");
            Console.ReadKey();

            Print("Игорь Насыров, г. Пермь.", 10, 5);
            #endregion
        }
		
		//метод вывода сообщений по координатам курсора
        static void Print(string message, int x, int y) 
        {
            Console.SetCursorPosition(x, y);
            Console.Write(message);
            Console.ReadKey();
        }

		// 6-ое задание сделали с преподавателем на вебинаре.
    }
}
