using Antiaris.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Projectiles.Ranged
{
	public class ShroomiteNeedle : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.DamageType = DamageClass.Ranged;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.alpha = 100;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Needle");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "针刺真菌");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Грибнитовая игла");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileUtils.DrawAfterImages(projectile, spriteBatch, lightColor);

			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
		}
	}
}
