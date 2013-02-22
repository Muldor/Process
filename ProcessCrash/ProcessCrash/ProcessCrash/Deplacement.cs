using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProcessCrash
{
    public class Deplacement : Personnage
    {
        KeyboardState etatclavier;
        private float gravite;
        float vit;
        bool saut;
        Vector2 position;
        int[,] tab_in;


        public Deplacement()
        {
            tab_in = Getcol();
            vit = this.GetVit();
            position = this.GetPos();
            etatclavier = Keyboard.GetState();
            if (etatclavier.IsKeyDown(Keys.Up))
            { Up(position, this); }
            else if (etatclavier.IsKeyDown(Keys.Down))
            { Down(position, this); }
            if (etatclavier.IsKeyDown(Keys.Left))
            { Left(position, this); }
            else if (etatclavier.IsKeyDown(Keys.Right))
            { Right(position, this); }
        }

            
        private void Up(Vector2 position, Personnage perso)
        {
            if (perso.GetSaut())
            {
                perso.GotSaut(false);
                perso.GotPos(position);
            }
            
        }

        private void Down(Vector2 position, Personnage perso)
        {
            position.Y -= vit;
            if (Collision(position, false))
            {
                position.Y += vit;
                perso.GotPos(position);
            }
        }

        private void Left(Vector2 position, Personnage perso)
        {
            position.X -= vit;
            if (Collision(position, true))
            {                position.X += vit;
                perso.GotPos(position);
            }
        }

        private void Right(Vector2 position, Personnage perso)
        {
            position.X += vit;
            if (Collision(position, true))
            {
                position.X -= vit;
                perso.GotPos(position);
            }
        }

        private bool Collision(Vector2 position, bool surX)
        {
            int tix = (int)(position.X / 64);
            int tiy = (int)(position.Y / 64);
            if (tab_bin[tix,tiy] == 1)
            {
                return false;
            }
            return true;
        }

    }
}
