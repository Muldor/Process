using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace ProcessCrash
{
    public class Personnage
    {

        private Vector2 position;
        private float vitesse;
        private int vie;
        private bool saut;

        public Personnage() { }
        //Classe personnage lors de sa creation prend sa vitesse, sa position, et sa vie
        public Personnage(float vitesse, int life, Vector2 position)
        {
            this.vitesse = vitesse;
            this.position = position;
            this.vie = life;
            this.saut = false;
        }

        

        //Change la position du personnage
        public void GotPos(Vector2 pos)
        {
            this.position = pos;
        }
        //Envoie la position actuel du personnage
        public Vector2 GetPos()
        {
            return this.position;
        }

        //Envoie si le personnge a sautw
        public bool GetSaut()
        {
            return saut;
        }
        //Change le booleen saut
        public void GotSaut(bool sot)
        {
            this.saut = sot;
        }

        //Envoie la vitesse actuel du personnage
        public float GetVit()
        {
            return this.vitesse;
        }
        //Change la vitesse du personnage
        public void GotVit(float bonus)
        {
            this.vitesse += bonus;
        }

        //Compteur de point de vie du personnage
        public void Life(bool effect)
        {
            if (effect)
                this.vie++;
            else
                this.vie--;
        }


    }
}
