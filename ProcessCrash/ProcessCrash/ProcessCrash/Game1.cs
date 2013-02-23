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
         public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int[,] tab_in;
        public bool en_jeu, direc;
        bool option, fullscreen, isfull, sortie;
        StreamReader map;
        public Vector2 pos_LED, pos_size, pos_dif, hero;
        int compte, difficulte;
        Texture2D size, dif, options, menu, LED, Dim1, Dim2, Dif1, Dif2, Dif3, persoD, brasD, persoG, brasG;
        Menu lemenu;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            fullscreen = false;
            option = false;
            Personnage heros = new Personnage(8f, 2, hero);
            lemenu = new Menu();
            hero = heros.GetPos();
            compte = 2;
            isfull = true;

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
            
            if (!en_jeu)
            {
                if (fullscreen && isfull)
                {
                    isfull = false;
                    this.graphics.IsFullScreen = true;
                    graphics.ApplyChanges();
                }
                if (!fullscreen && !isfull)
                {
                    isfull = true;
                    this.graphics.PreferredBackBufferWidth = 800;
                    this.graphics.PreferredBackBufferHeight = 600;
                    graphics.ApplyChanges();
                }
                if (lemenu.GetOut())
                {
                    Exit();
                }
                difficulte = lemenu.GetDiff();
                compte = lemenu.Men(compte, option, fullscreen);
                option = lemenu.GetOption();
                fullscreen = lemenu.GetScreen();
                DrawLED();
                DrawDiff();
            }
            // TODO: Add your update logic here
            Draw(gameTime);
            base.Update(gameTime);
        }

        private void DrawLED()
        {
            pos_size.X = 240;
            pos_size.Y = 285;
            if (compte == 0)
            {
                pos_LED.X = 594;
                pos_LED.Y = 411;
            }
            else if (compte == 1)
            {
                pos_LED.X = 594;
                pos_LED.Y = 306;
            }
            else
            {
                pos_LED.X = 595;
                pos_LED.Y = 200;
            }
        }

        private void DrawDiff()
        {
            pos_dif.X = 460;
            pos_dif.Y = 180;
            if (difficulte == 0)
            {
                dif = Dif1;
            }
            if (difficulte == 1)
            {
                dif = Dif2;
            }
            if (difficulte == 2)
            {
                dif = Dif3;
            } 
        }
        protected override void Draw(GameTime gameTime)
        {
            // Affiche les spritesq

            base.Draw(gameTime);
            spriteBatch.Begin();
            if (en_jeu)
            {
                // Affiche les sprites
                //Jeu
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
            }
                //Menu
            else
            {
                if (option)
                {
                    spriteBatch.Draw(options, Vector2.Zero, Color.White);
                    if (fullscreen)
                    {
                        spriteBatch.Draw(Dim2, pos_size, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(Dim1, pos_size, Color.White);
                    }
                    spriteBatch.Draw(dif, pos_dif, Color.White);
                }
                else
                {
                    spriteBatch.Draw(menu, Vector2.Zero, Color.White);
                }
                spriteBatch.Draw(LED, pos_LED, Color.White);
            }
                spriteBatch.End();

                base.Draw(gameTime);
            
        }
    }
}