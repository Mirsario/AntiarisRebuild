using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace Antiaris.Projectiles.Thrown
{
	public class OceanRider : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.DamageType = DamageClass.Ranged;
			projectile.penetrate = 1;
			projectile.timeLeft = 240;
			projectile.extraUpdates = 1;
			aiType = 14;
			projectile.alpha = 100;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Rider");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Океанский ездок");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			++projectile.ai[1];
			if (projectile.ai[1] % 25.0 == 0.0)
			{
				Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<Bubble>(), projectile.damage, (int)(projectile.knockBack * 0.7f), player.whoAmI, 0f);
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

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 19, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
		}
	}
}
