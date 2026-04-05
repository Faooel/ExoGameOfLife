using System;
using System.Windows;
using GameOfLife.Views;
using GameOfLife.Controllers;
using GameOfLife.Logic;

namespace GameOfLife
{
    public class Program
    {
        [STAThread] // DOIT ÊTRE ICI
        public static void Main()
        {
            Application app = new Application();
            
            // Initialisation logique
            StandardRule rule = new StandardRule();
            GameEngine engine = new GameEngine(20, 20, rule);
            GameController controller = new GameController(engine);
            
            // Initialisation vue
            MainWindow window = new MainWindow(controller, engine);
            engine.Grid[5, 5].IsAlive = true;
            engine.Grid[5, 6].IsAlive = true;
            engine.Grid[5, 7].IsAlive = true;
            app.Run(window);
        }
    }
}