using System;

namespace GameOfLife.Logic 
{
    public class StandardRule : ILifeRule 
    {
        // savoir si la cellule survit ou nait
        public bool WillBeAlive(bool vivant, int nb_v) 
        {
            // si cellule vivante
            if (vivant == true) 
            {
                if (nb_v == 2 || nb_v == 3) 
                {
                    return true;
                }
                else 
                {
                    return false; 
                }
            }
            else 
            {
                // regle naissance
                if (nb_v == 3) 
                {
                    return true;
                }
                return false;
            }
        }
    }
}