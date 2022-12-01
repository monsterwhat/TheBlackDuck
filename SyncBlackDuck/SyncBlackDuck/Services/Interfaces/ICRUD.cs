using System;
using System.Collections.Generic;

namespace SyncBlackDuck.Services.Interfaces
{
    public interface ICRUD<T>
    {
        public Boolean Insertar(T item);
        public Boolean Modificar(T item);
        public Boolean Eliminar(T item);
        public List<T> VerTodo();
    }
}
