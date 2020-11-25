using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class RoyalCrystal : ModProjectile
	{
		private bool pos = true;

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 36;
			projectile.height = 60;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Crystal");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "皇家水晶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Королевский кристал");
			Main.projPet[projectile.type] = true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (Main.myPlayer != projectile.owner)
				return;
			projectile.scale = projectile.Opacity;
			if (player.inventory[player.selectedItem].type == ModContent.ItemType<RoyalStave>() && !pos)
			{
				if (!(player.itemAnimation < player.inventory[player.selectedItem].useAnimation - 1))
				{
					Vector2 velocity = AntiarisHelper.VelocityToPoint(projectile.Center, Main.MouseWorld, 6);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<RoyalCrystalSpike>(), projectile.damage, projectile.knockBack * 0.5f, projectile.owner);
				}
			}
			if (pos)
			{
				pos = false;
				Vector2 vector;
				vector.X = Main.MouseWorld.X - 30f;
				vector.Y = Main.MouseWorld.Y - 30f;
				projectile.netUpdate = true;
				projectile.position = vector;
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(BuffID.Midas, 100);
			}
			SoundEngine.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}
