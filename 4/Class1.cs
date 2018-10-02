using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_4
{
    class MyArray
    {
        int[] a;
        public int MaxCount { get; set; }

        /// <summary>
        /// Создаем целочисленный массив, заполняющийся числами от начального значения с заданным шагом.
        /// </summary>
        /// <param name="n">количество элементов</param>
        /// <param name="start">значение 0 элемента массива</param>
        /// <param name="step">шаг изменения каждого последующего значения</param>
        public MyArray(int n, int start, int step)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = start + step * i;
            }
        }

        /// <summary>
        /// Читаем массив из файла
        /// </summary>
        /// <param name="filename">имя файла .txt</param>
        public MyArray(string filename)
        {
            //Если файл существует
            if (File.Exists(filename))
            {
                //Считываем все строки из файла
                string[] ss = File.ReadAllLines(filename);
                a = new int[ss.Length];
                //Переводим данные из строкового формата в числовой
                for (int i = 0; i < ss.Length; i++)
                    a[i] = int.Parse(ss[i]);
            }
            else Console.WriteLine("Error load file");
        }

        /// <summary>
        /// Свойство для расчета суммы всех элементов целочисленного массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }

        /// <summary>
        /// Метод меняющий знаки элементов массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= -1;
            }
        }

        /// <summary>
        /// Метод умножающий все элементы массива на число
        /// </summary>
        /// <param name="x">множитель</param>
        public void Multi(int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = -a[i];
            }
        }

        /// <summary>
        /// Свойство, показывающие количество элементов массива с максимальным значением
        /// </summary>
        public int MaxCounter(int[] arr)
        {
            int max = arr.Max();
            int s = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == max)
                    s += 1;
            }
            return s;
        }

        /// <summary>
        /// Выводим на консоль все элементы массива в одной строке
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит количеств пар элементов массива, делящихся на n без остатка
        /// </summary>
        /// <param name="n">делитель</param>
        /// <returns>количество пар элементов массива</returns>
        public int Pair_to_N(int n)
        {
            int count = 0;
            for (int i = 0; i < (a.Length - 1); i++)
            {
                if ((a[i] % n == 0) || (a[i + 1] % n == 0))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Свойство для записи в файл
        /// </summary>
        /// <param name="filename"></param>
        public void Rec(string filename)
        {
            //переводим данные из чисел в строки
            string[] a_string = new string[a.Length];
            for (int i = 0; i < a_string.Length; i++)
                a_string[i] = Convert.ToString(a[i]);

            //пишем массив со строками в файл
            System.IO.File.WriteAllLines(filename, a_string);
        }
    }

}
