using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
	public class LivingSnowman : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 54;
			npc.damage = 18;
			npc.defense = 9;
			npc.knockBackResist = 0.5f;
			npc.width = 66;
			npc.height = 72;
			animationType = 3;
			npc.aiStyle = 3;
			aiType = 73;
			npc.npcSlots = 0.8f;
			npc.HitSound = SoundID.NPCHit11;
			npc.DeathSound = SoundID.NPCDeath15;
			npc.value = Item.buyPrice(0, 0, 0, 85);
			banner = npc.type;
			bannerItem = ModContent.ItemType<LivingSnowmanBanner>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Snowman");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "活雪人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Живой снеговик");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Snowball, Main.rand.Next(10, 15), false, 0, false, false);
				if (Main.rand.Next(25) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballCannon, 1, false, 0, false, false);
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default, 0.7f);
				}
				int num220 = 5;
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(200, 500) * 0.01f;
					int k = Projectile.NewProjectile(npc.position.X, npc.position.Y, value17.X, value17.Y, ProjectileID.SnowBallFriendly, npc.damage, 1f);
					Main.projectile[k].hostile = true;
					Main.projectile[k].friendly = false;
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LivingSnowmanGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LivingSnowmanGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LivingSnowmanGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (AntiarisMod.NormalSpawn(spawnInfo) && AntiarisMod.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneSnow && y < Main.worldSurface ? 0.04f : 0f;
		}
	}
}