using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
	public class PetrousKnight2 : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 276;
			npc.damage = 42;
			npc.defense = 28;
			npc.knockBackResist = 0f;
			npc.width = 40;
			npc.height = 56;
			animationType = 295;
			npc.aiStyle = 3;
			aiType = 73;
			npc.npcSlots = 0.4f;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath43;
			npc.value = Item.buyPrice(0, 0, 6, 0);
			npc.rarity = 1;
			banner = npc.type;
			bannerItem = ModContent.ItemType<PetrousKnight2Banner>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petrous Knight");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔岩骑士");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Окаменевший рыцарь");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			var GlowMask = mod.GetTexture("Glow/PetrousKnight2_GlowMask");
			SpriteEffects Effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
		}

		public override void AI()
		{
			npc.velocity.X = 0.54f * npc.direction;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StoneHammer2>(), 1, false, 0, false, false);
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 50; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 60, 2.5f * hitDirection, -2.5f, 0, default, 1.2f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PetrousKnightGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PetrousKnightGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PetrousKnightGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PetrousKnightGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PetrousKnightGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (AntiarisMod.NormalSpawn(spawnInfo) && AntiarisMod.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.GetModPlayer<AntiarisPlayer>(mod).mirrorZone && WorldGen.crimson && Main.hardMode && !ModContent.GetInstance<AntiarisWorld>().DownedTowerKeeper && y < Main.worldSurface ? 0.12f : 0f;
		}
	}
}