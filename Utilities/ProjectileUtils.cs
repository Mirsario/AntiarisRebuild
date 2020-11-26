using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace Antiaris.Utilities
{
	public static class ProjectileUtils
    {
        public static void DrawAfterImages(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[projectile.type].Value;
            var drawOrigin = new Vector2(texture.Width * 0.5f, projectile.height * 0.5f);

            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);

                spriteBatch.Draw(texture, drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
        }
    }
}
