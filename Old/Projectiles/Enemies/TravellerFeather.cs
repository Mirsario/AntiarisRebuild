using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Projectiles.Enemies
{
	public class TravellerFeather : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.tileCollide = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Traveller Feather");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Перо путешестенника");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "漂泊之羽");
		}

		public override void Kill(int timeLeft)
		{
			if (Main.netMode != NetmodeID.Server)
			{
				Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
				SoundEngine.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
			}
		}
	}
}
