using System;
using System.Collections.Generic;

namespace TheBlackDuck.Models.Interfaces
{
    public interface ICRUD<T>
    {
        Boolean UpdateByID();
        List<T> ListAll();
        Boolean DeleteByID();
        T GetByID();
    }

}
