using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class VoidBall : ModProjectile
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.aiStyle = 72;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			projectile.timeLeft = 240;
			projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Void Sphere");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сфера пустоты");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "虚空魔球");
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projFrames[projectile.type] = 3;
		}

		public override void AI()
		{
			if (projectile.alpha > 0)
				projectile.alpha--;
			projectile.direction = 1;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= Main.projFrames[projectile.type])
				projectile.frame = 0;
			float moveX = projectile.Center.X;
			float moveY = projectile.Center.Y;
			float distance = 600f;
			bool target = false;
			for (int k = 0; k < 200; ++k)
			{
				NPC npc = Main.npc[k];
				if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.lifeMax > 5 && npc.type != NPCID.TargetDummy && projectile.Distance(npc.Center) < (double)distance && Collision.CanHit(projectile.Center, 1, 1, npc.Center, 1, 1))
				{
					float moveToX = npc.position.X + npc.width / 2;
					float moveToY = npc.position.Y + npc.height / 2;
					float distanceTo = Math.Abs(projectile.position.X + projectile.width / 2 - moveToX) + Math.Abs(projectile.position.Y + projectile.height / 2 - moveToY);
					if (distanceTo < distance)
					{
						distance = distanceTo;
						moveX = moveToX;
						moveY = moveToY;
						target = true;
					}
				}
			}
			if (target)
			{
				Vector2 vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float newMoveToX = moveX - vector.X;
				float newMoveToY = moveY - vector.Y;
				float newDistance = (float)Math.Sqrt(newMoveToX * (double)newMoveToX + newMoveToY * (double)newMoveToY);
				float speed = 6.4f;
				projectile.velocity.X = (float)((projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
				projectile.velocity.Y = (float)((projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 4; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 240, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[dust].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
			}
			for (int k = 0; k < 30; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, 0.0f, 0.0f, 200, new Color(), 3.7f);
				Main.dust[dust].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 3f;
				int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 90, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[dust2].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.dust[dust2].velocity *= 2f;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust2].fadeIn = 1f;
				Main.dust[dust2].color = Color.Crimson * 0.5f;
			}
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, 0.0f, 0.0f, 0, new Color(), 2.7f);
				Main.dust[dust].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.14159274101257).RotatedBy(projectile.velocity.ToRotation(), new Vector2()) * projectile.width / 2f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 3f;
			}
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 240, 0.0f, 0.0f, 0, new Color(), 1.5f);
				Main.dust[dust].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.14159274101257).RotatedBy(projectile.velocity.ToRotation(), new Vector2()) * projectile.width / 2f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 3f;
			}
			for (int k = 0; k < 2; k++)
			{
				int gore = Gore.NewGore(projectile.position + new Vector2(projectile.width * Main.rand.Next(100) / 100f, projectile.height * Main.rand.Next(100) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[gore].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.gore[gore].velocity *= 0.3f;
				Main.gore[gore].velocity.X += Main.rand.Next(-10, 11) * 0.05f;
				Main.gore[gore].velocity.Y += Main.rand.Next(-10, 11) * 0.05f;
			}
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.type == NPCID.TargetDummy)
				return;
			int newLife = Main.rand.Next(2, 5);
			Player player = Main.player[projectile.owner];
			player.statLife += newLife;
			player.HealEffect(newLife);
			NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, projectile.owner, newLife);
			projectile.netUpdate = true;
		}
	}
}
