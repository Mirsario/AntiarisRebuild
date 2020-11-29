using Antiaris.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Projectiles.Ranged
{
	public class LightEnergy : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 28;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.DamageType = DamageClass.Ranged;
			projectile.penetrate = 4;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			projectile.alpha = 255;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Light Energy");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "光凝聚体");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Энергия света");
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
					projectile.scale += 0.2f;
					projectile.damage += 5;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
					projectile.scale += 0.2f;
					projectile.damage += 5;
				}
				SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
			}
			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileUtils.DrawAfterImages(projectile, spriteBatch, lightColor);

			return true;
		}
	}
}
