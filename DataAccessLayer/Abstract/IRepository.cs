using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        int Insert(T p);
        int Update(T p);
        int Delete(T p);

        T GetById(int id);
        List<T> ListWhere(int id);
    }
}
