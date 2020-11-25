using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Projectiles.Ranged
{
	public class SplitBullet : ModProjectile
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
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Split Bullet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "子母弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Разрывная пуля");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ProjectileTags.Bullet);
			this.SetTag(ProjectileTags.Explosive);
		}*/

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SVDMG>(), projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);

			if (projectile.owner == Main.myPlayer)
			{
				const int NumSplits = 3;

				for (int i = 0; i < NumSplits; i++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(200, 500) * 0.01f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<VortexExplosion>(), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}

				for (int i = 0; i < NumSplits; i++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= 100 * 0.1f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<SplitBullet2>(), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}
		}
	}
}