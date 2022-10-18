using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SyncBlackDuck.Services.Interfaces
{
    public interface ICRUD<T>
    {
        public Boolean insertar(T item);
        public Boolean modificar(T item, char T);
        public Boolean eliminar(T item);
        public ArrayList verTodo();

    }
}
