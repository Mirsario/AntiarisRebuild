using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
	public class PurplePixie : ModNPC
	{
		private bool active;

		private int frame = 0;
		private double frameCounter = 0.0;
		private int spawning = 0;

		private float timer;
		private float timer2;
		private float timer3;
		private float timer4;
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			npc.noGravity = true;
			npc.width = 56;
			npc.height = 40;
			npc.aiStyle = -1;
			npc.damage = 62;
			npc.defense = 22;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit5;
			npc.knockBackResist = 0.5f;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = Item.buyPrice(0, 0, 10, 0);
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			bannerItem = ModContent.ItemType<PurplePixieBanner>();
			banner = npc.type;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Pixie");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Фиолетовая пикси");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "紫色小精灵");
			Main.npcFrameCount[npc.type] = 4;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(NPCTags.UnholyWeakness);
		}*/

		public override void AI()
		{
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.velocity.X <= 0.0 ? -1 : 1;
			npc.rotation = npc.velocity.X * 0.1f;
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 173, 0.0f, 0.0f, 200, default, 1.0f);
				Main.dust[dust].velocity *= 0.3f;
			}
			if (Main.rand.Next(40) == 0)
				SoundEngine.PlaySound(27, (int)npc.position.X, (int)npc.position.Y, 1);
			if (npc.wet)
			{
				npc.velocity.Y -= 0.2f;
				if (npc.velocity.Y < -2.0)
					npc.velocity.Y = -2.0f;
			}
			if (timer3 < 250.0)
				++this.timer3;
			if (this.spawning < 3)
				if (Main.netMode != NetmodeID.MultiplayerClient && timer3 % 75.0 == 0.0)
				{
					this.spawning++;
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<PurplePetitePixie>(), 0, 0.0f, npc.whoAmI, 0.0f, 0.0f, 255);
				}
			if (npc.life > npc.lifeMax)
				npc.life = npc.lifeMax;
			float distance = 124.0f;
			float moveX = npc.Center.X;
			float moveY = npc.Center.Y;
			bool target = false;
			foreach (NPC lamp in Main.npc)
				if (lamp.type == ModContent.NPCType<PixieLamp>() && this.timer2 <= 0.0f)
					if (Collision.CanHit(lamp.Center, 1, 1, npc.Center, 1, 1))
					{
						float distanceTo = Vector2.Distance(npc.Center, lamp.Center);
						float moveToX = lamp.position.X + lamp.width / 2;
						float moveToY = lamp.position.Y + lamp.height / 2;
						if (distanceTo <= (double)distance)
						{
							if (!this.active)
								++this.timer;
							if (timer % 60.0 == 0.0)
								if (Main.rand.Next(3) == 0)
									this.active = true;
						}
						else
							this.active = false;
						if (this.active)
						{
							moveX = moveToX;
							moveY = moveToY;
							target = true;
						}
						if (distanceTo <= 75.0)
							if (Main.rand.Next(500) == 0)
							{
								if (Main.rand.Next(2) == 0)
								{
									this.timer2 = 1250.0f;
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PedCrystalPixieDust>(), Main.rand.Next(2, 4), false, 0, false, false);
								}
								else
								{
									this.timer2 = 450.0f;
									for (int k = 0; k < 50; k++)
									{
										int dust = Dust.NewDust(npc.position, npc.width, npc.height, 90, 0.0f, -2.0f, 0, new Color(), 2.0f);
										Main.dust[dust].noGravity = true;
										Dust dust1 = Main.dust[dust];
										dust1.position.X = dust1.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
										Dust dust2 = Main.dust[dust];
										dust2.position.Y = dust2.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
										if (Main.dust[dust].position != npc.Center)
											Main.dust[dust].velocity = npc.DirectionTo(Main.dust[dust].position) * 4.0f;
									}
									lamp.checkDead();
									lamp.townNPC = false;
									lamp.life = -1;
									lamp.active = false;
									lamp.HitEffect(0, 10.0);
									Item.NewItem((int)lamp.position.X, (int)lamp.position.Y, lamp.width, lamp.height, ModContent.ItemType<PixieLamp>(), 1, false, 0, false, false);
								}
							}
					}
			if (target)
			{
				Vector2 vector = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
				float newMoveToX = moveX - vector.X;
				float newMoveToY = moveY - vector.Y;
				float newDistance = (float)Math.Sqrt(newMoveToX * (double)newMoveToX + newMoveToY * (double)newMoveToY);
				float speed = 2.0f;
				npc.velocity.X = (float)((npc.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
				npc.velocity.Y = (float)((npc.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			}
			else
			{
				bool target2 = false;
				bool moon = npc.type == NPCID.Poltergeist && !Main.pumpkinMoon;
				if (npc.justHit)
					npc.ai[2] = 0.0f;
				if (!moon)
				{
					if (npc.ai[2] >= 0.0)
					{
						int distanceToTarget = 16;
						bool velocity = false;
						bool velocityToWeight = false;
						if (npc.position.X > npc.ai[0] - (double)distanceToTarget && npc.position.X < npc.ai[0] + (double)distanceToTarget)
							velocity = true;
						else if (npc.velocity.X < 0.0 && npc.direction > 0 || npc.velocity.X > 0.0 && npc.direction < 0)
							velocity = true;
						int hW = distanceToTarget + 24;
						if (npc.position.Y > npc.ai[1] - (double)hW && npc.position.Y < npc.ai[1] + (double)hW)
							velocityToWeight = true;
						if (velocity && velocityToWeight)
						{
							++npc.ai[2];
							if (npc.ai[2] >= 30.0 && hW == 16)
								target2 = true;
							if (npc.ai[2] >= 60.0)
							{
								npc.ai[2] = -200.0f;
								npc.direction *= -1;
								npc.velocity.X *= -1.0f;
								npc.collideX = false;
							}
						}
						else
						{
							npc.ai[0] = npc.position.X;
							npc.ai[1] = npc.position.Y;
							npc.ai[2] = 0.0f;
						}
						npc.TargetClosest(true);
					}
					else if (npc.type == NPCID.Reaper)
					{
						npc.TargetClosest(true);
						npc.ai[2] += 2.0f;
					}
					else
					{
						++npc.ai[2];
						if (player.position.X + (double)(player.width / 2) > npc.position.X + (double)(npc.width / 2))
							npc.direction = -1;
						else
							npc.direction = 1;
						foreach (NPC npc1 in Main.npc)
							if (npc1.active && npc1.type == ModContent.NPCType<PurplePetitePixie>())
							{
								float distanceTo2 = Vector2.Distance(player.Center, npc.Center);
								float distance2 = 100.0f;
								if (distanceTo2 < (double)distance2)
								{
									this.timer4 += 15;
									Vector2 shootPos = npc.Center;
									float inaccuracy = 9.0f;
									Vector2 shootVel = player.Center - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
									shootVel.Normalize();
									shootVel *= 9.0f;
									float color = 3.0f;
									if (Main.netMode != NetmodeID.MultiplayerClient && Collision.CanHitLine(npc.Center, 0, 0, player.Center, 0, 0) && this.timer4 % 60.0 == 0.0)
										Projectile.NewProjectile(npc.Center.X, npc.Center.Y, shootVel.X, shootVel.Y, ModContent.ProjectileType<PetitePixie>(), 22, 4.0f, 0, 0.0f, color);
								}
							}
					}
				}
				int posX = (int)((npc.position.X + (double)(npc.width / 2)) / 16.0) + npc.direction * 2;
				int posY = (int)((npc.position.Y + (double)npc.height) / 16.0);
				bool zero = true;
				bool zero2 = false;
				int speed2 = 4;
				for (int k = posY; k < posY + speed2; ++k)
				{
					if (Main.tile[posX, k] == null)
						Main.tile[posX, k] = new Tile();
					if (Main.tile[posX, k].nactive() && Main.tileSolid[Main.tile[posX, k].type] || Main.tile[posX, k].liquid > 0)
					{
						if (k <= posY + 1)
							zero2 = true;
						zero = false;
						break;
					}
				}
				if (player.npcTypeNoAggro[npc.type])
				{
					bool velocity = false;
					for (int k = posY; k < posY + speed2 - 2; ++k)
					{
						if (Main.tile[posX, k] == null)
							Main.tile[posX, k] = new Tile();
						if (Main.tile[posX, k].nactive() && Main.tileSolid[Main.tile[posX, k].type] || Main.tile[posX, k].liquid > 0)
						{
							velocity = true;
							break;
						}
					}
					npc.directionY = (!velocity).ToDirectionInt();
				}
				if (target2)
				{
					zero2 = false;
					zero = true;
				}
				if (zero)
				{
					npc.velocity.Y += 0.2f;
					if (npc.velocity.Y > 2.0)
						npc.velocity.Y = 2f;
				}
				else
				{
					if (npc.directionY < 0 && npc.velocity.Y > 0.0 || zero2)
						npc.velocity.Y -= 0.2f;
				}
				if (npc.collideX)
				{
					npc.velocity.X = npc.oldVelocity.X * -0.4f;
					if (npc.direction == -1 && npc.velocity.X > 0.0 && npc.velocity.X < 1.0)
						npc.velocity.X = 1f;
					if (npc.direction == 1 && npc.velocity.X < 0.0 && npc.velocity.X > -1.0)
						npc.velocity.X = -1f;
				}
				if (npc.collideY)
				{
					npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
					if (npc.velocity.Y > 0.0 && npc.velocity.Y < 1.0)
						npc.velocity.Y = 1f;
					if (npc.velocity.Y < 0.0 && npc.velocity.Y > -1.0)
						npc.velocity.Y = -1f;
				}
				float maxX = 3.5f;
				if (npc.direction == -1 && npc.velocity.X > -(double)maxX)
				{
					npc.velocity.X -= 0.1f;
					if (npc.velocity.X > (double)maxX)
						npc.velocity.X -= 0.1f;
					else if (npc.velocity.X > 0.0)
						npc.velocity.X += 0.05f;
					if (npc.velocity.X < -(double)maxX)
						npc.velocity.X = -maxX;
				}
				else if (npc.direction == 1 && npc.velocity.X < (double)maxX)
				{
					npc.velocity.X += 0.1f;
					if (npc.velocity.X < -(double)maxX)
						npc.velocity.X += 0.1f;
					else if (npc.velocity.X < 0.0)
						npc.velocity.X -= 0.05f;
					if (npc.velocity.X > (double)maxX)
						npc.velocity.X = maxX;
				}
				float maxY = 2.0f;
				if (npc.directionY == -1 && npc.velocity.Y > -(double)maxY)
				{
					npc.velocity.Y -= 0.04f;
					if (npc.velocity.Y > (double)maxY)
						npc.velocity.Y -= 0.05f;
					else if (npc.velocity.Y > 0.0)
						npc.velocity.Y += 0.03f;
					if (npc.velocity.Y < -(double)maxY)
						npc.velocity.Y = -maxY;
				}
				else if (npc.directionY == 1 && npc.velocity.Y < (double)maxY)
				{
					npc.velocity.Y += 0.04f;
					if (npc.velocity.Y < -(double)maxY)
						npc.velocity.Y += 0.05f;
					else if (npc.velocity.Y < 0.0)
						npc.velocity.Y -= 0.03f;
					if (npc.velocity.Y > (double)maxY)
						npc.velocity.Y = maxY;
				}
			}
			Lighting.AddLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.9f, 0.2f, 0.1f);
		}

		public override void FindFrame(int frameHeight)
		{
			this.frameCounter++;
			if (this.frameCounter >= 4.0)
			{
				this.frame++;
				this.frameCounter = 0;
			}
			if (this.frame >= 4)
				this.frame = 0;
			npc.frame.Y = this.frame * frameHeight;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.spawnTileY <= Main.worldSurface || !spawnInfo.player.ZoneHoly)
				return 0.0f;
			return 0.095f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PurpleBigCrystal>(), Main.rand.Next(1, 3), false, 0, false, false);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life > 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 173, 2.5f * hitDirection, -2.5f, 0, default, 0.7f);
			}
			else
			{
				for (int k = 0; k < 50; k++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 173, 0.0f, -2.0f, 0, new Color(), 2.0f);
					Main.dust[dust].noGravity = true;
					Dust dust1 = Main.dust[dust];
					dust1.position.X = dust1.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					Dust dust2 = Main.dust[dust];
					dust2.position.Y = dust2.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					if (Main.dust[dust].position != npc.Center)
						Main.dust[dust].velocity = npc.DirectionTo(Main.dust[dust].position) * 2.0f;
				}
			}
		}
	}
}
