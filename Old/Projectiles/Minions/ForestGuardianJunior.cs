using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
	public class ForestGuardianJunior : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 34;
			projectile.height = 50;
			Main.projFrames[projectile.type] = 4;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1.0f;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forest Guardian Junior");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "森林守护者幼体");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Младший страж леса");
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 15;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.damage = (int)(player.minionDamage * 12);
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 4)
				projectile.frame = 0;
			projectile.rotation = projectile.velocity.X * 0.06f;
			if (Math.Abs(projectile.velocity.X) > 0.2)
				projectile.spriteDirection = -projectile.direction;
			projectile.rotation = projectile.velocity.X * 0.05f;
			if (Vector2.Distance(player.Center, projectile.Center) > 650.0)
			{
				projectile.position.X = player.position.X;
				projectile.position.Y = player.position.Y;
			}
			float moveX = projectile.Center.X;
			float moveY = projectile.Center.Y;
			float distance = 650.0f;
			bool target = false;
			//if bat is target (AI)
			NPC minionAttackTargetNpc = projectile.OwnerMinionAttackTargetNPC;
			if (minionAttackTargetNpc != null && minionAttackTargetNpc.CanBeChasedBy(projectile, true) && projectile.Distance(minionAttackTargetNpc.Center) < (double)distance && Collision.CanHit(projectile.Center, 1, 1, minionAttackTargetNpc.Center, 1, 1))
			{
				float moveToX = minionAttackTargetNpc.position.X + minionAttackTargetNpc.width / 2;
				float moveToY = minionAttackTargetNpc.position.Y + minionAttackTargetNpc.height / 2;
				float distanceTo = Math.Abs(projectile.position.X + projectile.width / 2 - moveToX) + Math.Abs(projectile.position.Y + projectile.height / 2 - moveToY);
				if (distanceTo < distance)
				{
					distance = distanceTo;
					moveX = moveToX;
					moveY = moveToY;
					target = true;
				}
			}
			if (!target)
			{
				for (int k = 0; k < 200; ++k)
				{
					NPC npc = Main.npc[k];
					if (npc.CanBeChasedBy(projectile, true) && projectile.Distance(npc.Center) < (double)distance && Collision.CanHit(projectile.Center, 1, 1, npc.Center, 1, 1))
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
			}
			//basic AI
			++projectile.ai[0];
			if (projectile.ai[0] < 45.0)
			{
				if (Vector2.Distance(player.Center, projectile.Center) > 150.0)
				{
					Vector2 vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
					float newMoveToX = player.Center.X - vector.X;
					float newMoveToY = player.Center.Y - vector.Y;
					float newDistance = (float)Math.Sqrt(newMoveToX * (double)newMoveToX + newMoveToY * (double)newMoveToY);
					float speed = 15.0f;
					projectile.velocity.X = (float)((projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
					projectile.velocity.Y = (float)((projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
				}
			}
			else
				projectile.ai[0] = 60.0f;
			if (target)
			{
				Vector2 vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float newMoveToX = moveX - vector.X;
				float newMoveToY = moveY - vector.Y;
				float newDistance = (float)Math.Sqrt(newMoveToX * (double)newMoveToX + newMoveToY * (double)newMoveToY);
				float speed = 6.0f;
				projectile.velocity.X = (float)((projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
				projectile.velocity.Y = (float)((projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			}
			else
			{
				Vector2 vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float speed = 6.0f;
				float x = player.Center.X - vector.X;
				float y = (float)(player.Center.Y - (double)vector.Y - 60.0);
				float distance2 = (float)Math.Sqrt(x * (double)x + y * (double)y);
				if (distance2 > 2000.0)
				{
					projectile.position.X = player.Center.X - projectile.width / 2;
					projectile.position.Y = player.Center.Y - projectile.width / 2;
				}
				if (distance2 > 70.0)
				{
					float speedForDistance = speed / distance2;
					float xToPlayer = x * speedForDistance;
					float yToPlayer = y * speedForDistance;
					projectile.velocity.X = (float)((projectile.velocity.X * 20.0 + xToPlayer) / 21.0);
					projectile.velocity.Y = (float)((projectile.velocity.Y * 20.0 + yToPlayer) / 21.0);
				}
				else
				{
					if (projectile.velocity.X == 0.0 && projectile.velocity.Y == 0.0)
					{
						projectile.velocity.X = -0.15f;
						projectile.velocity.Y = -0.05f;
					}
					Vector2 vector2 = projectile.velocity * 1.01f;
					projectile.velocity = vector2;
				}
			}
			for (int k = 0; k < 1000; k++)
			{
				if (k != projectile.whoAmI && Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type && Math.Abs(projectile.position.X - Main.projectile[k].position.X) + (double)Math.Abs(projectile.position.Y - Main.projectile[k].position.Y) < projectile.width)
				{
					if (projectile.position.X < (double)Main.projectile[k].position.X)
						projectile.velocity.X = projectile.velocity.X - 0.05f;
					else
						projectile.velocity.X = projectile.velocity.X + 0.05f;
					if (projectile.position.Y < (double)Main.projectile[k].position.Y)
						projectile.velocity.Y = projectile.velocity.Y - 0.05f;
					else
						projectile.velocity.Y = projectile.velocity.Y + 0.05f;
				}
			}
			bool flag = projectile.type == ModContent.ProjectileType<ForestGuardianJunior>();
			AntiarisPlayer modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.forestGuardianJunior = false;
				}
				if (modPlayer.forestGuardianJunior)
				{
					projectile.timeLeft = 2;
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = oldVelocity.Y;
			}
			return false;
		}
	}
}
