using Cocos2D;
using CocosDenshion;
using FlappyBirdTeam.GameObjects;
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
        private Texture2D _birdTextureDown;
        private Texture2D _birdTextureUp;
        
        //Temporary field
        private Bird bird = new Bird(200, 100, 100, 100);
        public FlappyBirdGame()
        {
            _graphics = new GraphicsDeviceManager(this) {IsFullScreen = false};
            Content.RootDirectory = "Content";
            _currentGameState = GameState.Game;
            CCApplication application = new AppDelegate(this, _graphics);
            Components.Add(application);
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
            _birdTextureDown = Content.Load<Texture2D>("bird_down");
            _birdTextureUp = Content.Load<Texture2D>("bird_up");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        private void ProcessBackClick()
        {
            if (CCDirector.SharedDirector.CanPopScene)
            {
                CCDirector.SharedDirector.PopScene();
            }
            else
            {
                Exit();
            }
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
               ProcessBackClick();
            // v_currentScreen.Update(gameTime);

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

            base.Draw(gameTime);
        }

        private void DrawGameScreen(GameTime gameTime)
        {
            Texture2D _currentBirdtexture = (bird.IsFlyingUp) ? _birdTextureDown : _birdTextureUp;
            _spriteBatch.Draw(_currentBirdtexture, new Rectangle((int)bird.Position.X, (int)bird.Position.Y, (int)bird.Size.X, (int)bird.Size.Y), null, Color.Beige, bird.Rotation, new Vector2(10, 10), SpriteEffects.None, 0);
            _spriteBatch.End();
        }
        private void UpdateGameScreen(GameTime gameTime)
        {
            //bool direction = bird.Update(gameTime);
            bird.Update(gameTime);
            if (bird.Position.Y > 800) ;
                //_currentGameState = GameState.End;
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
