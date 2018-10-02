//Насыров Игорь. г.Пермь. Домашка № 4.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_4
{
    
    class Program
    {
        /// <summary>
        /// Метод считывания из файла txt
        /// </summary>
        /// <param name="filename">имя файла .txt</param>
        static void Read(string filename)
        {
            if (File.Exists(filename))
            {
                //Считываем все строки из файла
                string[] ss = File.ReadAllLines(filename);
                for (int i = 0; i < ss.Length; i++)
                {
                    Console.Write(ss[i] + " ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("Error load file");
        }

        static void Main(string[] args)
        {
            #region Задание 1 (Пары эллементов)
            Random rnd = new Random();
            int[] Array1 = new int[20];
            int count = 0;

            for (int i = 0; i < Array1.Length; i++) Array1[i] = rnd.Next(-10000, 10001);
            for (int i = 0; i < Array1.Length - 1; i++)
            {
                if (Array1[i] % 3 == 0 || Array1[i + 1] % 3 == 0)
                {
                    count++;
                    Console.WriteLine("Пара числел - {0} и {1}", Array1[i], Array1[i + 1]);
                }
            }
            Console.WriteLine("Колличечтво пар элементов - " + count);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 2а
            MyArray array1 = new MyArray(15, 0, 2);
            array1.Print();

            Console.WriteLine("Сумма: " + array1.Sum);

            array1.Inverse();
            Console.Write("Инверсия: ");
            array1.Print();

            array1.Multi(3);
            Console.Write("Умножаем на 3: ");
            array1.Print();
            Console.WriteLine("Количество максимальных элементов в массиве array1: " + array1.MaxCount);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 2б
            MyArray array2 = new MyArray(@"d:\test.txt");

            Console.WriteLine("Читаем из файла");
            array2.Print();
            Console.WriteLine("Пишем в файл массив array1 и читаем файл с новыми данными");
            array1.Rec(@"d:\test.txt");
            Read(@"d:\test.txt");

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 3 (в структуру уже не успел)
            //Считываем все строки из файла
            int attempts = 4;
            bool passing;

            string ulogin;
            string upassword;

            StreamReader sr = new StreamReader(@"d:\account.txt");
            string login = sr.ReadLine();
            string password = sr.ReadLine();

            do
            {
                Console.Write("Введите логин: ");
                ulogin = Console.ReadLine();
                Console.Write("Введите пароль: ");
                upassword = Console.ReadLine();
                attempts--;

                if (ulogin == login && upassword == password)
                {
                    passing = true;
                }
                else passing = false;

                if (passing == true)
                    Console.WriteLine("Добро пожаловать!");
                else
                    Console.WriteLine("Логин или пароль, введен не верно!");
                Console.ReadKey();
                Console.Clear();
            } while (attempts > 1);

            Console.WriteLine("Вы не прошли проверку, прощайте!");
            Console.ReadKey();
            Console.Clear();
            #endregion
        }


    }
}