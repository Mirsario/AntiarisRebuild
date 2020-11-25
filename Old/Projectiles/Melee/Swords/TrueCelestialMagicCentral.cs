using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
	public class TrueCelestialMagicCentral : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 60;
			projectile.height = 60;
			projectile.aiStyle = 0;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			aiType = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Flame");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "神圣火焰");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Небесное пламя");
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (Main.myPlayer != projectile.owner)
				return;
			Vector2 vector;
			vector.X = Main.MouseWorld.X - 30f;
			vector.Y = Main.MouseWorld.Y - 30f;
			projectile.netUpdate = true;
			projectile.position = vector;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 65f, 0.0f, 0.2f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X - 65f, projectile.Center.Y, 0.2f, 0.0f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 65f, 0.0f, -0.2f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X + 65f, projectile.Center.Y, -0.2f, 0.0f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X - 40f, projectile.Center.Y - 40f, 0.2f, 0.2f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X + 40f, projectile.Center.Y + 40f, -0.2f, -0.2f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X - 40f, projectile.Center.Y + 40f, 0.2f, -0.2f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X + 40f, projectile.Center.Y - 40f, -0.2f, 0.2f, ModContent.ProjectileType<CelestialMagic>(), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
		}
	}
}
