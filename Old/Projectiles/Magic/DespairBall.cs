using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class DespairBall : ModProjectile
	{
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			AntiarisUtils.DrawProjectileGlowMaskWorld(spriteBatch, projectile, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), projectile.rotation, projectile.scale);
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.tileCollide = false;
			projectile.scale = 1.2f;
			projectile.magic = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Despair Ball");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "绝望光球");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шар отчаяния");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			Vector2 targetPos = player.Center;
			float speed = 10f;
			float speedFactor = 0.7f;
			var projCenter = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
			float posX = targetPos.X - projCenter.X;
			float posY = targetPos.Y - projCenter.Y;
			float distance = (float)Math.Sqrt(posX * posX + posY * posY);
			if (distance > 3000f)
			{
				projectile.Kill();
			}
			distance = speed / distance;
			posX *= distance;
			posY *= distance;
			if (projectile.velocity.X < posX)
			{
				projectile.velocity.X = projectile.velocity.X + speedFactor;
				if (projectile.velocity.X < 0f && posX > 0f)
				{
					projectile.velocity.X = projectile.velocity.X + speedFactor;
				}
			}
			else if (projectile.velocity.X > posX)
			{
				projectile.velocity.X = projectile.velocity.X - speedFactor;
				if (projectile.velocity.X > 0f && posX < 0f)
				{
					projectile.velocity.X = projectile.velocity.X - speedFactor;
				}
			}
			if (projectile.velocity.Y < posY)
			{
				projectile.velocity.Y = projectile.velocity.Y + speedFactor;
				if (projectile.velocity.Y < 0f && posY > 0f)
				{
					projectile.velocity.Y = projectile.velocity.Y + speedFactor;
				}
			}
			else if (projectile.velocity.Y > posY)
			{
				projectile.velocity.Y = projectile.velocity.Y - speedFactor;
				if (projectile.velocity.Y > 0f && posY < 0f)
				{
					projectile.velocity.Y = projectile.velocity.Y - speedFactor;
				}
			}
			if (player.Hitbox.Intersects(projectile.Hitbox))
			{
				projectile.Kill();
			}
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X, projectile.velocity.Y);
			}
			projectile.rotation += 0.3f * projectile.direction;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X, projectile.velocity.Y);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			var drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}
