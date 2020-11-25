using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Miscellaneous
{
	public class CursedHand : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 62;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 113;
			projectile.timeLeft = 500;
			aiType = ProjectileID.BoneJavelin;
			projectile.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Hand");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "咒怨钢爪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Проклятая рука");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void AI()
		{
			if (projectile.timeLeft <= 475)
			{
				projectile.aiStyle = 0;
				if (projectile.timeLeft > 445)
				{
					projectile.velocity.X = 0f;
					projectile.velocity.Y = 0f;
				}
				projectile.rotation += 0.24f * projectile.direction;
				if (projectile.timeLeft <= 445)
				{
					Player owner = null;
					if (projectile.owner != -1)
					{
						owner = Main.player[projectile.owner];
					}
					else if (projectile.owner == 255)
					{
						owner = Main.LocalPlayer;
					}
					Player player = owner;
					Vector2 targetPos = player.Center;
					float speed = 13f;
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
				}
			}
		}
	}
}
