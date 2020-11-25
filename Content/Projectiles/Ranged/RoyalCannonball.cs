using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Projectiles.Ranged
{
	public class RoyalCannonball : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(261);
			projectile.height = 18;
			projectile.width = 18;
			aiType = 261;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Cannonball");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "皇家加农炮");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Королевское ядро");
		}

		public override void Kill(int timeLeft)
		{
			//VANILLA CODE
			for (int k = 0; k < 20; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 2f);
				Main.dust[dust].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[dust].scale = 0.5f;
					Main.dust[dust].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
			for (int k = 0; k < 20; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 3f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 5f;
				dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 2f);
				Main.dust[dust].velocity *= 2f;
			}
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
			float Scale = 0.33f;
			int gore = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);
			Main.gore[gore].velocity *= Scale;
			Gore expr_13E6D_cp_0 = Main.gore[gore];
			expr_13E6D_cp_0.velocity.X = expr_13E6D_cp_0.velocity.X + 1f;
			Gore expr_13E8D_cp_0 = Main.gore[gore];
			expr_13E8D_cp_0.velocity.Y = expr_13E8D_cp_0.velocity.Y + 1f;
			gore = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);
			Main.gore[gore].velocity *= Scale;
			Gore expr_13F30_cp_0 = Main.gore[gore];
			expr_13F30_cp_0.velocity.X = expr_13F30_cp_0.velocity.X - 1f;
			Gore expr_13F50_cp_0 = Main.gore[gore];
			expr_13F50_cp_0.velocity.Y = expr_13F50_cp_0.velocity.Y + 1f;
			gore = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);
			Main.gore[gore].velocity *= Scale;
			Gore expr_13FF3_cp_0 = Main.gore[gore];
			expr_13FF3_cp_0.velocity.X = expr_13FF3_cp_0.velocity.X + 1f;
			Gore expr_14013_cp_0 = Main.gore[gore];
			expr_14013_cp_0.velocity.Y = expr_14013_cp_0.velocity.Y - 1f;
			gore = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);
			Main.gore[gore].velocity *= Scale;
			Gore expr_140B6_cp_0 = Main.gore[gore];
			expr_140B6_cp_0.velocity.X = expr_140B6_cp_0.velocity.X - 1f;
			Gore expr_140D6_cp_0 = Main.gore[gore];
			expr_140D6_cp_0.velocity.Y = expr_140D6_cp_0.velocity.Y - 1f;
		}
	}
}
