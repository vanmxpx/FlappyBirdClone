﻿using FlappyBirdTeam.GameObjects;
﻿using FlappyBirdTeam.Tools;
using FlappyBirdTeam.View.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBirdTeam
{
    public class FlappyBirdGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Screen _currentScreen;
        private InputHandler _input = new InputHandler();
        private Bird bird = new Bird();
        public FlappyBirdGame()
        {
            _graphics = new GraphicsDeviceManager(this) {IsFullScreen = false};
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.PreferredBackBufferWidth = 480;
            Components.Add(new ScreenManager(this));
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                bird.OnTouch();
            _currentScreen.Update(gameTime);

            bird.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //fill the background
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            // TODO: Add your drawing code here
            var rect = new Texture2D(GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.Beige });
            _spriteBatch.Draw(rect, new Rectangle((int)bird.Position.X, (int)bird.Position.Y, (int)bird.Size.X, (int)bird.Size.Y), Color.Beige);
            _spriteBatch.End();
            _currentScreen.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
