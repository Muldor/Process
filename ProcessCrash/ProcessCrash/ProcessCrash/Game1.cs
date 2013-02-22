using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace ProcessCrash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int[] tab_in;
        public bool en_jeu, direc, fullscreen, option;
        StreamReader map;
        public Vector2 pos_LED, pos_size, pos_dif, hero;
        Texture2D fond, size, Dif, options, menu, LED, Dim1, Dim2, Dif1, Dif2, Dif3, persoD, brasD, persoG, brasG;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            fullscreen = false;
            Personnage heros = new Personnage(8f, 2, hero);
            hero = heros.GetPos();
         
            base.Initialize();

        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (!en_jeu)
            {
                menu = Content.Load<Texture2D>("Menu\\Menu");
                options = Content.Load<Texture2D>("Menu\\Options Optimal");
                LED = Content.Load<Texture2D>("Menu\\LED");
                Dim1 = Content.Load<Texture2D>("Menu\\Menu - Option - dim1");
                Dim2 = Content.Load<Texture2D>("Menu\\Menu - Option - dim2");
                Dif1 = Content.Load<Texture2D>("Menu\\Menu - Dif1");
                Dif2 = Content.Load<Texture2D>("Menu\\Menu - DIf2");
                Dif3 = Content.Load<Texture2D>("Menu\\Menu - DIf3");
            }
            else
            {

                persoD = Content.Load<Texture2D>("Perso\\Heros_D");
                brasD = Content.Load<Texture2D>("Perso\\Bras droit");
                persoG = Content.Load<Texture2D>("Perso\\Heros_G");
                brasG = Content.Load<Texture2D>("Perso\\Bras gauche");
            }

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {

            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Affiche les spritesq

            base.Draw(gameTime);
            spriteBatch.Begin();
            if (en_jeu)
            {
                // Affiche les sprites

                if (Keyboard.GetState().IsKeyDown(Keys.Right) || !direc)
                {
                    spriteBatch.Draw(persoD, hero, Color.White);
                    spriteBatch.Draw(brasD, hero, Color.White);
                    direc = false;
                }
                if ((Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Right)) || direc)
                {
                    spriteBatch.Draw(persoG, hero, Color.White);
                    spriteBatch.Draw(brasG, hero, Color.White);
                    direc = true;
                }
                spriteBatch.End();

                base.Draw(gameTime);
            }
        }
    }
}