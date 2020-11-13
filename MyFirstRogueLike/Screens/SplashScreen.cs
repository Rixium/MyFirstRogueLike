using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MyFirstRogueLike.Screens
{
    class SplashScreen : IScreen
    {

        private readonly Texture2D _splashImage;

        public SplashScreen(Texture2D splashImage)
        {
            _splashImage = splashImage;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            var origin = new Vector2(_splashImage.Width / 2f, _splashImage.Height / 2f);

            spriteBatch.Draw(
                _splashImage,
                new Vector2(Game1.ScreenWidth / 2f, Game1.ScreenHeight / 2f),
                null,
                Color.White,
                0f,
                origin,
                1f,
                SpriteEffects.None,
                0f
            );

            spriteBatch.End();
        }

        public void Update(float delta)
        {

        }
    }
}
