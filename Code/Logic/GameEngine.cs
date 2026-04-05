using GameOfLife.Models;
using System.Collections.Generic;

namespace GameOfLife.Logic {
    public class GameEngine {
        public Cell[,] Grid { get; private set; }
        public int Width { get; }
        public int Height { get; }
        private ILifeRule _rule;

        // constructeur initialiser la grille
        public GameEngine(int width, int height, ILifeRule rule) {
            this.Width = width;
            this.Height = height;
            this._rule = rule;
            this.Grid = new Cell[width, height];
            
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    Cell c = new Cell();
                    c.X = i;
                    c.Y = j;
                    c.IsAlive = false;
                    Grid[i, j] = c;
                }
            }
        }

        public void NextGeneration() {
            Cell[,] nextGrid = new Cell[Width, Height];
            
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    int count = CountNeighbors(i, j);
                    bool currentState = Grid[i, j].IsAlive;
                    
                    bool nextState = _rule.WillBeAlive(currentState, count);
                    
                    Cell nextCell = new Cell();
                    nextCell.X = i;
                    nextCell.Y = j;
                    nextCell.IsAlive = nextState;
                    nextGrid[i, j] = nextCell;
                }
            }
            // remplacer l'ancienne grille
            Grid = nextGrid;
        }

        private int CountNeighbors(int x, int y) {
            int count = 0;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (i == 0 && j == 0) continue;

                    int targetX = x + i;
                    int targetY = y + j;

                    // vérif bords de grille
                    if (targetX >= 0 && targetX < Width && targetY >= 0 && targetY < Height) {
                        if (Grid[targetX, targetY].IsAlive) {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}