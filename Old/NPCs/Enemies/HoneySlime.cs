﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
	public class HoneySlime : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 280;
			npc.damage = 80;
			npc.defense = 18;
			npc.knockBackResist = 0.4f;
			npc.width = 34;
			npc.height = 26;
			npc.aiStyle = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 4, 0);
			animationType = 1;
			bannerItem = ModContent.ItemType<HoneySlimeBanner>();
			banner = npc.type;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Slime");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовый слизень");
			Main.npcFrameCount[npc.type] = 2;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(NPCTags.Slime);
			this.SetTag(NPCTags.FireWeakness);
		}*/

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
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HoneyExtract>(), Main.rand.Next(2, 5), false, 0, false, false);
				}
				if (Main.rand.Next(Main.expertMode ? 2 : 3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HoneyBlock, Main.rand.Next(5, 10), false, 0, false, false);
				}
			}
		}

		public override void AI()
		{
			if (Main.rand.Next(700) == 0)
			{
				if (Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquid == 0 || Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquidType() == 0)
				{
					Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquidType(2);
					Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquid = 255;
					WorldGen.SquareTileFrame((int)npc.position.X / 16, (int)npc.position.Y / 16, true);
					if (Main.netMode == NetmodeID.MultiplayerClient)
						NetMessage.sendWater((int)npc.position.X / 16, (int)npc.position.Y / 16);
				}
			}
		}

		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
		{
			if (item.type == ItemID.FieryGreatsword || item.type == ItemID.MoltenPickaxe || item.type == ItemID.MoltenHamaxe)
			{
				SoundEngine.PlaySound(SoundID.LiquidsHoneyLava, npc.position);
				npc.Transform(ModContent.NPCType<CrispyHoneySlime>());
			}
		}

		public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
		{
			if (projectile.type == ProjectileID.Spark || projectile.type == ProjectileID.FlamingArrow || projectile.type == ProjectileID.Flare || projectile.type == ProjectileID.BallofFire ||
				projectile.type == ProjectileID.Flamarang || projectile.type == ProjectileID.Flamelash || projectile.type == ProjectileID.Sunfury || projectile.type == ProjectileID.Flames ||
				projectile.type == ProjectileID.Cascade || projectile.type == ProjectileID.HelFire || projectile.type == ProjectileID.InfernoFriendlyBlast ||
				projectile.type == ProjectileID.InfernoFriendlyBolt || projectile.type == ProjectileID.DD2FlameBurstTowerT3Shot || projectile.type == ProjectileID.DD2FlameBurstTowerT2Shot
				|| projectile.type == ProjectileID.DD2FlameBurstTowerT3 || projectile.type == ModContent.ProjectileType<Hellbat>() || projectile.type == ModContent.ProjectileType<HellbatExplosion>())
			{
				SoundEngine.PlaySound(SoundID.LiquidsHoneyLava, npc.position);
				npc.Transform(ModContent.NPCType<CrispyHoneySlime>());
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 153, 0f, 0f, 50, default, 1.5f);
					Main.dust[dust].velocity *= 2f;
					Main.dust[dust].noGravity = true;
				}
				if (Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquid == 0 || Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquidType() == 0)
				{
					Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquidType(2);
					Main.tile[(int)npc.position.X / 16, (int)npc.position.Y / 16].liquid = 255;
					WorldGen.SquareTileFrame((int)npc.position.X / 16, (int)npc.position.Y / 16, true);
					if (Main.netMode == NetmodeID.MultiplayerClient)
						NetMessage.sendWater((int)npc.position.X / 16, (int)npc.position.Y / 16);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (AntiarisMod.NormalSpawn(spawnInfo) && Main.hardMode && AntiarisMod.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && y > Main.rockLayer ? 0.01f : 0f;
		}
	}
}
