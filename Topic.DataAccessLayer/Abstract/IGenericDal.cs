using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Topic.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();   
        List<T> GetFilteredList(Expression<Func<T, bool>> filter);  //Liste şeklinde Filtreleme işlemlerinde kullanmak için bu method.
        T GetByFilter(Expression<Func<T, bool>> filter);    //Tek değerle filtreleme için.
        T GetById(int id);  //Tek değer döndürdüğü için T ile yazılıyor.
        void Delete(int  id);   //Geriye değer döndürmediği için void.
        void Create(T entity);
        void Update(T entity);
    }
}
