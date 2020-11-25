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
	public class BulletShroom : ModProjectile
	{
		const int ShootDirection = 7;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bullet Shroom");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蘑菇弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Грибная пуля");
		}

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
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ProjectileTags.Bullet);
		}*/

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);

			int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -ShootDirection, 0, ProjectileID.TruffleSpore, 5, 1f, Main.myPlayer, 0f, 0f);
			int b = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, ShootDirection, 0, ProjectileID.TruffleSpore, 5, 1f, Main.myPlayer, 0f, 0f);
			int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, ShootDirection, ProjectileID.TruffleSpore, 5, 1f, Main.myPlayer, 0f, 0f);
			int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -ShootDirection, ProjectileID.TruffleSpore, 5, 1f, Main.myPlayer, 0f, 0f);

			Main.projectile[a].friendly = true;
			Main.projectile[b].friendly = true;
			Main.projectile[c].friendly = true;
			Main.projectile[d].friendly = true;

			Main.projectile[a].tileCollide = false;
			Main.projectile[b].tileCollide = false;
			Main.projectile[c].tileCollide = false;
			Main.projectile[d].tileCollide = false;

			Main.projectile[a].timeLeft = 60;
			Main.projectile[b].timeLeft = 60;
			Main.projectile[c].timeLeft = 60;
			Main.projectile[d].timeLeft = 60;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileUtils.DrawAfterImages(projectile, spriteBatch, lightColor);

			return true;
		}
	}
}
