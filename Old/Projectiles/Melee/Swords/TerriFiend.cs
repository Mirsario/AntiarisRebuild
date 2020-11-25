using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
	public class TerriFiend : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 52;
			projectile.aiStyle = 0;
			aiType = 14;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			Main.projFrames[projectile.type] = 10;
			projectile.penetrate = 5;
			projectile.timeLeft = 64;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terri Fiend");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "狂界恶魔");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Тэрри-черт");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (Main.myPlayer != projectile.owner)
				return;
			projectile.frameCounter++;
			if (projectile.frameCounter > 6)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame > 9)
			{
				projectile.frame = 0;
			}
			projectile.rotation = 0f;
			projectile.velocity.Y += projectile.ai[0];
			Vector2 vector = projectile.velocity * 1.08f;
			projectile.velocity = vector;
		}

		public override void Kill(int timeLeft)
		{
			Vector2 velocity = AntiarisHelper.VelocityToPoint(projectile.Center, Main.MouseWorld, 8);
			SoundEngine.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Projectiles/Explosion"), projectile.position);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<TerriBlade>(), projectile.damage, projectile.knockBack * 0.5f, projectile.owner, 0.0f, 0.0f);
			for (int i = 0; i < 6; ++i)
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 59, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 59, new Color(), 1.4f);
			for (int i = 0; i < 6; ++i)
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 62, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 62, new Color(), 1.4f);
			for (int i = 0; i < 6; ++i)
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 65, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 65, new Color(), 1.4f);
		}
	}
}
