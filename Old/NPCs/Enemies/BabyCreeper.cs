using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Antiaris.NPCs.Town;

namespace Antiaris.NPCs.Enemies
{
	public class BabyCreeper : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 50;
			npc.damage = 12;
			npc.defense = 6;
			npc.knockBackResist = 0f;
			npc.width = 34;
			npc.height = 36;
			npc.aiStyle = -1;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.npcSlots = 2f;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 1, 15);
			animationType = 238;
			npc.rarity = 1;
			banner = npc.type;
			bannerItem = ModContent.ItemType<BabyCreeperBanner>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baby Creeper");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "爬行者幼体");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маленький паучок");
			Main.npcFrameCount[npc.type] = 4;
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
				int playerIndex = npc.lastInteraction;
				if (!Main.player[playerIndex].active || Main.player[playerIndex].dead)
				{
					playerIndex = npc.FindClosestPlayer();
				}
				Player player = Main.player[playerIndex];
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				QuestSystem questSystem = Main.player[playerIndex].GetModPlayer<QuestSystem>(mod);
				int number = 0;
				if (questSystem.currentQuest == QuestItemID.SpiderMass)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SpiderMass>(), Main.rand.Next(2, 4), false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
			}
		}

		public override void AI()
		{
			//vanilla code
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
				npc.TargetClosest(true);
			float num1 = 2f;
			float num2 = 0.08f;
			Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float num3 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
			float num4 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
			float num5 = (int)(num3 / 8.0) * 8;
			float num6 = (int)(num4 / 8.0) * 8;
			vector2.X = (int)(vector2.X / 8.0) * 8;
			vector2.Y = (int)(vector2.Y / 8.0) * 8;
			float num7 = num5 - vector2.X;
			float num8 = num6 - vector2.Y;
			float num9 = (float)Math.Sqrt(num7 * (double)num7 + num8 * (double)num8);
			float num10;
			float num11;
			if (num9 == 0.0)
			{
				num10 = npc.velocity.X;
				num11 = npc.velocity.Y;
			}
			else
			{
				float num12 = num1 / num9;
				num10 = num7 * num12;
				num11 = num8 * num12;
			}
			if (Main.player[npc.target].dead)
			{
				num10 = (float)(npc.direction * (double)num1 / 2.0);
				num11 = (float)(-num1 / 2.0);
			}
			npc.spriteDirection = -1;
			if (!Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
			{
				++npc.ai[0];
				if (npc.ai[0] > 0.0)
					npc.velocity.Y = npc.velocity.Y + 23f / 1000f;
				else
					npc.velocity.Y = npc.velocity.Y - 23f / 1000f;
				if (npc.ai[0] < -100.0 || npc.ai[0] > 100.0)
					npc.velocity.X = npc.velocity.X + 23f / 1000f;
				else
					npc.velocity.X = npc.velocity.X - 23f / 1000f;
				if (npc.ai[0] > 200.0)
					npc.ai[0] = -200f;
				npc.velocity.X = npc.velocity.X + num10 * 0.007f;
				npc.velocity.Y = npc.velocity.Y + num11 * 0.007f;
				npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
				if (npc.velocity.X > 1.5)
					npc.velocity.X = npc.velocity.X * 0.9f;
				if (npc.velocity.X < -1.5)
					npc.velocity.X = npc.velocity.X * 0.9f;
				if (npc.velocity.Y > 1.5)
					npc.velocity.Y = npc.velocity.Y * 0.9f;
				if (npc.velocity.Y < -1.5)
					npc.velocity.Y = npc.velocity.Y * 0.9f;
				if (npc.velocity.X > 3.0)
					npc.velocity.X = 3f;
				if (npc.velocity.X < -3.0)
					npc.velocity.X = -3f;
				if (npc.velocity.Y > 3.0)
					npc.velocity.Y = 3f;
				if (npc.velocity.Y < -3.0)
					npc.velocity.Y = -3f;
			}
			else
			{
				if (npc.velocity.X < (double)num10)
				{
					npc.velocity.X = npc.velocity.X + num2;
					if (npc.velocity.X < 0.0 && num10 > 0.0)
						npc.velocity.X = npc.velocity.X + num2;
				}
				else if (npc.velocity.X > (double)num10)
				{
					npc.velocity.X = npc.velocity.X - num2;
					if (npc.velocity.X > 0.0 && num10 < 0.0)
						npc.velocity.X = npc.velocity.X - num2;
				}
				if (npc.velocity.Y < (double)num11)
				{
					npc.velocity.Y = npc.velocity.Y + num2;
					if (npc.velocity.Y < 0.0 && num11 > 0.0)
						npc.velocity.Y = npc.velocity.Y + num2;
				}
				else if (npc.velocity.Y > (double)num11)
				{
					npc.velocity.Y = npc.velocity.Y - num2;
					if (npc.velocity.Y > 0.0 && num11 < 0.0)
						npc.velocity.Y = npc.velocity.Y - num2;
				}
				npc.rotation = (float)Math.Atan2(num11, num10);
			}
			float num13 = 0.5f;
			if (npc.collideX)
			{
				npc.netUpdate = true;
				npc.velocity.X = npc.oldVelocity.X * -num13;
				if (npc.direction == -1 && npc.velocity.X > 0.0 && npc.velocity.X < 2.0)
					npc.velocity.X = 2f;
				if (npc.direction == 1 && npc.velocity.X < 0.0 && npc.velocity.X > -2.0)
					npc.velocity.X = -2f;
			}
			if (npc.collideY)
			{
				npc.netUpdate = true;
				npc.velocity.Y = npc.oldVelocity.Y * -num13;
				if (npc.velocity.Y > 0.0 && npc.velocity.Y < 1.5)
					npc.velocity.Y = 2f;
				if (npc.velocity.Y < 0.0 && npc.velocity.Y > -1.5)
					npc.velocity.Y = -2f;
			}
			if ((npc.velocity.X > 0.0 && npc.oldVelocity.X < 0.0 || npc.velocity.X < 0.0 && npc.oldVelocity.X > 0.0 || (npc.velocity.Y > 0.0 && npc.oldVelocity.Y < 0.0 || npc.velocity.Y < 0.0 && npc.oldVelocity.Y > 0.0)) && !npc.justHit)
				npc.netUpdate = true;
			if (Main.netMode == NetmodeID.MultiplayerClient)
				return;
			if (Main.netMode != NetmodeID.MultiplayerClient && Main.expertMode && (npc.target >= 0 && Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1)))
			{
				++npc.localAI[0];
				if (npc.justHit)
				{
					npc.localAI[0] -= Main.rand.Next(20, 60);
					if (npc.localAI[0] < 0.0)
						npc.localAI[0] = 0.0f;
				}
				if (npc.localAI[0] > 225.0)
					npc.localAI[0] = 0.0f;
			}
			int num14 = (int)npc.Center.X / 16;
			int num15 = (int)npc.Center.Y / 16;
			bool flag = false;
			for (int index1 = num14 - 1; index1 <= num14 + 1; ++index1)
			{
				for (int index2 = num15 - 1; index2 <= num15 + 1; ++index2)
				{
					if (Main.tile[index1, index2] == null)
						return;
					if (Main.tile[index1, index2].wall > 0)
						flag = true;
				}
			}
			if (flag)
				return;
			npc.Transform(ModContent.NPCType<BabyCreeperGround>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int i = 0; i < 20; ++i)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 53, 2.5f * hitDirection, -2.5f, 0, new Color(), 1f);
				}
			}
			else
			{
				for (int i = 0; i < damage / npc.lifeMax * 50.0; ++i)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 53, hitDirection, -1f, 0, new Color(), 0.8f);
				}
			}
		}
	}
}