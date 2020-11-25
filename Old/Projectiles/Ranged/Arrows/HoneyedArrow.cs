using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged.Arrows
{
	public class HoneyedArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.DamageType = DamageClass.Ranged;
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			aiType = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honeyed Arrow");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовая стрела");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 153, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(6) == 0 && target.active && !target.dontTakeDamage && !target.immortal)
			{
				Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, ModContent.ItemType<HoneyCandy>(), 1, false, 0, false, false);
			}
		}

	}
}
