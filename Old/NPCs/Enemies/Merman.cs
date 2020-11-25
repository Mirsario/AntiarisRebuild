using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Antiaris.NPCs.Enemies
{
	public class Merman : ModNPC
	{
		private int frame = 0;
		private int timer = 0;
		private bool threw = false;
		private bool attacking = false;

		public override void SetDefaults()
		{
			npc.lifeMax = 250;
			npc.damage = 80;
			npc.defense = 20;
			npc.knockBackResist = 0.3f;
			npc.width = 50;
			npc.height = 40;
			npc.aiStyle = 3;
			aiType = NPCID.GoblinScout;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit51;
			npc.noGravity = false;
			npc.DeathSound = SoundID.NPCDeath54;
			npc.value = Item.buyPrice(0, 0, 4, 0);
			bannerItem = ModContent.ItemType<MermanBanner>();
			banner = npc.type;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Merman");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Русал");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int i = 0; i < 5; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, npc.velocity.X, npc.velocity.Y);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MermanGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MermanGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MermanGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MermanGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MermanGore5"), 1f);
			}
		}

		public override void AI()
		{
			timer++;
			if (timer % 10 == 0)
			{
				frame++;
			}
			if (Main.rand.Next(100) == 0 && npc.HasPlayerTarget && Main.player[npc.target].statLife > 0)
			{
				if (Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
				{
					attacking = true;
				}
			}
			if (!attacking && frame > 5)
			{
				frame = 0;
			}
			if (frame < 6 && attacking)
			{
				frame = 6;
			}
			if (attacking && frame > 15)
			{
				attacking = false;
				timer = 0;
				frame = 0;
				threw = false;
			}
			if (attacking)
			{
				Player player = Main.player[npc.target];
				npc.position.X = npc.oldPosition.X;
				if (player.position.X > (double)npc.position.X)
					npc.spriteDirection = 1;
				else if (player.position.X < (double)npc.position.X)
					npc.spriteDirection = -1;
				if (frame == 9 && !threw)
				{
					threw = true;
					SoundEngine.PlaySound(SoundID.Item1, npc.position);
					Vector2 player2 = player.Center;
					Vector2 vector2_1 = player2;
					float speed = 10f;
					Vector2 vector2_2 = vector2_1 - npc.Center;
					float distance = (float)System.Math.Sqrt(vector2_2.X * (double)vector2_2.X + vector2_2.Y * (double)vector2_2.Y);
					vector2_2 *= speed / distance;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector2_2.X, vector2_2.Y, ModContent.ProjectileType<MermanSpear>(), 80, 5.0f, 0, 0.0f, 0.0f);
				}
			}
			npc.spriteDirection = npc.direction;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<OceanRider>(), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FishBag>(), 1, false, 0, false, false);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (AntiarisMod.NormalSpawn(spawnInfo) && Main.raining && AntiarisMod.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneHoly && y < Main.worldSurface ? 0.1f : 0f;
		}
	}
}