﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Miscellaneous
{
	public class AdventurerAttack2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.penetrate = 3;
			projectile.timeLeft = 240;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ProjectileTags.TownNPCProj);
		}*/

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override void AI()
		{
			if (projectile.alpha > 0)
				projectile.alpha--;
			projectile.spriteDirection = -projectile.direction;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= Main.projFrames[projectile.type])
				projectile.frame = 0;
			for (int k = 0; k < 5; k++)
			{
				float x = projectile.velocity.X / 3f;
				float y = projectile.velocity.Y / 3f;
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, 0.0f, 0.0f, 0, new Color(), 1.6f);
				Main.dust[dust].position.X = projectile.Center.X - x;
				Main.dust[dust].position.Y = projectile.Center.Y - y;
				Main.dust[dust].velocity *= 0.0f;
				Main.dust[dust].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 7; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, Main.rand.Next(-4, 4), Main.rand.Next(-4, 4), 0, new Color(), 1.5f);
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
