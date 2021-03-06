using System.Collections.Generic;
using System.Linq;
using Antiaris.NPCs.Town;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris
{
	public class AntiarisTile : GlobalTile
	{
		private int[] randomTiles = { 0, 3, 185, 186, 187, 71, 28 };

		private bool tile = false;

		public override bool Drop(int i, int j, int type)
		{
			Player player = Main.LocalPlayer;
			QuestSystem questSystem = player.GetModPlayer<QuestSystem>(mod);
			if (Main.netMode != NetmodeID.MultiplayerClient && !WorldGen.noTileActions && !WorldGen.gen)
			{
				if (type == 53 || type == 234 || type == 116 || type == 112)
				{
					if (Main.rand.Next(250) == 0)
					{
						Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<MonsterSkull>(), 1, false, 0, false, false);
					}
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.Grass)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Leaf>(), Main.rand.Next(3, 9), false, 0, false, false);
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Apple>(), Main.rand.Next(0, 3), false, 0, false, false);
					if (!Main.dayTime)
					{
						if (Main.rand.Next(3) == 0)
						{
							if (NPC.CountNPCS(ModContent.NPCType<ForestGuardian>()) < 1)
							{
								NPC.NewNPC(i * 16, (j - 10) * 16, ModContent.NPCType<ForestGuardian>(), 0, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
							}
						}
					}
				}
				if (type == TileID.PalmTree && Main.rand.Next(3) == 0)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 16, 16, ModContent.ItemType<Coconut>(), Main.rand.Next(3, 4), false, 0, false, false);
				}
				if (type == TileID.PalmTree)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<PalmLeaf>(), 1, false, 0, false, false);
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.JungleGrass)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<TropicalLeaf>(), Main.rand.Next(3, 9), false, 0, false, false);
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.SnowBlock)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<ChilledLeaf>(), Main.rand.Next(3, 9), false, 0, false, false);
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.HallowedGrass)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<EnchantedLeaf>(), Main.rand.Next(3, 9), false, 0, false, false);
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.CorruptGrass)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<InfectedLeaf>(), Main.rand.Next(3, 9), false, 0, false, false);
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == 199)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<OrganLeaf>(), Main.rand.Next(3, 9), false, 0, false, false);
				}
				if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.SnowBlock && Main.rand.Next(40) == 0)
				{
					Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<OwlFeather>(), 1, false, 0, false, false);
				}
			}
			return base.Drop(i, j, type);
		}

		public override bool CanExplode(int i, int j, int type)
		{
			Player player = Main.LocalPlayer;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (aPlayer.mirrorZone && (type == TileID.GrayBrick || type == TileID.DemoniteBrick || type == TileID.CrimtaneBrick))
			{
				return false;
			}
			return base.CanExplode(i, j, type);
		}

		public override void AnimateTile()
		{
			if (ModContent.GetInstance<AntiarisWorld>().frozenTime)
			{
				for (int i = 0; i < 469; i++)
				{
					Main.tileFrameCounter[i] = 0;
				}
			}
		}

		public override bool PreDraw(int i, int j, int type, SpriteBatch spriteBatch)
		{
			int frameX = Main.tile[i, j].frameX;
			int frameY = Main.tile[i, j].frameY;
			if (Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod).findTreasure2)
			{
				bool checkFrame = false;
				if (type == 185 && frameY == 18 && (frameX >= 576 && frameX <= 882))
					checkFrame = true;
				if (type == 186 && frameX >= 864 && frameX <= 1170)
					checkFrame = true;
				if (checkFrame || Main.tileSpelunker[type] || Main.tileAlch[type] && type != 82)
				{
					if (!Main.gamePaused && Main.rand.Next(5) == 0)
					{
						int dust = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 59, 0.0f, 0.0f, 150, new Color(), 1.0f);
						Main.dust[dust].fadeIn = 1.0f;
						Main.dust[dust].velocity *= 0.1f;
						Main.dust[dust].noLight = true;
						Main.dust[dust].noGravity = true;
					}
				}
			}
			return true;
		}

		public override void RandomUpdate(int i, int j, int type)
		{
			if (type == 117 || type == 116 || type == 164 || type == 402 || type == 403)
			{
				if (randomTiles.Contains(Framing.GetTileSafely(i, j - 1).type) && randomTiles.Contains(Framing.GetTileSafely(i, j - 2).type) && Main.hardMode)
				{
					if (Main.rand.Next(300) == 0 && (j >= (int)(Main.maxTilesY * 0.349999994039536) && j <= Main.maxTilesY - 300))
					{
						WorldGen.PlaceObject(i - 1, j - 1, ModContent.TileType<DazzlingHeart>());
						NetMessage.SendObjectPlacment(-1, i - 1, j - 1, ModContent.TileType<DazzlingHeart>(), 0, 0, -1, -1);
					}
				}
			}
		}

		public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
		{
			if (Main.LocalPlayer.GetModPlayer<AntiarisPlayer>(mod).mirrorZone && (type == TileID.GrayBrick || type == TileID.DemoniteBrick || type == TileID.CrimtaneBrick))
			{
				return false;
			}
			List<int> weakBlocks = new List<int>()
			{
				TileID.Dirt,
				TileID.ClayBlock,
				TileID.Sand,
				TileID.HardenedSand,
				TileID.Silt,
				TileID.Slush,
				TileID.Ash,
				TileID.Ebonsand,
				TileID.Crimsand,
				TileID.Pearlsand,
				TileID.CorruptHardenedSand,
				TileID.CrimsonHardenedSand,
				TileID.HallowHardenedSand,
				TileID.Mud
			};
			if (Main.LocalPlayer.inventory[Main.LocalPlayer.selectedItem].type == ModContent.ItemType<SteelShovel>())
			{
				if (!weakBlocks.Contains(type) && !TileID.Sets.Grass[type] && !TileID.Sets.GrassSpecial[type] && !TileID.Sets.Snow[type] &&
				 !TileID.Sets.Mud[type] && !TileID.Sets.Leaves[type] && !TileID.Sets.NeedsGrassFraming[type])
					return false;
			}
			return true;
		}
	}
}