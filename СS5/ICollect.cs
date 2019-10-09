using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СS5
{
    public interface ICollect<T>
    {
        void Add(params T[] a);
        void Show();
        void Delete();
    }
}
