using Microsoft.Xna.Framework.Graphics;
using MyFirstRogueLike.Screens;
using System;

namespace MyFirstRogueLike.Managers
{
    public class ScreenManager
    {

        private IScreen _activeScreen;
        private IScreen _nextScreen;

        public void SetScreen(IScreen screen)
        {
            _nextScreen = screen;
        }

        public void SwitchToNextScreen()
        {
            if(_nextScreen != null)
            {
                _activeScreen = _nextScreen;
            }

            _nextScreen = null;
        }

        public void Update(float delta)
        {
            _activeScreen?.Update(delta);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _activeScreen?.Draw(spriteBatch);
        }

    }

}
