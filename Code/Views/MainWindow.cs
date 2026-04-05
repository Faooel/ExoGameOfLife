using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameOfLife.Controllers;

namespace GameOfLife.Views {
    public partial class MainWindow : Window {
        private GameController _control; // Nom plus court
        private GameOfLife.Logic.GameEngine _moteur; 
        private Canvas _zoneDessin = new Canvas();
        private int _tailleCarre = 15;

        public MainWindow(GameController controller, GameOfLife.Logic.GameEngine engine) {
            _control = controller;
            _moteur = engine;

            // param de la fenetre
            this.Title = "Projet Game of Life - Janvier 2026";
            this.Width = 520; 
            this.Height = 620;
            this.Background = Brushes.LightGray;

            StackPanel pileVerticale = new StackPanel();
            
            // boutons
            StackPanel boutons = new StackPanel { 
                Orientation = Orientation.Horizontal, 
                Margin = new Thickness(10, 5, 10, 5) 
            };

            // bouton pour avancer
            Button btnStep = new Button { 
                Content = "Tour Suivant", 
                Padding = new Thickness(10),
                Margin = new Thickness(5) 
            };
            btnStep.Click += (s, e) => {
                _control.Step();
                DessinerLaGrille();
            };

            // bouton sauvegarde
            Button btnSave = new Button { 
                Content = "Save (DB)", 
                Padding = new Thickness(10),
                Margin = new Thickness(5) 
            };
            btnSave.Click += (s, e) => {
                _control.Save();
                MessageBox.Show("C'est bon, l'etat est en base !");
            };

            boutons.Children.Add(btnStep);
            boutons.Children.Add(btnSave);
            pileVerticale.Children.Add(boutons);
            
            // config du Canvas
            _zoneDessin.Width = 480;
            _zoneDessin.Height = 480;
            _zoneDessin.Background = Brushes.White;
            _zoneDessin.Margin = new Thickness(10);
            
            pileVerticale.Children.Add(_zoneDessin);
            this.Content = pileVerticale;

            DessinerLaGrille();
        }

        public void DessinerLaGrille() {
            _zoneDessin.Children.Clear();

            for (int i = 0; i < _moteur.Width; i++) {
                for (int j = 0; j < _moteur.Height; j++) {
                    
                    Rectangle r = new Rectangle();
                    r.Width = _tailleCarre - 1;
                    r.Height = _tailleCarre - 1;
                    
                    if (_moteur.Grid[i, j].IsAlive == true) {
                        r.Fill = Brushes.Black;
                    } else {
                        r.Fill = Brushes.WhiteSmoke;
                    }

                    r.Stroke = Brushes.LightBlue;
                    r.StrokeThickness = 0.3;

                    Canvas.SetLeft(r, i * _tailleCarre);
                    Canvas.SetTop(r, j * _tailleCarre);
                    
                    _zoneDessin.Children.Add(r);
                }
            }
        }
    }
}