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
        int[,] tab_bin = new int[100, 100];
        
        public bool en_jeu, direc;
        bool option, fullscreen, isfull, mapload;
        StreamReader map;
        string line;
        public Vector2 pos_LED, pos_size, pos_dif, hero, pos_carre = Vector2.Zero;
        int compte, difficulte, ord = (-1), abs = 0, tailtile = 64;
        Texture2D dif, options, menu, LED, Dim1, Dim2, Dif1, Dif2, Dif3, persoD, brasD, persoG, brasG;
        Texture2D b, c, d, h, k, l, m, n, o, p, q, s, u, v, x, y, z, carre;
        Texture2D[,] tab_map = new Texture2D[9, 45] ;
        Menu lemenu;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }
        protected override void Initialize()
        {
            // TODO) Add your initialization logic here
            fullscreen = false;
            option = false;
            en_jeu = true;
            Personnage heros = new Personnage(8f, 2, hero);
            lemenu = new Menu();
            hero = heros.GetPos();
            compte = 2;
            isfull = true;
            map = new StreamReader("map_in.txt");
            line = "";
            
            base.Initialize();

        }


        public void Texture()
        {
            b = Content.Load<Texture2D>("Map\\Tiles\\b");
            c = Content.Load<Texture2D>("Map\\Tiles\\c");
            d = Content.Load<Texture2D>("Map\\Tiles\\d");
            h = Content.Load<Texture2D>("Map\\Tiles\\d");
            l = Content.Load<Texture2D>("Map\\Tiles\\l");
            k = Content.Load<Texture2D>("Map\\Tiles\\k");
            m = Content.Load<Texture2D>("Map\\Tiles\\m");
            n = Content.Load<Texture2D>("Map\\Tiles\\k");
            o = Content.Load<Texture2D>("Map\\Tiles\\o");
            p = Content.Load<Texture2D>("Map\\Tiles\\p");
            q = Content.Load<Texture2D>("Map\\Tiles\\q");
            s = Content.Load<Texture2D>("Map\\Tiles\\s");
            u = Content.Load<Texture2D>("Map\\Tiles\\u");
            v = Content.Load<Texture2D>("Map\\Tiles\\v");
            x = Content.Load<Texture2D>("Map\\Tiles\\x");
            y = Content.Load<Texture2D>("Map\\Tiles\\y");
            z = Content.Load<Texture2D>("Map\\Tiles\\z");
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

                menu = Content.Load<Texture2D>("Menu\\Menu");
                options = Content.Load<Texture2D>("Menu\\Options Optimal");
                LED = Content.Load<Texture2D>("Menu\\LED");
                Dim1 = Content.Load<Texture2D>("Menu\\Menu - Option - dim1");
                Dim2 = Content.Load<Texture2D>("Menu\\Menu - Option - dim2");
                Dif1 = Content.Load<Texture2D>("Menu\\Menu - Dif1");
                Dif2 = Content.Load<Texture2D>("Menu\\Menu - DIf2");
                Dif3 = Content.Load<Texture2D>("Menu\\Menu - DIf3");
            
                Texture();
                persoD = Content.Load<Texture2D>("Perso\\Heros_D");
                brasD = Content.Load<Texture2D>("Perso\\Bras droit");
                persoG = Content.Load<Texture2D>("Perso\\Heros_G");
                brasG = Content.Load<Texture2D>("Perso\\Bras gauche");


            // TODO) use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {

            // TODO) Unload any non ContentManager content here
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
                en_jeu = lemenu.GetGame();
                difficulte = lemenu.GetDiff();
                compte = lemenu.Men(compte, option, fullscreen);
                option = lemenu.GetOption();
                fullscreen = lemenu.GetScreen();
                DrawLED();
                DrawDiff();
            }
            else
            {
                if (!mapload)
                {
                    do
                    {
                        mapload = Read_Draw();
                    } while (!mapload);
                    map.Close();
                }
            }
            // TODO) Add your update logic here
            Draw(gameTime);
            base.Update(gameTime);
        }


        //affichage
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

                if (en_jeu)
                {
                    // Affiche les sprites
                    DrawMap();
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

        private void DrawMap()
        {
            for (int y = 0; y < tab_map.LongLength -1; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    pos_carre.X = x * tailtile;
                    pos_carre.Y = y * tailtile;
                    carre = tab_map[y, x];
                    spriteBatch.Draw(carre,
                        pos_carre,
                        Color.White);
                }
            }

            
        }

        
        public bool Read_Draw()
        {
            if (abs == line.Length && !map.EndOfStream)
            {
                line = map.ReadLine();
                abs = 0;
                ord++;
            }
            if (map.EndOfStream)
            {
                return true;
            }
            if (line[abs] == 'z')
            {
                
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = z; 
            }

            else if (line[abs] == 'x')
            {
                carre = x;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = x;
            }
            else if (line[abs] == 'c')
            {
                carre = c;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = c;
            }
            else if (line[abs] == 'v')
            {
                carre = v;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = v;
            }
            else if (line[abs] == 'd')
            {
                carre = d;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = d;
            }
            else if (line[abs] == 'b')
            {
                carre = b;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = b;
            }
            else if (line[abs] == 'q')
            {
                carre = q;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = q;
            }
            else if (line[abs] == 'p')
            {
                carre = p;
                tab_bin[ord, abs] = 1;
                tab_map[ord, abs] = p;
            }
            else if (line[abs] == 'k')
            {
                carre = k;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = k;
            }
            else if (line[abs] == 'm')
            {
                carre = m;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = m;
            }
            else if (line[abs] == 'n')
            {
                carre = n;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = n;
            }
            else if (line[abs] == 'y')
            {
                carre = y;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = y;
            }
            else if (line[abs] == 'h')
            {
                carre = h;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = h;
            }
            else if (line[abs] == 'l')
            {
                carre = l;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = l;
            }
            else
            {
                carre = s;
                tab_bin[ord, abs] = 0;
                tab_map[ord, abs] = s;
            }
            abs++;
            return false;
            
        }
    }
}

