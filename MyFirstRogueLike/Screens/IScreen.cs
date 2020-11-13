using Microsoft.Xna.Framework.Graphics;

namespace MyFirstRogueLike.Screens
{
    public interface IScreen
    {
        void Update(float delta);
        void Draw(SpriteBatch spriteBatch);
    }

}
