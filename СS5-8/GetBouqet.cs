using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СS5
{
    class GetBouqet<T>:ICollect<T> where T :Plant
    {
        private static List<Plant> mainCollection = new List<Plant>();
        public void Add(params T[] objs)
        {
            foreach(Plant i in objs)  mainCollection.Add(i);
            mainCollection.Sort();
        }
        public void Show()
        {
            foreach(Plant i in mainCollection)
            {
                i.Show();
            }
        }
        public void Delete()
        {
            Console.WriteLine("Введите название для удаления");
            string name=Console.ReadLine();
            int count = 0;
            foreach(Plant i in mainCollection)
            {
                if (i.Color == name)
                {
                    mainCollection.Remove(i);
                    break;
                }
                count++;
            }
        }
        public int BuyBouquet()
        {
            foreach (Plant i in mainCollection)
            {
                i.Show();
            }
            int sum=0;
            foreach(Plant i in mainCollection)
            {
                sum+=i.Buy();
            }
            return sum;
        }
    }
}
