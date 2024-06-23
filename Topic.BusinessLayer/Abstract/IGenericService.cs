using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Topic.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();
        List<T> TGetFilteredList(Expression<Func<T, bool>> filter);  //Liste şeklinde Filtreleme işlemlerinde kullanmak için bu method.
        T TGetByFilter(Expression<Func<T, bool>> filter);    //Tek değerle filtreleme için.
        T TGetById(int id);  //Tek değer döndürdüğü için T ile yazılıyor.
        void TDelete(int id);   //Geriye değer döndürmediği için void.
        void TCreate(T entity);
        void TUpdate(T entity);
    }
}
