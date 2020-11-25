using Antiaris.Items.Materials;
using Antiaris.Items.Weapons.Melee.Miscellaneous;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
	public class WrathOrc : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 68;
			npc.damage = 14;
			npc.defense = 8;
			npc.knockBackResist = 0.4f;
			npc.width = 68;
			npc.height = 68;
			animationType = 429;
			npc.aiStyle = 3;
			aiType = 73;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.DD2_OgreHurt;
			npc.DeathSound = SoundID.NPCDeath40;
			npc.value = Item.buyPrice(0, 0, 5, 0);
			banner = npc.type;
			bannerItem = ModContent.ItemType<WrathOrcBanner>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wrath Orc");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "狂兽人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Яростный орк");
			Main.npcFrameCount[npc.type] = 10;
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
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WrathElement>(), 1, false, 0, false, false);
				if (Main.rand.Next(25) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<OrcishAxe>(), 1, false, 0, false, false);
				}
			}
		}

		public override void AI()
		{
			Player player = Main.player[npc.target];
			float distanceTo = Vector2.Distance(player.Center, new Vector2((int)npc.position.X, (int)npc.position.Y));
			float distance = 300.0f;
			if (distanceTo <= (double)distance)
			{
				npc.velocity.X = 4f * npc.direction;
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default, 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathOrcGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathOrcGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathOrcGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathOrcGore4"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (AntiarisMod.NormalSpawn(spawnInfo) && AntiarisMod.NoZoneAllowWater(spawnInfo)) && NPC.downedBoss1 && !Main.dayTime && y < Main.worldSurface ? 0.1f : 0f;
		}
	}
}