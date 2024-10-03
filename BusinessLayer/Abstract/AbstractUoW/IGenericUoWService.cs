using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUoW
{
    public interface IGenericUoWService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TMultiUpdate(List<T> entity);
        T TGetById(int id);
    }
}
