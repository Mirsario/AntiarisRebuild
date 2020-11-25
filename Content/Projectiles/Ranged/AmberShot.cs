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
	public class AmberShot : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 42;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.DamageType = DamageClass.Ranged;
			projectile.penetrate = 1;
			projectile.timeLeft = 80;
			projectile.extraUpdates = 1;
			projectile.alpha = 255;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Buckshot");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "石质铅弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Каменная картечь");
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

		public override void AI()
		{
			for (int i = 0; i < 2; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * i;
				int dust = Dust.NewDust(new Vector2(x, y), 1, 1, 6, 0f, 0f, 0, default, 2f);
				Main.dust[dust].alpha = projectile.alpha;
				Main.dust[dust].position.X = x;
				Main.dust[dust].position.Y = y;
				//Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			float count = 25.0f;
			for (int k = 0; k < (double)count; k++)
			{
				Vector2 vector2 = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy(k * (6.22 / count), new Vector2()) * new Vector2(2.0f, 8.0f)).RotatedBy(projectile.velocity.ToRotation(), new Vector2());
				int dust = Dust.NewDust(projectile.Center - new Vector2(0.0f, 4.0f), 0, 0, 6, 0.0f, 0.0f, 0, new Color(), 1.0f);
				Main.dust[dust].scale = 1.25f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].position = projectile.Center + vector2;
				Main.dust[dust].velocity = projectile.velocity * 0.0f + vector2.SafeNormalize(Vector2.UnitY) * 1.0f;
			}
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180, false);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileUtils.DrawAfterImages(projectile, spriteBatch, lightColor);

			return true;
		}
	}
}
