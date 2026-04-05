using GameOfLife.Logic;
using GameOfLife.Data;

namespace GameOfLife.Controllers {
    public class GameController {
        private GameEngine _engine;
        private GameRepository _repo = GameRepository.Instance;
        public GameController(GameEngine engine) {
            _engine = engine; 
        }

        public void Step() {
            _engine.NextGeneration();
        }

        public void Save() {
            // Simulation transformation de la grille
            string data = "";
            for (int x = 0; x < _engine.Width; x++) {
                for (int y = 0; y < _engine.Height; y++) {
                    // 1 pour vivant, 0 pour mort
                    data += _engine.Grid[x, y].IsAlive ? "1" : "0";
                }
                data += "|"; 
            }
            
            _repo.SaveState(data); 
        }
    }
}