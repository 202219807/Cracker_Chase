using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Mover cheese;
        Target cracker;
        Sprite background;
        SoundEffect BurpSound;

        int screenWidth;
        int screenHeight;

        List<Sprite> gameSprites = new List<Sprite>();
        List<Target> crackers = new List<Target>();

        SpriteFont messageFont;

        string messageString = "Hello world";
        int score;
        int timer;
        bool playing;

        /// <summary> 
        /// <c>startPlayingGame</c> resets various elements and sets up the game for play, 
        /// including displaying a message and setting flags for playing and timer duration. 
        /// </summary> 
        void startPlayingGame()
        {
            foreach (Sprite s in gameSprites)
            {
                s.Reset();
            }
            foreach (Target t in crackers)
            {
                t.Reset();
            }
            messageString = "Cracker Chase";

            playing = true;
            timer = 600;
            score = 0;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary> 
        /// <c>Initialize</c> initializes the component by calling the inherited `Initialize` 
        /// method and performing any additional initialization required for the specific implementation. 
        /// </summary> 
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary> 
        /// <c>LoadContent</c> loads textures, fonts, and a sound effect into memory for use 
        /// in the game. It creates a SpriteBatch, a Texture2D for each loaded texture, and 
        /// adds them to a list of game sprites and another list for later use. 
        /// </summary> 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            messageFont = Content.Load<SpriteFont>("MessageFont");

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            Texture2D cheeseTexture = Content.Load<Texture2D>("cheese");
            Texture2D cloth = Content.Load<Texture2D>("Tablecloth");
            Texture2D crackerTexture = Content.Load<Texture2D>("cracker");

            BurpSound = Content.Load<SoundEffect>("Burp");

            background = new Sprite(screenWidth, screenHeight, cloth, screenWidth, 0, 0);
            gameSprites.Add(background);

            int crackerWidth = screenWidth / 20;

            for (int i = 0; i < 100; i++)
            {
                cracker = new Target(screenWidth, screenHeight, crackerTexture, crackerWidth, 0, 0);
                gameSprites.Add(cracker);
                crackers.Add(cracker);
            }

            int cheeseWidth = screenWidth / 15;
            cheese = new Mover(screenWidth, screenHeight, cheeseTexture, cheeseWidth, screenWidth / 2, screenHeight / 2, 500, 500);
            gameSprites.Add(cheese);

            // go to the start screen state
            startPlayingGame();
        }

        /// <summary> 
        /// <c>UnloadContent</c> is responsible for unloading any non-ContentManager content. 
        /// </summary> 
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


     

        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();

            if (playing)
            {


                if (keys.IsKeyDown(Keys.Up))
                {
                    cheese.StartMovingUp();
                }
                else
                {
                    cheese.StopMovingUp();
                }

                if (keys.IsKeyDown(Keys.Down))
                {
                    cheese.StartMovingDown();
                }
                else
                {
                    cheese.StopMovingDown();
                }

                if (keys.IsKeyDown(Keys.Left))
                {
                    cheese.StartMovingLeft();
                }
                else
                {
                    cheese.StopMovingLeft();
                }

                if (keys.IsKeyDown(Keys.Right))
                {
                    cheese.StartMovingRight();
                }
                else
                {
                    cheese.StopMovingRight();
                }

                foreach (Sprite s in gameSprites)
                {
                    s.Update(1.0f / 60.0f);
                }
                foreach (Target t in crackers)
                {
                    if (cheese.IntersectsWith(t))
                    {
                        BurpSound.Play();
                        t.Reset();
                        score = score + 10;
                    }
                }

                timer = timer - 1;

                int secsLeft = timer / 60;
                messageString = "Time: " + secsLeft.ToString() + " Score: " + score;

                if (timer == 0)
                {
                    messageString = " Game Over : Press Space to exit   Score: " + score.ToString();
                    playing = false;
                }
            }
            else
            {
                if (keys.IsKeyDown(Keys.Space))
                {
                    Exit();
                }
            }

            base.Update(gameTime);
        }

        
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            foreach (Sprite s in gameSprites)
            {
                s.Draw(spriteBatch);
            }
            float xPos = (screenWidth - messageFont.MeasureString(messageString).X) / 2;

            Vector2 statusPos = new Vector2(xPos, 10);

            spriteBatch.DrawString(messageFont, messageString, statusPos, Color.Red);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
