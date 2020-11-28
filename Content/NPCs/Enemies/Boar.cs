using Antiaris.Content.Gores;
using Antiaris.Content.Items.Placeables.Banners;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.NPCs.Enemies
{
	public class Boar : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 65;
			npc.damage = 14;
			npc.defense = 10;
			npc.knockBackResist = 0.2f;
			npc.width = 66;
			npc.height = 44;
			animationType = NPCID.Bunny;
			npc.aiStyle = 26;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 4, 0);
			banner = npc.type;
			bannerItem = ModContent.ItemType<BoarBanner>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boar");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "大山猪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кабан");
			Main.npcFrameCount[npc.type] = 7;
		}

		public override void AI()
		{
			if (!Main.dayTime)
			{
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active)
					{
						Main.player[k].npcTypeNoAggro[1] = false;
						npc.damage = 26;
						npc.aiStyle = 26;
					}
				}
			}
			else
			{
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active)
					{
						if (npc.life == npc.lifeMax)
						{
							Main.player[k].npcTypeNoAggro[1] = true;
							npc.damage = 0;
							npc.aiStyle = 7;
						}
						if (npc.life < npc.lifeMax)
						{
							Main.player[k].npcTypeNoAggro[1] = false;
							npc.damage = Main.expertMode ? 25 : 14;
							npc.aiStyle = 26;
						}
					}
				}
			}
			npc.netUpdate = true;
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
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default, 0.7f);
				}

				for (byte i = 0; i < 4; i++)
				{
					int index = Gore.NewGore(npc.position, npc.velocity, ModContent.GoreType<BoarGore>());
					Main.gore[index].Frame.CurrentRow = i;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return SpawnCondition.OverworldDaySlime.Chance * 0.12f;
			;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Leather, Main.rand.Next(1, 2), false, 0, false, false);
				if (Main.rand.Next(25) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bacon, 1, false, 0, false, false);
				}
			}
		}
	}
}
