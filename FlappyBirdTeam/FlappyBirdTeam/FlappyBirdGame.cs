﻿using FlappyBirdTeam.GameObjects;
using FlappyBirdTeam.Tools;
using FlappyBirdTeam.View;
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
        private Texture2D _birdTexture;
        private GameState _currentGameState;
        private float _birdRotation;
        
        //Temporary field
        private Bird bird = new Bird(200, 100, 190, 190);
        public FlappyBirdGame()
        {
            _graphics = new GraphicsDeviceManager(this) {IsFullScreen = false};
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.PreferredBackBufferWidth = 480;
            Components.Add(new ScreenManager(this));
            Content.RootDirectory = "Content";
            _currentGameState = GameState.Game;
            _birdRotation = 0.1f;
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
            _birdTexture = Content.Load<Texture2D>("bird_fall_down_small");

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
            // v_currentScreen.Update(gameTime);

            switch(_currentGameState)
            {
                case GameState.End: UpdateEndScreen(gameTime);
                    break;
                case GameState.Hello: UpdateHelloScreen(gameTime);
                    break;
                case GameState.Game: UpdateGameScreen(gameTime);
                    break;
            }

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

            switch (_currentGameState)
            {
                case GameState.End: DrawEndScreen(gameTime);
                    break;
                case GameState.Hello: DrawHelloScreen(gameTime);
                    break;
                case GameState.Game: DrawGameScreen(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }

        private void DrawGameScreen(GameTime gameTime)
        {
            _spriteBatch.Draw(_birdTexture, new Rectangle((int)bird.Position.X, (int)bird.Position.Y, (int)bird.Size.X, (int)bird.Size.Y), null,  Color.Beige, _birdRotation, new Vector2(10,10),SpriteEffects.None, 0);
            _spriteBatch.End();
        }
        private void UpdateGameScreen(GameTime gameTime)
        {
            _birdRotation += 0.1f;
            //bool direction = bird.Update(gameTime);
            bird.Update(gameTime);
            if (bird.Position.Y > 800)
                _currentGameState = GameState.End;
        }
        private void DrawEndScreen(GameTime gameTime)
        {
            Texture2D _gameOverTexture = Content.Load<Texture2D>("game_over");
            _spriteBatch.Draw(_gameOverTexture, new Rectangle(150, 300, 200, 200), Color.White);
            _spriteBatch.End();
        }
        private void UpdateEndScreen(GameTime gameTime)
        {

        }
        private void DrawHelloScreen(GameTime gameTime)
        {

        }
        private void UpdateHelloScreen(GameTime gameTime)
        {

        }
    }
}
