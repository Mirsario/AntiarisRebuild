using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Enemies
{
	public class PetitePixie : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.alpha = byte.MaxValue; //or 255
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.penetrate = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petite Pixie");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "迷你精灵");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маленькая пикси");
		}

		public override void AI()
		{
			int type = -1;
			if (projectile.ai[1] == 0.0)
				type = 60; //red
			else if (projectile.ai[1] == 1.0)
				type = 61; //green
			else if (projectile.ai[1] == 2.0)
				type = 59; //blue
			else if (projectile.ai[1] == 3.0)
				type = 173; //purple
			for (int k = 0; k < 5; k++)
			{
				Dust dust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, type, projectile.velocity.X, projectile.velocity.Y, 100, new Color(), 1.0f)];
				dust.velocity = Vector2.Zero;
				dust.position -= projectile.velocity / 5.0f * k;
				dust.noGravity = true;
				dust.scale = 0.8f;
				dust.noLight = true;
			}
		}
	}
}
