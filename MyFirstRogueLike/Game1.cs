using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyFirstRogueLike.Screens;

namespace MyFirstRogueLike
{
    public class Game1 : Game
    {

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _splashImage;
        private SoundEffect _soundEffect;

        private IScreen _screen;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _splashImage = Content.Load<Texture2D>("splashImage");
            _soundEffect = Content.Load<SoundEffect>("splashSound");

            _soundEffect.Play();

            _screen = new SplashScreen(_splashImage);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var delta = (float) (gameTime.ElapsedGameTime.TotalMilliseconds / 1000f);
            _screen.Update(delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _screen.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
