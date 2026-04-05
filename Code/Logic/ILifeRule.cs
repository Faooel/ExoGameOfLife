using System;
using System.Collections.Generic;

namespace GameOfLife.Logic 
{
    // interface les differentes variantes
    public interface ILifeRule 
    {
        bool WillBeAlive(bool vivant, int nb_v);
    }
}