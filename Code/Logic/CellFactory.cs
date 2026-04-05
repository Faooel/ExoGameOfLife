using GameOfLife.Models;

namespace GameOfLife.Logic {
    public class CellFactory {
        // fabriquer une cellule
        public Cell CreateCell(int coordX, int coordY, bool estVivante) {
            // créer une cell
            var nouvelleCellule = new Cell();
            
            nouvelleCellule.X = coordX;
            nouvelleCellule.Y = coordY;
            nouvelleCellule.IsAlive = estVivante;

            return nouvelleCellule;
        }
    }
}