using System;
using System.Collections.Generic;

namespace SyncBlackDuck.Services.Interfaces
{
    public interface ICRUD<T>
    {
        public Boolean insertar(T item);
        public Boolean modificar(T item);
        public Boolean eliminar(T item);
        public List<T> verTodo();

    }
}
