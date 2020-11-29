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
	public class BloodyBullet : ModProjectile
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.DamageType = DamageClass.Ranged;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Bullet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "血之弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кровавая пуля");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ProjectileTags.Bullet);
		}*/

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.damage += 4;
		}

		public override void AI()
		{
			for (int i = 0; i < 5; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * i;

				var dust = Dust.NewDustDirect(new Vector2(x, y), 1, 1, 60, 0f, 0f, 0, default, 2f);

				dust.alpha = projectile.alpha;
				dust.position.X = x;
				dust.position.Y = y;
				dust.velocity *= 0f;
				dust.noGravity = true;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileUtils.DrawAfterImages(projectile, spriteBatch, lightColor);

			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}
	}
}