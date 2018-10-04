//Насыров Игорь. г.Пермь. Домашка № 5.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace HomeWork5
{
    class Program
    {
        /// <summary>
        /// Проверяем логин (не меньше 2х и не больше 10ти латинских букв, цифра не может быть первой).
        /// С использованием ругулярки
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static bool LoginRegex(string login)
        {
            return Regex.IsMatch(login, @"^[a-zA-Z][a-zA-Z0-9]{1,9}$");
        }

        static void Main(string[] args)
        {
            //1.Создать программу, которая будет проверять корректность ввода логина. 
            //Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита 
            //или цифры, при этом цифра не может быть первой:

            #region Задание 1а (без использования регулярок)
            string mylogin;

            Console.Write("Введите логин: ");
            mylogin = Console.ReadLine();

            Console.WriteLine(mylogin);

            if (mylogin.Length < 2 || mylogin.Length > 10 || Char.IsNumber(mylogin[0]))
                Console.WriteLine("Нет, это не верный формат!");
            else
                Console.WriteLine("Да, этот логин подойдет!");

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 1б (С использованием регулярок)
            bool correctLogin;
            Console.Write("Введите логин: ");
            correctLogin = LoginRegex(Console.ReadLine());

            if (correctLogin)
                Console.WriteLine("Молодец, ты знаешь как вводить этот чертов логин!");
            else
                Console.WriteLine("Нет, это не верный формат!");

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 4 задача ЕГЭ
            Random rnd = new Random();
            List<students> mylist = new List<students>();
            mylist.Add(new students() { lastname = "Ладен", name = "Усама", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Луначарский", name = "Павел", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Катасонов", name = "Олег", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Свиридова", name = "Алена", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Кинчев", name = "Костя", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Цезарь", name = "Юлий", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Камянецкий", name = "Сергей", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Михалков", name = "Никита", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Малахов", name = "Чудила", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Сивкова", name = "Алиса", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });
            mylist.Add(new students() { lastname = "Горбачев", name = "Михуил", Mark_1 = rnd.Next(1, 5), Mark_2 = rnd.Next(1, 5), Mark_3 = rnd.Next(1, 5) });

            List<students> newList = new List<students>();
            foreach (var item in mylist)
            {
                double sr = ((double)item.Mark_1 + (double)item.Mark_2 + (double)item.Mark_3) / 3;
                newList.Add(new students() { lastname = item.lastname, name = item.name, srMark = sr });
                Console.WriteLine(item.lastname + " " + item.name + " " + item.Mark_1 + " " + item.Mark_2 + " " + item.Mark_3 + ". Средний балл = {0:0.00}", sr);
            }

            Console.WriteLine("\nХудшие ученики:\n");
            newList = newList.OrderBy(o => o.srMark).ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(newList[i].lastname + " " + newList[i].name + " " + "{0:0.00}", newList[i].srMark);
            }
            for (int i = 4; i < newList.Count; i++)
            {
                if (newList[i].srMark == newList[3].srMark)
                {
                    Console.WriteLine(newList[i].lastname + " " + newList[i].name + " " + "{0:0.00}", newList[i].srMark);
                }
            }
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 5 (игра угадайка)
            int points = 0;
            var document = XDocument.Load(Environment.CurrentDirectory + @"\questions.xml");

            var list = new List<XmlData>();
            foreach (var item in document.Element("body").Elements("questions"))
                list.Add(new XmlData() { question = item.Attribute("question").Value, answer = item.Attribute("answer").Value });

            Random rand = new Random();
            int kol = 0;
            bool flag = true;

            while (flag == true)
            {
                int value = rand.Next(0, 9);
                Console.WriteLine(list[value].question);
                string enter = Console.ReadLine().ToLower();

                if (enter == list[value].answer)
                {
                    Console.WriteLine("Верно!");
                    points += 5; // +5 очков если ответ верный
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Ответ неверный!");
                    Console.ReadKey();
                    Console.Clear();
                }
                kol++;
                if (kol == 5) flag = false;
            }
            Console.WriteLine("Ваши очки = {0}", points);
            Console.ReadKey();
            #endregion
        }
    }
}
