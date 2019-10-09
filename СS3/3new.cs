using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public interface IComparable
    {
        int CompareTo(object o);
    }
    public partial class Customer
    {
        public void  DoSomething() { }
    }

    public partial class Customer: IComparable
    {
        public string Name
        {
            set
            {
                if (10 < value.Length && value.Length < 50 && !value.Contains("123456789")) name = value;
                else name = "Не указано";
            }
            get
            {
                return name;
            }
        }
        public int CompareTo(object o)
        {
            Customer p = o as Customer;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public int Balance
        {
            set
            {
                if (0 <= value)  balance = value;
                else balance = 0;
            }
            get { return balance; }
        }
        public int Creditenum //Свойства
        {
            set
            {
                if (  0<=value&&value <= 99999)
                     creditenum= value;
                else creditenum = -1;
            }
            get { return creditenum; }
        }
        private string id;
        private string name;
        private string adress;
        private int creditenum;
        private int balance;
        public static int count = 1;    
        private const string serg="Serega";
        

        public void Add(int amount)
        {
            balance += amount;
        }
        public void Get(int amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                return;
            }
            Console.WriteLine("У вас недостаточно средств");
        }
        private Customer()//Стандартная дата
        {
            id =Convert.ToString(count) ;
            name = "Не указано";
            adress= "Не указано";
            creditenum = -1;
            balance = 0;
            
        }
        public Customer(int balance) : this()
        {
            this.balance = balance;
        }
        public string hash1(int month, int year)//Вычисление хэша взято с Support.Microsoft
        {
            string sSourceData=Convert.ToString(month)+year;
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            string ByteArrayToString(byte[] arrInput)
            {
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (int i = 0; i < arrInput.Length; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }
                return sOutput.ToString();
            }
            return ByteArrayToString(tmpHash);
            
        }
        public Customer(int numb,int bal):this()//Контейнер
        {
            this.creditenum = numb;
            this.balance = bal;
            count++;
            this.id = Convert.ToString(hash1(numb, bal));
        }
        public Customer(string name="N/A",string adress="N/A",int numb=0, int bal=0) : this()//Контейнер
        {
            this.name = name;
            this.adress = adress;   
            this.creditenum = numb;
            this.balance = bal;
            count++;
            this.id = Convert.ToString(hash1(numb, bal));
        }
        static Customer()
        {
            Customer a = new Customer();
        }
        public void Info1()//Функция вывода данных
        {
            Console.WriteLine($"{id}-{name} {adress}    {creditenum}    {balance} руб. ");
        }
        public void Info2()//Функция вывода данных
        {
            Console.WriteLine($"{count}-{name}/{adress}/{creditenum}    {balance} руб.   ----   {id}");
        }
        public readonly int day=DateTime.Today.Day;
        public readonly int month=DateTime.Today.Month;
        public readonly int year=DateTime.Today.Year;
        public void outref(ref int a,out int c)
        {
            a++;
            c = 3;
        }
        ~Customer()
        {

        }
    }
    class Program
    {
        
        public static void n()
        {
            Console.WriteLine("Hi");
            Thread.Sleep(400);
        }
        delegate void Message();
        static void Main(string[] args)
        {
            Message mes = n;
            Message mes2 = new Message(n);
            List<Customer> arr = new List<Customer>();
            
            Thread a = new Thread(new ThreadStart(n));
            var xc=a;
            xc.Start();
            Customer first = new Customer("Козловский Андрей Сергеевич","г.Минск",1234,100000);
            first.Balance = -490;
            first.Creditenum = -2;
            mes += first.Info1;
            mes();
            Console.WriteLine(first.ToString());
            var birthday = new {day=7,month="Декабря",year=2000 };
            Console.WriteLine($"Я родился {birthday.day} {birthday.month} {birthday.year} года");
            Customer second = new Customer("Шестопалов Денис Александрович","г.Львов", 2, 2000);
            //Customer fifth = new Customer();
            Customer third = new Customer(234,124);
            Customer fourth = new Customer("Капустин Александр Александрович","д.Бижеревичи", 6, 2020);
            Console.WriteLine("{0}",fourth.GetType());
            Customer[] customersAll = new Customer[4]{ first, second, third, fourth };
            int am;
            Console.WriteLine("Введите количество элементов для добавления");
            am = Convert.ToInt16(Console.ReadLine());
            Array.Resize<Customer>(ref customersAll, am+4);
            for (int i = 0; i < am; i++)
            {
                customersAll[i + 4] = new Customer(0,0);
            }
            for (int i = 0; i <  am+4; i++)
            {
                customersAll[i].Info1();
            }
            first.Balance = 1000;
            first.Info1();
            first.Add(10000);
            first.Info1();
            first.Get(1000);
            first.Info1();
            int b = 3;
            int c = 0;
            first.outref(ref b,out c);
            Console.WriteLine(); Console.WriteLine();
            Customer temp = new Customer(0,1);
            int q = 0;
            arr.Add(first);
            for(int i=0;i<customersAll.Length-1;i++)
            {
                for(int j=0;j<customersAll.Length-1;j++)
                {
                    if(customersAll[j].Name==customersAll[i].Name)
                    {
                        continue;
                    }
                    while (customersAll[j].Name[q] == customersAll[i].Name[q]) q++;
                    if (customersAll[j].Name[q] > customersAll[j+1].Name[q])
                    {
                        temp = customersAll[j];
                        customersAll[j] = customersAll[j + 1];
                        customersAll[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < am + 4; i++)
            {
                if(customersAll[i].Name!="Не указано")
                customersAll[i].Info1();
            }
            Console.WriteLine("Введите нижнее значение и верхнее");
            int min=Convert.ToInt32(Console.ReadLine()),max= Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<am+4;i++)
            {
                if(customersAll[i].Creditenum>min&& customersAll[i].Creditenum < max)
                {
                    customersAll[i].Info1();
                }
            }
            Console.WriteLine(Customer.count);
        }
    }
}
