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

        int compteur = 2;
        Vector2 haut, milieu, bas;

        public Menu()
        {
            
        }

        public void MajorMenu()
        {
            if (compteur == 2)
            {

            }
            else if (compteur == 1)
            {
                compteur = 2;
                OptionMenu();
            }
            else if (compteur == 0)
            {

            }
        }

        public void OptionMenu()
        {
            if (compteur == 2)
            {
                
            }
            else if(compteur == 1)
            {
                if (fullscreen & Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    fullscreen = false;
                }
                if (!fullscreen & Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    fullscreen = true;
                }
            }
            else if (compteur == 0)
            {
                
            }
        }

        private void Deplacement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                compteur--;
                if (compteur < 0)
                {
                    compteur = 2;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                compteur++;
                compteur %= 3;
            }          
        }
    }
}
