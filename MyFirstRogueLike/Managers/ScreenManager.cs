using Microsoft.Xna.Framework.Graphics;
using MyFirstRogueLike.Screens;
using System.Collections.Generic;

namespace MyFirstRogueLike.Managers
{
    public class ScreenManager
    {
        private IReadOnlyCollection<IScreen> _screens;

        private IScreen _activeScreen;
        private IScreen _nextScreen;

        public ScreenManager(IReadOnlyCollection<IScreen> screens)
        {
            _screens = screens;
        }

        public void SetScreen(ScreenType screenType)
        {
            foreach (var screen in _screens)
            {
                if (screen.ScreenType == screenType)
                {
                    _nextScreen = screen;
                    return;
                }
            }
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
