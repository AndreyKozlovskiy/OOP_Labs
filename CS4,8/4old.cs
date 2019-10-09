using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSHARP4
{
    public class Set
    {

        public static int count = 0;
        private int[] arr;
        public class Owner
        {
            static int count = 0;
            private string name;
            private string orghanisation;
            private int id;
            public Owner()
            {

            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value + '.';
                }
            }
            public string Orghanisation
            {
                get
                {
                    return orghanisation;
                }
                set
                {
                    orghanisation = value + '.';
                }
            }
            public Int64 Iden
            {

                set { id = count; }
                get { count++; return count; }

            }
        }
        public static class MathOperations
        {
            static public int Min(Set array)
            {
                return array.arr.Min();
            }
            static public int Max(Set array)
            {
                return array.arr.Max();
            }
            static public int Countelem(Set array)
            {
                return array.arr.Length;
            }
        }
        Owner identif;
        public class Date 
        {
            private string strdate = "06.08.2019";
            public string str
            {
                get
                {
                    return strdate;
                }
            }
        }
        public Set()
        { }
        public Set(int[] array)
        {
            arr = array;
            count++;
        }
        public int[] arrset
        {
            get
            {
                return arr;
            }
            set
            {
                arr = value;
            }
        }
        public void Show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}\t", arr[i]);
            }
            Console.WriteLine();
        }
        static public Int32[] operator -(Set array, int IndexToDelete)
        {
            if (array.arr.Length == 0) return array.arr;
            if (array.arr.Length <= IndexToDelete) return array.arr;

            var output = new int[array.arr.Length - 1];
            int counter = 0;

            for (int i = 0; i < array.arr.Length; i++)
            {
                if (i == IndexToDelete - 1) continue;
                output[counter] = array.arr[i];
                counter++;
            }
            return output;
        }
        static public List<int> operator *(Set array1, Set array2)
        {
            List<int> b = new List<int>();
            if (array1.arr.Length == 0 || array1.arr.Length == 0) return null;
            for (int i = 0; i < array1.arr.Length; i++)
            {
                for (int j = 0; j < array2.arr.Length; j++)
                {
                    if (array1.arr[i] == array2.arr[j])
                    {
                        b.Add(array1.arr[i]);
                        i++;
                        if(i>array1.arr.Length)
                        {
                            i = 0;
                        }
                        j = 0;
                        
                    }
                }
            }
            return b;
        }
        static public bool operator <(Set array1, Set array2)
        {
            if (array1.arr.Length == array2.arr.Length)
                Console.WriteLine("Множества равнозначны");
            if (array1.arr.Length > array2.arr.Length)
                Console.WriteLine("Множество 1 мощнее Множества 2");
            if (array1.arr.Length < array2.arr.Length)
                Console.WriteLine("Множество 2 мощнее Множества 1");
            return true;
        }
        static public bool operator >(Set array1, Set array2)
        {
            int d = 0;
            for (int i = 0; i < array2.arr.Length; i++)
            {
                for (int j = 0; j < array1.arr.Length; j++)
                {
                    if (array2.arr[i] == array1.arr[j])
                    {
                        d++;
                        continue;
                    }
                }
            }
            if (d == array2.arr.Length) return true;
            return false;
        }
        static public bool operator &(Set array1, Set array2)
        {
            if (array1.arr.Length != array2.arr.Length) return false;
            for (int i = 0; i < array2.arr.Length; i++)
            {
                if (array2.arr[i] != array1.arr[i]) return false;
            }
            return true;
        }

        public void  Delnul()
        {
            if (arr.Length == 0) return ;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0) count++;
            }
            var output = new int[arr.Length - count];
            var counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0) continue;
                output[counter] = arr[i];
                counter++;
            }
            arr=output;
        }
    }
    public interface ICollect<T>
    {
        void Add(params T[] a);
        void Show();
        void Delete(int index);
    }
    class SetCollection<T> : ICollect<T>
    {
        private List<T> lst = new List<T>();
        public void WriteInFile(T obj)
        {
            if (lst.Contains(obj))
            {
                byte[] array;
                using (FileStream fstream = new FileStream(@"D:\data.txt", FileMode.Create))
                {
                    array = Encoding.Default.GetBytes(obj.ToString());
                    fstream.Write(array, 0, array.Length);
                    Console.WriteLine("Текст записан в файл");
                }
                using (FileStream fstream = File.OpenRead(@"D:\data.txt"))
                {
                    array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string textFromFile = System.Text.Encoding.Default.GetString(array);
                    Console.WriteLine($"Текст из файла\n{textFromFile}");
                }
            }
        }
        public void Add(params T[] objToAdd)
        {
            foreach(T i in objToAdd)
            lst.Add(i);
        }
        public void Delete(int index)
        {
            lst.RemoveAt(index);
        }
        public void Show()
        {
            foreach(T i in lst)
            {
                Console.WriteLine($"{i.ToString()}");
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            { 
            Set s1 = new Set();
            Set s2 = new Set();
            int[] getvalues()
                {
                Console.Write("Введите количество элементов:");
                int amou = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                int[] mass = new int[amou];
                for (int i = 0; i < amou; i++)
                {
                    mass[i] = Convert.ToInt32(Console.ReadLine());
                }
                return mass;
            }
            SetCollection<double> myCollection3 = new SetCollection<double>();
            myCollection3.Add(3.5, 2.4);
            myCollection3.WriteInFile(3.6);
            SetCollection<int> myCollection4 = new SetCollection<int>();
            myCollection4.Add(10, 5);
            myCollection4.WriteInFile(10);
            SetCollection<string> myCollection = new SetCollection<string>();
            myCollection.Add("abc","csd");
            myCollection.WriteInFile("sadasd");
            SetCollection<Set> myCollection2 = new SetCollection<Set>();
            myCollection2.Add(s1, s2);
            myCollection2.WriteInFile(s1);
            int Showmenu(int choic)
            {
                
                Console.Write("\n0-Выход\n1-Замена множества\n2-Вывод множества\n3-Удаления элемента из множества\n" +
                    "4-Добавления нового множества\n5-Пересечение множеств\n"+
                    "6-Проверка на подмножество\n7-Проверка на равенство\n8-Сравнение множеств\n" +
                    "9-Удаление нулевых элементов\n10-Вывести дату создания\n11-Данные пользователя\n" +
                    "12-Подсчет элементов\n13-Подсчет минимального значения\n14-Подсчет максимального значения\nВведите название операции:");
                choic=Convert.ToInt16(Console.ReadLine());
                return choic;
            }
            int choice = 1;
                while (choice != 0)
                {
                    choice = Showmenu(choice);
                    switch (choice)
                    {
                        case 1:
                            s1 = new Set(getvalues());
                            break;
                        case 2:
                            s1.Show();
                            break;
                        case 3:
                            Console.Write("Какой элемент удалить");
                            s1.arrset = s1 - Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            s2 = new Set(getvalues());
                            break;
                        case 5:
                            List<int> li = s1 * s2;
                            foreach (int i in li)
                            {
                                Console.WriteLine(i);
                            }
                            break;
                        case 6:
                            bool usl = s1 > s2;
                            if (usl == true) Console.WriteLine("Часть подмножества");
                            else Console.WriteLine("Не часть подмножества");
                            break;
                        case 7:
                            Console.WriteLine($"Множества равны:{s1 & s2}");
                            break;
                        case 8:
                            var q = s1 < s2;
                            break;
                        case 9:
                            s1.Delnul();
                            break;
                        case 10:
                            Set.Date today = new Set.Date();
                            Console.WriteLine(today.str);
                            break;
                        case 11:
                            Set.Owner own = new Set.Owner();
                            Console.WriteLine("Введите ваше имя и название организации");
                            own.Name = Console.ReadLine();
                            own.Orghanisation = Console.ReadLine();
                            Console.WriteLine($"Здравствуйте, {own.Name}, из компании {own.Orghanisation}, Ваш id={own.Iden}");
                            break;
                        case 12:
                            Console.WriteLine(Set.MathOperations.Countelem(s1));
                            break;
                        case 13:
                            Console.WriteLine(Set.MathOperations.Min(s1));
                            break;
                        case 14:
                            Console.WriteLine(Set.MathOperations.Max(s1));
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.TargetSite);
            }
        }
    }
}
