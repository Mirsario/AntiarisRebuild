using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Antiaris.Content.Projectiles.Ranged
{
	public class SplitBullet2 : SplitBullet
	{
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SVDMG>(), projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);

			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);

			if (projectile.owner == Main.myPlayer)
			{
				int num220 = 3;
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(200, 500) * 0.01f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<VortexExplosion>(), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}
		}
	}
}
