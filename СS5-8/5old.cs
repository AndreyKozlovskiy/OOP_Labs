using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace СS5
{
    class PlantException:ArgumentException
    {
        public string Strvalue { get; }
        public int Value { get; }
        public PlantException(string message)
        : base(message)
        { }
        public PlantException(string message,int val): base(message)
        {
            Value = val;
        }
        public PlantException(string message, string val) : base(message)
        {
            Strvalue = val;
        }
    }
    enum FlowerCatalog
    {
        Roses,
        Romashki,
        Narciss
    }
    interface IMusttobe
    {

        void Show();
        int Buy();
        string ToString();
    }
    class Printer
    {
        
        static public void IAmPrinnting(IMusttobe A)
        {
            A.ToString();
        }
    }
    abstract partial class Plant:IMusttobe,IComparable
    {
        private string name;
        private int price;
        private int amount;
        public string Color { get; set; }
        private int id;
        static int count =0;
        public int CompareTo(object obj)
        {
            Plant p = obj as Plant;
            if (p != null)
                return this.price.CompareTo(p.price);
            else
                throw new PlantException("Невозможно сравнить два объекта");
        }
        public string Getname
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Getprice
        {
            get
            {
                count++;
                return price;
            }
            set
            {
                if(value>=0)
                {
                    price = value;
                }
                else
                {
                    throw new PlantException("Нельзя задать цену отрицательным значением",value);
                }
            }
        }
        public int Getamount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value >= 0)
                {
                    amount = value;
                }
                else
                {
                    throw new PlantException("Нельзя задать количество отрицательным значением",value);
                }
            }
        }
        public int Getid
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        virtual public void Show()
        {
            Console.WriteLine($"{id}-{name}  {price} р.  {amount} шт.   цвет:{Color}");
        }
        virtual public int Buy()
        {
            Console.WriteLine("Какое количество товаров вы хотите купить");
            int amountToBuy = Convert.ToInt32(Console.ReadLine());
            if (amountToBuy > amount)
            {
                Console.WriteLine("Такого количества нет на складе");
                return 0;
            }
            amount -= amountToBuy;
            Console.WriteLine("Покупка совершенна");
            return amountToBuy * price;
        }
        public override string ToString()
        {
            return $"Тип объекта:{this.GetType()} \n{this.id}\t{this.name}\t{this.price}";
        }
    }
    class Paper:Plant
    {
       
    }
    sealed class Tree:Paper
    {

    }
    abstract class Bouquet:Plant
    {
        abstract public void Pleusure();
    }
     sealed class Flower: Bouquet
    {
        public override void Pleusure()
        {
            Console.WriteLine("Поставляем только лучшие цветы");
        }
    }
    sealed class Bush : Bouquet
    {
        public override void Pleusure()
        {
            Console.WriteLine("Поставляем только лучшие цветы и кустарники");
        }
        public int amount;
        public string name;
        public int price;
        public int id;
        override public int Buy()
        {
            Console.WriteLine("Какое количество товаров вы хотите купить");
            int amountToBuy = Convert.ToInt32(Console.ReadLine());
            if (amountToBuy > amount)
            {
                Console.WriteLine("Такого количества нет на складе");
                return 0;
            }
            amount -= amountToBuy;
            return amountToBuy * price;
        }
        override public void Show()
        {
            Console.WriteLine($"{id}-{name}  {price} р.  {amount} шт.   цвет:{Color}");
        }
    }

    class Program
    {
        static void Yourchoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Showbase();
                    break;
                case 2:
                    Console.WriteLine("Что вы бы хотели купить(Выберите по индексу):");
                    Showbase();
                    short choiceToBuy = Convert.ToInt16(Console.ReadLine());
                    if (choiceToBuy == 1 || choiceToBuy == 2 || choiceToBuy == 3)
                    {
                        switch (choiceToBuy)
                        {
                            case 1:
                                Kaktus.Buy();
                                break;
                            case 2:
                                Roses.Buy();
                                Roses.Pleusure();
                                break;
                            case 3:
                                Gladiolus.Buy();
                                Gladiolus.Pleusure();
                                break;
                        }
                    }
                    break;
                case 3:
                    {
                        choiceToBuy = 1;
                        while (choiceToBuy != 0)
                        {
                            Console.WriteLine("0-выход\n1-Добавить элементы в коллекцию\n2-Показать элементы в коллекции" +
                                "\n3-Удаление элемента из коллекции\n4-Купить букет" +
                                "");
                            choiceToBuy = Convert.ToInt16(Console.ReadLine());
                            if (choiceToBuy == 1 || choiceToBuy == 2 || choiceToBuy == 3 || choiceToBuy == 4)
                            {
                                switch (choiceToBuy)
                                {
                                    case 1:
                                        MyCollection.Add(Kaktus, Roses, Gladiolus);
                                        break;
                                    case 2:
                                        MyCollection.Show();
                                        break;
                                    case 3:
                                        MyCollection.Delete();
                                        break;
                                    case 4:
                                        Console.WriteLine($"{Controller.Buy(MyCollection)} руб.");
                                        break;

                                }
                            }
                        }
                    }
                    return;
                default: return;
            }
        }
        static Plant.Charact sda = new Plant.Charact();
        static Plant papirus = new Paper();
        static Bush Roses = new Bush();
        static Flower Gladiolus = new Flower();
        static Tree Kaktus = new Tree();
        static GetBouqet<Plant> MyCollection = new GetBouqet<Plant>();
        static void Showbase()
        {
            Kaktus.Show();
            Roses.Show();
            Gladiolus.Show();
        }
        static void Main()
        {
            sda.color = "sda";
            sda.location = "Minsk";
            sda.years = 14;
            Debug.Assert(sda.years != 13, "Years can't be 14");
            int[] aa = null;
            try {
                Console.Write("Введите вид кактуса:");
                Kaktus.Getname = Console.ReadLine();
                Console.Write("Введите цену:");
                Kaktus.Getprice = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество:");
                Kaktus.Getamount = Convert.ToInt32(Console.ReadLine());
                Kaktus.Getid = 1;
                Roses.id = 2;
                Gladiolus.Getid = 3;
                Console.Write("Введите вид роз:");
                Roses.name = Console.ReadLine();
                Console.Write("Введите цену:");
                Roses.price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество:");
                Roses.amount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите вид гладиолуса:");
                Gladiolus.Getname = Console.ReadLine();
                Console.Write("Введите цену:");
                Gladiolus.Getprice = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество:");
                Gladiolus.Getamount = Convert.ToInt32(Console.ReadLine());
                string someStr = null;
                bool chekStr = someStr is string;
                if (Kaktus is Plant)
                {
                    Plant Kaktus1 = (Plant)Kaktus;
                }
                Plant ed = Kaktus as Plant;
                //if (ed != null) { Console.WriteLine(ed.GetType()); }
                //Printer.IAmPrinnting(Kaktus);
                //Printer.IAmPrinnting(Roses);
                //Printer.IAmPrinnting(Gladiolus);
                int choice = 1;
                Kaktus.Color = "Green"; Roses.Color = "White"; Gladiolus.Color = "Yellow";
                while (choice != 0)
                {
                    Console.WriteLine("0-Выход\n1-Просмотреть базу\n2-Купить товар\n3-перейти к коллекциям");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Yourchoice(choice); 
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Место:{ex.Source}");
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine("Индекс элемента массива или коллекции находится вне диапазона допустимых значений");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Место:{ex.Source}");
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine("Попытка поделить на ноль");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Место:{ex.Source}");
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine("Значение аргумента находится вне диапазона допустимых значений");
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine($"Место:{ex.Source}");
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine("Попытка произвести недопустимые преобразования типов");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Место:{ex.Source}");
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine("Попытка обращения к объекту, который равен null");
            }
            catch(PlantException ex)
            {
                Console.WriteLine($"Место:{ex.Source}");
                try
                {
                    Console.WriteLine("ENTER 0");
                    int q=Convert.ToInt32(Console.ReadLine());
                    int i = 10 /q;
                }
                catch(DivideByZeroException e )
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение:{ex.Strvalue}{ex.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Конец программы");
            }
        }
    }
}
