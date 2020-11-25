using System.Linq;
using Antiaris.NPCs.Town;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Antiaris
{
	public class AntiarisNPC : GlobalNPC
	{
		internal static readonly int[] Slimes =
		{
			1,
			16,
			59,
			71,
			81,
			138,
			121,
			122,
			141,
			147,
			183,
			184,
			204,
			225,
			244,
			302,
			333,
			335,
			334,
			336,
			537
		};

		public bool deceleration = false;
		public bool despairingFlamesB = false;
		public bool electrified = false;
		public bool lRage = false;
		public bool prey = false;

		private Rectangle NpcFrame;

		public bool splinter = false;

		public override bool InstancePerEntity => true;

		public override void ResetEffects(NPC npc)
		{
			splinter = false;
			despairingFlamesB = false;
			electrified = false;
			lRage = false;
			deceleration = false;
			prey = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (despairingFlamesB)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				npc.lifeRegen -= 16;
				npc.velocity /= 1.2f;
			}
			if (electrified)
			{
				Lighting.AddLight((int)npc.Center.X / 16, (int)npc.Center.Y / 16, 0.3f, 0.8f, 1.1f);
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				npc.lifeRegen -= 8;
			}
			if (lRage)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				npc.lifeRegen -= 40;
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (despairingFlamesB)
				for (int i = 0; i < 2; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 64, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, Color.White, 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity.Y -= 2f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}

			if (electrified)
				if (Main.rand.NextBool(1, 3))
				{
					int dust = Dust.NewDust(new Vector2(npc.position.X - 2f, npc.position.Y - 2f), npc.width + 4, npc.height + 4, 226, 0.0f, 0.0f, 100, new Color(), 0.5f);
					Main.dust[dust].velocity *= 1.6f;
					--Main.dust[dust].velocity.Y;
					Main.dust[dust].position = Vector2.Lerp(Main.dust[dust].position, npc.Center, 0.5f);
				}

			if (deceleration)
				for (int k = 0; k < 2; k++)
					if (Main.rand.NextBool(1, 3))
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 29, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1.5f);
						Main.dust[dust].noGravity = true;
						Main.dust[dust].velocity.Y += 2f;
					}
		}

		public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
		{
			var quest1 = mod.GetTexture("Miscellaneous/QuestIcon");
			if (quest1 == null)
				return;
			QuestSystem questSystem = Main.LocalPlayer.GetModPlayer<QuestSystem>();
			if (questSystem.currentQuest >= 0 && questSystem.currentQuest != -1 && questSystem.GetCurrentQuest() is KillQuest)
				foreach (int i in (questSystem.GetCurrentQuest() as KillQuest).TargetType)
					if (npc.type == i)
					{
						SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
						var origin = new Vector2(quest1.Width / 2, quest1.Height / 2);
						float y = 50.0f;
						Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
						spriteBatch.Draw(quest1, position, null, Color.White, 0.0f, origin, npc.scale, effects, 0.0f);
					}

			AntiarisPlayer aPlayer = Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod);
			var quest2 = mod.GetTexture("Miscellaneous/QuestIcon2");
			if (quest2 == null)
				return;
			if (npc.type == NPCID.BoundGoblin || npc.type == NPCID.BoundWizard || npc.type == NPCID.BoundMechanic || npc.type == NPCID.WebbedStylist || npc.type == NPCID.SleepingAngler || npc.type == NPCID.BartenderUnconscious)
			{
				SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				var origin = new Vector2(quest2.Width / 2, quest2.Height / 2);
				float y = 50.0f;
				Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
				spriteBatch.Draw(quest2, position, null, Color.White, npc.rotation, origin, npc.scale, effects, 0.0f);
			}

			var target = mod.GetTexture("Miscellaneous/TargetIcon");
			if (target == null)
				return;
			if (npc.buffType.Contains(ModContent.BuffType<Marked>()))
			{
				SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				var origin = new Vector2(target.Width / 2, target.Height / 2);
				Vector2 position = npc.Center - Main.screenPosition;
				spriteBatch.Draw(target, position, null, Color.White, 0, origin, npc.scale, effects, 0.0f);
			}

			var preyIcon = mod.GetTexture("Miscellaneous/Prey");
			if (prey)
			{
				SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				var origin = new Vector2(preyIcon.Width / 2, preyIcon.Height / 2);
				float y = 50.0f;
				Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
				spriteBatch.Draw(preyIcon, position, null, Color.White, 0, origin, npc.scale, effects, 0.0f);
			}
		}

		public override void NPCLoot(NPC npc)
		{
			int playerIndex = npc.lastInteraction;
			if (!Main.player[playerIndex].active || Main.player[playerIndex].dead)
			{
				playerIndex = npc.FindClosestPlayer();
			}
			Player player = Main.player[playerIndex];
			QuestSystem questSystem = Main.player[playerIndex].GetModPlayer<QuestSystem>(mod);
			ConfusedGuide.GuideQuestSystem guideQuestSystem = Main.player[playerIndex].GetModPlayer<ConfusedGuide.GuideQuestSystem>(mod);
			AntiarisPlayer aPlayer = Main.player[playerIndex].GetModPlayer<AntiarisPlayer>(mod);
			Pirate.PirateQuestSystem pirateQuestSystem = Main.player[playerIndex].GetModPlayer<Pirate.PirateQuestSystem>(mod);
			int number = 0;
			if (!npc.SpawnedFromStatue)
			{
				if ((npc.type == NPCID.Zombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.ZombieEskimo || npc.type == NPCID.PincushionZombie || npc.type == NPCID.SlimedZombie ||
					 npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.FemaleZombie
					 || npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.ZombieMushroom || npc.type == NPCID.ZombieMushroomHat || npc.type == NPCID.ZombieDoctor || npc.type == NPCID.ZombieSuperman ||
					 npc.type == NPCID.ZombiePixie || npc.type == NPCID.ZombieXmas || npc.type == NPCID.ZombieSweater || npc.type == NPCID.ArmedZombie
					 || npc.type == NPCID.ArmedZombieEskimo || npc.type == NPCID.ArmedZombiePincussion || npc.type == NPCID.ArmedZombieSlimed || npc.type == NPCID.ArmedZombieSwamp || npc.type == NPCID.ArmedZombieTwiggy ||
					 npc.type == NPCID.ArmedZombieCenx || npc.type == NPCID.BloodZombie) && Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodDroplet>(), Main.rand.Next(3, 4), false, 0, false, false);

				if ((npc.type == NPCID.Zombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.ZombieEskimo || npc.type == NPCID.PincushionZombie || npc.type == NPCID.SlimedZombie ||
					 npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.FemaleZombie
					 || npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.ZombieMushroom || npc.type == NPCID.ZombieMushroomHat || npc.type == NPCID.ZombieDoctor || npc.type == NPCID.ZombieSuperman ||
					 npc.type == NPCID.ZombiePixie || npc.type == NPCID.ZombieXmas || npc.type == NPCID.ZombieSweater || npc.type == NPCID.ArmedZombie || npc.type == NPCID.ArmedZombieEskimo
					 || npc.type == NPCID.ArmedZombiePincussion || npc.type == NPCID.ArmedZombieSlimed || npc.type == NPCID.ArmedZombieSwamp || npc.type == NPCID.ArmedZombieTwiggy || npc.type == NPCID.ArmedZombieCenx ||
					 npc.type == NPCID.BloodZombie) && Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodDroplet>(), Main.rand.Next(3, 4), false, 0, false, false);

				if ((npc.type == NPCID.Medusa || npc.type == NPCID.GreekSkeleton || npc.type == NPCID.GraniteGolem || npc.type == NPCID.GraniteFlyer) && Main.rand.Next(4) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RuneStone>(), 1, false, 0, false, false);

				if (npc.type == NPCID.Necromancer || npc.type == NPCID.NecromancerArmored)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<NecroCloth>(), Main.rand.Next(10, 14), false, 0, false, false);

				if (questSystem.currentQuest == QuestItemID.GlacialCrystal &&
					(npc.type == NPCID.IcyMerman || npc.type == NPCID.UndeadViking || npc.type == NPCID.IceSlime || npc.type == NPCID.IceElemental || npc.type == NPCID.SpikedIceSlime ||
					 npc.type == NPCID.IceBat) && Main.rand.Next(4) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<GlacialCrystal>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.Necronomicon &&
					(npc.type == NPCID.AngryBones || npc.type == NPCID.AngryBonesBig || npc.type == NPCID.AngryBonesBigMuscle || npc.type == NPCID.AngryBonesBigHelmet || npc.type == NPCID.DarkCaster ||
					 npc.type == NPCID.CursedSkull) && Main.rand.Next(6) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Necronomicon>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.HarpyEgg && npc.type == NPCID.Harpy && Main.rand.Next(6) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HarpyEgg>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.AdventurersFishingRod && (npc.type == NPCID.Zombie ||
																					  npc.type == NPCID.BaldZombie ||
																					  npc.type == NPCID.ZombieEskimo ||
																					  npc.type == NPCID.PincushionZombie ||
																					  npc.type == NPCID.SlimedZombie ||
																					  npc.type == NPCID.SwampZombie ||
																					  npc.type == NPCID.TwiggyZombie ||
																					  npc.type == NPCID.FemaleZombie ||
																					  npc.type == NPCID.ZombieRaincoat ||
																					  npc.type == NPCID.ZombieMushroom ||
																					  npc.type == NPCID.ZombieMushroomHat ||
																					  npc.type == NPCID.ZombieDoctor ||
																					  npc.type == NPCID.ZombieSuperman ||
																					  npc.type == NPCID.ZombiePixie ||
																					  npc.type == NPCID.ZombieXmas ||
																					  npc.type == NPCID.ZombieSweater ||
																					  npc.type == NPCID.ArmedZombie ||
																					  npc.type == NPCID.ArmedZombieEskimo ||
																					  npc.type == NPCID.ArmedZombiePincussion ||
																					  npc.type == NPCID.ArmedZombieSlimed ||
																					  npc.type == NPCID.ArmedZombieSwamp ||
																					  npc.type == NPCID.ArmedZombieTwiggy ||
																					  npc.type == NPCID.ArmedZombieCenx ||
																					  npc.type == NPCID.BloodZombie)
																				  && Main.rand.Next(6) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AdventurersFishingRodPart1>(), 1, false, 0, false, false);
					if (Main.netMode != NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.AdventurersFishingRod && (npc.type == NPCID.Zombie ||
																					  npc.type == NPCID.BaldZombie ||
																					  npc.type == NPCID.ZombieEskimo ||
																					  npc.type == NPCID.PincushionZombie ||
																					  npc.type == NPCID.SlimedZombie ||
																					  npc.type == NPCID.SwampZombie ||
																					  npc.type == NPCID.TwiggyZombie ||
																					  npc.type == NPCID.FemaleZombie ||
																					  npc.type == NPCID.ZombieRaincoat ||
																					  npc.type == NPCID.ZombieMushroom ||
																					  npc.type == NPCID.ZombieMushroomHat ||
																					  npc.type == NPCID.ZombieDoctor ||
																					  npc.type == NPCID.ZombieSuperman ||
																					  npc.type == NPCID.ZombiePixie ||
																					  npc.type == NPCID.ZombieXmas ||
																					  npc.type == NPCID.ZombieSweater ||
																					  npc.type == NPCID.ArmedZombie ||
																					  npc.type == NPCID.ArmedZombieEskimo ||
																					  npc.type == NPCID.ArmedZombiePincussion ||
																					  npc.type == NPCID.ArmedZombieSlimed ||
																					  npc.type == NPCID.ArmedZombieSwamp ||
																					  npc.type == NPCID.ArmedZombieTwiggy ||
																					  npc.type == NPCID.ArmedZombieCenx ||
																					  npc.type == NPCID.BloodZombie)
																				  && Main.rand.Next(6) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AdventurersFishingRodPart2>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.AdventurersFishingRod && (npc.type == NPCID.Zombie ||
																					  npc.type == NPCID.BaldZombie ||
																					  npc.type == NPCID.ZombieEskimo ||
																					  npc.type == NPCID.PincushionZombie ||
																					  npc.type == NPCID.SlimedZombie ||
																					  npc.type == NPCID.SwampZombie ||
																					  npc.type == NPCID.TwiggyZombie ||
																					  npc.type == NPCID.FemaleZombie ||
																					  npc.type == NPCID.ZombieRaincoat ||
																					  npc.type == NPCID.ZombieMushroom ||
																					  npc.type == NPCID.ZombieMushroomHat ||
																					  npc.type == NPCID.ZombieDoctor ||
																					  npc.type == NPCID.ZombieSuperman ||
																					  npc.type == NPCID.ZombiePixie ||
																					  npc.type == NPCID.ZombieXmas ||
																					  npc.type == NPCID.ZombieSweater ||
																					  npc.type == NPCID.ArmedZombie ||
																					  npc.type == NPCID.ArmedZombieEskimo ||
																					  npc.type == NPCID.ArmedZombiePincussion ||
																					  npc.type == NPCID.ArmedZombieSlimed ||
																					  npc.type == NPCID.ArmedZombieSwamp ||
																					  npc.type == NPCID.ArmedZombieTwiggy ||
																					  npc.type == NPCID.ArmedZombieCenx ||
																					  npc.type == NPCID.BloodZombie)
																				  && Main.rand.Next(6) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AdventurersFishingRodPart3>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.DemonWings && npc.type == NPCID.Demon && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DemonWingPiece>(), Main.rand.Next(1, 3), false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == QuestItemID.AdventurerChest && npc.type == NPCID.Shark && Main.rand.Next(6) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AdventurerChest>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (questSystem.currentQuest == 19 && (npc.type == NPCID.VampireBat || npc.type == NPCID.Vampire) && Main.rand.Next(4) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StrangeDiary>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}

				if (npc.type == NPCID.Demon && Main.rand.Next(22) == 0 && Main.hardMode)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HellScythe>(), 1, false, 0, false, false);
				if (npc.type == NPCID.VampireBat || npc.type == NPCID.Vampire)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<VampiricEssence>(), Main.rand.Next(2, 4), false, 0, false, false);
				if (npc.type == NPCID.MartianOfficer && Main.rand.Next(25) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ShieldGenerator>(), 1, false, 0, false, false);
				if (npc.type == NPCID.GoblinSummoner && Main.rand.Next(12) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ShadowflameCharm>(), 1, false, 0, false, false);
				if (npc.type == NPCID.GoblinSummoner)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Shadowflame>(), Main.rand.Next(5, 10), false, 0, false, false);
				if (npc.type == NPCID.BloodZombie)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodDroplet>(), Main.rand.Next(4, 6), false, 0, false, false);
				if (npc.type == NPCID.PirateCaptain && Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<GildedKey>(), 1, false, 0, false, false);
				if (!Main.expertMode && npc.type == NPCID.MoonLordCore && Main.rand.Next(100) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HeavenlyClock>(), 1, false, 0, false, false);
			}
			if (pirateQuestSystem.currentPirateQuest == 0)
			{
				if (npc.type == NPCID.EyeofCthulhu && Main.rand.Next(2) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AmuletPiece2>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
				if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
					if (npc.boss)
					{
						number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AmuletPiece1>(), 1, false, 0, false, false);
						if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
							NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
					}
				if (npc.type == NPCID.BrainofCthulhu && Main.rand.Next(2) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AmuletPiece1>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
				if (npc.type == NPCID.KingSlime && Main.rand.Next(2) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AmuletPiece3>(), 1, false, 0, false, false);
					if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
						NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
			}
			if (guideQuestSystem.CurrentQuest == 0 && (npc.type == NPCID.Zombie ||
																					  npc.type == NPCID.BaldZombie ||
																					  npc.type == NPCID.ZombieEskimo ||
																					  npc.type == NPCID.PincushionZombie ||
																					  npc.type == NPCID.SlimedZombie ||
																					  npc.type == NPCID.SwampZombie ||
																					  npc.type == NPCID.TwiggyZombie ||
																					  npc.type == NPCID.FemaleZombie ||
																					  npc.type == NPCID.ZombieRaincoat ||
																					  npc.type == NPCID.ZombieMushroom ||
																					  npc.type == NPCID.ZombieMushroomHat ||
																					  npc.type == NPCID.ZombieDoctor ||
																					  npc.type == NPCID.ZombieSuperman ||
																					  npc.type == NPCID.ZombiePixie ||
																					  npc.type == NPCID.ZombieXmas ||
																					  npc.type == NPCID.ZombieSweater ||
																					  npc.type == NPCID.ArmedZombie ||
																					  npc.type == NPCID.ArmedZombieEskimo ||
																					  npc.type == NPCID.ArmedZombiePincussion ||
																					  npc.type == NPCID.ArmedZombieSlimed ||
																					  npc.type == NPCID.ArmedZombieSwamp ||
																					  npc.type == NPCID.ArmedZombieTwiggy ||
																					  npc.type == NPCID.ArmedZombieCenx ||
																					  npc.type == NPCID.BloodZombie)
																				  && Main.rand.Next(6) == 0)
			{
				number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TheGuideforGuides>(), 1, false, 0, false, false);
				if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
			}
		}

		public override bool CheckDead(NPC npc)
		{
			AntiarisPlayer aPlayer = Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod);
			if (aPlayer.RavenousSpores && Main.rand.Next(3) == 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 44, 2.5f * npc.velocity.X, -2.5f, 0, default, 0.7f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -2f, 0f, ProjectileID.SporeCloud, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 2f, 0f, ProjectileID.SporeCloud, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, -2f, ProjectileID.SporeCloud, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 2f, ProjectileID.SporeCloud, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
			}
			if (npc.type == NPCID.Harpy && Main.rand.Next(3) == 0)
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ModContent.ProjectileType<CalmnessEnergy>(), 0, 0.0f, 0, 0.0f, 0.0f);
			return base.CheckDead(npc);
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			AntiarisPlayer aPlayer = Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod);
			if (type == NPCID.WitchDoctor && Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Equipables.Accessories.ScaryMask>());
				nextSlot++;
			}
			if (type == NPCID.ArmsDealer && Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Weapons.Ranged.Guns.ArmyRifle>());
				nextSlot++;
			}
			if (type == NPCID.ArmsDealer)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Consumables.Ammo.Buckshots.Buckshot>());
				nextSlot++;
			}
			if (type == NPCID.ArmsDealer && NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Weapons.Ranged.Guns.AssaultRifle>());
				nextSlot++;
			}
			QuestSystem questSystem = Main.LocalPlayer.GetModPlayer<QuestSystem>(mod);
			if (type == NPCID.ArmsDealer && questSystem.CurrentQuest == 12)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Materials.BonebardierBlueprint>());
				nextSlot++;
			}
			if (type == NPCID.Painter && Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Placeables.Decorations.TheKiller>());
				nextSlot++;
			}
			if (type == NPCID.Dryad && Main.LocalPlayer.ZoneHoly)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Miscellaneous.PixieLamp>());
				nextSlot++;
			}
			if (type == NPCID.Mechanic && Main.hardMode && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Placeables.Decorations.NixieTube>());
				nextSlot++;
			}
			if (type == NPCID.Mechanic && Main.hardMode && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Miscellaneous.Lightbulb>());
				nextSlot++;
			}
			if (type == NPCID.Mechanic && Main.hardMode && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Miscellaneous.LightingChip>());
				nextSlot++;
			}
			if (type == NPCID.Cyborg)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Miscellaneous.HandheldDevice>());
				nextSlot++;
			}
			if (type == NPCID.Clothier)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Equipables.Vanity.ScientistCoat>());
				nextSlot++;
			}
			if (type == NPCID.Clothier)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Equipables.Vanity.ScientistWig>());
				nextSlot++;
			}
		}

		public bool NoDamage;
		public int Damage;
		public override void SetDefaults(NPC npc)
		{
			NoDamage = npc.dontTakeDamage;
			Damage = npc.damage;
			if (!ModContent.GetInstance<AntiarisWorld>().frozenTime)
				this.NpcFrame = npc.frame;
			else
				npc.frame = this.NpcFrame;
		}

		public override bool PreAI(NPC npc)
		{
			if (ModContent.GetInstance<AntiarisWorld>().frozenTime)
			{
				npc.position.X = npc.oldPosition.X;
				npc.position.Y = npc.oldPosition.Y;
				npc.dontTakeDamage = true;
				npc.frameCounter = 0;
				npc.damage = 0;
				return false;
			}
			else
			{
				if (!NoDamage)
					npc.dontTakeDamage = false;
				npc.damage = Damage;
				return true;
			}
			return base.PreAI(npc);
		}

		public override void FindFrame(NPC npc, int frameHeight)
		{
			if (ModContent.GetInstance<AntiarisWorld>().frozenTime)
				return;
		}

		public override void AI(NPC npc)
		{
			AntiarisPlayer aPlayer = Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod);
			Player player = Main.LocalPlayer;

			if (AntiarisNPC.Slimes.Contains(npc.type))
			{
				if (player.inventory[player.selectedItem].type == ModContent.ItemType<EmeraldNet>())
					npc.catchItem = (short)(ModContent.ItemType<GreenGoo>());
				else
					npc.catchItem = -1;
			}

		}

		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (npc.buffType.Contains(ModContent.BuffType<Marked>()) && projectile.ranged)
			{
				damage += damage / 5;
			}
		}

		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (item.type == ModContent.ItemType<OrcishAxe>() && npc.HasBuff(ModContent.BuffType<Prey>()))
				damage = (int)(damage * 1.5);
		}

		public override void GetChat(NPC npc, ref string chat)
		{
			Player player = Main.LocalPlayer;
			AntiarisPlayer aPlayer = Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod);
			string mechanicName = "";
			int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
			if (mechanic >= 0)
			{
				mechanicName = Main.npc[mechanic].GivenName;
			}
			string Mechanic1 = Language.GetTextValue("Mods.Antiaris.Mechanic1", mechanicName);

			string GuideWerewolf = Language.GetTextValue("Mods.Antiaris.GuideWerewolf");
			string MerchantWerewolf = Language.GetTextValue("Mods.Antiaris.MerchantWerewolf");
			string NurseWerewolf = Language.GetTextValue("Mods.Antiaris.NurseWerewolf");
			string DemolitionistWerewolf = Language.GetTextValue("Mods.Antiaris.DemolitionistWerewolf");
			string DyeTraderWerewolf = Language.GetTextValue("Mods.Antiaris.DyeTraderWerewolf");
			string DryadWerewolf = Language.GetTextValue("Mods.Antiaris.DryadWerewolf");
			string TavernkeepWerewolf = Language.GetTextValue("Mods.Antiaris.TavernkeepWerewolf");
			string ArmsDealerWerewolf = Language.GetTextValue("Mods.Antiaris.ArmsDealerWerewolf");
			string StylistWerewolf = Language.GetTextValue("Mods.Antiaris.StylistWerewolf");
			string PainterWerewolf = Language.GetTextValue("Mods.Antiaris.PainterWerewolf");
			string AnglerWerewolf = Language.GetTextValue("Mods.Antiaris.AnglerWerewolf");
			string GoblinTinkererWerewolf = Language.GetTextValue("Mods.Antiaris.GoblinTinkererWerewolf");
			string WitchDoctorWerewolf = Language.GetTextValue("Mods.Antiaris.WitchDoctorWerewolf");
			string ClothierWerewolf = Language.GetTextValue("Mods.Antiaris.ClothierWerewolf");
			string MechanicWerewolf = Language.GetTextValue("Mods.Antiaris.MechanicWerewolf");
			string PartyGirlWerewolf = Language.GetTextValue("Mods.Antiaris.PartyGirlWerewolf");
			string WizardWerewolf = Language.GetTextValue("Mods.Antiaris.WizardWerewolf");
			string TaxCollectorWerewolf = Language.GetTextValue("Mods.Antiaris.TaxCollectorWerewolf");
			string TruffleWerewolf = Language.GetTextValue("Mods.Antiaris.TruffleWerewolf");
			string PirateWerewolf = Language.GetTextValue("Mods.Antiaris.PirateWerewolf");
			string SteampunkerWerewolf = Language.GetTextValue("Mods.Antiaris.SteampunkerWerewolf");
			string CyborgWerewolf = Language.GetTextValue("Mods.Antiaris.CyborgWerewolf");
			string SantaClausWerewolf = Language.GetTextValue("Mods.Antiaris.SantaClausWerewolf");
			string TravellingMerchantWerewolf = Language.GetTextValue("Mods.Antiaris.TravellingMerchantWerewolf");
			string SkeletonMerchantWerewolf = Language.GetTextValue("Mods.Antiaris.SkeletonMerchantWerewolf");
			if (!Main.dayTime && Main.hardMode && npc.type == NPCID.Mechanic)
			{
				if (Main.rand.Next(4) == 0)
					chat = Mechanic1;
			}
			if (player.GetModPlayer<AntiarisPlayer>(mod).isWerewolf && Main.rand.Next(4) == 0)
			{
				switch (npc.type)
				{
					case NPCID.Guide:
						chat = GuideWerewolf;
						break;
					case NPCID.Merchant:
						chat = MerchantWerewolf;
						break;
					case NPCID.Nurse:
						chat = NurseWerewolf;
						break;
					case NPCID.Demolitionist:
						chat = DemolitionistWerewolf;
						break;
					case NPCID.DyeTrader:
						chat = DyeTraderWerewolf;
						break;
					case NPCID.Dryad:
						chat = DryadWerewolf;
						break;
					case NPCID.DD2Bartender:
						chat = TavernkeepWerewolf;
						break;
					case NPCID.ArmsDealer:
						chat = ArmsDealerWerewolf;
						break;
					case NPCID.Stylist:
						chat = StylistWerewolf;
						break;
					case NPCID.Painter:
						chat = PainterWerewolf;
						break;
					case NPCID.Angler:
						chat = AnglerWerewolf;
						break;
					case NPCID.GoblinTinkerer:
						chat = GoblinTinkererWerewolf;
						break;
					case NPCID.WitchDoctor:
						chat = WitchDoctorWerewolf;
						break;
					case NPCID.Clothier:
						chat = ClothierWerewolf;
						break;
					case NPCID.Mechanic:
						chat = MechanicWerewolf;
						break;
					case NPCID.PartyGirl:
						chat = PartyGirlWerewolf;
						break;
					case NPCID.Wizard:
						chat = WizardWerewolf;
						break;
					case NPCID.TaxCollector:
						chat = TaxCollectorWerewolf;
						break;
					case NPCID.Truffle:
						chat = TruffleWerewolf;
						break;
					case NPCID.Pirate:
						chat = PirateWerewolf;
						break;
					case NPCID.Steampunker:
						chat = SteampunkerWerewolf;
						break;
					case NPCID.Cyborg:
						chat = CyborgWerewolf;
						break;
					case NPCID.SantaClaus:
						chat = SantaClausWerewolf;
						break;
					case NPCID.TravellingMerchant:
						chat = TravellingMerchantWerewolf;
						break;
					case NPCID.SkeletonMerchant:
						chat = SkeletonMerchantWerewolf;
						break;
				}
			}
			string GuideClockHelp = Language.GetTextValue("Mods.Antiaris.GuideClockHelp");
			QuestSystem questSystem = Main.LocalPlayer.GetModPlayer<QuestSystem>();
			if (npc.type == NPCID.Guide)
			{
				if (questSystem.CurrentQuest == 19)
				{
					if (player.active)
					{
						if (player.HasItem(ModContent.ItemType<BrokenHeavenlyClock>()) && player.HasItem(ModContent.ItemType<StrangeDiary>()))
						{
							chat = GuideClockHelp;
						}
					}
				}
			}
		}

		public override bool? CanChat(NPC npc)
		{
			Player player = Main.LocalPlayer;
			if (ModContent.GetInstance<AntiarisWorld>().frozenTime)
				return false;
			else
				return base.CanChat(npc);
		}
	}
}
