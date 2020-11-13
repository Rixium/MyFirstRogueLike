using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyFirstRogueLike.Managers;
using MyFirstRogueLike.Screens;
using System;

namespace MyFirstRogueLike
{
    public class Game1 : Game
    {

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            _screenManager = new ScreenManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var splashImage = Content.Load<Texture2D>("splashImage");
            var soundEffect = Content.Load<SoundEffect>("splashSound");

            soundEffect.Play();

            _screenManager.SetScreen(new SplashScreen(splashImage));
            _screenManager.SwitchToNextScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var delta = (float) (gameTime.ElapsedGameTime.TotalMilliseconds / 1000f);
            _screenManager.Update(delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _screenManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
