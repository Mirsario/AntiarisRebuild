using Antiaris.Content.Tiles.Furniture;
using Antiaris.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Antiaris.Content.WorldBuilding.Structures
{
	public class GuideHouseStructure : StructureBase
	{
		public override void Generate(GenerationProgress progress, GameConfiguration configuration)
		{
			string GuideHouseGen = Language.GetTextValue("Mods.Antiaris.GuideHouseGen");
			if (progress != null)
			{
				progress.Message = GuideHouseGen;
				progress.Set(0.1f);
			}
			int startX = Main.maxTilesX / 2 + 5;
			int endX = Main.spawnTileX + 50;
			StartPositionX = 0;
			StartPositionY = 0;
			for (int attempts = 0; attempts < 10000; attempts++)
			{
				StartPositionX = WorldGen.genRand.Next(startX, endX);
				StartPositionY = 200;
				do
				{
					StartPositionY++;
				}
				while (!Main.tile[StartPositionX, StartPositionY].active() && StartPositionY < Main.worldSurface);
				if (Main.tile[StartPositionX, StartPositionY].active() && (Main.tile[StartPositionX, StartPositionY].type == TileID.Dirt || Main.tile[StartPositionX, StartPositionY].type == TileID.Grass) && TileUtilities.GetLiquidLevel(StartPositionX, StartPositionY - 1, LiquidType.Water) <= 0)
				{
					goto GenerateBuild;
				}
			}
		//AntiarisHelper.Log("Continue...");

		GenerateBuild:
			//AntiarisHelper.Log("Generating guide house...");
			int SpawnGuide = NPC.NewNPC((StartPositionX + 15) * 16, (StartPositionY - 6) * 16, Mod.Find<ModNPC>("UnconsciousGuide").Type, 0, 0f, 0f, 0f, 0f, 255);
			Main.npc[SpawnGuide].homeTileX = -1;
			Main.npc[SpawnGuide].homeTileY = -1;
			Main.npc[SpawnGuide].direction = 1;
			Main.npc[SpawnGuide].homeless = false;

			PlaceGrids();
			
			WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 13, 79, true, Bed);
			WorldGen.PlaceChest(StartPositionX + 14, StartPositionY - 13, ChestType);
			int ChestIndex2 = Chest.FindChest(StartPositionX + 14, StartPositionY - 14);
			if (ChestIndex2 != -1)
			{
				do_GuideHouseLoot2(Main.chest[ChestIndex2].item);
			}
			WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 11, 42, true, 3);
			WorldGen.PlaceObject(StartPositionX + 14, StartPositionY - 15, 78, true);
			WorldGen.PlaceObject(StartPositionX + 8, StartPositionY - 5, 387, true);
			WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 6, 14, true, Table);
			WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 8, 103, true);
			WorldGen.PlaceObject(StartPositionX + 8, StartPositionY - 10, 50, true);
			WorldGen.PlaceObject(StartPositionX + 9, StartPositionY - 10, 13, true, 1);
			WorldGen.PlaceObject(StartPositionX + 15, StartPositionY - 10, 246, true, 3);
			WorldGen.PlaceObject(StartPositionX + 1, StartPositionY - 5, Mailbox);
			WorldGen.PlaceObject(StartPositionX + 22, StartPositionY - 6, Dray);
			WorldGen.PlaceObject(StartPositionX + 19, StartPositionY - 6, 10, true, Door);
			WorldGen.KillTile(StartPositionX + 11, StartPositionY - 2, false, false, true);
			WorldGen.KillTile(StartPositionX + 12, StartPositionY - 2, false, false, true);
			WorldGen.KillTile(StartPositionX + 11, StartPositionY - 3, false, false, true);
			WorldGen.KillTile(StartPositionX + 12, StartPositionY - 3, false, false, true);
			WorldGen.KillTile(StartPositionX + 10, StartPositionY - 2, false, false, true);
			WorldGen.KillTile(StartPositionX + 9, StartPositionY - 2, false, false, true);
			WorldGen.KillTile(StartPositionX + 10, StartPositionY - 3, false, false, true);
			WorldGen.KillTile(StartPositionX + 9, StartPositionY - 3, false, false, true);
			WorldGen.KillTile(StartPositionX + 8, StartPositionY - 2, false, false, true);
			WorldGen.KillTile(StartPositionX + 8, StartPositionY - 3, false, false, true);
			WorldGen.PlaceChest(StartPositionX + 11, StartPositionY - 2, 21, true, 28);
			int ChestIndex1 = Chest.FindChest(StartPositionX + 11, StartPositionY - 3);
			if (ChestIndex1 != -1)
			{
				do_GuideHouseLoot(Main.chest[ChestIndex1].item);
			}
		}

		protected override ushort[] GetTileTheme(int type)
		{
			switch (type)
			{
				case TileID.Dirt:
					return new ushort[]
					{
						TileID.Dirt, TileID.WoodBlock, TileID.GrayBrick, TileID.Stone, TileID.Platforms, TileID.StoneSlab
					};
				case TileID.SnowBlock:
					return new ushort[]
					{
						TileID.SnowBlock, TileID.BorealWood, TileID.IceBrick, TileID.IceBlock, TileID.Platforms, TileID.StoneSlab
					};

				case TileID.IceBlock:
					return new ushort[]
					{
						TileID.SnowBlock, TileID.BorealWood, TileID.IceBrick, TileID.IceBlock, TileID.Platforms, TileID.StoneSlab
					};
				default:
					return null;
			}
		}

		protected override ushort[] GetWallTheme(int type)
		{
			switch (type)
			{
				case TileID.Dirt:
					return new ushort[]
					{
						WallID.GrayBrick, WallID.Wood, WallID.LivingWood, WallID.Planked, WallID.StoneSlab, WallID.WoodenFence
					};

				case TileID.SnowBlock:
					return new ushort[]
					{
						WallID.IceBrick, WallID.BorealWood, WallID.LivingWood, WallID.Planked, WallID.StoneSlab, WallID.BorealWoodFence
					};

				case TileID.IceBlock:
					return new ushort[]
					{
						WallID.IceBrick, WallID.BorealWood, WallID.LivingWood, WallID.Planked, WallID.StoneSlab, WallID.BorealWoodFence
					};

				default:
					return null;
			}
		}

		//0=air, 1=dirt/snow/ice, 2=wood, 3=stone brick, 4=stone, 5=platform, 6=stone slab	
		protected override byte[,] TileGrid => new byte[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{6,6,6,6,6,0,0,2,5,5,2,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{6,0,6,6,6,2,3,2,2,2,2,0,0,0,0,0,2,3,2,6,6,6,6,6},
			{0,0,6,0,6,0,0,2,2,2,2,0,0,0,2,2,2,3,2,6,0,6,6,0},
			{0,0,6,0,0,0,0,0,2,2,2,2,0,0,2,2,2,3,2,0,0,0,6,0},
			{0,0,0,0,0,0,0,0,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,0,3,2,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,2,3,2,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,0,4,3,4,4,3,4,4,3,4,4,3,4,0,0,0,0,0,0},
			{0,0,0,0,0,0,4,3,4,4,3,4,4,3,4,4,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,4,4,4,3,4,4,3,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
		};

		//0=air, 1=stone wall, 2=wooden wall, 3=living wood wall, 4=planked wall, 5=stone slab wall, 6=fence
		protected override byte[,] WallGrid => new byte[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{6,6,6,6,6,0,0,2,5,5,2,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{6,0,6,6,6,2,3,2,2,2,2,0,0,0,0,0,2,3,2,6,6,6,6,6},
			{0,0,6,0,6,0,0,2,2,2,2,0,0,0,2,2,2,3,2,6,0,6,6,0},
			{0,0,6,0,0,0,0,0,2,2,2,2,0,0,2,2,2,3,2,0,0,0,6,0},
			{0,0,0,0,0,0,0,0,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,0,3,2,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,2,3,2,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,0,4,3,4,4,3,4,4,3,4,4,3,4,0,0,0,0,0,0},
			{0,0,0,0,0,0,4,3,4,4,3,4,4,3,4,4,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,4,4,4,3,4,4,3,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
		};

		protected override byte[,] SlopeGrid => new byte[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,2,0,0,0,3,0,0,0,0,0,0,0,0,0,0,4,0,0,0,1,0,0},
			{0,0,0,2,0,0,0,3,0,0,0,0,0,0,0,0,4,0,0,0,1,0,0,0},
			{0,0,0,0,2,0,0,0,3,0,0,0,0,0,0,4,0,0,0,1,0,0,0,0},
			{0,0,0,0,0,2,0,0,0,3,0,0,0,0,4,0,0,0,1,0,0,0,0,0},
			{0,0,0,0,0,0,2,0,0,0,3,0,0,4,0,0,0,1,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,2,0,0,0,3,4,0,0,0,1,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,2,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,2,0,0,1,0,0,0,0,0,0,0,0,0,0}
		};
	}
}
