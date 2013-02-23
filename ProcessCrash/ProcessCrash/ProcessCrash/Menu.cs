    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ProcessCrash
{
    class Menu : Game1
    {
        KeyboardState oldState;
        KeyboardState newState;
        int compteur, difficulte;
        bool option, fullscreen, exit, en_jeu = false;
        public Menu()
        {
            
        }

        public bool GetOption()
        {
            return option;
        }

        public bool GetScreen()
        {
            return fullscreen;
        }

        public bool GetOut()
        {
            return exit;
        }

        public int GetDiff()
        {
            return difficulte;
        }

        public bool GetGame()
        {
            return en_jeu;
        }

        public int Men(int compte, bool opt, bool screen)
        {
            compteur = compte;
            fullscreen = screen;
            option = opt;
            newState = Keyboard.GetState();
            if (option)
            {
                OptionMenu();
            }
            else
            {
                MajorMenu();
            }
            oldState = newState;
            return compteur;
        }

        public void MajorMenu( )
        {
            Deplacement();
            if (compteur == 2 && newState.IsKeyDown(Keys.Enter))
            {
                if (!oldState.IsKeyDown(Keys.Enter))
                {
                    en_jeu = true;
                }
            }
            else if (compteur == 1 && newState.IsKeyDown(Keys.Enter))
            {
                if (!oldState.IsKeyDown(Keys.Enter))
                {
                    option = true;
                    compteur = 2;
                }
            }
            else if (compteur == 0 && newState.IsKeyDown(Keys.Enter))
            {
                if (!oldState.IsKeyDown(Keys.Enter))
                {
                    exit = true;
                }
            }
        }

        public void OptionMenu( )
        {
            Deplacement();
            if (compteur == 2 )
            {
                if (newState.IsKeyDown(Keys.Left) && difficulte >= 0)
                {
                    if (!oldState.IsKeyDown(Keys.Left))
                    {
                        difficulte--;
                    }
                }
                if (newState.IsKeyDown(Keys.Right) && difficulte < 2)
                {
                    if (!oldState.IsKeyDown(Keys.Right))
                    {
                        difficulte++;
                    }
                }
            }
            else if (compteur == 1 && newState.IsKeyDown(Keys.Enter))
            {
                if (!oldState.IsKeyDown(Keys.Enter))
                {
                    if (fullscreen)
                    {
                        
                        fullscreen = false;
                    }
                    if (!fullscreen)
                    {

                        fullscreen = true;
                    }
                }
                
            }
            else if (compteur == 0 && newState.IsKeyDown(Keys.Enter))
            {
                if (!fullscreen & !oldState.IsKeyDown(Keys.Enter))
                {
                    option = false;
                }
            }
        }

        private void Deplacement()
        {
            
            if (newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    compteur++;
                    compteur %= 3;
                }
            }
            if (newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    compteur--;
                    if (compteur < 0)
                    {
                        compteur = 2;
                    }
                }
            }
            
        }
    }
}
