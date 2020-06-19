using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GraDuchMonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D ghost;
        Vector2 spritePosition = Vector2.Zero;
        Rectangle rectange = new Rectangle(0, 0, 200, 200);
        Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);
        MouseState ms = Mouse.GetState();
        float time1 = 0.0f;
        //float time2 = 0.5f;
        int clickCountWhite = 0;
        int clickCountBlue = 0;
        int clickCountRed = 0;
        int color = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("street");
            ghost = Content.Load<Texture2D>("ghost");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
        /// 

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }

            time1 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //time1 = MathHelper.Max(0, (float)gameTime.ElapsedGameTime.TotalSeconds);
            Random rand = new Random();
            if (time1 > 0.7f)
            {
                spritePosition.X = rand.Next(0, 700);
                spritePosition.Y = rand.Next(0, 400);
                time1 = 0;
                color++;
                if (color == 3)
                {
                    color = 0;
                }
            }

            MouseState pms = ms;
            ms = Mouse.GetState();
            rectange = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, ghost.Width, ghost.Height);

            if (pms.LeftButton == ButtonState.Released && ms.LeftButton == ButtonState.Pressed && rectange.Contains(ms.X, ms.Y))
            {
                if (color == 0)
                {
                    clickCountWhite++;
                }
                else if (color == 1)
                {
                    clickCountBlue++;
                }
                else if (color == 2)
                {
                    clickCountRed++;
                }
                this.Window.Title = "W: " + clickCountWhite.ToString() + " B: " + clickCountBlue.ToString() + " R: " + clickCountRed.ToString();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.Viewport.Bounds, Color.White);
            if (color == 0)
            {
                spriteBatch.Draw(ghost, spritePosition, Color.White);
            }
            else if (color == 1)
            {
                spriteBatch.Draw(ghost, spritePosition, Color.Blue);
            }
            else if (color == 2)
            {
                spriteBatch.Draw(ghost, spritePosition, Color.Red);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}